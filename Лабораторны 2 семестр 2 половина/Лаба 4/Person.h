#pragma once
#include <iostream>
#include <string>
using namespace std;

class Person
{

public:
	Person();
	Person(string n, int a);
	Person(const Person& per);
	~Person();

	void setName(string n);
	void setAge(int a);
	string getName();
	int getAge();

	Person& operator=(const Person&);
	friend istream& operator>> (istream& in, Person& per);
	friend ostream& operator<< (ostream& out, Person& per);

protected:
	string name;
	int age;
};
