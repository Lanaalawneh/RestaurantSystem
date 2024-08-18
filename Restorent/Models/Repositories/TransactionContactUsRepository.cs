namespace Restorent.Models.Repositories
{
    public class TransactionContactUsRepository : IRepository<TransactionContactUs>
    {

        public AppDbContext Db { get; }

        public TransactionContactUsRepository(AppDbContext Db)
        {
            this.Db = Db;
        }

        

        public void Active(int id, TransactionContactUs entity)
        {
           TransactionContactUs data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(TransactionContactUs entity)
        {
            Db.TransactionContactUs.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, TransactionContactUs entity)
        {
            TransactionContactUs data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public TransactionContactUs Find(int id)
        {
            return Db.TransactionContactUs.SingleOrDefault(s => s.TransactionContactUsId == id);
        }

        public void Update(int id, TransactionContactUs entity)
        {
            Db.TransactionContactUs.Update(entity);
            Db.SaveChanges();
        }

        public IList<TransactionContactUs> View()
        {
            return Db.TransactionContactUs.Where(x => x.IsDelete == false).ToList();
        }

        public IList<TransactionContactUs> ViewFormClient()
        {
            return Db.TransactionContactUs.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
