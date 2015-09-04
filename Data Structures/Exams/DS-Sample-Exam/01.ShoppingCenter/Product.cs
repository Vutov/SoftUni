namespace _01.ShoppingCenter
{
    using System;

    public class Product : IComparable<Product>, IEquatable<Product>
    {
        public Product(int id, string name, decimal price, string producer)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Producer { get; set; }

        public int CompareTo(Product other)
        {
            if (this.Name != other.Name)
            {
                return this.Name.CompareTo(other.Name);
            }

            if (this.Producer != other.Producer)
            {
                return this.Producer.CompareTo(other.Producer);
            }

            if (this.Price != other.Price)
            {
                return this.Price.CompareTo(other.Price);
            }

            return this.Id.CompareTo(other.Id);
        }

        public bool Equals(Product other)
        {
            return this.Id == other.Id;
        }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2}}}", this.Name, this.Producer, this.Price.ToString("f2"));
        }
    }
}