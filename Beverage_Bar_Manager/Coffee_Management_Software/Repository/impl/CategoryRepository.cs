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
    class CategoryRepository : ICategoryRepository
    {
        public bool CheckCateEx(int id) => CategoryDAO.Instance.CheckCateEx(id);

        public void DeleteCate(FoodCategory category) => CategoryDAO.Instance.DeleteCate(category);

        public List<CategoryDTO> GetCategories() => CategoryDAO.Instance.GetCategories();
        public List<FoodCategory> GetCategoriesIsActive() => CategoryDAO.Instance.GetCategoriesIsActive();

        public FoodCategory GetCateInfoById(int id) => CategoryDAO.Instance.GetCateInfoById(id);

        public void InsertCate(FoodCategory category) => CategoryDAO.Instance.InsertCate(category);

        public void UpdateCate(FoodCategory category) => CategoryDAO.Instance.UpdateCate(category);
    }
}
