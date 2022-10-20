using GreenHouseFull.Core.Context;
using GreenHouseFull.Core.Entities;
using GreenHouseFull.Core.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.DAL
{
    internal class ProDAL<TEntity> : EFRepoBase<MyDbContext, TEntity> where TEntity : MyEntityBase
    {
        public ProDAL()
        {
        }

        public ProDAL(MyDbContext context) : base(context)
        {
        }
    }
}
