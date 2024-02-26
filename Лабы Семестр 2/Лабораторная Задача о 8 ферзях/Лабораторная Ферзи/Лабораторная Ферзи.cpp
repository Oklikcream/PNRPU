#include <iostream>

using namespace std;

const int N = 8;
int board[N][N];
int extern sum = 0;

void printB() 
{
    for (int i = 0; i < N; i++) {
        for (int j = 0; j < N; j++) {
            if (board[i][j] == -1) {
                cout << "Q ";
            }
            else if (board[i][j] == 0) {
                cout << ". ";
            }
            else
            {
                cout << "# ";
            }
        }
        cout << endl;
    }
    cout << endl;
}

void setQ(int i, int j)
{
    for (int t = 0; t < N; t++)
    {
        board[i][t] += 1;
        board[t][j] += 1;
    }

    for (int x = 0; x < N; x++) 
    {
        for (int y = 0; y < N; y++) 
        {
            if (abs(x - i) == abs(y - j)) 
            {
                board[x][y] += 1;
            }
        }
    }
    board[i][j] = -1;
    printB();
}

void delQ(int i, int j)
{
    for (int t = 0; t < N; t++)
    {
        board[i][t] -= 1;
        board[t][j] -= 1;
    }

    for (int x = 0; x < N; x++)
    {
        for (int y = 0; y < N; y++)
        {
            if (abs(x - i) == abs(y - j))
            {
                board[x][y] -= 1;
            }
        }
    }
    board[i][j] = 0;
    printB();
}

bool try_set_queen(int i)
{
    bool res = false;
    for (int j = 0; (j < N) && (!res); ++j) {
        if (board[i][j] == 0)
        {
            setQ(i, j);
            if (i == 7)
            {
                sum += 1;
                cout << "Это был " << sum << "й способ решения. \nНажмите ENTER чтобы продолжить";
                getchar();
            }
            else
                if (!(res = try_set_queen(i + 1)))
                    cout << "Ставить некуда, возвращаемся на строку выше." << endl;
                    delQ(i, j);
        }
    }

    return res;
}

int main() 
{
    setlocale(LC_ALL, "RUS");

    cout << "Всего существует 92 способа решения задачи" << endl;
    cout << "Нажмите ENTER чтобы продолжить";
    getchar();
    try_set_queen(0);
    cout << sum;

    return 0;
}