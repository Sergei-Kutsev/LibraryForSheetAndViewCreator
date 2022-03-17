using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining_Library
{
    public class SelectionUtils
    {
        public static Element PickObject(ExternalCommandData commandData, string message = "Выберите элемент")//мы можем не задавать второй параметр и тогда он будет выбран по умолчанию
        {
            UIApplication uiapp = commandData.Application; 
            UIDocument uidoc = uiapp.ActiveUIDocument;//помогает выбирать элементы
            Document doc = uidoc.Document; //переменная помогает распаковать объект из reference в элемент

            var selectedObject = uidoc.Selection.PickObject(ObjectType.Element, message); //запрашивается объект
            var oElement = doc.GetElement(selectedObject); //получаем объект
            return oElement;
        }

        public static T GetObject<T>(ExternalCommandData commandData, string promptMessage) //в данном методе мы используем дженерики, а они позволяют выбрать 
                                                                                            //любой объект и сразу преобразовать его в нужный тип
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            Reference selectedObj = null;
           
            T elem; // передаем сюда любой тип
            try
            {
                selectedObj = uidoc.Selection.PickObject(ObjectType.Element, promptMessage); //выбираем элемент
            }
            catch (Exception) //если пользователь нажал escape, то вместо исключения получаем значение по умолчанию - null, либо 0
            {
                return default(T);
            }
            elem = (T)(object)doc.GetElement(selectedObj.ElementId); //выбираем элемент-> преобразовываем его в общий object, а затем преобразовываем в нужный тип
            return elem;
        }

        public static List<Element> PickObjects(ExternalCommandData commandData, string message = "Выберите элементы") //выбираем множество труб, поэтому List
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;//помогает выбирать элементы
            Document doc = uidoc.Document; //переменная помогает распаковать объект из reference в элемент

            var selectedObjects = uidoc.Selection.PickObjects(ObjectType.Element, message); //выбираем элементы типа reference
            List<Element> elementList = selectedObjects.Select(selectedObject => doc.GetElement(selectedObject)).ToList();//преобразовываем каждый reference в список
            return elementList;
        }

        public static List<XYZ> GetPoints(ExternalCommandData commandData,
            string promptMessage, ObjectSnapTypes objectSnapTypes)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;//помогает выбирать элементы

            List<XYZ> points = new List<XYZ>();

            while(true) //бесконечный цикл выбора точек в модели, по которым будет строиться элемент. Для выхода из цикла нужно нажать escape
            {
                XYZ pickedPoint = null;
                try
                {
                    pickedPoint = uidoc.Selection.PickPoint(objectSnapTypes, promptMessage);
                }
                catch (Autodesk.Revit.Exceptions.OperationCanceledException ex )
                {
                    break;
                }
                points.Add(pickedPoint);
            }
            return points;
        }

        public static List<XYZ> GetTwoPoints(ExternalCommandData commandData, string promptMessage, ObjectSnapTypes objectSnapTypes)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;//помогает выбирать элементы

            List<XYZ> points = new List<XYZ>();
            int i = 0;
            do //цикл выбора точек в модели, по которым будет строиться элемент. Для выхода из цикла нужно нажать escape
            {
                XYZ pickedPoint = null;
                try
                {
                    pickedPoint = uidoc.Selection.PickPoint(objectSnapTypes, promptMessage);
                }
                catch (Autodesk.Revit.Exceptions.OperationCanceledException ex)
                {
                    break;
                }
                points.Add(pickedPoint);

                i++;
            }
            while (i <= 1);

            

            return points;
        }
    }
}
