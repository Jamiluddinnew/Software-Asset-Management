using SoftwareAm2.Repos.Interface;
using SoftwareAM2.data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SoftwareAm2.Repos
{
    public class UserDataRepository : IRepository<User>
    {
        private readonly TestDB2Context context;

        public UserDataRepository(TestDB2Context _context)
        {
            context = _context;
        }
        public void Add(User entity)
        {
            context.User.Add(entity);
            context.SaveChanges();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return context.User;
        }

        public User GetbyId(int Id)
        {
            User user= context.User.Find(Id);
            return user;
            
        }

        public void Update(User entityraw, User entity)
        {
            //entityraw.UserName = entity.UserName;
            //entityraw.UserContact = entity.UserContact;
            entityraw= context.User.Include(a => a.License).Single(b => b.Id == entityraw.Id);
            entityraw.UserName = entity.UserName;
            entityraw.UserContact = entityraw.UserContact;
            var deletedLicense = entityraw.License.Except(entity.License).ToList();
            var addedLicense = entity.License.Except(entityraw.License).ToList();

            deletedLicense.ForEach(LicenseToDelete =>
                entityraw.License.Remove(
                    entityraw.License
                        .First(b => b.LicenseId == LicenseToDelete.LicenseId)));

            foreach (var addedlicense in addedLicense)
            {
                context.Entry(addedlicense).State = EntityState.Added;
            }

            context.SaveChanges();
        }
    }
}
