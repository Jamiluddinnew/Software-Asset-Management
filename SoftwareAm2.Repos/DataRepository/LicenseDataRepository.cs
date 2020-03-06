using SoftwareAm2.Repos.Interface;
using SoftwareAM2.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.ComponentModel;
using System.Text;

namespace SoftwareAm2.Repos
{
    public class LicenseDataRepository : IRepository<License>
    {
        private readonly TestDB2Context context;

        public LicenseDataRepository(TestDB2Context _context)
        {
            context = _context;
        }
        public void Add(License entity)
        {
            context.License.Add(entity);
            context.SaveChanges();
        }

        public void Delete(License entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<License> GetAll()
        {
            return context.License;
        }

        public License GetbyId(int Id)
        {
            License license = context.License.Find(Id);
            return license;
        }

        public void Update(License entityraw, License entity)
        {
            entityraw.LicenseId = entity.LicenseId;
            entityraw.LisenseStart = entity.LisenseStart;
            entityraw.LisenseEnd = entity.LisenseEnd;

        }

    }
}
