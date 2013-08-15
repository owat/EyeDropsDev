using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EyeDropsDev.Models
{
    public class UserMedicineModel
    {
       public UserMedicine medicine;
       public Drug drug;
    }

    public interface IUserMedicineRepository
    {
        List<UserMedicineModel> getAllUserUserMedicines(int userId);
        UserMedicine getUserMedicine(int id);
        int addUserUserMedicine(int userId,int medicineId,int numBottles,String strength, string size, int eye, string Manufacturer, DateTime startings);
    }
}