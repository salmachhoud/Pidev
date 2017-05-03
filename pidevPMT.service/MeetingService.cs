using pidevPMT.data.Infrastructure;
using pidevPMT.data.Models;
using pidevPMT.domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pidevPMT.service
{
    public class MeetingService :Service<meeting>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public MeetingService() :
            base(ut) { }
       
        public void createMeeting(meeting p)
        {
            ut.getRepository<meeting>().Add(p);
            ut.Commit();
        }
        public IEnumerable<meeting> GetAllMeetings()
        {
            return ut.getRepository<meeting>().GetAll();
        }
        public meeting GetMeetingById(int id)
        {
            return ut.getRepository<meeting>().GetById(id);
        }

        public void updateMeeting(meeting m)
        {
            ut.getRepository<meeting>().Update(m);
            ut.Commit();
        }
      
        public void deleteMeeting(meeting var)
        {
            ut.getRepository<meeting>().Delete(var);

        }
        public void deleteMeetingCascade(int var)
        {
            var meeting = GetById(var);
            ut.getRepository<meeting>().Delete(meeting);
        }

        public IEnumerable<meeting> GetMeetingByCategory(string categoryName)
        {
            return ut.getRepository<meeting>().GetMany(x => x.categorymeeting.Name == categoryName);
        }
        public IEnumerable<meeting> GetMeetingByCategory(int id)
        {
            return ut.getRepository<meeting>().GetMany(x => x.categorymeeting.Id == id);
        }
        public void RemoveMeetingFromCategory(int categoryId, int meetingId)
        {
            var meeting = ut.getRepository<meeting>().GetById(meetingId);
            var category = ut.getRepository<categorymeeting>().GetById(categoryId);
            if (meeting != null && category != null)
            {
                foreach (var em in category.list)
                {
                    if (category.list.Contains(meeting))
                        category.list.Remove(meeting);
                }

                ut.getRepository<categorymeeting>().Update(category);
            }
        }
        public int MeetingCountByCategory(int CategoryId)
        {
            var category = ut.getRepository<categorymeeting>().GetById(CategoryId);

            return category.list.Count();
        }

        ///Meeting Search By EndDate and StartDate
        public IEnumerable<meeting> GetMeetingsByDate(DateTime begin, DateTime end)
        {
            return ut.getRepository<meeting>().GetMany(x => x.StartDate >= begin && x.EndDate <= end);
        }
        //
        public IEnumerable<meeting> GetMeetingsNotFinished()
        {
            return
                  ut.getRepository<meeting>()
                  .GetMany(y => DateTime.Compare(DateTime.Now, y.EndDate.Value) < 0);
        }
        //
      /*  public IEnumerable<meeting> GetMeetingsFinished()
        {
            var meetings = ut.getRepository<meeting>()
                    .GetMany(y => DateTime.Compare(DateTime.Now, y.EndDate.Value) > 0);
            return meetings.Where(y =>
            {
                return DateTime.Compare(DateTime.Now, y.EndDate.Value) > 0;
            });
        }*/
        //
        public IEnumerable<meeting> GetFinishedMeetingyByDate()
        {
            var a = ut.getRepository<meeting>().GetAll().Where(x => x.EndDate <= DateTime.Now);
            return a;
        }
        public IEnumerable<meeting> GetNoneFinishedMeetingByDate()
        {
            var a = ut.getRepository<meeting>().GetAll().Where(x => x.EndDate >= DateTime.Now);
            return a;
        }
        //
        
         public List<meeting> GetLastWeekMeetings()
        {
            return ut.getRepository<meeting>().GetMany().Where(e => e.StartDate<= DateTime.Now.AddDays(-7) && e.StartDate >= DateTime.Now.AddDays(-14)).OrderBy(e => e.StartDate).ToList();
        }
       

        public List<meeting> GetNextWeekMeetings()
        {
            return ut.getRepository<meeting>().GetMany().Where(e => e.StartDate >= DateTime.Now.AddDays(7) && e.StartDate <= DateTime.Now.AddDays(14)).OrderBy(e => e.StartDate).ToList();
            
        }
        public List<meeting> GetPrivateMeetings()
        {
            return ut.getRepository<meeting>().GetMany().Where(e => e.Private ==true).ToList();
        }
        public List<meeting> GetPublicMeetings()
        {
            return ut.getRepository<meeting>().GetMany().Where(e => e.Private == false).ToList();
        }
    //***************Affect Methods******************//
        public void AffecterMeetingsToCategory(int idCategory, IEnumerable<int> meetingsIds)
        {
            var category = ut.getRepository<categorymeeting>().GetById(idCategory);
            if (category != null)
            {
                foreach (var meetingId in meetingsIds)
                {
                    var meeting = ut.getRepository<meeting>().GetById(meetingId);
                    if (meeting != null && !category.list.Contains(meeting))
                        category.list.Add(meeting);
                }

                ut.getRepository<categorymeeting>().Update(category);
            }
        }
        //ajout du meeting avec le user
        public void AffectMeetingToUser(meeting met, int employeeId)
        {
            var userr = ut.getRepository<user>().GetById(employeeId);
            if (userr != null)
            {
                ICollection<user> listUser = new List<user>();
                listUser.Add(userr);
                met.UsersM = listUser;
                ut.getRepository<meeting>().Add(met);

            }

            else
            {
                Console.WriteLine("User does not exist ");
            }
        }
        //
        public void AffecterMeetingToUser(int MeetingId, int UserId)
        {
            var userr = ut.getRepository<user>().GetById(UserId);
            var meeting = ut.getRepository<meeting>().GetById(MeetingId);

            if (userr != null && meeting != null)
            {
                foreach (var i in meeting.UsersM)
                {
                    if (!meeting.UsersM.Contains(i))
                        meeting.UsersM.Add(i);

                }

                ut.getRepository<meeting>().Update(meeting);
            }
        }
        //***************End Affect Methods******************//
        //Advanced Method
        public user GetMostBusyUser()
        {
            //recuperetaion de tt la liste des users
            var ListUser = ut.getRepository<user>().GetAll();
            int max = 0;
            user user = null;
            foreach (var i in ListUser)
            {
                var nb = i.meetingUser.Count();
                if (nb > max)
                {
                    user = i;
                    max = nb;
                }
            }
            return user;
          }
        //
        public IEnumerable<user> GetMostThreeBusyUsers()

        {
            IEnumerable<user> users = ut.getRepository<user>().GetAll();
            //ordre decroissant selon selon nb de meeting du user
            var emp1 = users.OrderByDescending(x => x.meetingUser.Count).Take(3);
            return emp1;
        }

       
	   
	   
	   
	   
	   
	   
	   
        
    }
}
