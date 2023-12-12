#include <iostream>
using namespace std;

int main() {
	setlocale(LC_ALL, "Rus");

	int n = 4;
	cout << "¬ведите длину основани€" << endl;
	
	while ((n < 3) || ((n % 2) == 0)) {
		cout << "ƒлина должна быть нечетной и больше 3:" << endl;
		cin >> n;
	}

	cout << ' ' << endl;

	for (int i = 1; i <= (n + 1) / 2; i++) {
		
		for (int j = 1; j <= (n + 1) / 2 - i; j++) {
			cout << ' ';
		}

		for (int j = 1; j <= i * 2 - 1; j++) {
			cout << '*';
		}
		cout << endl;
	}
	return 0;
}