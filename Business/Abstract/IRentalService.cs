﻿using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();

        IDataResult<Rental> GetByCustomerId(int id);

        IResult Add(Rental rental);

        IResult AddMultiple(Rental[] rentals);

        IResult Delete(Rental rental);
        IResult Update(Rental rental);

        IDataResult<List<RentalDetailDto>> GetRentalDetails();

    }
}
