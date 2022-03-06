using Microsoft.AspNetCore.Mvc;
using ProductsShop.WebAPI.Abstraction.DataContext;
using ProductsShop.WebAPI.Abstraction.Interfaces;
using ProductsShop.WebAPI.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.WebAPI.Abstraction.Controllers
{
    [ApiController]
    public class BaseController<TModel> : ControllerBase 
        where TModel : class, IModel
    {
        private BaseRepository<TModel> _repository;

        public BaseController(BaseDataContext<TModel> dataContext)
        {
            _repository = new BaseRepository<TModel>(dataContext);
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<TModel>>> Get()
        {
            return await _repository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TModel>> GetById(int id)
        {
            var model = await _repository.GetById(id);
            if (model != null) 
                return new ObjectResult(model); 
            return NotFound();
        }

        [HttpPost("/create")]
        public async Task<ActionResult<TModel>> AddModel(TModel model)
        {
            if(model != null)
            {
                await _repository.Add(model);
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TModel>> Put(TModel model)
        {
            if (model != null) 
            { 
                var m = await _repository.Update(model);
                if (m != null) 
                    return Ok(m); 
                return NotFound();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TModel>> Delete(int id)
        {
            var m = await _repository.Delete(id);
            if (m != null)
                return Ok(m);
            return NotFound();
        }
    }
}
