using Business.Abstract;
using Business.Constraints;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(
                IsOverflowCarImageCount(carImage.CarId));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            var imageResult = _fileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

       

        public IResult Delete(CarImage carImage)
        {
            try
            {
                var imageDelete = _carImageDal.Get(c => c.Id == carImage.Id);
                if (imageDelete == null)
                {
                    return new ErrorResult(Messages.CarImageNotFound);
                }
                _carImageDal.Delete(carImage);

                return new SuccessResult(Messages.CarImageDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult("Resim Silinemedi");
            }
            
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(ShowDefaultImage(carId));
            if (result == null)
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));

            }
            return new ErrorDataResult<List<CarImage>>("Hata");
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id), Messages.CarImageListed);
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var imageDelete = _carImageDal.Get(c => c.Id == carImage.Id);
            if (imageDelete == null)
            {
                return new ErrorResult("Bulunamadı");
            }
            var updatedFile = _fileHelper.Update(file, imageDelete.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IResult IsOverflowCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(im => im.CarId == carId);

            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.OverflowCarImageMessage);
            }

            return new SuccessResult();
            
        }
        private IResult ShowDefaultImage(int carId)
        {


            try
            {
                string path = @"\images\default.png";
                var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
                if (result)
                {
                    List<CarImage> carImages = new List<CarImage>();
                    carImages.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = path });
                    return new SuccessDataResult<List<CarImage>>(carImages);
                }
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<CarImage>>("Hata");
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId).ToList());
        }
    }
}
