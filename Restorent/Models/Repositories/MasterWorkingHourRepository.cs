namespace Restorent.Models.Repositories
{
    public class MasterWorkingHourRepository : IRepository<MasterWorkingHour>
    {
        public AppDbContext Db { get; }


        public MasterWorkingHourRepository( AppDbContext Db)
        {
            this.Db = Db;
        }

        

        public void Active(int id, MasterWorkingHour entity)
        {
            MasterWorkingHour data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterWorkingHour entity)
        {
            Db.MasterWorkingHour.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterWorkingHour entity)
        {
            MasterWorkingHour data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
            Db.SaveChanges() ;
        }

        public MasterWorkingHour Find(int id)
        {
            return Db.MasterWorkingHour.SingleOrDefault(s => s.MasterWorkingHourId == id);
        }

        public void Update(int id, MasterWorkingHour entity)
        {
            Db.MasterWorkingHour.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterWorkingHour> View()
        {
            return Db.MasterWorkingHour.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterWorkingHour> ViewFormClient()
        {
            return Db.MasterWorkingHour.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
