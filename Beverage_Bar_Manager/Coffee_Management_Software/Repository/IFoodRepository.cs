using Coffee_Management_Software.DTO;
using Coffee_Management_Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.Repository
{
    interface IFoodRepository
    {
        List<FoodDTO> GetListFoodInfoByAll(int flag, int idCate, string name, int page, int recordNum);
        int CountTotalRecord(int flag, int idCate, string name);
        Food GetFoodInfoById(int id);
        void InsertFoodInfo(Food food);
        void UpdateFoodInfo(Food food);
        void DeleteFoodInfo(Food food);
        List<Food> GetListFoodByIDCate(int id);
        bool CheckFoodEx(int id); 
    }
}
