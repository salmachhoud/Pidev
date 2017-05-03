

using pidevPMT.data.Infrastructure;
using pidevPMT.data.Models;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace pro.service
{
 public class ReservationService :Service<reservation>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();

        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public ReservationService() : base(ut)
        {
        }

        public void createreservation(reservation r)
        {
            ut.getRepository<reservation>().Add(r);
            ut.Commit();
        }
        public IEnumerable<reservation> GetAllreservation()
        {

            return ut.getRepository<reservation>().GetAll();

        }
        public void updatereservation(reservation r)
        {

            ut.getRepository<reservation>().Update(r);
            ut.Commit();

        }
        public reservation GetreservationById(int id)
        {
            return ut.getRepository<reservation>().GetById(id);
        }
        public void deletereservation(reservation r)
        {
            ut.getRepository<reservation>().Delete(r);

        }

        public void SaveChange()
        {

            ut.Commit();
        }
        /*public void getUser()
        {
            var data = from user p in ut.UserRepository.GetAll().ToList()
                       join reservation t in ut.ReservationRepository.GetAll().ToList()

                       on p.username equals t.username into temp
                       from usertest in temp.DefaultIfEmpty()
                       select new
                       {
                           lastname = p.lastname,
                           firstname = p.firstname
                       };
         
           
        }*/
    }
}

