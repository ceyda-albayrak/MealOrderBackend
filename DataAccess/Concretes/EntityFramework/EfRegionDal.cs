using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Concretes.EntityFramework;
using Core.DataAccess.Dapper;
using DataAccess.Abstracts;
using Entities;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfRegionDal : EfEntityRepositoryBase<Region,YemekSiparisContext>, IRegionDal
    {
    }
}
