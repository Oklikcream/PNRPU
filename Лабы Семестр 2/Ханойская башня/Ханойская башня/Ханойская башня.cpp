#include <iostream>
using namespace std;

extern int iter = 0;

void han(int n, int st, int end, int t = 0)
{
	if (n == 0)
	{
		cout << "___________________________" << endl;
		cout << "Обнаружена итерация с n = 0 /\\" << endl;
		cout << "Переходим на итерацию выше. ||" << endl ;
		cout << "---------------------------" << endl << endl;
	}
	else
	{	
		int it = ++iter;

		cout << "_________________________" << endl;
		cout << "Создаём итерацию с ID: " << it << "" << endl;
		cout << "Start: " << st << "  Temp: " << t << "  End: " << end << endl;
		cout << "-------------------------" << endl << endl;

		t = 6 - st - end;

		han(n - 1, st, t, end);
		cout << "_________________________" << endl;
		cout << "Итерация: " << it << endl;
		cout << "Start: " << st << "  Temp: " << t << "  End: " << end << endl;
		cout << "Переложим диск " << n << " с " << st << " на " << end << endl;
		cout << "-------------------------" << endl << endl;
		han(n - 1, t, end, st);
	}
}


int main()
{
	setlocale(LC_ALL, "Rus");

	int n;

	cout << "Введите количество дисков: ";
	cin >> n;

	cout << endl;
	han(n, 1, 3, 2);
	cout << "Всего итераций: " << iter << endl;

	return 0;
}