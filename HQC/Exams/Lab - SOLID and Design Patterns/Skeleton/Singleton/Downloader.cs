namespace WebScraper
{
    using System.Net;

    public class Downloader
    {
        private readonly WebClient webClient;

        public Downloader()
        {
            this.webClient = new WebClient();
        }

        public void Download(string address, string localFile)
        {
            using (this.webClient)
            {
                this.webClient.DownloadFile(address, localFile);
            }
        }
    }
}
