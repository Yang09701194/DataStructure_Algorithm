using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft;
using Newtonsoft.Json;

namespace DSAlgo
{
	class Program
	{
		static void Main(string[] args)
		{
			Queue q = new Queue();
			q.Enqueue("test");
			q.Enqueue(DateTime.Now);


			Queue<string> q2 = new Queue<string>();
			q2.Enqueue("test");
			//q2.Enqueue(DateTime.Now);



			Console.Read(); 

		}
	}
}
