namespace Software_University_Learning_System
{
    class DropoutStudent: Student
    {
        public string Reason { get; set; }

        public DropoutStudent(string firstName, string lastName, int age, string studentNumber, double avgGrade,
            string reason) : base(firstName, lastName, age, studentNumber, avgGrade)
        {
            this.Reason = reason;
        }
    }
}
