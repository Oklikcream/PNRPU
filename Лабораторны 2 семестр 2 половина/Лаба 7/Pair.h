#pragma once
#include <iostream>
using namespace std;

class Pair
{
	int first;
	double second;
public:
	Pair() { first = 0; second = 0; };
	Pair(int f, double s) { first = f; second = s; };
	Pair(const Pair& P) { first = P.first; second = P.second; };
	~Pair() {};
	void setfirst(int f) { first = f; };
	void setsecond(double s) { second = s; };
	int getfirst() { return first; };
	double getsecond() { return second; };

	Pair& operator=(const Pair&);
	Pair& operator-(const Pair&);
	Pair operator+(const int);
	Pair operator+(const double);
	Pair operator*(const Pair);

	friend ostream& operator<<(ostream&, Pair&);
	friend istream& operator>>(istream&, Pair&);
};

