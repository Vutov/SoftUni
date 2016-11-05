// Kamigawa - Spas Vutov

#include "Country.h"
#include "VacationPlace.h"
#include <map>
#include <iostream>

Country::Country(std::string name, std::vector<Beach> beaches, std::string currency, double exchangeCourseEur)
{
	this->_name = name;
	this->_beaches = beaches;
	this->_currency = currency;
	this->_exchangeCourseEur = exchangeCourseEur;
	this->_places = std::map<std::string, VacationPlace>();
	this->_searchLock = false;
}

Country::~Country()
{
	this->_beaches.clear();
}

std::string Country::getName() const
{
	return this->_name;
}

std::vector<Beach> Country::getBeaches() const
{
	return  this->_beaches;
}

std::string Country::getCurrency() const
{
	return  this->_currency;
}

double Country::getExchangeCourseToEur() const
{
	return  this->_exchangeCourseEur;
}

void Country::addPlace(VacationPlace& place)
{
	if (this->_searchLock)
	{
		std::cout << "Search lock" << std::endl;
	}
	else {
		this->_places.insert_or_assign(place.getName(), place);
	}
}

bool Country::removePlace(std::string name)
{
	if (this->_searchLock)
	{
		std::cout << "Search lock" << std::endl;
		return false;
	}

	if (this->_places.erase(name))
	{
		return true;
	}

	return false;
}

std::string Country::findPlaceByName(std::string name)
{
	this->_searchLock = true;
	auto place = this->_places.find(name);
	if (place != this->_places.end())
	{
		this->_searchLock = false;
		return place->second.getFullInformation();
	}

	this->_searchLock = false;
	return "Nothing found for : " + name;
}

void Country::findPlaceBy(int visitorsPerYear, int terrainCleannesScore, int waterCleannesScore)
{
	this->_searchLock = true;
	for (auto place : this->_places)
	{
		if (place.second.has(visitorsPerYear, terrainCleannesScore, waterCleannesScore))
		{
			std::cout << "Place in " << this->getName() << ":" << std::endl
				<< place.second.getFullInformation() << std::endl;
			this->_searchLock = false;
			return;
		}
	}

	std::cout << "No place found in " << this->getName() << std::endl;
	this->_searchLock = false;
}