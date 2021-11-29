using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppCore.Bases.Repository
{
    public abstract class RepositoryBase<TModel> : IDisposable where TModel : class, new()
    {
        private readonly DbContext db;

        public RepositoryBase(DbContext dbParameter)
        {
            db = dbParameter;
        }

        public virtual List<TModel> Listele()
        {
            try
            {
                return db.Set<TModel>().ToList();
            }
            catch (Exception exc)
            {

                throw exc;
            }

        }

        public virtual List<TModel> Listele(Expression<Func<TModel, bool>> predicate)
        {
            try
            {
                return db.Set<TModel>().Where(predicate).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public virtual IQueryable<TModel> ListeleQuery()
        {
            try
            {
                DbQuery<TModel> sorgu = db.Set<TModel>();
               
                return sorgu.AsQueryable();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public virtual IQueryable<TModel> ListeleQuery(Expression<Func<TModel, bool>> predicate)
        {
            try
            {
                DbQuery<TModel> sorgu = db.Set<TModel>();

                return sorgu.AsQueryable().Where(predicate);
            }
            catch (Exception e)
            {

                throw e;
            }
        }



        public virtual TModel IdileGetir(int id)
        {
            try
            {
                return db.Set<TModel>().Find(id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public virtual TModel IdileGetir(Expression<Func<TModel, bool>> predicate)
        {
            try
            {
                return db.Set<TModel>().SingleOrDefault(predicate);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

       public virtual void EkleDb(TModel model)
        {
            db.Set<TModel>().Add(model);
        }

        public virtual void GuncelleDb(TModel model)
        {
            db.Entry(model).State = EntityState.Modified;
        }

         
        public virtual void SilDb(int id)
        {
            var model = db.Set<TModel>().Find(id);
            if (model.GetType().GetProperty("IsDeleted") != null)
            {
                TModel _model = model;
                _model.GetType().GetProperty("IsDeleted").SetValue(_model, true);
                GuncelleDb(_model);
            }
            else
            {
                db.Set<TModel>().Remove(model);
            }
        }

        public virtual int Kaydet()
        {
            try
            {
                return db.SaveChanges();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
