#include <iostream>
#include <cmath>

using namespace std;

const double epsilon = 1e-6;

double f(double x) {
	return x - 0.3932 * (pow(2.7183, x) - pow(2.7183, -x) - 2);
}

double iterative(double x0, int maxIterations, double epsilon) {
	double currentX = x0;

	for (int i = 0; i < maxIterations; i++) {
		double nextX = f(currentX);

		if (abs(nextX - currentX) < epsilon) {
			return nextX;
		}
		currentX = nextX;
	}

	return currentX;
}
int main() {
	setlocale(LC_ALL, "Rus");
	double a, b;
	int maxIterations = 1000;

	cout << "Введите границу слева: ";
	cin >> a;
	cout << "Введите границу справа: ";
	cin >> b;

	double x0 = (a + b) / 2;

	double x = iterative(x0, maxIterations, epsilon);

	cout << "Приблизительное значение корня: " << x;

	return 0;
}
