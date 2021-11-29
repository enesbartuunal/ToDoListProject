//using _1_AppCore.Bases.IService;
//using _1_AppCore.Bases.Repository;
//using _3_DataAccess.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace _3_DataAccess.Services
//{
//    class UserService : IService<User>
//    {
//        private readonly RepositoryBase<User> userRepository;
//        public UserService(RepositoryBase<User> parameter)
//        {
//            userRepository = parameter;
//        }
//        public void Ekle(User model, bool kaydet = true)
//        {
//            try
//            {
//                userRepository.EkleDb(model);
//                if (kaydet)
//                {
//                    Kaydet();
//                }
//            }
//            catch (Exception e)
//            {

//                throw e;
//            }
//        }

//        public IQueryable<User> GenelSorgu(Expression<Func<User, bool>> predicate = null)
//        {
//            try
//            {
//                var sorgu = userRepository.ListeleQuery();
//                if (predicate != null)
//                {
//                    sorgu = sorgu.Where(predicate);
//                }
//                return sorgu;
//            }
//            catch (Exception e)
//            {

//                throw e;
//            }
//        }

//        public void Güncelle(User model, bool kaydet = true)
//        {
//            try
//            {
//                userRepository.GuncelleDb(model);
//                if (kaydet)
//                {
//                    Kaydet();
//                }
//            }
//            catch (Exception e)
//            {

//                throw e;
//            }
//        }

//        public int Kaydet()
//        {
//            try
//            {
//               return userRepository.Kaydet();
//            }
//            catch (Exception e)
//            {

//                throw e;
//            }
//        }

//        public void Sil(int id, bool kaydet = true)
//        {
//            try
//            {
//                userRepository.SilDb(id);
//                if (kaydet)
//                {
//                    Kaydet();
//                }
//            }
//            catch (Exception e)
//            {

//                throw e;
//            }
//        }

//        public User TekilSorgu(int id)
//        {
//            var idnew = Convert.ToString(id);
//            var sorgu = GenelSorgu(a=>a.Id==idnew);
//            var sonuc = sorgu.FirstOrDefault();
//            return sonuc;
//        }
//    }
//}
