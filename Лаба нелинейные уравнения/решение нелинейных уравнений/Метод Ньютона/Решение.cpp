#include <iostream>
#include <cmath>

using namespace std;

const double epsilon = 1e-6;

double f(double x) {
	return pow(2.7183, x) - pow(2.7183, -x) - 2;
}

double f1(double x) {
	return pow(2.7183, x) + pow(2.7183, -x);
}


double f2(double x) {
	return pow(2.7183, x) - pow(2.7183, -x);
}

int main() {
	setlocale(LC_ALL, "Rus");
	double a, b, x;

	cout << "������� ����� �������: ";
	cin >> a;
	cout << "������� ������ �������: ";
	cin >> b;

	x = (a + b) / 2;

	if (f(a) * f2(a) > 0)
		a = x;
	else
		b = x;

	while (abs(f(x)) >= epsilon) {
		x = x - (f(x) / f1(x));

	}
	cout << "��������������� ������ ���������: " << x;
	return 0;
}
