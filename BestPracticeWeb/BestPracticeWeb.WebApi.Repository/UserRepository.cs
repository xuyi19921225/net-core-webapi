using BestPracticeWeb.WebApi.IRepository;
using BestPracticeWeb.WebApi.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BestPracticeWeb.WebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private DBContext context;
        private SqlSugarClient db;
        private SimpleClient<User> entityDB;

        internal SqlSugarClient Db
        {
            get { return db; }
            private set { db = value; }
        }
        public DBContext Context
        {
            get { return context; }
            set { context = value; }
        }
        public UserRepository()
        {
            DBContext.Init(BaseDBConfig.ConnectionString);
            context = DBContext.GetDBContext();
            db = context.Db;
            entityDB = context.GetEntityDB<User>(db);
        }
        public int Add(User model)
        {
            //返回的i是long类型,这里你可以根据你的业务需要进行处理
            var i = db.Insertable(model).ExecuteReturnBigIdentity();
            return i.ObjToInt();
        }

        public bool Delete(User model)
        {
            var i = db.Deleteable(model).ExecuteCommand();
            return i > 0;
        }

        public List<User> Query(Expression<Func<User, bool>> whereExpression)
        {
            return entityDB.GetList(whereExpression);

        }

        public int Sum(int i, int j)
        {
            return i + j;
        }

        public bool Update(User model)
        {
            //这种方式会以主键为条件
            var i = db.Updateable(model).ExecuteCommand();
            return i > 0;
        }
    }
}
