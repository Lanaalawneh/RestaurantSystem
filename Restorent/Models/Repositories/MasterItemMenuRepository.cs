using Microsoft.EntityFrameworkCore;

namespace Restorent.Models.Repositories
{
    public class MasterItemMenuRepository : IRepository<MasterItemMenu>
    {
        public AppDbContext Db { get; }

        public MasterItemMenuRepository(AppDbContext Db)
        {
            this.Db = Db;
        }


        public void Active(int id, MasterItemMenu entity)
        {
            MasterItemMenu data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterItemMenu entity)
        {
          
            
            Db.MasterItemMenu.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterItemMenu entity)
        {
            MasterItemMenu data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterItemMenu Find(int id)
        {
            return Db.MasterItemMenu.SingleOrDefault(s => s.MasterItemMenuId == id);
        }

        public void Update(int id, MasterItemMenu entity)
        {
            Db.MasterItemMenu.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterItemMenu> View()
        {
            return Db.MasterItemMenu.Include(z=>z.MasterCategoryMenu).Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterItemMenu> ViewFormClient()
        {
            return Db.MasterItemMenu.Where(x => x.IsActive == true && x.IsDelete == false).ToList();

        }
    }
}
