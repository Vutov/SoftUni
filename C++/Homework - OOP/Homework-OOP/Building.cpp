#include "string"
#include "Building.h"

using namespace std;

Building::Building(){
	_buildingName = "";
	_floors = 0;
	_offices = 0;
	_employees = 0;
	_freeWorkingSeats = 0;
	_hasOnlyOffices = true;
};

Building::Building(string buildingName, int floors, int offices, int employees, int freeWorkingSeats, bool hasOnlyOffices)
{
	_buildingName = buildingName;
	_floors = floors;
	_offices = offices;
	_employees = employees;
	_freeWorkingSeats = freeWorkingSeats;
	_hasOnlyOffices = hasOnlyOffices;
};

Building::~Building()
{
	// http://pages.cs.wisc.edu/~siff/CS367/Notes/dynamic-memory.html
	// Not sure we have something to delete for this class.
};

string Building::getBuildingName() {
	return _buildingName;
};

int Building::getFloors() {
	return _floors;
};

int Building::getOffices() {
	return _offices;
};

int Building::getEmployees() {
	return _employees;
};

int Building::getFreeWorkingSeats() {
	return _freeWorkingSeats;
};

bool Building::getHasOnlyOffices() {
	return _hasOnlyOffices;
};

double Building::GetEmployeeFreeSeatCoef() {
	if (_employees == 0 && _freeWorkingSeats == 0){
		return 0;
	}

	double result = (double)_employees / (_employees + _freeWorkingSeats);
	return result;
};

double Building::GetPeoplePerFloor() {
	if (_employees == 0 && _floors == 0){
		return 0;
	}

	double result = (double)_employees / _floors;
	return result;
};

double Building::GetOfficesPerFloor(){
	if (_offices == 0 && _floors == 0){
		return 0;
	}

	double result = (double)_offices / _floors;
	return result;
};

double Building::GetPeoplePerOffices(){
	if (_employees == 0 && _offices == 0){
		return 0;
	}

	double result = (double)_employees / _offices;
	return result;
};