using BestPracticeWeb.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BestPracticeWeb.WebApi.IRepository
{
    public interface IUserRepository
    {
        int Sum(int i, int j);

        int Add(User model);
        bool Delete(User model);
        bool Update(User model);
        List<User> Query(Expression<Func<User, bool>> whereExpression);
    }
}
