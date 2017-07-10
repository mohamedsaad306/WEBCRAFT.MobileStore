namespace WEBCRAFT.MobileStore.Models
{
    public class InvoicableProduct
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int FK_ProductId { get; set; }
        public int Count { get; set; }
    }

}