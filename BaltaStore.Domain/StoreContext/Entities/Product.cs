using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities

{
    public class Product : Notifiable
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public decimal QuantityStock { get; private set; }

        public Product(string title, string description, string image, decimal price, decimal quantityStock)
        {
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            QuantityStock = quantityStock;
        }

        public override string ToString()
        {
            return Title;
        }

        public void DecreaseQuantity(decimal quantity)
        {
            QuantityStock -= quantity;
        }
    }
}
