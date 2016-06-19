#pragma once
#include "Person.h"

class GuestTeacher :
	public Person
{
private:
	double _salaryForCourse;

public:
	GuestTeacher(int id, string name, string courseName, double salaryForCourse);
	~GuestTeacher();
	string virtual getData();
};