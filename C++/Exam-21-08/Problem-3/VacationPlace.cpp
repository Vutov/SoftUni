// Kamigawa - Spas Vutov

#include "VacationPlace.h"

static const char * TerrainTypeStrings[] = { "Sand", "Rocks", "Ceramic", "Concrete", "Mixed", "OtherTerrain" };
static const char * WaterTypeStrings[] = { "Sea", "Ocean", "Pool", "Pudle", "None", "OtherWather" };

VacationPlace::VacationPlace()
{
}


VacationPlace::VacationPlace(std::string name, double longitude, double altitude, TerrainType terrainType,
	WaterType waterType, int terrainCleannesScore, int waterCleannesScore, int visiotrsPerYear,
	double averageCostPerDay, int numberOfBars, double daikiriPRice, double moxitoPrice, double juicePrice)
{
	this->_name = name;
	this->_coordinates = Coordinates(longitude, altitude);
	this->_terrainType = terrainType;
	this->_waterType = waterType;
	this->_terrainCleannesScore = this->setTerrainCleannes(terrainCleannesScore);
	this->_waterCleannesScore = this->setWaterCleannes(waterCleannesScore);
	this->_visitorsPerYear = visiotrsPerYear;
	this->_averageCostsPerDay = averageCostPerDay;
	this->_numberOfBars = numberOfBars;
	this->_daikiriPrice = daikiriPRice;
	this->_moxitoPrice = moxitoPrice;
	this->_juiceiPrice = juicePrice;
}


VacationPlace::~VacationPlace()
{
}

int VacationPlace::setTerrainCleannes(int terrainCleannesScore)
{
	if (terrainCleannesScore < 0 || terrainCleannesScore > 10)
	{
		throw std::invalid_argument("received invalid value");
	} 

	return terrainCleannesScore;
}

int VacationPlace::setWaterCleannes(int waterCleannesScore)
{
	if (waterCleannesScore < 0 || waterCleannesScore > 10)
	{
		throw std::invalid_argument("received invalid value");
	}

	return waterCleannesScore;
}


std::string VacationPlace::getFullInformation() const
{
	std::string info = "Name: " + this->_name 
		+ ",\nCoordinates: " + std::to_string(this->_coordinates.getX()) + " - " + std::to_string(this->_coordinates.getY())
		+ ",\nTerrain: " + TerrainTypeStrings[this->_terrainType] + "(" + std::to_string(this->_terrainCleannesScore) + ")"
		+ ",\nWater: " + WaterTypeStrings[this->_waterType] + "(" + std::to_string(this->_waterCleannesScore) + ")"
		+ ",\nVisitors per year: " + std::to_string(this->_visitorsPerYear)
		+ ",\nAverage Cost per Day: " + std::to_string(this->_averageCostsPerDay)
		+ ",\nNumber of bars: " + std::to_string(this->_numberOfBars)
		+ ",\nDaikiri Price: " + std::to_string(this->_daikiriPrice)
		+ ",\nMoxito Price: " + std::to_string(this->_moxitoPrice)
		+ ",\nJuice Price: " + std::to_string(this->_juiceiPrice)
		+ "\n";

		return info;
}

std::string VacationPlace::getName() const
{
	return this->_name;
}

bool VacationPlace::has(int visitorsPerYear, int terrainCleannesScore, int waterCleannesScore) const
{
	if (this->_visitorsPerYear == visitorsPerYear &&
		this->_terrainCleannesScore == terrainCleannesScore &&
		this->_waterCleannesScore == waterCleannesScore)
	{
		return true;
	}

	return false;
}
