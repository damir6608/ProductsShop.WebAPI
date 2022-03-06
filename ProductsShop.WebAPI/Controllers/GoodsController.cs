using Microsoft.AspNetCore.Mvc;
using ProductsShop.Web.API.Goods.Models;
using ProductsShop.WebAPI.Abstraction.Controllers;
using ProductsShop.WebAPI.Abstraction.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : BaseController<product>
    {
        public GoodsController(BaseDataContext<product> options) : base(options)
        {

        }
    }
}
