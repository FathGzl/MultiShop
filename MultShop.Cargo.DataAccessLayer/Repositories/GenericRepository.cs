﻿using MultShop.Cargo.DataAccessLayer.Abstract;
using MultShop.Cargo.DataAccessLayer.Concrete;

namespace MultShop.Cargo.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _context;
        public GenericRepository(CargoContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var values = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(values);
            _context.SaveChanges();
        }
        public List<T> GetAll()
        {
            var values = _context.Set<T>().ToList();
            return values;
        }
        public T GetById(int id)
        {
            var value = _context.Set<T>().Find(id);
            return value;
        }
        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
