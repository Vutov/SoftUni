#include "Item.h"
#include <iostream>
#include "Cart.h"

Cart addItemToCart(std::vector<Item> &items, Cart &cart, std::string &line)
{
	bool found = false;
	for (Item &item : items)
	{
		if (item.getCode() == line)
		{
			found = true;
			cart += item;
			std::cout << "Item found" << std::endl;
			break;
		}
	}

	if (!found)
	{
		std::cout << "Item not found" << std::endl;
	}

	return cart;
}

Cart cashout(Cart &cart)
{
	double money = 0;
	std::cout << "Please enter the amount of money" << std::endl;
	std::cin >> money;
	double sum = cart.getCashoutPrice();
	double diff = money - sum;
	if (diff > 0)
	{
		std::cout << "CandyShop" << std::endl << "BIC12345678" << std::endl <<
			"Address: Somewhere in the middle of nowhere" << std::endl <<
			"Purchases <" << sum << ">" << std::endl << "Change: <" << diff << "> leva" << std::endl;
		cart.clear();
	}
	else
	{
		std::cout << "Not enough money!" << std::endl;
	}

	return cart;
}

std::vector<Item> changeItemsPrice(std::vector<Item> &items, std::string &line)
{
	std::cout << "Enter code to for item to change and new price" << std::endl;
	std::string code = "";
	double price = 0;
	std::cin >> code >> price;
	bool found = false;
	for (Item &item : items)
	{
		if (item.getCode() == code)
		{
			found = true;
			item.newPrice(price);
			std::cout << "Price changed" << std::endl;
			break;
		}
	}

	if (!found)
	{
		std::cout << "Item not found" << std::endl;
	}

	return items;
}

int main()
{
	std::vector<Item> items = { Item("1Abc123123", 10, "Beer"), Item("2Abc123123", 20.2, "Water"), Item("3Abc123123", 1.2, "Soap") };
	auto cart = Cart();

	std::string line = "";
	while (std::cin >> line)
	{
		if (line.length() == 10)
		{
			cart = addItemToCart(items, cart, line);
		}
		else if (line == "C")
		{
			cart.clear();
		}
		else if (line == "T")
		{
			std::cout << cart.getCashoutPrice() << std::endl;
		}
		else if (line == "G")
		{
			cart = cashout(cart);
		}
		else if (line == "Change")
		{
			items = changeItemsPrice(items, line);
		}
		else if (line == "Exit")
		{
			return 0;
		}
		else
		{
			std::cout << "Unknown command" << std::endl;
		}
	}

	return 0;
}
