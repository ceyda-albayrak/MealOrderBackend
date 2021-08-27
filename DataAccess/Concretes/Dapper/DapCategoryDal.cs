using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Dapper;
using DataAccess.Abstracts;
using DataAccess.Abstracts.DapDal;
using Entities;

namespace DataAccess.Concretes.Dapper
{
    public class DapCategoryDal: DapperRepositoryBase<Category>, IDapCategoryDal
    {
    }
}
