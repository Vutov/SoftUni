#include "GuestTeacher.h"

GuestTeacher::GuestTeacher(int id, string name, string courseName, double salaryForCourse)
:Person(id, name, courseName)
{
	this->_salaryForCourse = salaryForCourse;
}


GuestTeacher::~GuestTeacher()
{
}

string GuestTeacher::getData()
{
	string data = Person::getData();
	return data + ", salary:" + to_string(this->_salaryForCourse);
}