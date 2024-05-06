#pragma once
#include <iostream>
#include <string>
#include "Student.h"
using namespace std;

Student::Student() : Person()
{
	subject = "";
	assessment = 0;
}

Student::Student(string n, int a, string sub, int as) : Person(n, a)
{
	subject = sub;
	assessment = as;
}

Student::Student(const Student& per)
{
	name = per.name;
	age = per.age;
	subject = per.subject;
	assessment = per.assessment;
}

Student::~Student()
{
}

void Student::setSubject(string n)
{
	subject = n;
}

void Student::setAssessment(int a)
{
	assessment = a;
}

string Student::getSubject()
{
	return subject;
}

int Student::getAssessment()
{
	return assessment;
}

bool Student::checkAs()
{
	if (assessment <= 2)
		cout << "\n� " << name << " �������������������� ������" << endl;
	else
		cout << "\n� " << name << " ������������������ ������" << endl;
	return assessment >= 2;
}

Student& Student::operator=(const Student& per)
{
	if (this == &per)
		return *this;
	name = per.name;
	age = per.age;
	subject = per.subject;
	assessment = per.assessment;
	return *this;
}

istream& operator>>(istream& in, Student& per)
{
	cout << "\n���: "; getline(in, per.name);
	cout << "�������: "; in >> per.age;
	cout << "�������: "; in >> per.subject;
	cout << "������: "; in >> per.assessment;
	return in;
}

ostream& operator<<(ostream& out, Student& per)
{
	out << "\n���: " << per.name << "\n";
	out << "�������: " << per.age << "\n";
	out << "�������: " << per.subject << "\n";
	out << "������: " << per.assessment << "\n";
	return out;
}