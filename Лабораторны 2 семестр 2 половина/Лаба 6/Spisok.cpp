#include "Spisok.h"

Spisok::Spisok(int s, int k)
{
	size = s;
	data = new int[size];
	for (int i = 0; i < size; i++)
		data[i] = k;
	beg.elem = &data[0];
	end.elem = &data[size];
}

Spisok::Spisok(const Spisok& a)
{
	size = a.size;
	data = new int[size];
	for (int i = 0; i < size; i++)
		data[i] = a.data[i];
	beg = a.beg;
	end = a.end;
}

Spisok::~Spisok()
{
	delete[]data;
	data = 0;
}
Spisok& Spisok::operator=(const Spisok& a)
{
	if (this == &a)
		return *this;
	size = a.size;
	if (data != 0) 
		delete[]data;
	data = new int[size];
	for (int i = 0; i < size; i++)
		data[i] = a.data[i];
	beg = a.beg;
	end = a.end;
	return *this;
}

int& Spisok::operator[](int index)
{
	if ((index < size) || (index >= 0)) 
		return data[index];
	else cout << "\nError! Неверный индекс";
}

Spisok Spisok::operator*(Spisok& k)
{
	Spisok temp(size);
	for (int i = 0; i < size; ++i)
		temp.data[i] = data[i] * k.data[i];
	return temp;
}

int Spisok::operator()()
{
	int len = size;
	return len;
}

ostream& operator<<(ostream& out, const Spisok& a)
{
	for (int i = 0; i < a.size; ++i)
		out << a.data[i] << " ";
	return out;
}
istream& operator>>(istream& in, Spisok& a)
{
	for (int i = 0; i < a.size; ++i)
		in >> a.data[i];
	return in;
}