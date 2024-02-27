#include <iostream>
#include <ctime>
#include <stdlib.h>
using namespace std;

const int n = 10;

void func(int a, int c[])
{   
    int t;
    int d;

    d = c[0];

    for (int i = 0; i < d; i++)
    {
        t = c[0];
        for (int j = 0; j < a - 1; j++)
        {
            c[j] = c[j + 1];
        }
        c[a - 1] = t;
    }

    for (int j = 0; j < a; j++)
    {
        cout << c[j] << ' ';
    }
}

void func(int a, int c[], bool f)
{
    int t;
    int d;

    d = c[a - 1];

    for (int i = 0; i < d; i++)
    {
        t = c[a - 1];
        for (int j = a - 1; j > 0; j--)
        {
            c[j] = c[j - 1];
        }
        c[0] = t;
    }

    for (int j = 0; j < a; j++)
    {
        cout << c[j] << ' ';
    }
}


int main()
{
    srand(time(NULL));
    int m[n];
    for (int i = 0; i < n; i++)
    {
        m[i] = rand() % 10 + 1;
        cout << m[i] << ' ';
    }
    cout << endl;

    if (m[0] % 2 == 0)
    {
        func(n, m);
    }
    else
    {
        func(n, m, 1);
    }

    return 0;
}
