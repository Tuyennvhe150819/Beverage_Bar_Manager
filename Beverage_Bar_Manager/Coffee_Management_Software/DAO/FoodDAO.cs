using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffee_Management_Software.Models;
using System.Windows.Forms;
using Coffee_Management_Software.DTO;

namespace Coffee_Management_Software.DAO
{
    class FoodDAO
    {
        private static FoodDAO instance = null;
        private static readonly object instanceLock = new object();
        private FoodDAO() { }
        public static FoodDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new FoodDAO();
                    }
                    return instance;
                }
            }
        }
        public List<FoodDTO> GetListFoodInfoByAll(int flag, int idCate, string name,int page, int recordNum)
        {
            List<FoodDTO> foodDTOs = new List<FoodDTO>();
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                var foods = (from f in db.Foods
                             join fc in db.FoodCategories
                             on f.IdCatagory equals fc.Id
                             select new FoodDTO
                             {
                                 IdFood = f.Id,
                                 NameFood = f.Name,
                                 NameCate = fc.Name,
                                 Price = double.Parse(f.Price.ToString()),
                                 Description = f.Description,
                                 Status = (bool)f.Status ? "Đang hoạt động" : "Ngưng bán",
                                 Size = f.Size,
                                 IdCate = fc.Id
                             }).ToList();

                if (flag == 1)
                {
                    foods = foods.Where(f => f.IdCate.Equals(idCate)).ToList();
                }
                else if (flag == 2)
                {
                    name = name.ToLower();
                    foods = foods.Where(f => f.NameFood.ToLower().Contains(name)).ToList();
                }
                foods = foods.Skip((page - 1) * recordNum).Take(recordNum).ToList();
                return foods;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CountTotalRecord(int flag, int idCate, string name)
        {
            int count = 0;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                count = db.Foods.Count();
                if (flag == 1)
                {
                    count = db.Foods.Where(f => f.IdCatagory.Equals(idCate)).Count();
                }
                else if (flag == 2)
                {
                    count = db.Foods.Where(f => f.Name.ToLower().Contains(name)).Count();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return count;
        }

        public Food GetFoodInfoById(int id)
        {
            Food food;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                food = db.Foods.SingleOrDefault(f => f.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
            return food;
        }

        public void InsertFoodInfo(Food food)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                db.Foods.Add(food);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public void UpdateFoodInfo(Food food)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                db.Entry<Food>(food).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteFoodInfo(Food food)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                var fo = db.Foods.SingleOrDefault(f => f.Id == food.Id);
                db.Foods.Remove(fo);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Food> GetListFoodByIDCate(int id)
        {
            List<Food> foods = new List<Food>();
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                foods = db.Foods.Where(f => f.IdCatagory.Equals(id) && f.Status.Equals(true)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return foods;
        }
        public bool CheckFoodEx(int id)
        {
            bool flag = false;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                int count = db.BillDetails.Where(c => c.IdFood.Equals(id)).Count();
                if (count <= 0)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return flag;
        }
    }
}
