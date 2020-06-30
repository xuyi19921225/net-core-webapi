using BestPracticeWeb.WebApi.IRepository;
using BestPracticeWeb.WebApi.IService;
using BestPracticeWeb.WebApi.Model;
using BestPracticeWeb.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BestPracticeWeb.WebApi.Service
{
    public class UserService:IUserService
    {
        public IUserRepository dal = new UserRepository();
        public int Sum(int i, int j)
        {
            return dal.Sum(i, j);

        }


        public int Add(User model)
        {
            return dal.Add(model);
        }

        public bool Delete(User model)
        {
            return dal.Delete(model);
        }

        public List<User> Query(Expression<Func<User, bool>> whereExpression)
        {
            return dal.Query(whereExpression);

        }

        public bool Update(User model)
        {
            return dal.Update(model);
        }
    }
}
