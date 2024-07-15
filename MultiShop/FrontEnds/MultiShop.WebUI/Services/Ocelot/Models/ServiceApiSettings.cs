namespace MultiShop.WebUI.Services.Ocelot.Models
{
    public class ServiceApiSettings
    {
        public string OcelotGatewayUrl { get; set; }
        public string IdentityApiUrl { get; set; }
        public IndividualServiceApi Catalog { get; set; }
        public IndividualServiceApi ImageStorage { get; set; }
        public IndividualServiceApi Discount { get; set; }
        public IndividualServiceApi Order { get; set; }
        public IndividualServiceApi Cargo { get; set; }
        public IndividualServiceApi Basket { get; set; }
        public IndividualServiceApi Payment { get; set; }
        public IndividualServiceApi Comment { get; set; }
    }

    public class IndividualServiceApi
    {
        public string Path { get; set; }
    }
}
