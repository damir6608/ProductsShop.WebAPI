using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsShop.WebAPI.Abstraction.DataContext;
using ProductsShop.WebAPI.Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.WebAPI.Abstraction.Repository
{
    public class BaseRepository<TModel> 
        where TModel : class, IModel
    {
        private BaseDataContext<TModel> _dt;

        public BaseRepository(BaseDataContext<TModel> dt)
        {
            _dt = dt;
        }
        /// <summary>
        /// return item list
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<TModel>>> Get()
        {
            return await _dt.Models.ToListAsync();
        }
        /// <summary>
        /// return model by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult<TModel>> GetById(int id)
        {
            return await _dt.Models.FirstOrDefaultAsync(_ => _.Id == id);
        }
        /// <summary>
        /// add model 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ActionResult<TModel>> Add(TModel model)
        {
            _dt.Add(model); await _dt.SaveChangesAsync();
            return model;
        }
        /// <summary>
        /// update model
        /// return null if not found
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ActionResult<TModel>> Update(TModel model)
        {
            if (model != null) 
                if (_dt.Models.Any(_ => _.Id == model.Id)) 
                    _dt.Update(model); 
                else return null; 
            await _dt.SaveChangesAsync();
            return model;
        }
        /// <summary>
        /// delete model by id
        /// return null if not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult<TModel>> Delete (int id)
        {
            TModel model = _dt.Models.FirstOrDefault(_ => _.Id == id);
            if (model != null) 
                _dt.Remove(model); 
            else 
                return null;
            await _dt.SaveChangesAsync();
            return model;
        }

    }
}
