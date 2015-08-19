namespace WebScraper
{
    using System.Collections.Generic;

    public class WebPageRepository
    {
        private static WebPageRepository instance;
        private static readonly object Locker = new object();
        private readonly Queue<string> addresses;

        protected WebPageRepository()
        {
            this.addresses = new Queue<string>();
            this.Seed();
        }

        public bool IsEmpty
        {
            get
            {
                return this.addresses.Count == 0;
            }
        }

        public static WebPageRepository Instance()
        {
            if (instance == null)
            {
                lock (Locker)
                {
                    if (instance == null)
                    {
                        instance = new WebPageRepository();
                    }
                }
            }

            return instance;
        }

        public void Add(string address)
        {
            this.addresses.Enqueue(address);
        }

        public string Remove()
        {
            return this.addresses.Dequeue();
        }

        private void Seed()
        {
            this.addresses.Enqueue("https://softuni.bg/");
            this.addresses.Enqueue("http://stackoverflow.com/");
            this.addresses.Enqueue("https://www.youtube.com/");
            this.addresses.Enqueue("https://www.google.bg/");
        }
    }
}
