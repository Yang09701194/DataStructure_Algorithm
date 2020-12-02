using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgo
{
	class TestStack
	{

		//	https://www.tutorialsteacher.com/csharp/csharp-stack

		// http://pages.cs.wisc.edu/~siff/CS367/Notes/stacks.html
		// For all the standard stack operations (push, pop, isEmpty, size), the worst-case run-time complexity can be O(1). 
		// 
		public static void Test()
		{ 
			Stack<int> stack = new Stack<int>();

			for (int i = 0; i < 10; i++)
			{
				stack.Push(i);
			}

			foreach (var s in stack)
			{
				Console.WriteLine(s);//會跟加入的順序反著印   類似pop的感覺
			}

			Console.WriteLine();

			Console.WriteLine(stack.Peek());
			Console.WriteLine(stack.Peek());

			int[] arr = new[] { 1, 2, 3, 4};
			Stack<int> stack2 = new Stack<int>(arr);

			Console.WriteLine(stack.Contains(3));

			while (stack.Count > 0)
			{
				Console.WriteLine(stack.Pop());
				Console.WriteLine(stack.Count);
			}
			
		}

	}
}
