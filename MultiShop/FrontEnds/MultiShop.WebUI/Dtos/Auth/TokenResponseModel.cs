namespace MultiShop.WebUI.Dtos.Auth
{
	public class TokenResponseModel
	{
        public string Token { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
