namespace DarkSorter
{
	public interface IRange<T>
	{
		T Mean { get; set; }

		T Range { get; set; }

		T Minimum { get; }

		T Maximum { get; }
	}
}