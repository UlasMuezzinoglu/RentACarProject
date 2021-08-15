﻿using Business.Abstract;
using Business.Constraints;
using Business.ValidationsRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult (Messages.ColorAdded);
        }

        [CacheRemoveAspect("IColorService.Get")]
        public IResult Delete(Color color)
        {
            try
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ColorCantDeleted);
            }
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();
            //return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorsListed);
            if (result.Count < 0)
            {
                return new ErrorDataResult<List<Color>>(Messages.ColorNotFound);
            }
            return new SuccessDataResult<List<Color>>(result, Messages.ColorListed);
        }

        [CacheAspect]
        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(color => color.Id == id),Messages.ColorListed);
        }


        [CacheRemoveAspect("IColorService.Get")]
        public IResult Update(Color color)
        {
            try
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ColorCantUpdated);
            }
        }
    }
}
