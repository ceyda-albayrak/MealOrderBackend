using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private ICategoryDal _categoryDal;
        private IRestaurantInfoDal _infoDal;
        public ProductManager(IProductDal productDal,ICategoryDal categoryDal,IRestaurantInfoDal infoDal)
        {
            _productDal = productDal;
            _categoryDal = categoryDal;
            _infoDal = infoDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public Result Add(Product product)
        {
            var cid = _categoryDal.Get(product.CategoryId);
            var rid = _infoDal.Get(product.RestaurantId);
            if (cid!=null)
            {
                if (rid!=null)
                {
                    _productDal.Add(product);
                    return new SuccessResult(Messages.Added);
                }

                return new ErrorResult("Böyle bir restaurant yok");

            }
            return new ErrorResult("Böyle bir category yok");

        }

        public Result Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.Deleted);
        }

        public DataResult<Product> Get(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(id), Messages.Listed);
        }
      

        public DataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.Listed);
        }

        public DataResult<List<Product>> GetByRestaurantId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.Listed);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public Result Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.Updated);
        }
    }
}
