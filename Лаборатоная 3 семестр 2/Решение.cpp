#include <iostream>
#include <ctime>
using namespace std;

int main() {
    setlocale(LC_ALL, "Rus");
    const int N = 20;
    int m[N];
    int k;
    int c;
    srand(time(NULL));

    for (int i = 0; i < N; i++) {
        m[i] = rand() % 10;
    }

    cout << "¬ведите k: ";
    cin >> k;

    for (int i = 0; i < N; i++) {
        cout << m[i] << ' ';
    }

    cout << '\n';

    for (int i = 1; i <= k; i++) {
        c = m[0];

        for (int j = 0; j < N - 1; j++) {
            m[j] = m[j + 1];
        }
        m[N - 1] = c;
    }

    for (int i = 0; i < N; i++) {
        cout << m[i] << ' ';
    }


    return 0;
}