namespace OnlineClothes.Domain.Paging;

public class PagingModel<T>
{
	public PagingModel(long totalCount, ICollection<T> items, int pageIndex)
	{
		total = totalCount;
		itemCount = items.Count;

		Items = items;
		PageIndex = pageIndex;
	}

	private long total { get; }
	private int itemCount { get; }

	public ICollection<T>? Items { get; set; }

	public int Pages => (int)(total / itemCount);

	public int PageIndex { get; set; }

	public static PagingModel<T> ToPages(long total, ICollection<T> items, int pageIndex)
	{
		return new PagingModel<T>(total, items, pageIndex);
	}

	public static PagingModel<T> ToPages(long total, IEnumerable<T> items, int pageIndex)
	{
		return new PagingModel<T>(total, items.ToArray(), pageIndex);
	}
}
