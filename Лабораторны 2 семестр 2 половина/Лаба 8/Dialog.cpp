#include "Dialog.h"
#include <string>
#include <iostream>

using namespace std;

Dialog::Dialog():Vector()
{
	EndState = 0;
}

Dialog::~Dialog()
{
}

void Dialog::GetEvent(TEvent& event)
{
	string OpInt = " -+szqm";
	string s;
	string param;

	char code;
	cout << ">";
	cin >> s;
	code = s[0];

	if (OpInt.find(code))
	{
		event.what = evMessage;
		switch (code)
		{
		case '+': event.command = cmAdd; break;
		case '-': event.command = cmDel; break;
		case 'm': event.command = cmMake; break;
		case 'z': event.command = cmGet; break;
		case 'q': event.command = cmQuit; break;
		case 's': event.command = cmShow; break;
		}
		if (s.length() > 1)
		{
			param = s.substr(1, s.length() - 1);
			int A = atoi(param.c_str());
			event.a = A;
		}
	}
	else
		event.what = evNothing;	

}

int Dialog::Execute()
{
	TEvent event;
	do {
		EndState = 0;
		cout << "\nВыберите:" << endl;
		cout << "mn) Создать (n элементов)" << endl;
		cout << "+) Добавить" << endl;
		cout << "-) Удалить" << endl;
		cout << "z) Просмотреть названия" << endl;
		cout << "s) Просмотреть полную информацию" << endl;
		cout << "q) Выйти" << endl;
		GetEvent(event);
		HandleEvent(event);
	} while (!Valid());
	return EndState;
}

int Dialog::Valid()
{
	if (EndState == 0)
		return 0;
	else
		return 1;
}

void Dialog::ClearEvent(TEvent& event)
{
	event.what = evNothing;
}

void Dialog::EndExec()
{
	EndState = 1;
}

void Dialog::HandleEvent(TEvent& event)
{
	if (event.what == evMessage)
	{
		switch (event.command)
		{
		case cmAdd:
			Add();
			ClearEvent(event);
			break;
		case cmDel:
			Del();
			ClearEvent(event);
			break;
		case cmMake:
			size = event.a;
			beg = new Object * [size];
			cur = 0;
			ClearEvent(event);
			break;
		case cmQuit:
			EndExec();
			ClearEvent(event);
			break;
		case cmShow:
			Show();
			ClearEvent(event);
			break;
		default:
			Vector::HandleEvent(event);
			break;
		}
	}
}
