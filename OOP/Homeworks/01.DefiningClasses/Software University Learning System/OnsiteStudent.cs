namespace Software_University_Learning_System
{
    class OnsiteStudent: CurrentStudent
    {
        public int Visits { get; set; }

        protected OnsiteStudent(string firstName, string lastName, int age,
            string studentNumber, double avgGrade, string currentCourse,
            int visits) : base(firstName, lastName, age, studentNumber, avgGrade, currentCourse)
        {
            this.Visits = visits;
        }
    }
}
