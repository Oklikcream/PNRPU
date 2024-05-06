#pragma once
#include "Print.h"
class Magazin :
    public Print
{
protected:
	int pages;
public:
	Magazin();
	~Magazin();
	Magazin(string, string, int);
	Magazin(const Magazin& m);
	void Show();
	void Input();
	int Get_pages();
	void Set_pages(int);
	Magazin& operator=(const Magazin&);
};

