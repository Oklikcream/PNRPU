#include "Vector.h"

Vector::Vector()
{
	beg = 0;
	cur = 0;
	size = 0;
}

Vector::Vector(int n)
{
	beg = new Object * [n];
	cur = 0;
	size = n;
}

Vector::Vector(const Vector& vec)
{
	for (int i = 0; i < vec.size; i++)
	{
		beg[i] = vec.beg[i];
	}
	size = vec.size;
	cur = vec.cur;
}

Vector::~Vector()
{
	if (beg != 0)
		delete[] beg;
	beg = 0;
}

void Vector::Add(Object* obj)
{
	if (cur < size)
	{
		beg[cur] = obj;
		cur += 1;
	}
}

ostream& operator<<(ostream& out, Vector& vec) 
{
	if (vec.size == 0)
		out << "Пусто" << endl;
	else
	{
		Object** v = vec.beg;
		for (int i = 0; i < vec.cur; i++)
		{
			(*v)->Show();
			v++;
		}
	}
	return out;
}

