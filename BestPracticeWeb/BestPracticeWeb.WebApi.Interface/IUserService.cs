using System;
using System.Collections.Generic;
using System.Text;

namespace BestPracticeWeb.WebApi.IService
{
   public interface IUserService
    {
        int Sum(int i, int j);

        int Add(User model);
        bool Delete(User model);
        bool Update(User model);
        List<User> Query(Expression<Func<User, bool>> whereExpression);
    }
}
