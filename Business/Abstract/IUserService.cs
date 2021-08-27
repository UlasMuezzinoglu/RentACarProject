using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {

        List<OperationClaim> GetClaims(User user);
        void Add(User user);

        IResult Update(User user, string password);
        IDataResult<User> GetByUserId(int userId);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        User GetByMail(string email);

        IDataResult<User> GetByEmail(string email);



    }
}
