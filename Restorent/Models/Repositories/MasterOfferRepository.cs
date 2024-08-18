namespace Restorent.Models.Repositories
{
    public class MasterOfferRepository : IRepository<MasterOffer>
    {
        public AppDbContext Db { get; }

        public MasterOfferRepository(AppDbContext Db)
        {
            this.Db = Db;
        }
 
        public void Active(int id, MasterOffer entity)
        {
            MasterOffer data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }


        public void Add(MasterOffer entity)
        {
            Db.MasterOffer.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterOffer entity)
        {
            MasterOffer data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterOffer Find(int id)
        {
            return Db.MasterOffer.SingleOrDefault(s => s.MasterOfferId == id);
        }

        public void Update(int id, MasterOffer entity)
        {
            Db.MasterOffer.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterOffer> View()
        {
            return Db.MasterOffer.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterOffer> ViewFormClient()
        {
            return Db.MasterOffer.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
