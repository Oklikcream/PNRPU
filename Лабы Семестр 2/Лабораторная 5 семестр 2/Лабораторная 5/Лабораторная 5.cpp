#include < iostream>
#include <ctime>

using namespace std;

bool Check(int* arr[], int a[], int r, int c) 
{
	bool fl = true;
	for (int i = r * c; (i < r * c + r) && fl; i++) 
	{
		if (arr[i - r * c][0] != a[i]) fl = false;
	}
	return fl;
}

void SwapArr(int* arr[], int c, int n, int m) 
{
	for (int i = 0; i < c; i++) 
	{
		swap(arr[m][i], arr[n][i]);
	}
}

int main() {
	srand(time(NULL));
	setlocale(LC_ALL, "Rus");
	/*
	5 4 8 9
	1 3 2 10
	11 7 6 0
	*/
	const int r = 3;
	const int c = 4;
	int arr[r][c];
	int* parr[r];

	for (int i = 0; i < r; i++) 
	{
		parr[i] = arr[i];
	}

	int a[2 * r * c]{ 1,3,2,10,11,7,6,0,5,4,8,9,5,1,11,9,10,0,4,3,7,8,2,6 };// исходный
	int s = 0;

	for (int i = 0; i < r; i++) 
	{
		for (int j = 0; j < c; j++) 
		{
			arr[i][j] = a[s++];
		}
	}

	bool fl = false;
	int n, m;

	while (fl == false) 
	{
		n = rand() % r;
		m = rand() % r;
		SwapArr(parr, c, n, m);
		fl = Check(parr, a, r, c);
	}

	for (int i = 0; i < r; i++) 
	{
		for (int j = 0; j < c; j++) 
		{
			cout << parr[i][j] << ' ';
		}
		cout << endl;
	}
}
