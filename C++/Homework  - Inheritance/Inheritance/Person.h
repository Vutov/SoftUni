#pragma once
#include <string>

using namespace std;

class Person
{
private:
	int _id;
	string _name;
	string _currentCourse;

public:
	Person(int id, string name, string courseName);
	~Person();

	int getID();
	string getName();
	string getCurrentCourse();
	string virtual getData();
};

