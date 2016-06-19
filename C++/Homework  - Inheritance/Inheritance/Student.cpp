#include "Student.h"

Student::Student(int id, string name, string courseName, int currentPoints, double averageMark)
	:Person(id, name, courseName)
{
	this->_currentPoints = currentPoints;
	this->_averageMark = averageMark;
}


Student::~Student()
{
}

int Student::getCurrentPoints()
{
	return this->_currentPoints;
};

double Student::getAverageMark()
{
	return this->_averageMark;
};

string Student::getData()
{
	string data = Person::getData();
	return data + ", current points:" + to_string(this->_currentPoints) + ", average mark:" + to_string(this->_averageMark);
}