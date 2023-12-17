#include <iostream>
#include <cmath>

using namespace std;

const double epsilon = 1e-6;

int main() {
	setlocale(LC_ALL, "Rus");
	double a, b, x, fb, fx;
	cout << "Введите предел слева: ";
	cin >> a;
	cout << "Введите предел справа: ";
	cin >> b;

	while (abs(b - a) >= epsilon) {
		x = (a + b) / 2;

		fb = pow(2.7183, b) - pow(2.7183, -b) - 2;
		fx = pow(2.7183, x) - pow(2.7183, -x) - 2;

		if (fb * fx < 0)
			a = x;
		else
			b = x;
	}

	cout << "Приближенный корень: " << b;
	return 0;
}
