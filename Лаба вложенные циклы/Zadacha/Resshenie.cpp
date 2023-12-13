#include <iostream>
using namespace std;

int main() {
	setlocale(LC_ALL, "Rus");

	int n = 0;
	int p;
	int z = 1;

	cout << "¬ведите длину основани€" << endl;
	
	while ((n < 3) || ((n % 2) == 0)) {
		cout << "ƒлина должна быть нечетной и больше 3:" << endl;
		cin >> n;
	}

	p = (n - 1) / 2;

	cout << ' ' << endl;

	for (int i = 1; i <= (n + 1) / 2; i++) {
		
		for (int j = 1; j <= p; j++) {
			cout << ' ';
		}

		p -= 1;

		for (int j = 1; j <= z; j++) {
			cout << '*';
		}

		z += 2;

		cout << endl;
	}
	return 0;
}