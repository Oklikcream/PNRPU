#include <iostream>
#include <ctime>
using namespace std;

int main() {
    setlocale(LC_ALL, "Rus");
    const int N = 20;
    int fN = N; // fake N - ��� "��������" ��������� �� �������
    int m[N];
    int k;
    srand(time(NULL));

    for (int i = 0; i < N; i++) {
        m[i] = rand() % 10;
    }

    cout << "������� k: ";
    cin >> k;

    // ����������� ����� ���������� �������
    for (int i = 0; i < N ; i++) {
        cout << m[i] << ' ';
    }

    cout << '\n';

    // ����������� ����� �� k �� k-1
    for (int i = k-1; i < N + k - 1; i++) {
        cout << m[i % N] << ' ';
    }

    cout << '\n';

    // ���������� ������������� ��������
    int max = m[0];
    int max_ind = 0;
    for (int i = 1; i < fN; i++) {
        if (m[i] > max) {
            max = m[i];
            max_ind = i;
        }
    }
    // �������� ��������� ����������� � ������������
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

    // ����������� ����� �� k �� k+1
    for (int i = N + k - 1; i > k - 1; i--) {
        cout << m[i % N] << ' ';
    }

    cout << '\n';
    return 0;
}
