// Kamigawa - Spas Vutov

#pragma once
class Coordinates
{
private:
	double _x;
	double _y;

public:
	Coordinates();
	Coordinates(double x, double y);
	~Coordinates();
	double getX() const;
	double getY() const;
};

