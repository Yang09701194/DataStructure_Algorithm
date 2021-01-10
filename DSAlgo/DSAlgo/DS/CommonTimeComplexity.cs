using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgo.DS
{
	class CommonTimeComplexity
	{
	}


	//
	// 裡面更詳細   
	// https://en.wikipedia.org/wiki/Search_data_structure
	// +----------------------+----------+------------+----------+--------------+
	// |                      |  Insert  |   Delete   |  Search  | Space Usage  |
	// +----------------------+----------+------------+----------+--------------+
	// | Unsorted array       | O(1)     | O(1)       | O(n)     | O(n)         |
	// | Value-indexed array  | O(1)     | O(1)       | O(1)     | O(n)         |
	// | Sorted array         | O(n)     | O(n)       | O(log n) | O(n)         |
	// | Unsorted linked list | O(1)*    | O(1)*      | O(n)     | O(n)         |
	// | Sorted linked list   | O(n)*    | O(1)*      | O(n)     | O(n)         |
	// | Balanced binary tree | O(log n) | O(log n)   | O(log n) | O(n)         |
	// | Heap                 | O(log n) | O(log n)** | O(n)     | O(n)         |
	// | Hash table           | O(1)     | O(1)       | O(1)     | O(n)         |
	// +----------------------+----------+------------+----------+--------------+
	// 

}
