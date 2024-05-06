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
	cout << "\nНазвание: " << title;
	cout << "\nАвтор: " << author;
	cout << "\nСтраницы: " << pages << endl;
}

void Magazin::Input()
{
	cout << "\nНазвание: "; cin >> title;
	cout << "Автор: ";cin >> author;
	cout << "Страницы: ";cin >> pages;
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