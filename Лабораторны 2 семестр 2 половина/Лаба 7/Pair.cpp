#include "Pair.h"
Pair& Pair::operator=(const Pair& P)
{
	first = P.first;
	second = P.second;
	return *this;
}

Pair& Pair::operator-(const Pair& P)
{
	first -= P.first;
	second -= P.second;
	return *this;
}

Pair Pair::operator+(const int a)
{
	Pair p(*this);
	p.first += a;
	return p;
}

Pair Pair::operator+(const double b)
{
	Pair p(*this);
	p.second += b;
	return p;
}

Pair Pair::operator*(const Pair p)
{
	Pair temp(*this);
	temp.first = first * p.first;
	temp.second = second * p.second;
	return temp;
}

istream& operator>>(istream& in, Pair& P)
{
	cout << "First: ";
	in >> P.first;
	cout << "Second: ";
	in >> P.second;
	return in;
}

ostream& operator<<(ostream& out, Pair& P)
{
	return (out << P.first << ':' << P.second);
}