#include <iostream>
#include <string>
#include <algorithm>
#include "Building.h"

using namespace std;

int main()
{
	Building xyzIndustries = Building("XYZ industries", 6, 127, 600, 196);
	Building rapidCrew = Building("Rapid Development Crew", 8, 210, 822, 85, false);
	Building softUni = Building("SoftUni", 11, 106, 200, 60);

	Building businessPark[] = { xyzIndustries, rapidCrew, softUni };

	Building mostEmployeesBuilding;
	Building mostFreePlacesBuilding;
	Building highestCoefBuilding;
	Building mostPeoplePerFloor;
	Building leastPeoplePerFloor;
	Building mostOfficesPerFloor;
	Building leastOfficesPerFloor;
	Building mostPeoplePerOffice;
	Building leastPeoplePerOffice;

	for each(Building building in businessPark){
		if (building.getEmployees() > mostEmployeesBuilding.getEmployees()){
			mostEmployeesBuilding = building;
		}

		if (building.getFreeWorkingSeats() > mostFreePlacesBuilding.getFreeWorkingSeats()){
			mostFreePlacesBuilding = building;
		}

		if (building.GetEmployeeFreeSeatCoef() > highestCoefBuilding.GetEmployeeFreeSeatCoef()){
			highestCoefBuilding = building;
		}

		if (building.GetPeoplePerFloor() > mostPeoplePerFloor.GetPeoplePerFloor()){
			mostPeoplePerFloor = building;
		}

		if (building.GetPeoplePerFloor() < leastPeoplePerFloor.GetPeoplePerFloor() || leastPeoplePerFloor.GetPeoplePerFloor() == 0){
			leastPeoplePerFloor = building;
		}

		if (building.GetPeoplePerFloor() > mostOfficesPerFloor.GetPeoplePerFloor()){
			mostOfficesPerFloor = building;
		}

		if (building.GetPeoplePerFloor() < leastOfficesPerFloor.GetPeoplePerFloor() || leastOfficesPerFloor.GetPeoplePerFloor() == 0){
			leastOfficesPerFloor = building;
		}

		if (building.GetPeoplePerFloor() > mostPeoplePerOffice.GetPeoplePerFloor()){
			mostPeoplePerOffice = building;
		}

		if (building.GetPeoplePerFloor() < leastPeoplePerOffice.GetPeoplePerFloor() || leastPeoplePerOffice.GetPeoplePerFloor() == 0){
			leastPeoplePerOffice = building;
		}
	}

	cout << "Most employees building : " << mostEmployeesBuilding.getBuildingName() << endl;
	cout << "Most free places building : " << mostFreePlacesBuilding.getBuildingName() << endl;
	cout << "Most coef building : " << highestCoefBuilding.getBuildingName() << endl;
	cout << "Most people per floor building : " << mostPeoplePerFloor.getBuildingName() << endl;
	cout << "Least people per floor building : " << leastPeoplePerFloor.getBuildingName() << endl;
	cout << "Most offices per floor building : " << mostOfficesPerFloor.getBuildingName() << endl;
	cout << "Least offices per floor building : " << leastOfficesPerFloor.getBuildingName() << endl;
	cout << "Least people per office building : " << mostPeoplePerOffice.getBuildingName() << endl;
	cout << "Least people per office building : " << leastPeoplePerOffice.getBuildingName() << endl;

	return 0;
}