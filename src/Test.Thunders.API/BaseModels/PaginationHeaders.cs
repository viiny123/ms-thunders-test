using Microsoft.AspNetCore.Mvc;

namespace Test.Thunders.API.BaseModels;

public class PaginationHeaders
{
    /// <summary>
    /// Page number
    /// </summary>
    [FromHeader(Name = "x-page-number")]
    public int PageNumber { get; set; }

    /// <summary>
    /// Page size
    /// </summary>
    [FromHeader(Name = "x-page-size")]
    public int PageSize { get; set; }

    public PaginationHeaders()
    {
        PageNumber = 1;
        PageSize = 10;
    }

    public PaginationHeaders(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber < 1 ? 1 : pageNumber;
        PageSize = pageSize;
    }
}