using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgo.DS
{


	//http://alrightchiu.github.io/SecondRound/queue-yi-arrayshi-zuo-queue.html
	class MySequentialQueue
	{
		int capacity, front, back;
		int[] queue;


		public MySequentialQueue()
		{
			capacity = 5;
			front = -1;
			back = -1;
			queue = new int[capacity];
		}


		public void DoubleCapacity()
		{
			capacity *= 2;
			int[] newQueue = new int[capacity];
			int j = - 1;
			for (int i = front + 1; i <= back; i++, j++)
			{
				newQueue[j] = queue[i];
			}

			front = -1; back = j;
		}


		public void printCircularQueue()
		{
			Console.WriteLine($"front:{GetFront()} back:{GetBack()} capacity:{GetCapacity()} ");



		}

		public void Push(int i)
		{
			if (IsFull())
				DoubleCapacity();
			queue[++back] = i;
		}

		public void pop()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Queue is Empty.\r\n");
				return;
			}

			front++;
		}


		public int GetBack()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Queue is empty.\r\n");
				return -1;
			}
			return queue[back];
		}

		public int GetFront()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Queue is empty.\r\n");
				return -1;
			}

			return queue[front + 1];
		}


		public bool IsEmpty()
		{
			return front == back;
		}
		public bool IsFull()
		{
			return back + 1 == back;
		}


		public int getSize()
		{
			return back - front;
		}

		public int GetCapacity()
		{
			return capacity;

		}
		
	}
	

	//http://alrightchiu.github.io/SecondRound/queue-yi-arrayshi-zuo-queue.html
	class MyCircularQueue
	{

	}

	//看一下 .NET 本身怎麼實作的
	/// <summary>
	/// http://www.cplusplus.com/reference/queue/queue/
	/// https://www.tutorialspoint.com/cplusplus-program-to-implement-queue-using-array
	/// </summary>
	class MyQueue
	{
		// Q 的方法命名   C#用 queue dequeue
		// C++  push pop

		int[] queue = new int[100];
		int n = 100, front = -1, rear/* 後部 */ = -1;

		public void Push()
		{
			if (rear == n - 1)
				Console.WriteLine("Queue Overflow");
			else
			{
				if (front == -1)
					front = 0;
				Console.WriteLine("Push the element in Queue:");
				int i = Convert.ToInt32(Console.ReadLine());
				rear++;
				queue[rear] = i;   //FIFO 所以放尾端
			}
		}

		public void Pop()
		{
			if (front == -1 || front > rear)
				Console.WriteLine("Queue Underflow");
			else
			{
				Console.WriteLine("element deleted  is " + queue[front]) ;
				front++;   //有個問題是  他沒有用 % 循環   查了一下才知道有 Sequential Circular
			}
		}

		public void show()
		{
			if (front == -1)
				Console.WriteLine("Queue is Empty");
			else
			{
				Console.WriteLine("Queue elements:");
				for (int i = 0; i <= rear; i++)
				{	
					Console.WriteLine(queue[i]);
				}
			}
		}

		public static void main()
		{
			MyQueue q = new MyQueue();
			Console.WriteLine(
@"1 push
2 pop
3 show
4 exit");
			int i;
			do
			{
				Console.WriteLine("Enter your choice");
				i = Convert.ToInt32(Console.ReadLine());
				switch (i)
				{
					case 1:
						q.Push();
						break;
					case 2:
						q.Pop();
						break;
					case 3:
						q.show();
						break;
					case 4:
						Console.WriteLine("exit");
						break;
					default:
						Console.WriteLine("invalid choice");
						break;
				}
			} while (i != 4);

		}

	}

}
