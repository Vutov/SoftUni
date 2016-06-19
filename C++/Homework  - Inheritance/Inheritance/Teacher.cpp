#include "Teacher.h"


Teacher::Teacher(int id, string name, string courseName, float montlySalary, int daysSinceJoined) : Person(id, name, courseName)
{
	this->_montlySalary = montlySalary;
	this->_daysSinceJoined = daysSinceJoined;
}


Teacher::~Teacher()
{
}

string Teacher::getData()
{
	string data = Person::getData();
	return data + ", _montly salary:" + to_string(this->_montlySalary) + ", _days since joined:" + to_string(this->_daysSinceJoined);
}