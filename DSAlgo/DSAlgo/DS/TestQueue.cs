using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DSAlgo
{
	class TestQueue
	{

		//https://www.guru99.com/c-sharp-queue.html
		public static void Test()
		{
			Queue q = new Queue();
			q.Enqueue("test");
			q.Enqueue(DateTime.Now);


			Queue<string> q2 = new Queue<string>();
			q2.Enqueue("test");
			//q2.Enqueue(DateTime.Now);

			q.Clear();

			for (int i = 0; i < 10; i++)
			{
				q.Enqueue(i);
			}

			q.Dequeue();
			q.Dequeue();

			foreach (object obj in q)
			{
				Console.WriteLine(obj);
			}

			Console.WriteLine(q.Contains(3));
			Console.WriteLine(q.Count);

			Console.Read();


		}

	}
}
