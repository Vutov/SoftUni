namespace Software_University_Learning_System
{
    class CurrentStudent : Student
    {
        public string CurrentCourse { get; set; }

        protected CurrentStudent(string firstName, string lastName, int age,
            string studentNumber, double avgGrade, string currentCourse)
            : base(firstName, lastName, age, studentNumber, avgGrade)
        {
            this.CurrentCourse = currentCourse;
        }
    }
}
