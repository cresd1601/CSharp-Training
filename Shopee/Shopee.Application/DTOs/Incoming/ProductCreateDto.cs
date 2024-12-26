﻿namespace Shopee.Application.DTOs.Incoming
{
    public class ProductCreateDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int StockQuantity { get; set; }
    }
}