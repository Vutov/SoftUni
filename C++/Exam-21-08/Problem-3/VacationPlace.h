// Kamigawa - Spas Vutov

#pragma once
#include <string>
#include "Coordinates.h"

enum TerrainType { Sand, Rocks, Ceramic, Concrete, Mixed, OtherTerrain };
enum WaterType { Sea, Ocean, Pool, Pudle, None, OtherWather };

class VacationPlace
{
private:
	std::string _name;
	Coordinates _coordinates;
	TerrainType _terrainType;
	WaterType _waterType;
	int _terrainCleannesScore;
	int _waterCleannesScore;
	int _visitorsPerYear;
	double _averageCostsPerDay;
	int _numberOfBars;
	double _daikiriPrice;
	double _moxitoPrice;
	double _juiceiPrice;

	int setTerrainCleannes(int terrainCleannesScore);
	int setWaterCleannes(int waterCleannesScore);
public:
	VacationPlace();
	VacationPlace(std::string name, double longitude, double altitude, TerrainType terrainType, WaterType waterType,
		int terrainCleannesScore, int waterCleannesScore, int visiotrsPerYear, double averageCostPerDay, int numberOfBars,
		double daikiriPRice, double moxitoPrice, double juicePrice);
	~VacationPlace();
	std::string getFullInformation() const;
	std::string getName() const;
	bool has(int visitorsPerYear, int terrainCleannesScore, int waterCleannesScore) const;
};
