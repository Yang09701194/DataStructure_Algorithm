#include "pch.h"


#include <iostream>
#include <queue>
using std::priority_queue;
using std::cout;

unsigned PriorityQueueTest() {

	int eles[] = {5,7,6,3,8,2};
	priority_queue<int> pq;


	//C++ �u�����O�� C# �@�˪�ı  ������ 1~n�Ӥ����h���N for 1 ~ n
	//���p�G�����V���U�o�˼g   �e��|�h�X�@��ü�  �N��}�C�e�ᦳ�ܦh���ê��F��
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

	while (!pq.empty()) {
		cout << '\t' << pq.top();
		pq.pop();
	}
	cout << '\n';

	return 0;
}



