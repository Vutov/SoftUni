#pragma once
#include "Person.h"

class Student : public Person
{
private:
	int _currentPoints;
	double _averageMark;

public:
	Student(int id, string name, string courseName, int currentPoints, double averageMark);
	~Student();

	int getCurrentPoints();
	double getAverageMark();
	string virtual getData();
};

