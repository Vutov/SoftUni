using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        public Student(string firstName, string lastName, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = this.GetDateFromInfo(this.OtherInfo);
            DateTime secondDate = this.GetDateFromInfo(other.OtherInfo);

            return firstDate > secondDate;
        }

        private DateTime GetDateFromInfo(string info)
        {
            var date = DateTime.Parse(info.Substring(info.Length - 10));

            return date;
        }
    }
}
