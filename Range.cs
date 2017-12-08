namespace DarkSorter
{
	public class IntRange : IRange<int>
	{
		public IntRange()
		{

		}

		public IntRange(int mean, int range)
		{
			this.Mean = mean;
			this.Range = range;
		}

		public int Mean { get; set; }

		public int Range { get; set; }

		public int Minimum
		{
			get
			{
				return Mean - Range / 2;
			}
		}

		public int Maximum
		{
			get
			{
				return Mean + Range / 2;
			}
		}
	}
}
