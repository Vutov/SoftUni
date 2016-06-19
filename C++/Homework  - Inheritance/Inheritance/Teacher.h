#pragma once
#include "Person.h"

class Teacher :
	public Person
{
private:
	float _montlySalary;
	int _daysSinceJoined;

public:
	Teacher(int id, string name, string courseName, float montlySalary, int daysSinceJoined);
	~Teacher();
	string virtual getData();
};

