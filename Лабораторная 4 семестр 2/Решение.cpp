#include <iostream>
#include <ctime>
using namespace std;

int main() {
    setlocale(LC_ALL, "Rus");
    const int N = 20;
    int fN = N; // fake N - для "удаления" элементов из массива
    int m[N];
    int k;
    srand(time(NULL));

    for (int i = 0; i < N; i++) {
        m[i] = rand() % 10;
    }

    cout << "Введите k: ";
    cin >> k;

    // циклический вывод начального массива
    for (int i = 0; i < N ; i++) {
        cout << m[i] << ' ';
    }

    cout << '\n';

    // циклический вывод от k до k-1
    for (int i = k-1; i < N + k - 1; i++) {
        cout << m[i % N] << ' ';
    }

    cout << '\n';

    // нахождение максимального элемента
    int max = m[0];
    int max_ind = 0;
    for (int i = 1; i < fN; i++) {
        if (m[i] > max) {
            max = m[i];
            max_ind = i;
        }
    }
    // удаление элементов совпадающих с максимальным
    int c = 0;
    for (int i = max_ind + 1; i < N; i++) {
        int fi = i - c;
        if (m[fi] == max) {
            for (int j = fi; j < (fN - 1); j++) {
                m[j] = m[j + 1];
            }
            fN--;
            c++;
        }
    }

    // циклический вывод от k до k+1
    for (int i = N + k - 1; i > k - 1; i--) {
        cout << m[i % N] << ' ';
    }

    cout << '\n';
    return 0;
}
