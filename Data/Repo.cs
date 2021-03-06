using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personalAPI.Models;

namespace personalAPI.Data
{
    public abstract class Repo<TModel> : IRepo<TModel>
        where TModel : class , IModel
    {
        private readonly Context _context;

        public Repo(Context context)
        {
            _context = context;
        }
        
        public void Add(TModel entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
             _context.Set<TModel>().Add(entity);
        }

        public void Delete(TModel entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Set<TModel>().Remove(entity);
        }

        public TModel Get(int id)
        {
            return _context.Set<TModel>().FirstOrDefault( p => p.Id == id);
        }

        public virtual IEnumerable<TModel> GetAll()
        {
            return _context.Set<TModel>().ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(TModel entity)
        {
            //nothing
        }
    }
}