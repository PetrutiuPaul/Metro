namespace Domain.Entities
{
    public class Item
    {
        public Item(string name, decimal price, int basketId)
        {
            Name = name;
            Price = price;
            BasketId = basketId;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int BasketId { get; set; }

        public Basket Basket { get; set; }
    }
}
