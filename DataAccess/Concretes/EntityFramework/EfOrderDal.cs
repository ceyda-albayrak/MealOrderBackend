﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Concretes.EntityFramework;
using DataAccess.Abstracts;
using Entities;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, YemekSiparisContext>, IOrderDal
    {
    }
}
