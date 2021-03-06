namespace Task1
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            if(obj == null || this.GetType().Equals(obj.GetType()) == false)
            {
                return false;
            }
            else
            {
                Product product = obj as Product;
                return (Price == product.Price) && (Name == product.Name);
            }
        }
    }
}
