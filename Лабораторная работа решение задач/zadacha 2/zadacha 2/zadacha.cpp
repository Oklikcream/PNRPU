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

    cout << "Введите количество элементов: ";
    cin >> n;
    cout << "Введите x: ";
    cin >> x;

    while (i <= n)
    {
        s += u;
        u = u * x / i;
        i += 1;
    }
    cout << "Сумма элементов: " << s;
    return 0;
}
