#pragma once

#include "Object.h"
#include <iostream>
#include <string>

using namespace std;

class Person:
	public Object
{
public:
	Person(void);
public:
	virtual ~Person(void);
	void Show();

	Person(string, int);
	Person(const Person&);

	void setName(string);
	void setAge(int);
	string getName();
	int getAge();

	Person& operator=(const Person&);
	friend istream& operator>> (istream& in, Person& per);
	friend ostream& operator<< (ostream& out, Person& per);

protected:
	string name;
	int age;
};

