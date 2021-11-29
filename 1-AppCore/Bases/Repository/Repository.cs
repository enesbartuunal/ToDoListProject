using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppCore.Bases.Repository
{
    public class Repository<TModel> : RepositoryBase<TModel> where TModel : class, new()
    {
        public Repository(DbContext dbParameter) : base(dbParameter)
        {

        }
    }
}
