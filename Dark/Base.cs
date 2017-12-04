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
		public string Filename { get; protected set; }

        public int? Temperature { get; protected set; }

        public int? Exposure { get; protected set; }

        public int? ISO { get; protected set; }

		public DateTime? Date { get; protected set; }
		
		public bool IsDark()
		{
            return
                Temperature.HasValue &&
                ISO.HasValue &&
                Exposure.HasValue &&
                Date.HasValue;
		}
			
	}
}
