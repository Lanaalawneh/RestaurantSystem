namespace Restorent.Models.Repositories
{
    public class TransactionNewsletterRepository : IRepository<TransactionNewsletter>
    {


        public AppDbContext Db { get; }

        public TransactionNewsletterRepository(AppDbContext Db)
        {
            this.Db = Db;
        }

        

        public void Active(int id, TransactionNewsletter entity)
        {
            TransactionNewsletter data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(TransactionNewsletter entity)
        {
            Db.TransactionNewsletter.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, TransactionNewsletter entity)
        {
            TransactionNewsletter data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public TransactionNewsletter Find(int id)
        {
            return Db.TransactionNewsletter.SingleOrDefault(s => s.TransactionNewsletterId == id);
        }

        public void Update(int id, TransactionNewsletter entity)
        {
            Db.TransactionNewsletter.Update(entity);
            Db.SaveChanges();
        }

        public IList<TransactionNewsletter> View()
        {
            return Db.TransactionNewsletter.Where(x => x.IsDelete == false).ToList();
        }

        public IList<TransactionNewsletter> ViewFormClient()
        {
            return Db.TransactionNewsletter.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
