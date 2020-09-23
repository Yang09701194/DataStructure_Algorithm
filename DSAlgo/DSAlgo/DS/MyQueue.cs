using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DSAlgo.DS
{

	//http://alrightchiu.github.io/SecondRound/queue-yi-arrayshi-zuo-queue.html
	//   arr index 0 >> 先進來的 ----  後進來的
	//                  pop >          push > 
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
			for (int i = front + 1; i <= back; i++)
			{
				j++;
				newQueue[j] = queue[i];
			}

			front = -1;
			back = j;
			queue = newQueue;
		}

		public void PrintSequentialQueue()
		{
			Console.WriteLine($"front:{GetFront()} back:{GetBack()} capacity:{GetCapacity()} ");
			Console.WriteLine("---");
			for (int j = front + 1; j <= back; j++)
			{
				Console.WriteLine(queue[j]);
			}
		}

		public void Push(int i)
		{
			if (Full)
				DoubleCapacity();
			queue[++back] = i;
		}

		public void Pop()
		{
			if (Empty)
			{
				Console.WriteLine("Queue is Empty.\r\n");
				return;
			}

			front++;
		}

		public int GetBack()
		{
			if (Empty)
			{
				Console.WriteLine("Queue is empty.\r\n");
				return -1;
			}
			return queue[back];
		}

		public int GetFront()
		{
			if (Empty)
			{
				Console.WriteLine("Queue is empty.\r\n");
				return -1;
			}

			return queue[front + 1]; //這邊 +1 乍看有點奇特  但前面給 -1 -1 確實沒錯
		}


		public bool Empty
		{
			get { return front == back; } 
		}

		public bool Full
		{
			get { return back + 1 == capacity; }
		}

		public int GetSize()
		{
			return back - front;
		}

		public int GetCapacity()
		{
			return capacity;
		}

		public static void main()
		{
			MySequentialQueue q = new MySequentialQueue();
			if(q.Empty)
				Console.WriteLine("q is empty");
			q.Push(24);
			while (true)
			{
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
							Console.WriteLine("enter value");
							i = Convert.ToInt32(Console.ReadLine());
							q.Push(i);
							break;
						case 2:
							q.Pop();
							break;
						case 3:
							q.PrintSequentialQueue();
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
	

	//http://alrightchiu.github.io/SecondRound/queue-yi-arrayshi-zuo-queue.html
	class MyCircularQueue
	{
		int capacity, front, back;
		int[] queue;

		public MyCircularQueue()
		{
			capacity = 5;
			front = back = 0;
			queue = new int[capacity];
		}

		public void DoubleCapacity()
		{
			capacity *= 2;
			int[] newQueue = new int[capacity * 2];
			int j = front, size = Size;
			for (int i = 1; i <= size; i++)
			{
				newQueue[i] = queue[++j % capacity];//	因為 circular    //j 要先加一, 因為 front 沒有東西
			}

			back = Size;//	要在更改 capacity 之前抓住 back
			front = 0;//	改變 front 要在 getSize() 之後

			queue = newQueue;
		}

		public void Push(int value)
		{
			if (Full)
				DoubleCapacity();
			back = (back + 1) % capacity;

			queue[back] = value;
		}

		public void Pop()
		{
			if (Empty)
			{
				Console.WriteLine("Queue is Empty.\r\n");
				return;
			}

			front++;
		}

		public void PrintSequentialQueue()
		{
			Console.WriteLine($"front:{GetFront()} back:{GetBack()} capacity:{GetCapacity()} ");
			Console.WriteLine("---");
			for (int j = front + 1; j <= back; j++)
			{
				Console.WriteLine(queue[j]);
			}
		}



		public int GetFront()
		{
			if (Empty)
			{
				Console.WriteLine("Queue is empty.\r\n");
				return -1;
			}

			return queue[(front + 1) % capacity]; //這邊 +1 乍看有點奇特  但前面給 -1 -1 確實沒錯
		}

		public int GetBack()
		{
			if (Empty)
			{
				Console.WriteLine("Queue is empty.\r\n");
				return -1;
			}
			return queue[back];
		}


		public bool Empty
		{
			get { return front == back; }
		}

		public bool Full
		{
			get { return front == (back + 1) % capacity; }
		}

		public int Size
		{
			get
			{
				if (front < back)
					return back - front;
				return capacity - (front - back);
			}
		}

		public int GetCapacity()
		{
			return capacity;
		}

		public static void main()
		{
			MyCircularQueue q = new MyCircularQueue();
			if(q.Empty)
				Console.WriteLine("q is empty.");
			q.Push(25);
			while (true)
			{
				Console.WriteLine(
@"1 push
2 pop 
3 show 
4 exit");
				int i;
				do
				{
					Console.WriteLine("Enter your choice.");
					i = Convert.ToInt32(Console.ReadLine());

					switch (i)
					{
						case 1:
							Console.WriteLine("enter value");
							i = Convert.ToInt32(Console.ReadLine());
							q.Push(i);
							break;
						case 2:
							q.Pop();
							break;
						case 3:
							q.PrintSequentialQueue();
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
