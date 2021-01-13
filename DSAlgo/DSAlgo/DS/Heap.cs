using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgo.DS
{


	/// <summary>
	/// Heap
	/// 堆積總是一棵完全樹。即除了最底層，其他層的節點都被元素填滿，且最底層儘可能地從左到右填入
	/// 
	/// 以下說明 Min Heap   Max只是大小相反  
	/// 
	/// insert/delete/balance o logn   
	/// insert 單純  新元素加到最下右的leaf  然後直系檢查比parent小就互換上升直到root
	/// https://www.youtube.com/watch?v=VEYSSANa-cw
	/// 
	/// delete  取出 top 把最右下的擺到 top 然後持續跟左右child比  有比任一大  跟最小的互換  繼續往下比
	/// https://www.youtube.com/watch?v=uescHE7Rw9k
	/// 
	/// 
	/// heapify  可以把一個無序數列轉換成heap
	///
	/// 做法是  從最下右的點開始  往左    三個三角形為一組進行 heap化  就是大小上升
	/// 最下層做完  上升一層  上升之後的heap化都要往下到最底 
	/// https://www.youtube.com/watch?v=5iBUTMWGtIQ
	/// http://notepad.yehyeh.net/Content/Algorithm/Sort/Heap/Heap.php
	/// https://youtu.be/HqPJF2L5h9U?t=2795
	/// 
	/// 
	///  
	/// Heap build 的 O 分析  實際上很複雜
	/// How can building a heap be O(n) time complexity?
	///
	/// 答案是  可以 build heap 就是 O n
	/// 一聽很奇特  因為 heapify O logn  總共 n 點  感覺 o nlogn
	/// 但 實際上  每個點heapify 是  點到root的高度
	///
	/// 最底層  直接就 n/2 一半的點不用heapify  就省掉很多
	/// 跟倒數第一層 n/4 高度只有1
	/// 高度 h 的點  有  n/2^(h+1) 
	/// sigma 之後  再用等比公式    最後就得到 O n
	///
	/// 更精準地說  2/n 4/n 8/n 三層就 0.875 只需 高度3的heapify
	/// 所以build 是 theta n   tight   這是因為從下面開始
	///
	/// 但是 heap sort  因為 delete 取掉   是持續由最上往下heapfiy  所以 o nlogn 
	///  
	/// 來自以下參考文章
	/// 這邊相對重點簡化  好讀
	/// https://www.geeksforgeeks.org/time-complexity-of-building-a-heap/
	/// 裡面的根據   更精準在 umd   有存在 DSAlgo\DS
	/// http://www.cs.umd.edu/~meesh/351/mount/lectures/lect14-heapsort-analysis-part.pdf
	///
	/// 內容相同較詳細
	/// https://stackoverflow.com/questions/9755721/how-can-building-a-heap-be-on-time-complexity
	///
	/// sift 篩
	///
	/// </summary>
	class Heap
	{


	}
}
