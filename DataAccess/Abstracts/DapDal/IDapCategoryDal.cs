using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Dapper;
using Entities;

namespace DataAccess.Abstracts.DapDal
{
    public interface IDapCategoryDal : IDapperRepository<Category>
    {
    }
}
