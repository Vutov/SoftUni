#include "Cart.h"


Cart::Cart()
{
}


Cart::~Cart()
{
	this->_items.clear();
}

void Cart::operator+=(const Item &item)
{
	this->_items.push_back(item);
}

double Cart::getCashoutPrice()
{
	double sum = 0;
	for (auto &item : this->_items)
	{
		sum += item.getPrice();
	}

	return sum;
}

void Cart::clear()
{
	this->_items.clear();
}
