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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public  CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public Result Add(Category category)
        {
           _categoryDal.Add(category);
           return new SuccessResult(Messages.Added);
        }

        public Result Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.Deleted);
        }

        public DataResult<Category> Get(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(id),Messages.Listed);
        }

        
        public DataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.Listed);
        }
        [ValidationAspect(typeof(CategoryValidator))]
        public Result Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.Updated);
        }
    }
}
