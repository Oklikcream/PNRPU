#include <iostream>
using namespace std;


int main()
{
    setlocale(LC_ALL, "Rus");

    int n;
    int i = 1;
    double x;
    double u = 1;
    double s = 0;

    cout << "������� ���������� ���������: ";
    cin >> n;
    cout << "������� x: ";
    cin >> x;

    while (i <= n)
    {
        s += u;
        u = u * x / i;
        i += 1;
    }
    cout << "����� ���������: " << s;
    return 0;
}
