namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using Utilities;

    public class Lecture
    {
        private string name;

        public Lecture(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException(Message.LectureNameLenError);
                }

                this.name = value;
            }
        }
    }
}
