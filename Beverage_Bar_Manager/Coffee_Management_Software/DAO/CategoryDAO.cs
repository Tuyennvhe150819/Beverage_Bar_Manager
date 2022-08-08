using Coffee_Management_Software.DTO;
using Coffee_Management_Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.DAO
{
    class CategoryDAO
    {
        private static CategoryDAO instance = null;
        private static readonly object instanceLock = new object();
        private CategoryDAO() { }
        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                    return instance;
                }
            }
        }
        public List<CategoryDTO> GetCategories()
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                var categories = (from c in db.FoodCategories
                              select new CategoryDTO
                              {
                                  IdCate = c.Id,
                                  NameCate = c.Name,
                                  DesCate = c.Description,
                                  StatusCate = (bool)c.Status ? "Đang hoạt động" : "Ngưng bán"
                              }).ToList();
                return categories;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public FoodCategory GetCateInfoById(int id)
        {
            FoodCategory category;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                category = db.FoodCategories.Where(f => f.Id == id).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }
        public void InsertCate (FoodCategory category)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                db.FoodCategories.Add(category);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        public void UpdateCate(FoodCategory category)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                db.Entry<FoodCategory>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public void DeleteCate(FoodCategory category)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                var cate = db.FoodCategories.SingleOrDefault(c => c.Id == category.Id);
                db.FoodCategories.Remove(cate);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public List<FoodCategory> GetCategoriesIsActive()
        {
            List<FoodCategory> categories;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                categories = db.FoodCategories.Where(f => f.Status.Equals(true)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }
        public bool CheckCateEx(int id)
        {
            bool flag = false;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                int count = db.Foods.Where(c => c.IdCatagory.Equals(id)).Count();
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
