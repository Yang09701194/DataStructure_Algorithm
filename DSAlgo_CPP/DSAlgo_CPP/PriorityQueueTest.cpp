#include "pch.h"


#include <iostream>
#include <queue>
using std::priority_queue;
using std::cout;

unsigned PriorityQueueTest() {

	int eles[] = {5,7,6,3,8,2};
	priority_queue<int> pq;


	//C++ 真的不是跟 C# 一樣直覺  直接用 1~n個元素去取就 for 1 ~ n
	//像如果直接向底下這樣寫   前後會多出一堆亂數  代表陣列前後有很多隱藏的東西
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

	while (!pq.empty()) {
		cout << '\t' << pq.top();
		pq.pop();
	}
	cout << '\n';

	return 0;
}



