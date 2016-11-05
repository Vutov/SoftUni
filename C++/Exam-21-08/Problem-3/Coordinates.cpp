// Kamigawa - Spas Vutov

#include "Coordinates.h"

Coordinates::Coordinates()
{
	this->_x = 0;
	this->_y = 0;
}

Coordinates::Coordinates(double x, double y)
{
	this->_x = x;
	this->_y = y;
}

Coordinates::~Coordinates()
{
}

double Coordinates::getX() const
{
	return this->_x;
}

double Coordinates::getY() const
{
	return this->_y;
}
