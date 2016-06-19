#include "Person.h"
#include <string>

using namespace std;

Person::Person(int id, string name, string courseName)
{
	this->_id = id;
	this->_name = name;
	this->_currentCourse = courseName;
}

Person::~Person()
{
}

int Person::getID()
{
	return this->_id;
};

string Person::getName()
{
	return this->_name;
};

string Person::getCurrentCourse()
{
	return this->_currentCourse;
};

string Person::getData()
{
	return "id:" + to_string(this->_id) + ", name: " + this->_name + ", current course: " + this->_currentCourse;
}