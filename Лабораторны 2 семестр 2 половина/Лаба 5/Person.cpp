#include "Person.h"

Person::Person(void)
{
	name = "";
	age = 0;
}

Person::~Person(void)
{
}

Person::Person(string n, int a)
{
	name = n;
	age = a;
}

Person::Person(const Person& per)
{
	name = per.name;
	age = per.age;
}

void Person::setName(string n)
{
	name = n;
}

void Person::setAge(int a)
{
	age = a;
}

string Person::getName()
{
	return name;
}

int Person::getAge()
{
	return age;
}

Person& Person::operator=(const Person& per)
{
	if (this == &per)
		return *this;
	name = per.name;
	age = per.age;
	return *this;
}

istream& operator>>(istream& in, Person& per)
{
	cout << "\n���: "; in >> per.name;
	cout << "�������: "; in >> per.age;
	return in;
}

ostream& operator<<(ostream& out, Person& per)
{
	out << "\n���: " << per.name << "\n";
	out << "�������: " << per.age;
	return out;
}

void Person::Show()
{
	cout << "\n���: " << name;
	cout << "\n�������: " << age;
	cout << "\n";
}
