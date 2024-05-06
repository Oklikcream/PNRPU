#include "Print.h"

Print::Print()
{
	title = "";
	author = "";
}

Print::~Print()
{
}

Print::Print(string t, string a)
{
	title = t;
	author = a;
}

Print::Print(const Print& p)
{
	title = p.title;
	author = p.author;
}

void Print::Show()
{
	cout << "\n��������: " << title;
	cout << "\n�����: " << author << endl;
}

void Print::Input()
{
	cout << "\n��������: "; cin >> title;
	cout << "�����: ";cin >> author;
}

string Print::Get_title()
{
	return title;
}
string Print::Get_author()
{
	return author;
}

void Print::Set_title(string t)
{
	title = t;
}
void Print::Set_author(string a)
{
	author = a;
}

Print& Print::operator=(const Print& p)
{
	if (this == &p)
		return *this;
	title = p.title;
	author = p.author;
	return *this;
}

void Print::HandleEvent(const TEvent& event)
{
	if (event.what == evMessage)
	{
		switch (event.command)
		{
		case cmGet:
			cout << "\n��������=" << Get_title() << endl;
			break;
		}
	}
}