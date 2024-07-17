using MultiShop.WebUI.Dtos.Cargo;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Cargo.Abstract
{
    public interface ICargoCargoCompanyApi
    {
        [Get("/cargoCompanies")]
        Task<List<ResultCargoCompanyDto>> GetAllCargoCompanies();
        [Get("/cargoCompanies/{id}")]
        Task<ResultCargoCompanyDto> GetCargoCompanyById(string id);
        [Post("/cargoCompanies")]
        Task CreateCargoCompany(CreateCargoCompanyDto dto);
        [Put("/cargoCompanies")]
        Task UpdateCargoCompany(ResultCargoCompanyDto dto);
        [Delete("/cargoCompanies/{id}")]
        Task DeleteCargoCompany(string id);
    }
}
