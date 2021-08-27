using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Concretes.EntityFramework;
using Core.DataAccess.Dapper;
using DataAccess.Abstracts;
using DataAccess.Abstracts.DapDal;
using Entities;

namespace DataAccess.Concretes.Dapper
{
    public class DapRegionDal : DapperRepositoryBase<Region>, IDapRegionDal
    {
    }
}
