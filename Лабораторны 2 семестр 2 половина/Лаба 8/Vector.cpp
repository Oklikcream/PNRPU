#include "Magazin.h"
#include <iostream>
#include "Vector.h"

using namespace std;

Vector::Vector()
{
	beg = 0;
	cur = -1;
	size = 0;
}
Vector::~Vector() 
{
	if (beg != 0)
		delete[] beg;
	beg = 0;
}

Vector::Vector(int n)
{
	beg = new Object * [n];
	cur = 0;
	size = n;
}

void Vector::Add() 
{
	if (cur < 0 || cur == size)
	{
		cout << "\nПереполнено" << endl;
		return;
	}
	Object* p;
	int y = 0;
	do {
		cout << "1.Печaтное издание\n";
		cout << "2.Журнал\n";
		cin >> y;
		if (y == 1)
		{
			Print* a = new (Print);
			a->Input();
			p = a;
			if (cur < size)
			{
				beg[cur] = p;
				cur++;
			}
			return;
		}
		else if (y == 2)
		{
			Magazin* b = new Magazin;
			b->Input();
			p = b;
			if (cur < size)
			{
				beg[cur] = p;
				cur++;
			}
			return;
		}
		cout << "Неверный оператор!" << endl;
	} while (y < 1 || y > 2);
}
void Vector::Show() 
{
	if (cur <= 0) 
	{
		cout << "\nПусто" << endl;
	}
	Object** p = beg;
	for (int i = 0; i < cur; i++) 
	{
		(*p)->Show();
		p++;
	}
}

int Vector::operator ()() 
{
	return cur;
}

void Vector::Del() 
{
	if (cur <= 0) 
	{
		return;
	}
	cur--;
}

void Vector::HandleEvent(const TEvent& event)
{
	if (event.what == evMessage)
	{
		if (cur <= 0)
		{
			cout << "\nПусто" << endl;
			return;
		}
		Object** p = beg;
		for (int i = 0; i < cur; i++)
		{
			(*p)->HandleEvent(event);
			p++;
		}
	}
}