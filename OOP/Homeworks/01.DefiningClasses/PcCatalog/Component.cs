using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcCatalog
{
    class Component
    {
        private string name;
        private string details;
        private decimal price;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length >= 2)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Name must be at least 2 symbols!");
                }
            }
        }

        public string Details
        {
            get { return this.details; }
            set
            {
                if (value == null || value.Length >= 2)
                {
                    this.details = value;
                }
                else
                {
                    throw new ArgumentException("Details must be at least 2 symbols!");
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value >= 0)
                {
                    this.price = value;
                }
                else
                {
                    throw new ArgumentException("Price must be positive!");
                }
            }
        }

        public Component(string name, decimal price, string details = null)
        {
            this.Name = name;
            this.Details = details;
            this.Price = price;
        }
    }
}
