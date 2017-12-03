/*
 * Created by SharpDevelop.
 * User: mo
 * Date: 02.12.2017
 * Time: 23:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
//using System.IO;
using System.Text.RegularExpressions;


namespace DarkSorter.Dark.Raw
{
	/// <summary>
	/// Description of CR2.
	/// </summary>
	public class CR2 : Dark.Raw.Base
	{	
		
		public CR2(string filename)
		{
			this.filename = filename;
			
			Regex rTemp = new Regex(@"Camera Temperature              : (-{0,1}\d+) C");
			Regex rExpo = new Regex(@"Exposure Time                   : (\d+)");
			Regex rDate = new Regex(@"Date/Time Original              : (\d{4}):(\d\d):(\d\d) (\d\d):(\d\d):\d\d");
			Regex rISO  = new Regex(@"ISO                             : (\d+)");
			
			Match m;

			System.Diagnostics.Process proc = new System.Diagnostics.Process();
			proc.StartInfo.FileName = "exiftool.exe";
			proc.StartInfo.Arguments = "\""+ filename +"\"";
			
			proc.StartInfo.RedirectStandardOutput = true;
			proc.StartInfo.UseShellExecute = false;
			
			proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			proc.StartInfo.CreateNoWindow = true;
							
			proc.Start();
			
			while (!proc.StandardOutput.EndOfStream) {
				string line = proc.StandardOutput.ReadLine();
				
				m = rTemp.Match(line);
				
				if (m.Success) {
					this.temperature = Convert.ToInt32(m.Groups[1].ToString());
				}
				
				m = rExpo.Match(line);

				if (m.Success) {
					this.exposure = Convert.ToInt32(m.Groups[1].ToString());
				}
				
				m = rDate.Match(line);

				if (m.Success) {
					this.date = new DateTime(
						Convert.ToInt32(m.Groups[1].ToString()),
						Convert.ToInt32(m.Groups[2].ToString()),
						Convert.ToInt32(m.Groups[3].ToString()),
						Convert.ToInt32(m.Groups[4].ToString()),
						Convert.ToInt32(m.Groups[5].ToString()),
					0);
				}
				
				m = rISO.Match(line);

				if (m.Success) {
					this.ISO = Convert.ToInt32(m.Groups[1].ToString());
				}
				
				if (
					(temperature != -1) &&
					(exposure != -1) &&
					(ISO != -1) &&
					(date != null)
				) {
					proc.StandardOutput.ReadToEnd();
					
					return;
				}
			}
		}
		
	}
}
