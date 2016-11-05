// Kamigawa - Spas Vutov
#pragma once
#include "Beach.h"
#include <vector>
#include "VacationPlace.h"
#include <map>
#include <thread>

class Country
{
private:
	std::string _name;
	std::vector<Beach> _beaches;
	std::string _currency;
	double _exchangeCourseEur;
	std::map<std::string, VacationPlace> _places;
	bool _searchLock;
public:
	Country(std::string name, std::vector<Beach> beaches, std::string currency, double exchangeCourseEur);
	~Country();
	std::string getName() const;
	std::vector<Beach> getBeaches() const;
	std::string getCurrency() const;
	double getExchangeCourseToEur() const;
	void addPlace(VacationPlace& place);
	bool removePlace(std::string);
	std::string findPlaceByName(std::string name);
	void findPlaceBy(int visitorsPerYear, int terrainCleannesScore, int waterCleannesScore);
};