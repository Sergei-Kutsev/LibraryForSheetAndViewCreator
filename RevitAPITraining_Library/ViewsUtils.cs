using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining_Library
{
    public class ViewsUtils
    {
        public static List<ViewPlan> GetFloorPlanViews(Document doc)
        {
            var views
               = new FilteredElementCollector(doc)
                   .OfClass(typeof(ViewPlan)) //забираем все планы в проекте
                   .Cast<ViewPlan>() //преобразуем 
                   .Where(p => p.ViewType == ViewType.FloorPlan)//указываем, что забираем только планы этажей, а не планы потолков и т.д.
                   .ToList();
            return views; //возвращаем
        }

        public static List<View> GetAllViews(Document doc)
        {
            var views
               = new FilteredElementCollector(doc)
                   .OfClass(typeof(View)) //забираем все виды в проекте
                   .WhereElementIsNotElementType()
                   .Cast<View>() //преобразуем 
                   .Where(p => p.ViewType != ViewType.DrawingSheet)
                   
                   .ToList();
            return views; //возвращаем
        }
    }
}
