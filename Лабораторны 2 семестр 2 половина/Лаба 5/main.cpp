#include "Object.h"
#include "Person.h"
#include <iostream>
#include <string>
#include "Student.h"
#include "Vector.h"
using namespace std;

void main()
{
	system("chcp 1251 > nul");

	Vector vec(5);

	Person per1;
	cin >> per1;
	cout << per1 << endl;
	Object* p = &per1;
	vec.Add(p);
	p->Show();

	Student stu;
	cin >> stu;
	cout << stu << endl;
	p = &stu;
	vec.Add(p);

	cout << vec << endl;
}