namespace Restorent.Models.Repositories
{
    public class MasterPartnerRepository : IRepository<MasterPartner>
    {


        public AppDbContext Db { get; }

        public MasterPartnerRepository(AppDbContext Db)
        {
            this.Db = Db;
        }

       
        public void Active(int id, MasterPartner entity)
        {
            MasterPartner data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }


        public void Add(MasterPartner entity)
        {
            Db.MasterPartner.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterPartner entity)
        {
            MasterPartner data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterPartner Find(int id)
        {
            return Db.MasterPartner.SingleOrDefault(s => s.MasterPartnerId == id);
        }

        public void Update(int id, MasterPartner entity)
        {
            Db.MasterPartner.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterPartner> View()
        {
            return Db.MasterPartner.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterPartner> ViewFormClient()
        {
            return Db.MasterPartner.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
