using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.MobileControls;

namespace RevitAPITraining_Library
{
    public class SheetUtils
    {
        public static IList<FamilySymbol> GetSheets(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;//помогает выбирать элементы
            Document doc = uidoc.Document; //переменная помогает распаковать объект из reference в элемент

            //var sheets = new FilteredElementCollector(doc) //собрали все листы которые есть в проекте
            //     //.WhereElementIsElementType()
            //     .OfClass(typeof(ViewSheet))
            //     .Cast<ViewSheet>()
            //     .ToList();

            IList<FamilySymbol> sheets = new FilteredElementCollector(doc) // ищем экземпляры среди загружаемых семейств
                .OfCategory(BuiltInCategory.OST_TitleBlocks) //в категории мебель
                .WhereElementIsElementType() //ищем только типы
                .Cast<FamilySymbol>()
                .ToList();

            //List<FamilySymbol> doortypes = new FilteredElementCollector(document) // ищем экземпляры среди семейств
            //    .OfCategory(BuiltInCategory.OST_Doors) //в категории дверей
            //    .WhereElementIsElementType() //ищем только типы
            //    .Cast<FamilySymbol>()
            //    .ToList();

            return sheets; //возвращаем
        }
    }
}
