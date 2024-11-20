using Microsoft.EntityFrameworkCore;

namespace WhereToGoTonight.DTOs.Common
{
    public class PaginatedList<T>
    {
        public IReadOnlyCollection<T> Items { get; }
        public int PageNumber { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        public PaginatedList(IReadOnlyCollection<T> items, int count, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0) throw new ArgumentException("PageNumber must be greater than 0.", nameof(pageNumber));
            if (pageSize <= 0) throw new ArgumentException("PageSize must be greater than 0.", nameof(pageSize));

            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Items = items;
        }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0) throw new ArgumentException("PageNumber must be greater than 0.", nameof(pageNumber));
            if (pageSize <= 0) throw new ArgumentException("PageSize must be greater than 0.", nameof(pageSize));

            var count = await source.CountAsync();
            var items = await source
                .Skip((pageNumber - 1) * pageSize) // Corrected for 1-based page numbering
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }

}