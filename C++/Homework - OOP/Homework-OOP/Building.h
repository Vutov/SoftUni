#pragma once
#include <string>

using namespace std;

class Building
{
private:
	string _buildingName;
	int _floors;
	int _offices;
	int _employees;
	int _freeWorkingSeats;
	bool _hasOnlyOffices;

public:
	Building();
	Building(string buildingName, int floors, int offices, int employees, int freeWorkingSeats, bool hasOnlyOffices = true);
	~Building();

	string getBuildingName();
	int getFloors();
	int getOffices();
	int getEmployees();
	int getFreeWorkingSeats();
	bool getHasOnlyOffices();

	double GetEmployeeFreeSeatCoef();
	double Building::GetPeoplePerFloor();
	double Building::GetOfficesPerFloor();
	double Building::GetPeoplePerOffices();
};