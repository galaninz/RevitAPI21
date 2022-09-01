using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI21
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            //По категории

            //List<FamilyInstance> familyInstances = new FilteredElementCollector(doc)
            //    .OfCategory(BuiltInCategory.OST_DuctCurves)
            //    .WhereElementIsNoElementType()
            //    .Cast<FamilyInstance>()
            //    .ToList();

            //TaskDialog.Show("Ducts count", familyInstances.Count.ToString());

            //По типу

            var ducts = new FilteredElementCollector(doc)
                .OfClass(typeof(Duct))
                .Cast<Duct>()
                .ToList();

            TaskDialog.Show("Ducts quantity", ducts.Count.ToString());

            return Result.Succeeded;

        }
    }
}
