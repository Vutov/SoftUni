using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    abstract class Animal : ISound
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        protected Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public override string ToString()
        {
            return string.Format("My name is {0}, I'm {1} yrs old {2}", this.Name, this.Age, GetType().Name);
        }

        public virtual string ProduceSound()
        {
            throw new NotImplementedException("Override ProduceSound()");
        }
    }
}
