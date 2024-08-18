using Microsoft.EntityFrameworkCore;

namespace Restorent.Models.Repositories
{
    public class MasterCategoryMenuRepository : IRepository<MasterCategoryMenu>
    {

        public AppDbContext Db { get; }


        public MasterCategoryMenuRepository(AppDbContext Db)
        {
            this.Db = Db;
        }

       

        public void Active(int id, MasterCategoryMenu entity)
        {
            MasterCategoryMenu data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterCategoryMenu entity)
        {
            Db.MasterCategoryMenu.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterCategoryMenu entity)
        {
            MasterCategoryMenu data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterCategoryMenu Find(int id)
        {
            return Db.MasterCategoryMenu.SingleOrDefault(d => d.MasterCategoryMenuId == id);
        }

        public void Update(int id, MasterCategoryMenu entity)
        {
            Db.MasterCategoryMenu.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterCategoryMenu> View()
        {
            return Db.MasterCategoryMenu.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterCategoryMenu> ViewFormClient()
        {
            return Db.MasterCategoryMenu.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
