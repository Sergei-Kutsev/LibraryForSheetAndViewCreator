using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining_Library
{
    public class CategoryUtils
    {
        public static List<Category> GetCategories(Document doc)
        {
            var categoryList = new List<Category>();
            Categories categories = doc.Settings.Categories; //из текущего проекта забираем все категории
            foreach (Category category in categories)
            {
                categoryList.Add(category); //закидываем все категории в список
            }
            return categoryList.OrderBy(c => c.Name).ToList(); //возвращаем список с категориями отсортированными по имени
        }
    }
}
