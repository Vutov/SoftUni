namespace OnlineShop.Services.Models.View
{
    using System;
    using System.Linq.Expressions;
    using OnlineShop.Models;

    public class AdTypeViewModel: IComparable<AdTypeViewModel>
    {
        public string Type { get; set; }

        public static Expression<Func<AdType, AdTypeViewModel>> Create
        {
            get
            {
                return a => new AdTypeViewModel()
                {
                    Type = a.Name
                };
            }
        }

        public int CompareTo(AdTypeViewModel other)
        {
            if (this.Type.Length > other.Type.Length)
            {
                return -1;
            }

            if (this.Type.Length < other.Type.Length)
            {
                return 1;
            }

            return this.Type.ToLower().CompareTo(other.Type.ToLower());
        }
    }
}