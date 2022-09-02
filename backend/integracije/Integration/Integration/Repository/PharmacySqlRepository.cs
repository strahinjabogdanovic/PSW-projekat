using Integration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Repository
{
    public class PharmacySqlRepository : PharmacyRepository
    {
        private MyDbContext context;
        public PharmacySqlRepository(MyDbContext myDbContext)
        {
            context = myDbContext;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Recipe> GetAll()
        {
            throw new NotImplementedException();
        }

        public Recipe GetOne(int id)
        {
            return context.Recipes.Where(f => f.IdR == id).FirstOrDefault();
        }

        public Drugs GetOneDrug(string medicine)
        {
            return context.DrugsInPharmacy.Where(f => f.Medicine.Equals(medicine)).FirstOrDefault();
        }

        public Storage GetOneStorage(string medicine)
        {
            return context.DrugsInStorage.Where(f => f.Medicine.Equals(medicine)).FirstOrDefault();
        }
        public bool Update(Drugs editedObject)
        {
            context.DrugsInPharmacy.Update(editedObject);
            context.SaveChanges();
            return true;
        }

        public bool Update(Storage editedObject)
        {
            context.DrugsInStorage.Update(editedObject);
            context.SaveChanges();
            return true;
        }

        public List<Storage> GetAllD() 
        {
            List<Storage> d = context.DrugsInStorage.ToList();
            return d;
        }

        public bool Save(Recipe newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(Recipe editedObject)
        {
            throw new NotImplementedException();
        }
    }
}
