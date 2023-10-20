namespace API.Helpers;
public class Pager<T> where T : class{
    public string? Search { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }
    public IEnumerable<T> Registers { get; set; }

    public Pager(
        IEnumerable<T> registers,
        int total,
        int pageIndex,
        int pageSize,
        string search
    ){
        Registers = registers;
        PageSize = pageSize;
        PageIndex = pageIndex;
        Total = total;
        Search = search;
    }

    public int TotalPages {
        get{
           return (int)Math.Ceiling(Total/ (double)PageSize); 
        }
    }

    public bool HasPreviusPage{
        get{
            return (PageIndex > 1);
        }
    }

    public bool HasNextPage{
        get{
            return (PageIndex < TotalPages);
        }
    }
}