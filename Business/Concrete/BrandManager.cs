using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constraints;
using Business.ValidationsRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("brand.add,admin ")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            
            
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
            
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Brand brand)
        {
            //ToDo -- transaction dene 
            return null;
        }

        public IResult Delete(Brand brand)
        {
            try
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.BrandDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.BrandCantDeledet);
            }
            
        }

        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandsListed);
        }


        [CacheAspect]
        [PerformanceAspect(7)] // bu metotun çalışması 7 saniyeyi geçerce beni uyar
        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(brand => brand.Id == id),Messages.BrandsListed);
        }

        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            try
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.BrandCantUpdated);
            }

        }
    }
}
