// Kamigawa - Spas Vutov

#include <vector>
#include "VacationPlace.h"
#include "Beach.h"
#include "Country.h"
#include <iostream>

int main()
{
	// Some examples how the classes work
	std::vector<VacationPlace> places = {
		VacationPlace("Some", 10.1, 12.3, Sand, Sea, 10, 10, 1234, 2.123, 1, 2, 3, 6),
		VacationPlace("Other", 40.1, 9.3, Mixed, OtherWather, 4, 10, 2, 0.123, 1, 3, 3, 2),
		VacationPlace("AnOther", 12.1, 6.3, Ceramic, Pudle, 6, 3, 33333, 1.143, 1, 5, 3, 4),
		VacationPlace("Nice", 5.1, 15.3, OtherTerrain, Sea, 7, 1, 1111, 5.123, 1,6, 3, 0),
	};

	std::vector<Beach> beachesBulgaria = { Beach("NiceBeach"), Beach("Ugly") };
	std::vector<Beach> beachesGreece = { Beach("SomeBeach"), Beach("OtherUgly") };

	auto bulgaria = Country("Bulgaria", beachesBulgaria, "lev", 1.95);
	auto greece = Country("Greece", beachesGreece, "eur", 1);

	bulgaria.addPlace(places[0]);
	bulgaria.addPlace(places[2]);
	std::cout << bulgaria.removePlace("AnOther") << std::endl;

	greece.addPlace(places[3]);
	std::cout << greece.findPlaceByName("Nice") << std::endl;
	std::cout << greece.findPlaceByName("Some1") << std::endl;

	std::vector <std::thread> threads;
	int visitorsPerYear = 1234;
	int terrainCleannesScore = 10;
	int waterCleannesScore = 10;

	threads.push_back(std::thread(&Country::findPlaceBy, bulgaria, visitorsPerYear, terrainCleannesScore, waterCleannesScore));
	threads.push_back(std::thread(&Country::findPlaceBy, greece, visitorsPerYear, terrainCleannesScore, waterCleannesScore));
		
	for (auto i = 0; i < threads.size(); i++)
	{
		threads[i].join();
	}

	return 0;
}