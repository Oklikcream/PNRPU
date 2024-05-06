#pragma once
#include <string>
#include <iostream>
#include "object.h"

using namespace std;

class Print:
	public Object
{
protected:
	string title;
	string author;
public:
	Print();
	virtual ~Print();
	Print(string t, string a);
	Print(const Print& p);
	
	void Show();
	void Input();

	string Get_title();
	string Get_author();
	void Set_title(string);
	void Set_author(string);
	Print& operator=(const Print&);

	void HandleEvent(const TEvent& event);
};

