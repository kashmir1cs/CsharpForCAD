using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Geometry;
// color 관련 참조 불러오기
using Autodesk.AutoCAD.Colors;

namespace CadCsharpLayer
{
    public class LayerCreation
    {
        [CommandMethod("CreateLayer")]
        public static void CreateLayer()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            // start a transaction
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                // Layter Table Open
                LayerTable lytab = trans.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                if (lytab.Has("Misc"))
                {
                    //Layer가 이미 존재할 경우 Message 출력
                    doc.Editor.WriteMessage("Already Exist");
                    trans.Abort();
                }
                else
                {
                    // layer 생성
                    lytab.UpgradeOpen();
                    LayerTableRecord ltr = new LayerTableRecord();
                    ltr.Name = "Misc"; 
                    ltr.Color = Color.FromColorIndex(ColorMethod.ByLayer, 1);// layer color index 지정
                    lytab.Add(ltr);
                    trans.AddNewlyCreatedDBObject(ltr, true);
                    db.Clayer = lytab["Misc"];
                    // Message 출력
                    doc.Editor.WriteMessage("Layer [ " + ltr.Name + "] 추가 성공");
                    // commit
                    trans.Commit();
                }
            }
        }
    }
}
