using Integration.Model;
using Integration.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Service
{
    public class PharmacyService
    {
        private PharmacySqlRepository psr;

        public PharmacyService(PharmacySqlRepository pharmacySqlRepository)
        {
            psr = pharmacySqlRepository;
        }
        public bool CheckRecipe(Recipe r)
        {
            Drugs d = psr.GetOneDrug(r.Medicine);
            int kolicinaUBazi = int.Parse(d.Quantity);
            int kolicinaSaRecepta = int.Parse(r.Quantity);
            int novaKolicina = kolicinaUBazi - kolicinaSaRecepta;
            Console.WriteLine(novaKolicina);
            if(novaKolicina <= 0)
            {
                return false;
            }
            else
            {
                d.Quantity = novaKolicina.ToString();
                psr.Update(d);
                return true;
            }
        }
        public Recipe GetRecipes(int id)
        {
            return psr.GetOne(id);
        }

        public List<Storage> GetAllD()
        {
            List<Storage> d = psr.GetAllD();
            return d;
        }

        public Drugs FindDrugPharmacy(string m)
        {
            return psr.GetOneDrug(m);
        }

        public Storage FindDrugStorage(string m)
        {
            return psr.GetOneStorage(m);
        }

        public bool AddDrugsToStorage(Drugs d, Storage s, string quantity)
        {
            int quantityInt = int.Parse(quantity);
            int quantityD = int.Parse(d.Quantity);
            int quantityS = int.Parse(s.Quantity);
            if ((quantityD - quantityInt) > 0)
            {
                d.Quantity = (quantityD - quantityInt).ToString();
                psr.Update(d);
                s.Quantity = (quantityS + quantityInt).ToString();
                psr.Update(s);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
