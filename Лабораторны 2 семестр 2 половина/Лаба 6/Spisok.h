#include <iostream>
using namespace std;

class Iterator
{
	friend class Spisok;
public:
	Iterator() { elem = 0; }
	Iterator(const Iterator& it) { elem = it.elem; }

	
	bool operator==(const Iterator& it) { return elem == it.elem; }
	bool operator!=(const Iterator& it) { return elem != it.elem; };
	
	void operator++() { ++elem; };

	void operator--() { --elem; }
	
	int& operator *() const { return*elem; }
private:
	int* elem;
};

class Spisok
{
public:
	
	Spisok(int s, int k = 0);
	
	Spisok(const Spisok& a);
	
	~Spisok();
	
	Spisok& operator=(const Spisok& a);
	
	int& operator[](int index);
	
	Spisok operator*(Spisok&);
	
	int operator()();
	
	friend ostream& operator<<(ostream& out, const Spisok& a);
	friend istream& operator>>(istream& in, Spisok& a);
	Iterator first() { return beg; }
	Iterator last() { return end; }
	int size;
	int* data;
	Iterator beg;
	Iterator end;
};

