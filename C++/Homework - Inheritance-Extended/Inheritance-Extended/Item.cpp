#include "Item.h"

Item::Item(std::string code, double price, std::string name)
{
	this->_code = code;
	this->_price = price;
	this->_name = name;
}

Item::~Item()
{
}

std::string Item::getCode() const
{
	return this->_code;
}

double Item::getPrice() const
{
	return this->_price;
}

void Item::newPrice(double price)
{
	this->_price = price;
}
