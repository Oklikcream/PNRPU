#include <iostream>
#include <string>
using namespace std;

// 1 zadanie
double l(double A[], double B[])
{
	return sqrt(pow((B[0] - A[0]), 2) + pow((B[1] - A[1]), 2));
}

// 2 zadanie
string belong(double M[], double A1[], double A2[], double A3[])
{
	if (((((A1[0] - M[0]) * (A2[1] - A1[1]) - (A2[0] - A1[0]) * (A1[1] - M[1]))) == 0) ||
		((((A2[0] - M[0]) * (A3[1] - A2[1]) - (A3[0] - A2[0]) * (A2[1] - M[1]))) == 0) ||
		((((A3[0] - M[0]) * (A1[1] - A3[1]) - (A1[0] - A3[0]) * (A3[1] - M[1]))) == 0))
	{
		return "����� M ����� �� ������� ������������";
	}
	
	else
	{	
		if ((((((A1[0] - M[0]) * (A2[1] - A1[1]) - (A2[0] - A1[0]) * (A1[1] - M[1]))) > 0) ==
			((((A2[0] - M[0]) * (A3[1] - A2[1]) - (A3[0] - A2[0]) * (A2[1] - M[1]))) > 0)) &&
			(((((A2[0] - M[0]) * (A3[1] - A2[1]) - (A3[0] - A2[0]) * (A2[1] - M[1]))) > 0) ==
				((((A3[0] - M[0]) * (A1[1] - A3[1]) - (A1[0] - A3[0]) * (A3[1] - M[1]))) > 0)))
		{
			return "����� M ������ ������������";
		}
		else
		{
			return "����� M ��� ������������";
		}
	}
}

// 3 zadanie
string belong(int p, double* M, ...);

const int n = 5; // Kolichestvo uglov

void main()
{	
	setlocale(LC_ALL, "Rus");

	double m1[2] = { 1, 1 };
	double m2[2] = { 0.5, 0 };
	double m3[2] = { 3, 1 };
	double a[2] = { 0, 0 };
	double b[2] = { 2, 0 };
	double c[2] = { 1, 2 };

	cout << "����� ������� � ��������� � ������ (" << a[0] << "; " << a[1] << ") � (" << b[0] << "; " << b[1] << ") �����: " << l(a, b) << endl << endl;

	cout << belong(m1, a, b, c) << endl; // ����� ������ ������������
	cout << belong(m2, a, b, c) << endl; // ����� �� ����� ������������
	cout << belong(m3, a, b, c) << endl << endl; // ����� ��� ������������

	double M[2];
	double A[2];
	double B[2];
	double C[2];
	double D[2];
	double E[2];
	cout << "������� ���������� ����� M: ";
	cin >> M[0] >> M[1];

	cout << "������� ���������� �����:" << "\nA:";
	cin >> A[0] >> A[1];
	cout << "B:";
	cin >> B[0] >> B[1];
	cout << "C:";
	cin >> C[0] >> C[1];
	cout << "D:";
	cin >> D[0] >> D[1];
	cout << "E:";
	cin >> E[0] >> E[1];

	cout << belong(n, M, A, B, C, D, E) << endl;

	// ������� ��� 3 �������:
	
	//double M1[2] = { 1, 1 };
	//double M2[2] = { 4, 1 };
	//double M3[2] = { 1.5, 0 };
	//double A[2] = { 0, 0 };
	//double B[2] = { 2, 0 };
	//double C[2] = { 3, 2 };
	//double D[2] = { 1, 3 };
	//double E[2] = { 0, 2 };

	//cout << belong(n, M1, A, B, C, D, E) << endl; // ����� ������ ��������������
	//cout << belong(n, M2, A, B, C, D, E) << endl; // ����� ��� ��������������
	//cout << belong(n, M3, A, B, C, D, E) << endl; // ����� �� ����� ��������������
}

// 3 zadanie
string belong(int p, double* M, ...)
{
	double m[n + 1][2];
	int j = 0;

	// Zanosim vershini tochki i mnogougolnika v massiv
	for (int i = 0; i <= p; i++)
	{
		m[i][0] = *(M + j);
		m[i][1] = *(M + j + 1);
		j += 6;
	}

	int count = 0;

	// Perebiraem storoni mnogougolnika
	for (int i = 1; i <= p; i++)
	{
		int j = i;
		int k = (i % 5) + 1;

		// Proverka, ne lezit li tocha na storone mnogougolnika
		if ((m[j][0] - m[0][0]) * (m[k][1] - m[0][1]) == (m[k][0] - m[0][0]) * (m[j][1] - m[0][1]) &&
			((m[j][0] <= m[0][0] && m[0][0] <= m[k][0]) || (m[j][0] >= m[0][0] && m[0][0] >= m[k][0])) &&
			((m[j][1] <= m[0][1] && m[0][1] <= m[k][1]) || (m[j][1] >= m[0][1] && m[0][1] >= m[k][1])))
		{
			return "����� M ����� �� ������� ��������������";
		}

		// Proverka, peresekaet li luch iz tochki tekushuu storonu po X
		if ((m[j][1] < m[0][1] && m[k][1] >= m[0][1] || m[j][1] > m[0][1] && m[k][1] <= m[0][1]) &&
			(m[j][0] + (m[0][1] - m[j][1]) / (m[k][1] - m[j][1]) * (m[k][0] - m[j][0]) < m[0][0]))
		{
			count++;
		}
	}
	if (count % 2 == 1)
		return "����� M ������ ��������������";
	else
		return "����� M ��� ��������������";
}
