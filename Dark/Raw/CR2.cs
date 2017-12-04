/*
 * Created by SharpDevelop.
 * User: mo
 * Date: 02.12.2017
 * Time: 23:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
//using System.IO;
using System.Text.RegularExpressions;

using DarkSorter.Helpers;

namespace DarkSorter.Dark.Raw
{
    /// <summary>
    /// Description of CR2.
    /// </summary>
    public class CR2 : Base
    {
        private static readonly Regex rTemp = new Regex(@"Camera\sTemperature\s+:\s*(-?\d+)\sC", RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
        private static readonly Regex rExpo = new Regex(@"Exposure\sTime\s+:\s*(\d+)", RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
        private static readonly Regex rDate = new Regex(@"Date/Time\sOriginal\s+:\s*(\d{4}):(\d{2}):(\d{2})\s(\d{2}):(\d{2}):\d{2}", RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
        private static readonly Regex rISO = new Regex(@"ISO\s+:\s*(\d+)", RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);

        private static readonly string path = Path.GetDirectoryName(typeof(CR2).Assembly.Location);

        public CR2(string filename)
        {
            this.Filename = filename;

            System.Diagnostics.Process proc = new System.Diagnostics.Process()
            {
                StartInfo =
                {
                    FileName = Path.Combine(path, "exiftool.exe"),
                    Arguments = "\""+ filename +"\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };

            proc.Start();

            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();

                if (
                    rTemp.IfMatch(line, m => this.Temperature = Convert.ToInt32(m.Groups[1].ToString())) ||
                    rExpo.IfMatch(line, m => this.Exposure = Convert.ToInt32(m.Groups[1].ToString())) ||
                    rDate.IfMatch(line, m =>
                                {
                                    this.Date = new DateTime(
                                        Convert.ToInt32(m.Groups[1].ToString()),
                                        Convert.ToInt32(m.Groups[2].ToString()),
                                        Convert.ToInt32(m.Groups[3].ToString()),
                                        Convert.ToInt32(m.Groups[4].ToString()),
                                        Convert.ToInt32(m.Groups[5].ToString()),
                                    0);
                                }) ||
                    rISO.IfMatch(line, m => this.ISO = Convert.ToInt32(m.Groups[1].ToString()))
                    )
                {
                    if (IsDark())
                    {
                        proc.StandardOutput.ReadToEnd();

                        return;
                    }
                }
            }
        }

    }
}
