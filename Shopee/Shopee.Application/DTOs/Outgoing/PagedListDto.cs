namespace Shopee.Application.DTOs.Outgoing
{
    public class PagedListDto<T>
    {
        public PagedListDto(T data, int currentPage, int pageSize, int totalPages)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            Data = data;
        }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public bool HasNextPage => CurrentPage * PageSize < TotalPages;

        public bool HasPreviousPage => CurrentPage > 1;

        public T Data { get; set; }
    }
}

