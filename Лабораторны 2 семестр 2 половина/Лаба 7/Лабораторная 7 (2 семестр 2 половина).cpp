#include <iostream>
#include "Spisok.h"
#include "Pair.h"
 
using namespace std;

void main()
{
	system("chcp 1251 > nul");

	Spisok<int>A(5, 0);
	cout << "Введите значения списка: ";
	cin >> A;
	cout << A << endl;

	Spisok<int>B(10, 1);
	cout << B << endl;

	B = A;
	cout << B << endl;

	cout << A[2] << endl;

	cout << "Размер=" << A() << endl;

	B = A * B;
	cout << B << endl;


	Pair p;
	cin >> p;
	cout << p << endl << endl;
	
	Spisok <Pair>C(2, p);
	cin >> C;
	cout << C << endl;

	Spisok <Pair> D(3, p);
	cout << D << endl;
	
	D = C;
	cout << D << endl;
	cout << C[1] << endl;
	cout << "Размер=" << C() << endl;

	D = C * D;
	cout << D << endl;
}

