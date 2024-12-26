namespace Shopee.Application.DTOs.Incoming
{
    public class ProductSearchCriteriaDto
    {
        public string? SearchTerm { get; set; }

        public string? SortColumn { get; set; }

        public int? Page { get; set; }

        public int? PageSize { get; set; }

        public bool? OrderByDescending { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

    }
}