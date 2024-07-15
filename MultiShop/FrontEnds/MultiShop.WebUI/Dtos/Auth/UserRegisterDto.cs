namespace MultiShop.WebUI.Dtos.Auth
{
	public class UserRegisterDto
	{
		public string UserName { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
