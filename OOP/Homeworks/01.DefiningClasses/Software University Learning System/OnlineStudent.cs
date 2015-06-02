namespace Software_University_Learning_System
{
    class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string firstName, string lastName, int age, string studentNumber, double avgGrade, string currentCourse)
            : base(firstName, lastName, age, studentNumber, avgGrade, currentCourse)
        {
        }
    }
}
