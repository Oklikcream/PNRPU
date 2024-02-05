#include <iostream>
#include <ctime>
using namespace std;

int main() {
    setlocale(LC_ALL, "Rus");
    const int N = 20;
    int c;
    int m[N];
    int p, q;
    srand(time(NULL));

    for (int i = 0; i < N; i++) {
        m[i] = rand() % 10;
    }

    cout << "¬ведите p и q: ";
    cin >> p;
    cin >> q;

    for (int i = 0; i < N ; i++) {
        cout << m[i] << ' ';
    }

    cout << endl;

    int f = 0;
    for (int i = p - 1; i < (p - 1 + q) / 2; i++) {
        c = m[i];
        m[i] = m[q - 1 - f];
        m[q - 1 - f] = c;
        f += 1;
    }

    for (int i = 0; i < N; i++) {
        cout << m[i] << ' ';
    }

    return 0;
}
