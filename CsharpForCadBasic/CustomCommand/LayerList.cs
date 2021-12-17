using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;

namespace CadCsharpForCadDict01
{
    // Layer 리스트 출력하기
    public class LayerClass
    {

        [CommandMethod("ListLayers")]
        public static void ListLayers()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            // start a transaction
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    doc.Editor.WriteMessage("\n레이어 정보 읽기 연습");
                    LayerTable lytab = trans.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                    foreach (ObjectId lyID in lytab)
                    {
                        // Layer에 대한 내용 Command 창에 출력함
                        LayerTableRecord lytr = trans.GetObject(lyID, OpenMode.ForRead) as LayerTableRecord;
                        doc.Editor.WriteMessage("\nLayer name: " + lytr.Name);
                        // Layer에 대한 Description Command 창에 출력
                        doc.Editor.WriteMessage("\nLayer Description: " + lytr.Description);
                        // Layer에 대한 색상 한글로 표기
                        doc.Editor.WriteMessage("\nLayer Color.ToString(): " + lytr.Color.ToString());
                    }
                    // commit transaction
                    trans.Commit();
                }
                catch (System.Exception ex)
                {

                    doc.Editor.WriteMessage("Error" + ex.Message);
                    trans.Abort();
                }

            }
        }
    }
}
