using System;

namespace _04.StudentClass
{
    class PropertyChangedEventArgs: EventArgs
    {
        public PropertyChangedEventArgs(string propertName, string oldValue, string newValue)
        {
            this.PropertyName = propertName;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }

        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
