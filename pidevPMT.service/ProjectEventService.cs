



using pidevPMT.data.Infrastructure;
using pidevPMT.data.Models;
using ServicePattern;
using System.Collections.Generic;



namespace pidevPMT.service
{
    public class ProjectEventService : Service<eventproject>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
      
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public ProjectEventService() : base(ut)
        {
        }
        public void createProjectEvent(eventproject r)
        {
            ut.getRepository<eventproject>().Add(r);
            ut.Commit();
        }
        public IEnumerable<eventproject> GetAllevent()
        {

            return ut.getRepository<eventproject>().GetAll();

        }
        public void updateProjectEvent(eventproject r)
        {

            ut.getRepository<eventproject>().Update(r);
            ut.Commit();

        }
        public eventproject GetProjectEventById(int id)
        {
            return ut.getRepository<eventproject>().GetById(id);
        }
        public void deleteProjectEvent(eventproject r)
        {
            ut.getRepository<eventproject>().Delete(r);

        }
    }
}
