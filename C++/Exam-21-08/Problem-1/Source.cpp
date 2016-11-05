// Kamigawa - Spas Vutov

#include <iostream>
#include <string>
#include <algorithm>
#include <map>
#include <vector>

int main()
{
	std::map<short int, short int> items;

	short int num = 0;
	for (auto i = 0; i < 255; i++)
	{
		std::cin >> num;
		if (items[num])
		{
			items[num] = items[num] + 1;
		}
		else {
			items.insert_or_assign(num, 1);
		}
	}

	std::vector<std::pair<short int, short int>> pairs;
	for (auto itr = items.begin(); itr != items.end(); ++itr)
	{
		pairs.push_back(*itr);
	}

	std::sort(pairs.begin(), pairs.end(), [=](std::pair<short int, short int>& a, std::pair<short int, short int>& b)
	{
		if (a.second == b.second)
		{
			return a.first > b.first;
		}

		return a.second > b.second;
	});

	std::cout << pairs[0].first << std::endl;

	return 0;
}