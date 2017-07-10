namespace WEBCRAFT.MobileStore.Models
{

    public class InvoicableServices
    {
        public int Id { get; set; }
        public Service Service { get; set; }
        public int FK_ServiceId { get; set; }
        public decimal SellPrice { get; set; }
        public int Count { get; set; }
    }
}