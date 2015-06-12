using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList.Attributes
{
    [AttributeUsage(
        AttributeTargets.Struct |
        AttributeTargets.Class |
        AttributeTargets.Enum |
        AttributeTargets.Interface |
        AttributeTargets.Method)]
    public class CurrVersion : Attribute
    {
        public CurrVersion(int majorVersion, int minorVersion)
        {
            this.MajorVersion = majorVersion;
            this.MinorVersion = minorVersion;
        }

        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }

        public override string ToString()
        {
            string result = string.Format(
                "Version {0}.{1}",
                this.MajorVersion,
                this.MinorVersion.ToString("X2"));

            return result;
        }
    }
}
