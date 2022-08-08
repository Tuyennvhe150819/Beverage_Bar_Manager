using Coffee_Management_Software.DAO;
using Coffee_Management_Software.DTO;
using Coffee_Management_Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.Repository.impl
{
    class FoodRepository : IFoodRepository
    {
        public bool CheckFoodEx(int id) => FoodDAO.Instance.CheckFoodEx(id);
        public int CountTotalRecord(int flag, int idCate, string name) => FoodDAO.Instance.CountTotalRecord(flag, idCate, name);
        public void DeleteFoodInfo(Food food) => FoodDAO.Instance.DeleteFoodInfo(food);

        public Food GetFoodInfoById(int id) => FoodDAO.Instance.GetFoodInfoById(id);

        public List<Food> GetListFoodByIDCate(int id)=> FoodDAO.Instance.GetListFoodByIDCate(id);

        public List<FoodDTO> GetListFoodInfoByAll(int flag, int idCate, string name, int page, int recordNum)
            => FoodDAO.Instance.GetListFoodInfoByAll(flag, idCate, name, page, recordNum);
        public void InsertFoodInfo(Food food) => FoodDAO.Instance.InsertFoodInfo(food);

        public void UpdateFoodInfo(Food food) => FoodDAO.Instance.UpdateFoodInfo(food);
    }
}
