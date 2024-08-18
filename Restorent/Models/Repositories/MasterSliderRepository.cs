namespace Restorent.Models.Repositories
{
    public class MasterSliderRepository : IRepository<MasterSlider>
    {

        public AppDbContext Db { get; }

        public MasterSliderRepository(AppDbContext Db)
        {
            this.Db = Db;
        }

        

        public void Active(int id, MasterSlider entity)
        {
            MasterSlider data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterSlider entity)
        {
            Db.MasterSlider.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterSlider entity)
        {
            MasterSlider data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterSlider Find(int id)
        {
            return Db.MasterSlider.SingleOrDefault(s => s.MasterSliderId == id);
        }

        public void Update(int id, MasterSlider entity)
        {
            Db.MasterSlider.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterSlider> View()
        {
            return Db.MasterSlider.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterSlider> ViewFormClient()
        {
            return Db.MasterSlider.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
