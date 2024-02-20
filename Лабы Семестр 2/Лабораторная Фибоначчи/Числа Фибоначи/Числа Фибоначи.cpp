#include <iostream>
using namespace std;

int fib(int n)
{
	if (n <= 1)
	{
		return n;
	}
	else
	{
		return fib(n - 1) + fib(n - 2);
	}
}


void main()
{
	setlocale(LC_ALL, "rus");

	int n;

	cout << "Введите число: ";
	cin >> n;
	
	for (int i = 0; i < n; i++) {
		cout << fib(i) << " ";
	}
}
