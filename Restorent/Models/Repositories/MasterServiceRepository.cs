namespace Restorent.Models.Repositories
{
    public class MasterServiceRepository : IRepository<MasterService>
    {

        public AppDbContext Db { get; }

        public MasterServiceRepository(AppDbContext Db)
        {
            this.Db = Db;
        }

       
        public void Active(int id, MasterService entity)
        {
            MasterService data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterService entity)
        {
            Db.MasterService.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterService entity)
        {
            MasterService data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterService Find(int id)
        {
            return Db.MasterService.SingleOrDefault(s => s.MasterServiceId == id);
        }

        public void Update(int id, MasterService entity)
        {
            Db.MasterService.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterService> View()
        {
            return Db.MasterService.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterService> ViewFormClient()
        {
            return Db.MasterService.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
