using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgo.DS
{
	class MyStack
	{
		int[] stack = new int[100];
		int n = 100, top = -1;

		public void push(int val)
		{
			if (top >= n - 1)
				throw new Exception("Stack Overflow");
			else
			{
				top++;
				stack[top] = val;
			}
		}

		public void pop()
		{
			if (top <= -1)
				throw new Exception("Stack Underflow");
			else
			{
				top--;
			}
		}

		public void show()
		{
			if (top >= 0)
			{
				for (int i = top; i >= 0; i--)
				{
					Console.WriteLine(stack[i]);
				}
			}
			else
				Console.WriteLine("Stack is empty");
		}

		public static void main()
		{
			MyStack stack = new MyStack();
			Console.WriteLine(
@"1 push
2 pop
3 show
4 exit");
			int i = 0;
			do
			{
				Console.WriteLine("Enter Choice:");
				i = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("choice: " + i);
				switch (i)
				{
					case 1:
						Console.WriteLine("Enter value to be pushed:");
						int v = Convert.ToInt32(Console.ReadLine());
						stack.push(v);
						break;
					case 2:
						stack.pop();
						break;
					case 3:
						stack.show();
						break;
					case 4:
						Console.WriteLine("exit");
						Console.Read(); 
						break;
					default:
						Console.WriteLine("Invalid Choice");
						break;
				}
			} while (i != 4);

		}

	}
}
