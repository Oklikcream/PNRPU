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
	cout << "������� ���������� ���������: ";
	cin >> N;
	cout << "������� ������������������: ";

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

	cout << "������������ �����: " << max << endl;
	cout << "�����: " << j << endl;
	cout << "����������: " << s << endl;
	return 0;
}