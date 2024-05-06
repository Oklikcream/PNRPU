#pragma once

#include "Object.h"
#include <iostream>
#include <string>

using namespace std;

class Vector
{	
	Object** beg;
	int size;
	int cur;
public:
	Vector();
	Vector(int);
	Vector(const Vector&);
	~Vector();

	void Add(Object*);
	friend ostream& operator<< (ostream& out, Vector& vec);
};

