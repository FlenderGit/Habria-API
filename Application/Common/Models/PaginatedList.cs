using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Models;

public class PaginatedList<T>
{
    public IReadOnlyCollection<T> Items { get; }
    public int PageNumber { get; }
    public int TotalPages { get; }
    public int Total { get; }

    public PaginatedList(IReadOnlyCollection<T> items, int totalItem, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling(totalItem / (double)pageSize);
        Total = totalItem;
        Items = items;
    }

    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int page, int size)
    {
        int total = await source.CountAsync();
        List<T> items = await source.Skip((page - 1) * size).Take(size).ToListAsync();
        return new (items, total, page, size);
    }
}
