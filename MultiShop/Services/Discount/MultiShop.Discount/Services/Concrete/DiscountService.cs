using Dapper;

using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services.Abstract;

namespace MultiShop.Discount.Services.Concrete
{
    public class DiscountService : IDiscountService
    {
        private readonly DiscountContext _dbContext;

        public DiscountService(DiscountContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(CreateCouponDto dto)
        {
            string query = $"INSERT INTO Coupons (Id,Code,Rate,IsActive,ValidDate) VALUES (@id,@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@id", Guid.NewGuid().ToString());
            parameters.Add("@code", dto.Code);
            parameters.Add("@rate", dto.Rate);
            parameters.Add("@isActive", dto.IsActive);
            parameters.Add("@validDate", dto.ValidDate);
            using var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(string id)
        {
            string query = $"DELETE FROM Coupons WHERE Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultCouponDto>> GetAllAsync()
        {
            string query = "SELECT * FROM Coupons";
            using var connection = _dbContext.CreateConnection();
            var coupons = await connection.QueryAsync<ResultCouponDto>(query);
            return coupons.ToList();
        }

        public async Task<GetByCouponIdDto?> GetByCodeAsync(string code)
        {
            string query = "SELECT * FROM Coupons WHERE Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using var connection = _dbContext.CreateConnection();
            var coupon = await connection.QueryFirstOrDefaultAsync<GetByCouponIdDto>(query, parameters);
            return coupon;

        }

        public async Task<GetByCouponIdDto?> GetByIdAsync(string id)
        {
            string query = "SELECT * FROM Coupons WHERE Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using var connection = _dbContext.CreateConnection();
            var coupon = await connection.QueryFirstOrDefaultAsync<GetByCouponIdDto>(query, parameters);
            return coupon;
        }

        public async Task UpdateAsync(UpdateCouponDto dto)
        {
            string query = $"UPDATE Coupons SET Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate WHERE Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", dto.Id);
            parameters.Add("@code", dto.Code);
            parameters.Add("@rate", dto.Rate);
            parameters.Add("@isActive", dto.IsActive);
            parameters.Add("@validDate", dto.ValidDate);
            using var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
