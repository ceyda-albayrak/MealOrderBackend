using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Abstracts.DapService;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Abstracts.DapDal;
using Entities;

namespace Business.Concretes
{
    public class DapOrderManager : IDapOrderService
    {
        private IDapOrderDal _orderDal;
        public DapOrderManager(IDapOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        [ValidationAspect(typeof(OrderValidator))]
        public Result Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult(Messages.Added);
        }

        public Result Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(Messages.Deleted);
        }

        public DataResult<Order> Get(int id)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(id), Messages.Listed);
        }

        public DataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(), Messages.Listed);
        }

        [ValidationAspect(typeof(OrderValidator))]
        public Result Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.Updated);
        }
    }
}
