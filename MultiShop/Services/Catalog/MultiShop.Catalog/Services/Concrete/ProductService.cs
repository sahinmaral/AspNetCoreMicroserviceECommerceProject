

using AutoMapper;

using Microsoft.Extensions.Options;

using MongoDB.Bson;
using MongoDB.Driver;

using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Entities.Concrete;
using MultiShop.Catalog.Services.Abstract;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Concrete
{
    public class ProductService : GenericService<Product>, IProductService
    {

        public ProductService(IMapper mapper, IOptions<DatabaseSettings> databaseSettingOptions) : base(mapper, databaseSettingOptions)
        {
            _collection = _database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        }

        public async Task CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _collection.InsertOneAsync(product);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(product => product.Id == id);
        }

        public async Task<List<ResultProductDto>> GetAllAsync()
        {
            var products = await _collection.Find(product => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(products);
        }

        public async Task<List<ResultProductDto>> GetAllByCategoryIdAsync(string categoryId)
        {
            var products = await _collection.Find(product => product.CategoryId == categoryId).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(products);
        }

        public async Task<GetByProductIdDto> GetByIdAsync(string id)
        {
            var product = await _collection.Find(product => product.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByProductIdDto>(product);
        }

        public async Task UpdateAsync(UpdateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            var filter = Builders<Product>.Filter.Eq(product => product.Id, product.Id);
            await _collection.FindOneAndReplaceAsync(filter, product);
        }

        public async Task UpdateProductImages(ResultProductImagesDto dto)
        {
            var savedProductDto = await GetByIdAsync(dto.Id);
            if (savedProductDto is null)
                throw new NullReferenceException("Böyle bir ürün bulunamadı");

            var savedProductEntity = _mapper.Map<Product>(savedProductDto);

            CheckAndAddNewProductImage(dto, savedProductEntity);
            CheckAndRemoveProductImage(dto, savedProductEntity);

            var product = _mapper.Map<UpdateProductDto>(savedProductEntity);
            await UpdateAsync(product);
        }

        private void CheckAndRemoveProductImage(ResultProductImagesDto dto, Product? savedProduct)
        {
            for (int i = 0; i < savedProduct.AdditionalImageUrls.Count; i++)
            {
                var image = savedProduct.AdditionalImageUrls[i];
                var searchedImage = dto.AdditionalImageUrls.FirstOrDefault(x => x == image);
                if (searchedImage is null)
                    savedProduct.AdditionalImageUrls.Remove(image);
            }
        }

        private void CheckAndAddNewProductImage(ResultProductImagesDto dto, Product? savedProduct)
        {
            for (int i = 0; i < dto.AdditionalImageUrls.Count; i++)
            {
                var image = dto.AdditionalImageUrls[i];
                var searchedImage = savedProduct.AdditionalImageUrls.FirstOrDefault(x => x == image);
                if (searchedImage is null)
                    savedProduct.AdditionalImageUrls.Add(image);
            }
        }

        public async Task AddProductImages(ResultProductImagesDto dto)
        {
            var productDto = await GetByIdAsync(dto.Id);
            if (productDto is null)
                throw new NullReferenceException("Böyle bir ürün bulunamadı");

            var productEntity = _mapper.Map<Product>(productDto);

            productEntity.AdditionalImageUrls = dto.AdditionalImageUrls;
            var product = _mapper.Map<UpdateProductDto>(productEntity);
            await UpdateAsync(product);
        }

        public async Task<int> CountAsync()
        {
            var count = await _collection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
            return Convert.ToInt16(count);
        }

        public async Task<decimal> AveragePriceAsync()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$match", new BsonDocument
                {
                    { "Price", new BsonDocument { { "$type", "string" } } }
                }),
                new BsonDocument("$group", new BsonDocument
                {
                    { "_id", BsonNull.Value },
                    { "averagePrice", new BsonDocument
                        {
                            { "$avg", new BsonDocument
                                {
                                    { "$toDouble", "$Price" }
                                }
                            }
                        }
                    }
                })
            };

            var result = await _collection.Aggregate<BsonDocument>(pipeline).FirstOrDefaultAsync();

            if (result == null || result["averagePrice"].IsBsonNull)
            {
                return 0;
            }

            return (decimal)result["averagePrice"].AsDouble;
        }

        public async Task<ResultProductDto> MostExpensiveProduct()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$addFields", new BsonDocument
                {
                    { "numericPrice", new BsonDocument("$toDouble", "$Price") }
                }),
                new BsonDocument("$sort", new BsonDocument
                {
                    { "numericPrice", -1 }
                }),
                new BsonDocument("$limit", 1),
                new BsonDocument("$project", new BsonDocument
                {
                    { "numericPrice", 0 }
                })
            };

            var result = await _collection.Aggregate<Product>(pipeline).FirstOrDefaultAsync();
            var product = _mapper.Map<ResultProductDto>(result);
            return product;
        }

        public async Task<ResultProductDto> MostCheapProduct()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$addFields", new BsonDocument
                {
                    { "numericPrice", new BsonDocument("$toDouble", "$Price") }
                }),
                new BsonDocument("$sort", new BsonDocument
                {
                    { "numericPrice", 1 }
                }),
                new BsonDocument("$limit", 1),
                new BsonDocument("$project", new BsonDocument
                {
                    { "numericPrice", 0 }
                })
            };

            var result = await _collection.Aggregate<Product>(pipeline).FirstOrDefaultAsync();
            var product = _mapper.Map<ResultProductDto>(result);
            return product;
        }
    }
}
