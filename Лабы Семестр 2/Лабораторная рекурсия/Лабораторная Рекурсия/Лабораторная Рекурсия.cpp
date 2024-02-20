#include <iostream>
using namespace std;

int r1(int n)
{
    if (n == 1)
    {
        return 1;
    }
    else
    {
        return n + r1(n-1);
    }
}

double r2(double x, int n)
{
    if (n == 0)
    {
        return x;
    }
    else
    {
        return ((pow(x, 2 * n + 1) / r1(2 * n + 1)) + r2(x, n-1));
    }

}


int main()
{
    setlocale(LC_ALL, "Rus");
    cout << r2(2, 10);
    return 0;
}
