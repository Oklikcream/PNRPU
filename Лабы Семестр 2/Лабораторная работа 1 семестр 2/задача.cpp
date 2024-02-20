#include <iostream>
#include <time.h>
using namespace std;

const int n = 100;

int main() 
{
	setlocale(LC_ALL, "Ru");

	int max, m[n], nu;
	int s = 1;
	srand(time(NULL));

	for (int i = 0; i < n; i++) 
	{
		m[i] = rand() % 200 - 100;
	}
	max = m[0];

	for (int i = 1;i < n;i++) 
	{
		if (m[i] > max) 
		{
			max = m[i];
			s = 1;
			nu = i + 1;
		}
		else
		{
			if (m[i] == max) 
			{
				s++;
			}
		}
	}

	for (int i = 0; i < n; i++)
	{
		cout << i + 1 << ") " << m[i] << endl;
	}

	cout << "Максимальный элемент: " << max << endl;
	cout << "Номер максимального элемента: " << nu << endl;
	cout << "Количество элементов, равных максимальному: " << s << endl;

	return 0;
}
