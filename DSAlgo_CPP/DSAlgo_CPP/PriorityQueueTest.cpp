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
	   
	//C++ 真的不是跟 C# 一樣直覺  直接用 1~n個元素去取就 for 1 ~ n
	//像如果直接像底下這樣寫   前後會多出一堆亂數  代表陣列前後有很多隱藏的東西
	//下次來試試看  iterator
	/*for (size_t i = 0; i < sizeof(eles); i++)
	{
		pq.push(eles[i]);
	}*/

	//這樣就很直覺 直接是對的  
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


//  C++看起來沒有 C#的各種List的基底型別  不能用base class就能接各種類型的集合  好像是不同種都要各自寫
//  https://stackoverflow.com/questions/35563193/what-is-the-base-class-for-stl-containers-list-deque-vector-etc
//  所以這邊無法達成
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
