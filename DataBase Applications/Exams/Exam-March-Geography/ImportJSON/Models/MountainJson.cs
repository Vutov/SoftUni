namespace ImportJSON.Models
{
    public class MountainJson
    {
        public MountainJson()
        {
            this.Countries = new string[0];
            this.Peaks = new PeakJson[0];
        }

        public string MountainName { get; set; }
        public PeakJson[] Peaks { get; set; }
        public string[] Countries { get; set; }
    }
}
