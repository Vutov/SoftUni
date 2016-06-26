#pragma once
#include <string>

class Item
{
private:
	std::string _code;
	double _price;
	std::string _name;

public:
	Item(std::string code, double price, std::string name);
	~Item();
	std::string getCode() const;
	double getPrice() const;
	void newPrice(double price);
};

