#include "Person.h"
#include "Student.h"
using namespace std;

int main()
{
	system("chcp 1251 > nul");
	Student student1("���1", 10101, "���", 2);
	Student student2("���2", 10102, " �����", 3);
	Student student3;
	cout << student1;
	cin >> student1;
	cout << student1;
	student3 = student2;
	student3.setName("���3");
	cout << student3;
	student1.checkAs();
	student2.checkAs();
	student3.checkAs();


	return 0;
}