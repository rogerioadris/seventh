namespace Seventh.Desafio.Domain.Views;

public class PaginationView<T> where T : class
{
    public PaginationView(IList<T> data)
    {
        Records = data.ToList();
    }

    public short Page { get; init; }

    public byte RecordPerPage { get; init; }

    public int TotalPages { get; init; }

    public int TotalRecords { get; init; }

    public int FirstRecord => ((Page - 1) * RecordPerPage) + 1;

    public int LastRecord => Math.Min(Page * RecordPerPage, TotalRecords);

    public bool NextPage => Page > 1;

    public bool PreviousPage => Page < TotalPages;

    public List<T>? Records { get; init; }
}
