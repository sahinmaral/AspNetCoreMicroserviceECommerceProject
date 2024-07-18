namespace MultiShop.WebUI.Models
{
    public class Data
    {
        public string from_symbol { get; set; }
        public string to_symbol { get; set; }
        public string type { get; set; }
        public double exchange_rate { get; set; }
        public double previous_close { get; set; }
    }
    public class FinanceExchangeResponseModel
    {
        public string status { get; set; }
        public string request_id { get; set; }
        public Data data { get; set; }

    }
}
