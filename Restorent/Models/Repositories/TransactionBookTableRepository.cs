namespace Restorent.Models.Repositories
{
    public class TransactionBookTableRepository : IRepository<TransactionBookTable>
    {

        public AppDbContext Db { get; }

        public TransactionBookTableRepository(AppDbContext Db)
        {
            this.Db = Db;
        }


        public void Active(int id, TransactionBookTable entity)
        {
            TransactionBookTable data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(TransactionBookTable entity)
        {
            Db.TransactionBookTable.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, TransactionBookTable entity)
        {
            TransactionBookTable data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public TransactionBookTable Find(int id)
        {
            return Db.TransactionBookTable.SingleOrDefault(s => s.TransactionBookTableId == id);
        }

        public void Update(int id, TransactionBookTable entity)
        {
            Db.TransactionBookTable.Update(entity);
            Db.SaveChanges();
        }

        public IList<TransactionBookTable> View()
        {
            return Db.TransactionBookTable.Where(x => x.IsDelete == false).ToList();
        }

        public IList<TransactionBookTable> ViewFormClient()
        {
            return Db.TransactionBookTable.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
