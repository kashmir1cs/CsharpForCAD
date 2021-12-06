using System;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;

namespace CadDrawObject01
{
    public class DrawObject
    {
        [CommandMethod("DrawPline")]
        public void DrawPline() // PolyLine그리기
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    doc.Editor.WriteMessage(" Drawing a 2D Polyline");
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    //Specify the Polyline's coordinate
                    Polyline pl = new Polyline();
                    pl.AddVertexAt(0, new Point2d(0, 0), 0, 0, 0);
                    pl.AddVertexAt(1, new Point2d(10, 10), 0, 0, 0);
                    pl.AddVertexAt(1, new Point2d(20, 20), 0, 0, 0);
                    pl.AddVertexAt(1, new Point2d(30, 30), 0, 0, 0);
                    pl.AddVertexAt(1, new Point2d(40, 40), 0, 0, 0);
                    pl.AddVertexAt(1, new Point2d(50, 50), 0, 0, 0);
                    pl.AddVertexAt(1, new Point2d(60, 60), 0, 0, 0);
                    pl.SetDatabaseDefaults();
                    btr.AppendEntity(pl);
                    trans.AddNewlyCreatedDBObject(pl, true);
                    trans.Commit();


                }

                catch (System.Exception ex)
                {
                    doc.Editor.WriteMessage(" Error encountered " + ex.Message);

                    trans.Abort();
                }
            }
        }
        [CommandMethod("DrawArc")]
        public void DrawArc()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    ed.WriteMessage("Drawing a Arc");
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    // specify Arc parameters
                    Point3d centerPt = new Point3d(100, 100, 0);
                    double arcRad = 200.0;
                    double startAngle = (Math.PI * 90) / 180; //change radian to degree
                    double endAngle = (Math.PI * 270) / 180; //change radian to degree
                    Arc arc = new Arc(centerPt, arcRad, startAngle, endAngle);
                    // set the default properties
                    arc.SetDatabaseDefaults(); // arc 기본 값으로 설정하기, 다른 객체들도 가능
                    btr.AppendEntity(arc);
                    trans.AddNewlyCreatedDBObject(arc, true);
                    trans.Commit();
                }

                catch (System.Exception ex)
                {
                    ed.WriteMessage("Error 발생" + ex.Message);
                    trans.Abort();
                }
            }
        }
        [CommandMethod("DrawCircle")]
        public void DrawCircle()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {

                try
                {
                    ed.WriteMessage("Drawing a Circle");
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    // specify circle parameters
                    Point3d centerPt = new Point3d(100, 100, 0);
                    double circleRad = 1000.0;
                    using (Circle circle = new Circle())
                    {
                        circle.Radius = circleRad;
                        circle.Center = centerPt;
                        btr.AppendEntity(circle);
                        trans.AddNewlyCreatedDBObject(circle, true);
                    }
                    trans.Commit();
                }
                catch (System.Exception ex)
                {
                    ed.WriteMessage("Error 발생" + ex.Message);
                    trans.Abort();
                }
            }

        }
        [CommandMethod("DrawMtext")]
        public void DrawMtext()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    ed.WriteMessage("Create MText Exercise");
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    // specify the MText parameter ( string, insertpoint)
                    string txt = "Csharp with autocad";
                    Point3d insPt = new Point3d(200, 200, 0);
                    using (MText mtx = new MText())
                    {
                        mtx.Contents = txt;
                        mtx.Location = insPt;
                        mtx.TextHeight = 50;

                        btr.AppendEntity(mtx);
                        trans.AddNewlyCreatedDBObject(mtx, true);
                        trans.Commit();

                    }
                }
                catch (System.Exception ex)
                {
                    ed.WriteMessage("Error 발생" + ex.Message);
                    trans.Abort();
                }
            }
        }

        [CommandMethod("DrawLine")]
        public void DrawLine()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;


            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    // send a message to the user
                    ed.WriteMessage("\nDrawing a Line object");
                    Point3d pt1 = new Point3d(0, 0, 0);
                    Point3d pt2 = new Point3d(100, 100, 100);
                    Line ln = new Line(pt1, pt2);
                    ln.ColorIndex = 1; // red color
                    btr.AppendEntity(ln);
                    trans.AddNewlyCreatedDBObject(ln, true);
                    trans.Commit();//data base에 entity 추가완료
                }
                catch (System.Exception ex)
                {

                    ed.WriteMessage("Error 발생" + ex.Message);
                    trans.Abort();
                }
            }

        }

    }
}
