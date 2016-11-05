// Kamigawa - Spas Vutov
#pragma once
#include <string>

class Beach
{
private:
	std::string _name;

public:
	Beach(std::string name);
	~Beach();
	std::string getBeachName() const;
};

