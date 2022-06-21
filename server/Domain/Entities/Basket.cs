using Domain.Common;
using Domain.Helpers.VAT;

namespace Domain.Entities
{
    public class Basket : IAggregateRoot
    {
        public Basket(string customer, bool paysVAT)
        {
            Customer = customer;
            PaysVAT = paysVAT;
            Items = new List<Item>();
        }

        public int Id { get; }

        public string Customer { get; set; }

        public bool PaysVAT { get; set; }

        public bool Close { get; set; }

        public bool Payed { get; set; }

        public List<Item> Items { get; set;}
        
        public decimal TotalNet => Items.Sum(i => i.Price);

        public decimal TotalGross => PaysVAT ? VatHelper.ApplyVAT(TotalNet) : TotalNet;

    }
}
