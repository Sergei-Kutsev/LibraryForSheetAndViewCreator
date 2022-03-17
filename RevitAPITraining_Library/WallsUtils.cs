using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining_Library
{
    public class WallsUtils
    {
        public static List<WallType> GetWallTypes(ExternalCommandData commandData) //метод который собирает все типы стен из модели
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;//помогает выбирать элементы
            Document doc = uidoc.Document; //переменная помогает распаковать объект из reference в элемент

            var wallTypes = new FilteredElementCollector(doc) //переменная со списком
                .OfClass(typeof(WallType))  
                .Cast<WallType>()
                .ToList();
           
            return wallTypes;
        }
    }
}
