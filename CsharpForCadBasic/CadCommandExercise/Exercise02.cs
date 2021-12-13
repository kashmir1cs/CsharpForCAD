using System;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;

namespace CadCsharpExercise02
{
    public class Class1
    {
        [CommandMethod("EraseX")]
        public static void EraseExercise()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            // start a transaction
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    // open the block table record modelspace for write
                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    // line개체 선언
                    Point3d stPoint = new Point3d(0, 0, 0);
                    Point3d endPoint = new Point3d(10, 10, 0);
                    Line ln = new Line(stPoint, endPoint);
                    btr.AppendEntity(ln);
                    trans.AddNewlyCreatedDBObject(ln, true);
                    Circle c1 = new Circle();
                    c1.Center = new Point3d(0, 0, 0);
                    c1.Radius = 5;
                    btr.AppendEntity(c1);
                    trans.AddNewlyCreatedDBObject(c1, true);
                    Polyline pl = new Polyline();
                    pl.AddVertexAt(0, new Point2d(0, 0), 0, 0, 0);
                    pl.AddVertexAt(1, new Point2d(-10, -10), 0, 0, 0);
                    pl.AddVertexAt(2, new Point2d(20, -20), 0, 0, 0);
                    btr.AppendEntity(pl);
                    trans.AddNewlyCreatedDBObject(pl, true);
                    DBObjectCollection col = new DBObjectCollection();
                    col.Add(ln);
                    col.Add(c1);
                    col.Add(pl);
                    foreach (Entity acEnt in col)
                    {
                        //조건문 처리 
                        if (acEnt is Circle) // collection 개체가 circle이면 
                        {
                            acEnt.Erase(true); // circle 삭제
                        }
                        else if (acEnt is Line)
                        {
                            acEnt.ColorIndex = 2;
                        }
                        else
                        {
                            acEnt.ColorIndex = 3;
                        }
                    }
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
