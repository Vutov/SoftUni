namespace Software_University_Learning_System
{
    class Student : Person
    {
        public string StudentNumber { get; private set; }
        public double AvgGrade { get; set; }

        protected Student(string firstName, string lastName, int age, string studentNumber,
            double avgGrade) : base(firstName, lastName, age)
        {
            this.StudentNumber = studentNumber;
            this.AvgGrade = avgGrade;
        }

        public override string ToString()
        {
            return string.Format("Name {0} {1}, avg grades {2}",
                this.FirstName, this.LastName, this.AvgGrade);
        }
    }
}
