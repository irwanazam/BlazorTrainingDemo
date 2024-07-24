namespace BlazorTrainingDemo.Modules.Inventories
{
    public class ProductStock
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public List<ProductStockDetail> ProductStockDetails { get; set; }
    }

    public class ProductStockDetail
    {
        public int Id { get; set; }

        public int ProductStockId { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public DateTime AddStockDateTime { get; set; }
    }
}
