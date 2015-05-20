namespace LinqExercise
{
    public class Student
    {
        public Student(
            int id, 
            string firstName, 
            string lastName, 
            string email, 
            string gender, 
            string studentType, 
            int examResult,
            int homeworksSent,
            int homeworksEvaluated,
            double teamworkScore,
            int attendancesCount,
            double bonus)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Gender = gender;
            this.StudentType = studentType;
            this.ExamResult = examResult;
            this.HomeworksSent = homeworksSent;
            this.HomeworksEvaluated = homeworksEvaluated;
            this.TeamworkScore = teamworkScore;
            this.AttendancesCount = attendancesCount;
            this.Bonus = bonus;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string StudentType { get; set; }

        public int ExamResult { get; set; }

        public int HomeworksSent { get; set; }

        public int HomeworksEvaluated { get; set; }

        public double TeamworkScore { get; set; }

        public int AttendancesCount { get; set; }

        public double Bonus { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0} {1} ({2} student) - {3}", 
                this.FirstName, 
                this.LastName, 
                this.StudentType,
                this.ExamResult);
        }
    }
}
