using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EyeDropsDev.Models
{
    public class UserMedicineRepository : IUserMedicineRepository
    {
        private eyeDropsDbDataContext db;

        public UserMedicineRepository(eyeDropsDbDataContext context)
        {
            db = context;
        }

        public List<UserMedicineModel> getAllUserUserMedicines(int userId)
        {
            var drugs = from u in db.UserMedicines
                        where u.UserID == userId
                        join d  in db.MedicineMasters on u.MedicineID equals d.ID into a2
                     from a1 in a2.DefaultIfEmpty()
                        select new
                        {
                            medicineId = u.MedicineID,
                            numBottles = u.NoOfBottles,
                            strength = u.Strength,
                            size = u.Size,
                            eye = u.Eye,
                            manufacturer = u.Manufacturer,
                            starting = u.StartingFrom,
                            ending = u.Ending,
                            image = a1.ImageName
                        };
            List<UserMedicineModel> mmodel = new List<UserMedicineModel>();
            if(drugs.ToList().Count > 0)
            {
                for (int i =0; i<drugs.ToList().Count ;i++)
                {
                    UserMedicineModel model = new UserMedicineModel();
                    model.medicine.MedicineID = drugs.ToList()[i].medicineId;
                    model.medicine.NoOfBottles = drugs.ToList()[i].numBottles;
                    model.medicine.Size = drugs.ToList()[i].size;
                    model.medicine.Strength = drugs.ToList()[i].strength;
                    model.medicine.StartingFrom = drugs.ToList()[i].starting;
                    model.medicine.Eye = drugs.ToList()[i].eye;
                    model.medicine.Manufacturer = drugs.ToList()[i].manufacturer;
                    model.medicine.Ending = drugs.ToList()[i].ending;
                    model.medicine.ImageData = drugs.ToList()[i].image;
                    mmodel.Add(model);
                }
            }
            return mmodel;
        }

        public UserMedicine getUserMedicine(int id)
        {
            var drugs = from u in db.UserMedicines
                        where u.ID == id
                        select u;
            var d = drugs.ToList();
            return d[0];
        }



public int addUserUserMedicine(int userId, int medicineId, int numBottles, string strength, string size, int eye, string Manufacturer, DateTime startings)
{
 	throw new NotImplementedException();
}
}
}