namespace Restorent.Models.Repositories
{
    public class MasterMenuRepository : IRepository<MasterMenu>
    {
        public AppDbContext Db { get; }
        public MasterMenuRepository(AppDbContext Db )
        {
            this.Db = Db;
        }

        

        public void Active(int id, MasterMenu entity)
        {
            MasterMenu data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);   
        }

        public void Add(MasterMenu entity)
        {
            Db.MasterMenu.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterMenu entity)
        {
            MasterMenu data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);   
        }

        public MasterMenu Find(int id)
        {
            return Db.MasterMenu.SingleOrDefault(s => s.MasterMenuId == id);
        }

        public void Update(int id, MasterMenu entity)
        {
            Db.MasterMenu.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterMenu> View()
        {
            return Db.MasterMenu.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterMenu> ViewFormClient()
        {
            return Db.MasterMenu.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
