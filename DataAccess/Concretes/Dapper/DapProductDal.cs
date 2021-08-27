using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Concretes.EntityFramework;
using Core.DataAccess.Dapper;
using DataAccess.Abstracts;
using DataAccess.Abstracts.DapDal;
using Entities;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concretes.Dapper
{
    public class DapProductDal : DapperRepositoryBase<Product>, IDapProductDal
    {
       
    }
}
