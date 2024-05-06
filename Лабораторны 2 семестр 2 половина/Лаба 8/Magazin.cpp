#include "Magazin.h"
Magazin::Magazin():Print()
{
	pages = 0;
}

Magazin::~Magazin()
{
}

Magazin::Magazin(string t, string a, int p) :Print(t, a)
{
	pages = p;
}

Magazin::Magazin(const Magazin& m)
{
	title = m.title;
	author = m.author;
	pages = m.pages;
}

void Magazin::Show()
{
	cout << "\n��������: " << title;
	cout << "\n�����: " << author;
	cout << "\n��������: " << pages << endl;
}

void Magazin::Input()
{
	cout << "\n��������: "; cin >> title;
	cout << "�����: ";cin >> author;
	cout << "��������: ";cin >> pages;
}

void Magazin::Set_pages(int p)
{
	pages = p;
}

int Magazin::Get_pages()
{
	return pages;
}

Magazin& Magazin::operator=(const Magazin& m)
{
	if (this == &m)
		return *this;
	title = m.title;
	author = m.author;
	pages = m.pages;
	return *this;
}