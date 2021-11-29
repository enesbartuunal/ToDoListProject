using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppCore.Bases.IService
{
    public interface IService<TModel> where TModel:class,new()
    {
        IQueryable<TModel> GenelSorgu(Expression<Func<TModel, bool>> predicate = null);

        TModel TekilSorgu(int id);

        void Ekle(TModel model, bool kaydet = true);

        void Güncelle(TModel model, bool kaydet = true);

        void Sil(int id, bool kaydet = true);

        int Kaydet();
    }
}
