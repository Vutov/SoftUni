using System;

class EmployeeData
{
    static void Main(string[] args)
    {
        string firstName = "Ivan";
        string lastName = "Ivanov";
        byte age = 2;
        char gender = 'm';
        ulong idNumber = 8306112507u;
        ulong uniqNum = 2756000045327569999u;
        Console.WriteLine("The employee's name is {0} {1}, {2} years old, gender {3}, with Personal ID Number: {4} and Unique employee number: {5}",
            firstName, lastName, age, gender, idNumber, uniqNum);

    }
}