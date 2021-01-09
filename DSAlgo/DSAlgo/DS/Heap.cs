using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgo.DS
{


	/// <summary>
	/// Heap
	///
	/// 以下說明 Min Heap   Max只是大小相反  
	/// 
	/// insert/delete/balance o logn   
	/// insert 單純  新元素加到最右下的leaf  然後直系檢查比parent小就互換上升直到root
	/// https://www.youtube.com/watch?v=VEYSSANa-cw
	/// 
	/// delete  取出 top 把最右下的擺到 top 然後持續跟左右child比  有比任一大  跟最小的互換  繼續往下比
	/// https://www.youtube.com/watch?v=uescHE7Rw9k
	///
	/// 
	/// heapify,，可以把一個無序數列轉換成heap
	///
	/// 
	/// 
	/// </summary>
	class Heap
	{


	}
}
