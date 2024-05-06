#include "Spisok.h"
#include <iostream>

int main()
{
    system("chcp 1251 > nul");

	Spisok a(5);
	cout << "a : " << a << "\n";
	cout << "a > ";
	cin >> a;
	cout << "a : " << a << "\n";
	a[2] = 0;
	cout << "a : " << a << "\n";
	cout << endl;

	Spisok b(10);
	cout << "b : " << b << "\n";
	cout << "b > ";
	cin >> b;
	cout << "b : " << b << "\n";
	b = a;
	cout << "b : " << b << "\n";
	cout << "a : " << a << "\n";
	Spisok c(10);
	c = a * b;
	cout << "a * b : " << c << "\n";
	cout << "\nДлина списка a=" << a() << endl;
	cout << endl;
	cout << *(a.first()) << endl;
	Iterator i = a.first();
	cout << *i << endl;
	cout << endl;
	int n;
	cout << "\nВведите номер элемента: > "; cin >> n;
	n--;
	for (int j = 0; j < n; ++j) ++i;
	cout << *i;

}
