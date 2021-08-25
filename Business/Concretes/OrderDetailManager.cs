using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes
{
    public class OrderDetailManager : IOrderDetailService
    {
        private IOrderDetailDal _orderDetailDal;
        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }
        public DataResult<List<OrderDetail>> GetAll()
        {
            return new SuccessDataResult<List<OrderDetail>>(_orderDetailDal.GetAll(), Messages.Listed);
        }

        public DataResult<OrderDetail> Get(int id)
        {
            return new SuccessDataResult<OrderDetail>(_orderDetailDal.Get(id), Messages.Listed);
        }

        [ValidationAspect(typeof(OrderDetailValidator))]
        public Result Add(OrderDetail orderDetail)
        {
            _orderDetailDal.Add(orderDetail);
            return new SuccessResult(Messages.Added);
        }
        [ValidationAspect(typeof(OrderDetailValidator))]
        public Result Update(OrderDetail orderDetail)
        {
            _orderDetailDal.Update(orderDetail);
            return new SuccessResult(Messages.Updated);
        }

        public Result Delete(OrderDetail orderDetail)
        {
            _orderDetailDal.Delete(orderDetail);
            return new SuccessResult(Messages.Deleted);
        }
    }
}
