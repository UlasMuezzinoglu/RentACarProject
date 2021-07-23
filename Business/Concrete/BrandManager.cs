using Business.Abstract;
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

        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
            Console.WriteLine("Marka Eklendiiiiii",brand.Name);
        }

        public void Delete(Brand brand)
        {
            try
            {
                _brandDal.Delete(brand);
            }
            catch (Exception)
            {

                Console.WriteLine("kanka olmayan birşeyi silemezsin kiiiii o nesne artık yoğğğ... o aslında yoooğğğğğ");
            }
            
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(brand => brand.Id == id);
        }

        public void Update(Brand brand)
        {
            try
            {
                _brandDal.Update(brand);
            }
            catch (Exception)
            {

                Console.WriteLine("kanka olmayan birşeyi Güncelleyemezsin kiiiii o nesne artık yoğğğ... o aslında yoooğğğğğ");

            }

        }
    }
}
