using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShop
{
    class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private int ram;
        private string graphicCard;
        private string hdd;
        private string screen;
        private Battery battery;
        private double price;

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = Validate(value);
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                this.manufacturer = Validate(value);
            }
        }

        public string Processor
        {
            get { return this.processor; }
            set
            {
                this.processor = Validate(value);
            }
        }

        public int Ram
        {
            get { return this.ram; }
            set
            {
                this.ram = Validate(value);
            }
        }

        public string GraphicCard
        {
            get { return this.graphicCard; }
            set
            {
                this.graphicCard = Validate(value);
            }
        }

        public string Hdd
        {
            get { return this.hdd; }
            set
            {
                this.hdd = Validate(value);
            }
        }

        public string Screen
        {
            get { return this.screen; }
            set
            {
                this.screen = Validate(value);
            }
        }

        public double Price
        {
            get { return this.price; }
            set
            {
                this.price = Validate(value);
            }
        }

        public Laptop(string model, string manufacturer, string processor, int ram,
            string grapthicCard, string hdd, string screen, string battery, double batteryLife, double price)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicCard = grapthicCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.battery = new Battery(battery, batteryLife);
            this.Price = price;
        }

        public Laptop(string model, double price)
            : this(model, "no data", "no data", 0, "no data", "no data",
                "no data", "no data", 0, price)
        {
            
        }

        public Laptop(string model, string manufacturer, string battery, double price)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.battery = new Battery(battery);
            this.Price = price;
        }

        public override string ToString()
        {
            return string.Format("model: {0}\nmanufacturer: {1}\nprocessor: {2}\nRAM: {3} GB\n" +
                "graphics card: {4}\nHDD: {5}\nscreen: {6}\nbattery: {7}\nprice: {8:f} lv.",
                this.model, this.Manufacturer, this.processor, this.ram, this.graphicCard,
                this.hdd, this.screen, this.battery, this.price);
        }

        private string Validate(string data)
        {
            if (data.Length > 0)
            {
                return data;
            }

            throw new ArgumentException("Cannot be empty!");

        }

        private double Validate(double data)
        {
            if (data >= 0)
            {
                return data;
            }

            throw new ArgumentException("Cannot be negative!");

        }

        private int Validate(int data)
        {
            if (data >= 0)
            {
                return data;
            }

            throw new ArgumentException("Cannot be negative!");

        }

        static void Main(string[] args)
        {
            Laptop myLaptop = new Laptop("Lenovo Yoga 2 Pro", "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)",
                8, "Intel HD Graphics 4400", "128GB SSD", "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display",
                "Li-Ion, 4-cells, 2550 mAh", 4.5, 2259);
            Laptop otherLaptop = new Laptop("Lenovo Yoga", 21.123);
            Laptop yetAnOther = new Laptop("ACER Aspire", "Acer", "Good", 123.1);
            Console.WriteLine(myLaptop);
            Console.WriteLine();
            Console.WriteLine(otherLaptop);
            Console.WriteLine();
            Console.WriteLine(yetAnOther);
            Console.WriteLine();
        }
    }
}
