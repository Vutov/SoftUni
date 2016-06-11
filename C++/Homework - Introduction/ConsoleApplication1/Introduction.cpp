#include "stdafx.h"
#include <iostream>
#include <string>
#include <algorithm>

using namespace std;

int main()
{
	string input = "";
	getline(cin, input);

	int lowerLetters = 0;
	int upperLetters = 0;
	int otherLetters = 0;

	for each (char letter in input)
	{
		if (letter >= 'a' && letter <= 'z')
		{
			lowerLetters++;
		}
		else if (letter >= 'A' && letter <= 'Z')
		{
			upperLetters++;
		}
		else {
			otherLetters++;
		}
	}

	cout << "Lower letters: " << lowerLetters << endl;
	cout << "Upper letters: " << upperLetters << endl;
	cout << "Other letters: " << otherLetters << endl;

	return 0;
}