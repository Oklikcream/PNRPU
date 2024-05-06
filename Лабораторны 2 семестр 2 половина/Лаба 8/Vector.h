#pragma once
#include "Object.h"
class Vector {
protected:
	Object** beg;
	int size;
	int cur;
public:
	Vector();
	Vector(int);
	~Vector(void);
	void Add();
	void Del();
	void Show();
	void HandleEvent(const TEvent& event);
	int operator()();
};

