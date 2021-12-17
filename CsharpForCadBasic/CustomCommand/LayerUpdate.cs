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


namespace CadForCsharpUpdateLayer
{
    public class UpdateLayer
    {
        [CommandMethod("UpdateLayer")]
        public static void UpLayer()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    LayerTable lytab = trans.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                    foreach(ObjectId lyID in lytab)
                    {
                        LayerTableRecord lytr = trans.GetObject(lyID, OpenMode.ForRead) as LayerTableRecord;
                        if(lytr.Name=="Misc")
                        {
                            lytr.UpgradeOpen();
                            // Upgrade the color
                            lytr.Color = Color.FromColorIndex(ColorMethod.ByLayer, 2);
                            // Update the Linetype 
                            LinetypeTable ltTab = trans.GetObject(db.LinetypeTableId, OpenMode.ForRead) as LinetypeTable;
                            if (ltTab.Has("Hidden") == true)
                            {
                                // Line Style "Hidden"이 존재할 경우 
                                // Layer의 Line Style "Hidden"으로 변경
                                lytr.LinetypeObjectId = ltTab["Hidden"];

                            }
                            //commit transaction

                            trans.Commit();
                            doc.Editor.WriteMessage("\n Layer update complete : " + lytr.Name);
                            break; //if문 확인 후 종료
                        }
                        else
                        {
                            doc.Editor.WriteMessage("\n Skipping Layer [ " + lytr.Name + " ]");

                        }
                    }
                }
                catch (System.Exception ex)
                {
                    doc.Editor.WriteMessage("Error 발생 : " + ex.Message);
                    trans.Abort();
                }
            }
        }

    }
}
