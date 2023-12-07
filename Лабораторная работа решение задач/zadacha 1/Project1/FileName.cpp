#include <iostream>
using namespace std;

int main()
{
	int max = 0;
	int s = 1;
	int a;
	int N;
	int j;
	int i = 1;

	setlocale(LC_ALL, "Rus");
	cout << "Введите количество элементов: ";
	cin >> N;
	cout << "Введите последовательность: ";

	while (i <= N)
	{
		cin >> a;

		if (max < a)
		{
			max = a;
			j = i;
			s = 1;
		}

		else
		{
			if (max == a)
			{
				s += 1;
			}
		}

		i += 1;

	}

	cout << "Максимальное число: " << max << endl;
	cout << "Номер: " << j << endl;
	cout << "Количество: " << s << endl;
	return 0;
}