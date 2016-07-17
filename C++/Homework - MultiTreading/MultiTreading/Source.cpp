#include  <iostream>
#include <vector>
#include <thread>
#include <mutex>

using  namespace  std;

mutex mtx;

void findFirstPrimeNumbers(unsigned long long max)
{
	unsigned long long startClock = clock();
	for (int i = 2; max > 0; ++i)
	{
		bool  isPrime = true;
		for (int j = 2; j < i; ++j)
		{
			if (i  % j == 0)
			{
				isPrime = false;
				break;
			}
		}
		if (isPrime)
		{
			--max;
			//mtx.lock();
			cout << "Prime, " << i << ", " << (float) (clock() - startClock) / CLOCKS_PER_SEC << " ms." << endl;
			//mtx.unlock();
		}
	}
}

void findFibonacciNumbers(unsigned long long max)
{
	unsigned long long c, first = 0, second = 1, next;
	unsigned long long startClock = clock();

	for (c = 0; c < max; c++)
	{
		if (c <= 1)
		{
			next = c;
		}
		else
		{
			next = first + second;
			first = second;
			second = next;
		}

		//mtx.lock();
		cout << "Fibunacci, " << next << ", " << (float)(clock() - startClock) / CLOCKS_PER_SEC << " ms." << endl;;
		//mtx.unlock();
	}

}

int  main()
{
	unsigned long long number;
	cin >> number;

	unsigned long long startClock = clock();
	vector <thread> threads;

	threads.push_back(thread(findFirstPrimeNumbers, number));
	threads.push_back(thread(findFibonacciNumbers, number));

	for (int i = 0; i < 2; i++)
	{
		threads[i].join();
	}

	/*findFirstPrimeNumbers(number);
	findFibonacciNumbers(number);*/

	cout << "Total: " << (float)(clock() - startClock) / CLOCKS_PER_SEC << endl;

	return  0;
}