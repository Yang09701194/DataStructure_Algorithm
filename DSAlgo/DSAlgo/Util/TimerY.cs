using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgo.Util
{
	public class TimerY
	{
		private DateTime _start = DateTime.Now;
		public TimerY()
		{
			_start = DateTime.Now;
		}

		public static TimerY New()
		{
			return new TimerY();
		}

		public string TimingMs(bool isPrint = false)
		{
			string ms = DateTime.Now.Subtract(_start).TotalMilliseconds.ToString();
			if(isPrint)
				Console.WriteLine(ms);
			return ms;
		}

	}
}
