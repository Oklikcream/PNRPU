#include <iostream>
#include <cmath>

using namespace std;

const double epsilon = 1e-6;

double f(double x) {
	return x - 0.3932 * (pow(2.7183, x) - pow(2.7183, -x) - 2);
}

double iterative(double x0, int maxIterations, double epsilon) {
	double currentX = x0;
	int coun = 0;

	for (int i = 0; i < maxIterations; i++) {
		double nextX = f(currentX);

		cout << nextX << endl;
		coun += 1;

		if (abs(nextX - currentX) < epsilon) {
			cout << "Шаги: " << coun << endl;
			return nextX;
		}
		currentX = nextX;
	}

	cout << "Шаги: " << coun << endl;
	return currentX;
}
int main() {
	setlocale(LC_ALL, "Rus");
	double a, b;
	int maxIterations = 1000;

	cout << "Введите левую границу: ";
	cin >> a;
	cout << "Введите правую границу: ";
	cin >> b;

	double x0 = (a + b) / 2;

	double x = iterative(x0, maxIterations, epsilon);

	cout << "Приблизительный корень уравнения: " << x;

	return 0;
}
