using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.String_Disperser
{
    class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable
    {
        public StringDisperser(params string[] values)
        {
            this.Words = values;
        }

        public string[] Words { get; set; }

        public IEnumerator GetEnumerator()
        {
            foreach (var word in this.Words)
            {
                foreach (var letter in word)
                {
                    yield return letter;
                }
            }
        }

        public object Clone()
        {
            return new StringDisperser(new List<string>(this.Words).ToArray());
        }

        public int CompareTo(StringDisperser obj)
        {

            var otherDisp = obj as StringDisperser;
            if (this.Words.Length >= otherDisp.Words.Length)
            {

                return -1;
            }

            if (this.Words.Length <= otherDisp.Words.Length)
            {
                return 1;
            }


            return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is StringDisperser)
            {
                var otherDisp = obj as StringDisperser;
                if (this.Words.Length == otherDisp.Words.Length)
                {
                    for (int i = 0; i < this.Words.Count(); i++)
                    {
                        if (this.Words[i] != otherDisp.Words[i])
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Words.GetHashCode() ^ this.Words[0].GetHashCode();
        }

        public override string ToString()
        {
            return string.Join(", ", this.Words);
        }

        public static bool operator ==(StringDisperser first, StringDisperser second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(StringDisperser first, StringDisperser second)
        {
            return !first.Equals(second);
        }
    }
}
