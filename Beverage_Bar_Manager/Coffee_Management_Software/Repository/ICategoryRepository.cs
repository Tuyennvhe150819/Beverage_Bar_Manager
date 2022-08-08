using Coffee_Management_Software.DTO;
using Coffee_Management_Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.Repository
{
    interface ICategoryRepository
    {
        public List<CategoryDTO> GetCategories();
        public FoodCategory GetCateInfoById(int id);
        public void InsertCate(FoodCategory category);
        public void UpdateCate(FoodCategory category);
        public void DeleteCate(FoodCategory category);
        List<FoodCategory> GetCategoriesIsActive();
        bool CheckCateEx(int id);
    }
}
