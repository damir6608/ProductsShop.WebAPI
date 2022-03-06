using ProductsShop.WebAPI.Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Web.API.Goods.Models
{
    public class Goods : IModel
    {
        public int Id { get; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public string? Type { get; set; }

        public int? Quantity { get; set; }

        public decimal Cost { get; set; }

        public DateTime? DeliveryDate { get; set; }
    }
}
