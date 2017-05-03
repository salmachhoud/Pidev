using pidevPMT.data.Infrastructure;
using pidevPMT.domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pidevPMT.service
{
    public class CategoryService : Service<categorymeeting>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public CategoryService() :
            base(ut)
        { }

        public void createCategory(categorymeeting p)
        {
            ut.getRepository<categorymeeting>().Add(p);
            ut.Commit();
        }
        public IEnumerable<categorymeeting> GetAllCat()
        {

            return ut.getRepository<categorymeeting>().GetMany();

        }
        public categorymeeting GetCategoryMById(int id)
        {
            return ut.getRepository<categorymeeting>().GetById(id);
        }

        public void updateCategory(categorymeeting m)
        {

            ut.getRepository<categorymeeting>().Update(m);
            ut.Commit();

        }
     /*   public void deleteCategory(categorymeeting var)
        {
            ut.getRepository<categorymeeting>().Delete(var);

        }*/
        //a essayer
        public int MeetingCountByCategory(int CategoryId)
        {
            var cat = ut.getRepository<categorymeeting>().GetById(CategoryId);

            return cat.list.Count();
        }
        //
        MeetingService service = new MeetingService();

        public void delete(int id)
        {
            var category = GetById(id);
            var meetings = ut.getRepository<meeting>().GetMany(x => x.CategoryID == id);
            foreach(var i in meetings)
            {
                service.deleteMeetingCascade(i.Id);

            }
            ut.getRepository<categorymeeting>().Delete(category);
            ut.Commit();
        }

    }
}
