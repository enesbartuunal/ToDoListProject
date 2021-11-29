using _1_AppCore.Bases.IService;
using _1_AppCore.Bases.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplicationMAZAKA.Models;

namespace _3_DataAccess.Services
{
    class DutyService : IService<DutyModel>
    {
        private readonly RepositoryBase<DutyModel> dutyRepository;

        public DutyService(RepositoryBase<DutyModel> parameter)
        {
            dutyRepository = parameter;
        }

        public void Ekle(DutyModel model, bool kaydet = true)
        {
            try
            {
                dutyRepository.EkleDb(model);
                if (kaydet)
                {
                    Kaydet();
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public IQueryable<DutyModel> GenelSorgu(Expression<Func<DutyModel, bool>> predicate = null)
        {
            var sorgu = dutyRepository.ListeleQuery();
            if (predicate != null)
            {
                sorgu = sorgu.Where(predicate);
            }
            return sorgu;
        }

        public void Güncelle(DutyModel model, bool kaydet = true)
        {
            dutyRepository.GuncelleDb(model);
            if (kaydet)
            {
                Kaydet();
            }
        }

        public int Kaydet()
        {
            try
            {
                return dutyRepository.Kaydet();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Sil(int id, bool kaydet = true)
        {
            try
            {
                dutyRepository.SilDb(id);
                if (kaydet)
                {
                    Kaydet();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public DutyModel TekilSorgu(int id)
        {
            var sorgu = GenelSorgu(q => q.Id == id);
            var sonuc = sorgu.FirstOrDefault();
            return sonuc;
        }
    }
}
