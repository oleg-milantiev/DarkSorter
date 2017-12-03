/*
 * Created by SharpDevelop.
 * User: mo
 * Date: 02.12.2017
 * Time: 23:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DarkSorter.Dark
{
	/// <summary>
	/// Description of Base.
	/// </summary>
	public class Base
	{
		protected string filename;
		protected int temperature = -1;
		protected int exposure = -1;
		protected int ISO = -1;
		protected DateTime? date;
		
		public Base()
		{
		}
		
		
		public string getFilename()
		{
			return filename;
		}
		public int getTemperature()
		{
			return temperature;
		}
		public int getExposure()
		{
			return exposure;
		}
		public int getISO()
		{
			return ISO;
		}
		public DateTime? getDate()
		{
			return date;
		}
		
		
		public bool isDark()
		{
			return (
				(temperature != -1) &&
				(ISO != -1) &&
				(exposure != -1) &&
				(date != null)
			);
		}
			
	}
}
