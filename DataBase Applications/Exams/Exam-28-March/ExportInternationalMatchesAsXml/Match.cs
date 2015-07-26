using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportInternationalMatchesAsXml
{
    public class Match
    {
        public string LeagueName { get; set; }

        public string HomeCountryName { get; set; }

        public string HomeCountryCode { get; set; }

        public string AwayCountryName { get; set; }

        public string AwayCountryCode { get; set; }

        public DateTime? Date { get; set; }

        public string Score { get; set; }

    }
}
