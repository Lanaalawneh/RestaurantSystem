namespace Restorent.Models.Repositories
{
    public class MasterSocialMediaRepository : IRepository<MasterSocialMedia>
    {
        public AppDbContext Db { get; }


        public MasterSocialMediaRepository(AppDbContext Db)
        {
            this.Db = Db;
        }

        public void Active(int id, MasterSocialMedia entity)
        {
            MasterSocialMedia data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterSocialMedia entity)
        {
            Db.MasterSocialMedia.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterSocialMedia entity)
        {
            MasterSocialMedia data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterSocialMedia Find(int id)
        {
            return Db.MasterSocialMedia.SingleOrDefault(s => s.MasterSocialMediaId == id);
        }

        public void Update(int id, MasterSocialMedia entity)
        {
            Db.MasterSocialMedia.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterSocialMedia> View()
        {
            return Db.MasterSocialMedia.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterSocialMedia> ViewFormClient()
        {
            return Db.MasterSocialMedia.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
