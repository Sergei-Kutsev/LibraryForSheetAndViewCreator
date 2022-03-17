using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining_Library
{
    public class FamilyInstanceUtils
    {
        public static FamilyInstance CreateFamilyInstance(
            ExternalCommandData commandData,
            FamilySymbol oFamSymb,
            XYZ insertionPoint,
            Level oLevel)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.DB.Document doc = uidoc.Document;
            FamilyInstance familyInstance = null;
           
            //создаем новый экземпляр семейства
            using (var t = new Autodesk.Revit.DB.Transaction(doc, "Create family instance"))
            {
                t.Start();
                if (!oFamSymb.IsActive) //если тип семейства не был раньше доступен в модели, то он активируется таким образом
                {
                    oFamSymb.Activate();
                    doc.Regenerate();
                }
                familyInstance = doc.Create.NewFamilyInstance( //создаем новое семейство
                                    insertionPoint,
                                    oFamSymb,
                                    oLevel,
                                    Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                t.Commit();
            }
            return familyInstance;
        }
    }
}
