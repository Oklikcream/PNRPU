#pragma once
#include <iostream>
using namespace std;
template <class T>
class Spisok
{
public:
	Spisok(int s, T k);
	Spisok(const Spisok<T>& a);
	~Spisok();
	Spisok& operator=(const Spisok<T>& a);
	T& operator[](int index);
	Spisok operator*(Spisok<T>&s);
	int operator()();
	friend ostream& operator<< <>(ostream& out, const Spisok<T>& a);
	friend istream& operator>> <>(istream& in, Spisok<T>& a);
protected:
	int size;
	T* data;
};

template <class T>
Spisok<T>::Spisok(int s, T k)
{
	size = s;
	data = new T[size];
	for (int i = 0; i < size; i++)
		data[i] = k;
}

template <class T>
Spisok<T>::Spisok(const Spisok& a)
{
	size = a.size;
	data = new T[size];
	for (int i = 0; i < size; i++)
		data[i] = a.data[i];
}

template <class T>
Spisok<T>::~Spisok()
{
	delete[]data;
	data = 0;
}

template <class T>
Spisok<T>& Spisok<T>::operator=(const Spisok<T>& a)
{
	if (this == &a)
		return *this;
	size = a.size;
	if (data != 0)
		delete[]data;
	data = new T[size];
	for (int i = 0; i < size; i++)
		data[i] = a.data[i];
	return *this;
}

template <class T>
T& Spisok<T>::operator[](int index)
{
	if ((index < size) || (index >= 0))
		return data[index];
	else cout << "\nError! Неверный индекс";
}


template <class T>
Spisok<T> Spisok<T>::operator*(Spisok<T>& s)
{
	Spisok<T> temp(size, s[0]);
	for (int i = 0; i < size; ++i)
		temp.data[i] = data[i] * s.data[i];
	return temp;
}

template <class T>
int Spisok<T>::operator ()()
{
	return size;
}

template <class T>
ostream& operator<< (ostream& out, const Spisok<T>& a)
{
	for (int i = 0; i < a.size; ++i)
		out << a.data[i] << " ";
	return out;
}
template <class T>
istream& operator>> (istream& in, Spisok<T>& a)
{
	for (int i = 0; i < a.size; ++i)
		in >> a.data[i];
	return in;
}