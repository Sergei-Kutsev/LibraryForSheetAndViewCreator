using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining_Library
{
    public class DuctsUtils
    {
        public static List<DuctType> GetDuctTypes(ExternalCommandData commandData) //метод который собирает все типы воздуховодов из модели
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;//помогает выбирать элементы
            Document doc = uidoc.Document; //переменная помогает распаковать объект из reference в элемент

            var ductTypes = new FilteredElementCollector(doc) //переменная со списком
                .OfClass(typeof(DuctType))
                .Cast<DuctType>()
                .ToList();

            return ductTypes;
        }
    }
}
