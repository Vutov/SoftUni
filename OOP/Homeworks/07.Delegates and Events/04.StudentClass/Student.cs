namespace _04.StudentClass
{
    class Student
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name {
            get
            {
                return this.name;
            }
            set
            {
                OnPropertyChanged("Name", this.Name, value);
                this.name = value;
            } 
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                OnPropertyChanged("Age", this.Age.ToString(), value.ToString());
                this.age = value;
            } 
        }

        public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs eventArgs);

        protected void OnPropertyChanged(string propertName, string oldValue, string newValue)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertName, oldValue, newValue));
            }
        }
    }
}
