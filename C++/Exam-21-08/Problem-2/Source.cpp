// Kamigawa - Spas Vutov

#include <ostream>
#include <iostream>

int main()
{
	float a = 0;
	float b = 0;
	float c = 0;
	std::cin >> a >> b >> c;

	float x1 = 0;
	float x2 = 0;
	auto hasRoots = true;

	auto determinant = b*b - 4 * a*c;
	if (determinant > 0) {
		x1 = (-b + sqrt(determinant)) / (2 * a);
		x2 = (-b - sqrt(determinant)) / (2 * a);
	}
	else if (determinant == 0) {
		x1 = (-b + sqrt(determinant)) / (2 * a);
		x2 = x1;
	}
	else {
		hasRoots = false;
	}

	if (hasRoots)
	{
		std::cout << roundf(x1 * 100) / 100 << "," << roundf(x2 * 100) / 100 << std::endl;
	}
	else {
		std::cout << "nan,nan" << std::endl;
	}

	return 0;
}