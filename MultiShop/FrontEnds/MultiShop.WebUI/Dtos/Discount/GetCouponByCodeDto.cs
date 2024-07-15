namespace MultiShop.WebUI.Dtos.Discount
{
    public class GetCouponByCodeDto
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
