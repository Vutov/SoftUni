#include <iostream>
#include <string>
#include <algorithm>
#include <vector>

#include "Person.h"
#include "Student.h"
#include "Teacher.h"
#include "GuestTeacher.h"

using namespace std;

Student readStudent()
{
	cout << "Pass data on new line - ID, Name, Course, Points, Mark" << endl;
	int id = 0;
	string name = "";
	string course = "";
	int currentPoints = 0;
	double mark = 0;

	cin >> id >> name >> course >> currentPoints >> mark;

	return Student(id, name, course, currentPoints, mark);
}

Teacher readTeacher()
{
	cout << "Pass data on new line - ID, Name, Course, Salary, Days" << endl;
	int id = 0;
	string name = "";
	string course = "";
	double salary = 0;
	int days = 0;

	cin >> id >> name >> course >> salary >> days;

	return Teacher(id, name, course, salary, days);
}

GuestTeacher readGuestTeacher()
{
	cout << "Pass data on new line - ID, Name, Course, Salary, Days" << endl;
	int id = 0;
	string name = "";
	string course = "";
	double salary = 0;

	cin >> id >> name >> course >> salary;

	return GuestTeacher(id, name, course, salary);
}


int main()
{

	int id = 0;

	vector<string> result;
	vector<Student> students;
	vector<Teacher> teachers;
	vector<GuestTeacher> guestTeachers;

	while (true)
	{
		int command = 0;
		cin >> command;
		switch (command)
		{
		case 1:
			cin >> id;
			for each(Student student in students)
			{
				if (student.getID() == id){
					cout << student.getData();
					break;
				}
			}
			break;
		case 2:
			cin >> id;
			for each(Teacher teacher in teachers)
			{
				if (teacher.getID() == id){
					cout << teacher.getData();
					break;
				}
			}
			break;
		case 3:
			cin >> id;
			for each(GuestTeacher teacher in guestTeachers)
			{
				if (teacher.getID() == id){
					cout << teacher.getData();
					break;
				}
			}
			break;
		case 4:
			students.push_back(readStudent());
			break;
		case 5:
			teachers.push_back(readTeacher());
			break;
		case 6:
			guestTeachers.push_back(readGuestTeacher());
			break;
		default:
			cout << "Invalid command!" << endl;
			break;
		}

	}

	return 0;
}
