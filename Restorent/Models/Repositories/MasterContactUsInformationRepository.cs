using Microsoft.EntityFrameworkCore;

namespace Restorent.Models.Repositories
{
    public class MasterContactUsInformationRepository : IRepository<MasterContactUsInformation>
    {
        public AppDbContext Db { get; }

        public MasterContactUsInformationRepository(AppDbContext Db)
        {
            this.Db = Db;
        }

       

        public void Active(int id, MasterContactUsInformation entity)
        {
            MasterContactUsInformation data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterContactUsInformation entity)
        {
            Db.MasterContactUsInformation.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterContactUsInformation entity)
        {
            MasterContactUsInformation data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterContactUsInformation Find(int id)
        {
            var d= Db.MasterContactUsInformation.SingleOrDefault(s => s.MasterContactUsInformationId == id);
            Db.ChangeTracker.Clear();
            return d;
        }

        public void Update(int id, MasterContactUsInformation entity)
        {
            Db.MasterContactUsInformation.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterContactUsInformation> View()
        {
            return Db.MasterContactUsInformation.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterContactUsInformation> ViewFormClient()
        {
            return Db.MasterContactUsInformation.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
