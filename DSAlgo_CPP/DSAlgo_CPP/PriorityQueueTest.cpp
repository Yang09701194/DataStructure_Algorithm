#include "pch.h"


#include <iostream>
#include <queue>
using std::priority_queue;
using namespace std;



//Priority queues are a type of container adaptors, specifically designed such that its first element is always the greatest of the elements it contains, according to some strict weak ordering criterion.

//This context is similar to a HEAP
//, where elements can be inserted at any moment, and only the max heap element can be retrieved(the one at the top in the priority queue).

unsigned PriorityQueueTest() {

	int eles[] = {5,7,6,3,8,2};
	priority_queue<int> pq;

	/*
	general pq
	8 7 6 5 3 2
	pqGreater
	2 3 5 6 7 8
	pqLess
	8 7 6 5 3 2
	*/
	   
	//C++ �u�����O�� C# �@�˪�ı  ������ 1~n�Ӥ����h���N for 1 ~ n
	//���p�G���������U�o�˼g   �e��|�h�X�@��ü�  �N��}�C�e�ᦳ�ܦh���ê��F��
	//�U���Ӹոլ�  iterator
	/*for (size_t i = 0; i < sizeof(eles); i++)
	{
		pq.push(eles[i]);
	}*/

	//�o�˴N�ܪ�ı �����O�諸  
	for (auto e: eles)
	{
		pq.push(e);
	}

	cout << "general pq pop" << endl; 
	while (!pq.empty()) {
		cout << ' ' << pq.top();
		pq.pop();
	}
	cout << '\n';


	priority_queue<int, vector<int>, greater<int>> pqGreater;
	for (auto e : eles)
	{
		pqGreater.push(e);
	}
	cout << "pqGreater pop" << endl;
	while (!pqGreater.empty()) {
		cout << ' ' << pqGreater.top();
		pqGreater.pop();
	}
	cout << '\n';


	priority_queue<int, vector<int>, less<int>> pqLess;
	for (auto e : eles)
	{
		pqLess.push(e);
	}
	cout << "pqLess pop" << endl;
	while (!pqLess.empty()) {
		cout << ' ' << pqLess.top();
		pqLess.pop();
	}
	cout << '\n';


	return 0;
}


//  C++�ݰ_�ӨS�� C#���U��List���򩳫��O  �����base class�N�౵�U�����������X  �n���O���P�س��n�U�ۼg
//  https://stackoverflow.com/questions/35563193/what-is-the-base-class-for-stl-containers-list-deque-vector-etc
//  �ҥH�o��L�k�F��
//void print(priority_queue<int> pq) {
//	//8 7 6 5 3 2
//	while (!pq.empty()) {
//		cout << ' ' << pq.top();
//		pq.pop();
//	}
//	cout << '\n';
//
//}
//
