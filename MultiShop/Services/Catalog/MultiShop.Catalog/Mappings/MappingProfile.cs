using AutoMapper;

using MultiShop.Catalog.Dtos.About;
using MultiShop.Catalog.Dtos.Brand;
using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Dtos.Contact;
using MultiShop.Catalog.Dtos.CustomerService;
using MultiShop.Catalog.Dtos.FeatureSlider;
using MultiShop.Catalog.Dtos.OfferDiscount;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Dtos.SpecialOffer;
using MultiShop.Catalog.Entities.Concrete;

namespace MultiShop.Catalog.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByCategoryIdDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByProductIdDto>().ReverseMap();
            CreateMap<Product, ResultProductImagesDto>().ReverseMap();

            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByProductDetailIdDto>().ReverseMap();

            CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, GetByFeatureSliderIdDto>().ReverseMap();

            CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, GetBySpecialOfferIdDto>().ReverseMap();

            CreateMap<CustomerService, CreateCustomerServiceDto>().ReverseMap();
            CreateMap<CustomerService, ResultCustomerServiceDto>().ReverseMap();
            CreateMap<CustomerService, UpdateCustomerServiceDto>().ReverseMap();
            CreateMap<CustomerService, GetByCustomerServiceIdDto>().ReverseMap();

            CreateMap<OfferDiscount, CreateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, ResultOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, UpdateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, GetByOfferDiscountIdDto>().ReverseMap();

            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, GetByBrandIdDto>().ReverseMap();

            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetByAboutIdDto>().ReverseMap();

            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetByContactIdDto>().ReverseMap();
        }
    }
}
