
using pidevPMT.data.Infrastructure;

using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pidevPMT.data.Models;

namespace pro.service
{
    public class UserService : Service<user>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();

        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public UserService() : base(ut)
        {
        }
        public void createuser(user r)
        {
            ut.getRepository<user>().Add(r);
            ut.Commit();
        }
        public IEnumerable<user> GetAlluser()
        {

            return ut.getRepository<user>().GetAll();

        }
        public void updateruser(user r)
        {

            ut.getRepository<user>().Update(r);
            ut.Commit();

        }
        public user GetuserById(int id)
        {
            return ut.getRepository<user>().GetById(id);
        }
        public void deletereservation(user r)
        {
            ut.getRepository<user>().Delete(r);

        }

        public void SaveChange()
        {

            ut.Commit();
        }
    }
}
