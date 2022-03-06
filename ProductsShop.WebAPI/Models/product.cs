using Microsoft.EntityFrameworkCore;
using ProductsShop.WebAPI.Abstraction.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProductsShop.Web.API.Goods.Models
{
    //[Keyless]
    public class product : IModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public string? Type { get; set; }

        public int? Quantity { get; set; }

        public decimal Cost { get; set; }

        public DateTime? DeliveryDate { get; set; }
    }
}
