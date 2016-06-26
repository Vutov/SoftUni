#pragma once
#include "Item.h"
#include <vector>

class Cart
{
private:
	std::vector<Item> _items;
public:
	Cart();
	~Cart();
	void operator+=(const Item &item);
	double getCashoutPrice();
	void clear();
};

