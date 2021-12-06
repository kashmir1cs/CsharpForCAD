using System;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
namespace CsharpForCadStudy01
{
 //dll 파일 추가 :
 //1. AcCoreMgd.DLL
 //2. AcDbMgd.DLL
 //3. AcMgd.DLL
    public class Class1
    {
        [CommandMethod("CsharpHello")]
        public void HelloAutoCADFormCsharp()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor edt = doc.Editor;

            edt.WriteMessage("Autocad Csharp으로 명령어 추가");

        }

        [CommandMethod("CsharpHi")]
        public void SayHo()
        {
            Application.ShowAlertDialog("Hello AutoCad from C#");
        }
    }
}
