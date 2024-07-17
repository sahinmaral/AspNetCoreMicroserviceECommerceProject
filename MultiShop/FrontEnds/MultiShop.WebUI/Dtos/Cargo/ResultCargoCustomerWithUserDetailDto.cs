using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Dtos.Cargo
{
    public class ResultCargoCustomerWithUserDetailDto
    {
        public ResultCargoCustomerDto CargoCustomer { get; set; }
        public UserDetailViewModel UserDetail { get; set; }
    }
}
