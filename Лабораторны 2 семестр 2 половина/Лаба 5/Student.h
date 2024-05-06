#pragma once
#include "Person.h"

class Student:
	public Person
{
	string subject;
	int assessment;
public:
	Student();
	Student(string n, int a, string sub, int as);
	Student(const Student&);
	~Student();

	void Show();

	void setSubject(string);
	void setAssessment(int);
	string getSubject();
	int getAssessment();
	bool checkAs();

	Student& operator=(const Student&);
	friend istream& operator>> (istream& in, Student& per);
	friend ostream& operator<< (ostream& out, Student& per);
};

