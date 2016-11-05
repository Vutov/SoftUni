// Kamigawa - Spas Vutov
#include "Beach.h"

Beach::Beach(std::string name)
{
	this->_name = name;
}

Beach::~Beach()
{
}

std::string Beach::getBeachName() const
{
	return this->_name;
}
