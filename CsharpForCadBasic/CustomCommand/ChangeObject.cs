using System;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;

namespace CadManipulateObjects
{
    public class Class1
    {
        [CommandMethod("ScaleObject")]
        public static void ScaleObject()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            // start a transaction
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                // mirror 연습
                try
                {
                    // open block table for read
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    // open the block table record modelspace for write
                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    // create a polyline
                    using (Polyline pl = new Polyline())
                    {
                        pl.AddVertexAt(0, new Point2d(1, 2), 0, 0, 0);
                        pl.AddVertexAt(1, new Point2d(1, 3), 0, 0, 0);
                        pl.AddVertexAt(2, new Point2d(2, 3), 0, 0, 0);
                        pl.AddVertexAt(3, new Point2d(3, 3), 0, 0, 0);
                        pl.AddVertexAt(4, new Point2d(4, 4), 0, 0, 0);
                        pl.AddVertexAt(5, new Point2d(4, 2), 0, 0, 0);
                        // close the polyline
                        pl.Closed = true;

                        pl.TransformBy(Matrix3d.Scaling(0.5, new Point3d(4, 4.25, 0)));
                        // Add the new object to the block table record
                        btr.AppendEntity(pl);
                        trans.AddNewlyCreatedDBObject(pl, true);
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

        [CommandMethod("RotateObject")]
        public static void RotateObject()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            // start a transaction
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                // mirror 연습
                try
                {
                    // open block table for read
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    // open the block table record modelspace for write
                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    // create a polyline
                    using(Polyline pl = new Polyline())
                    {
                        pl.AddVertexAt(0, new Point2d(1, 2), 0, 0, 0);
                        pl.AddVertexAt(1, new Point2d(1, 3), 0, 0, 0);
                        pl.AddVertexAt(2, new Point2d(2, 3), 0, 0, 0);
                        pl.AddVertexAt(3, new Point2d(3, 3), 0, 0, 0);
                        pl.AddVertexAt(4, new Point2d(4, 4), 0, 0, 0);
                        pl.AddVertexAt(5, new Point2d(4, 2), 0, 0, 0);
                        // close the polyline
                        pl.Closed = true;

                        Matrix3d curUCSMatrix = doc.Editor.CurrentUserCoordinateSystem; //현재 좌표계 확인
                        CoordinateSystem3d curUCS = curUCSMatrix.CoordinateSystem3d;
                        // rotate the polyline 45 degrees, around the Z-axis of the current UCS
                        // using a base point of (4,4.25,0)
                        pl.TransformBy(Matrix3d.Rotation(0.7854, curUCS.Zaxis, new Point3d(4, 4.25, 0)));
                        // Add the new object to the block table record
                        btr.AppendEntity(pl);
                        trans.AddNewlyCreatedDBObject(pl, true);


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
        [CommandMethod("MirrorObject")]
        public static void MirrorObject()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            // start a transaction
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                // mirror 연습
                try
                {
                    // open block table for read
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    // open the block table record modelspace for write
                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    // create polyline
                    using(Polyline pl = new Polyline())
                    {
                        pl.AddVertexAt(0, new Point2d(1, 1), 0, 0, 0);
                        pl.AddVertexAt(1, new Point2d(1, 2), 0, 0, 0);
                        pl.AddVertexAt(2, new Point2d(2, 2), 0, 0, 0);
                        pl.AddVertexAt(3, new Point2d(3, 2), 0, 0, 0);
                        pl.AddVertexAt(4, new Point2d(4, 4), 0, 0, 0);
                        pl.AddVertexAt(5, new Point2d(4, 1), 0, 0, 0);
                        // create a bulge
                        pl.SetBulgeAt(1, -2); //1번과 2번 사이 곡선 생성 (buldge 추가)


                        // close the polyline
                        pl.Closed = true;

                        // add the new object to the block table record

                        btr.AppendEntity(pl);
                        trans.AddNewlyCreatedDBObject(pl,true);
                        // mirror object
                        Polyline plMirror = pl.Clone() as Polyline;
                        // change color
                        plMirror.ColorIndex = 5;
                        
                        // define the mirror line
                        Point3d ptFrom = new Point3d(0, 4.25, 0);
                        Point3d ptTo = new Point3d(4, 4.25, 0);

                        Line3d ln = new Line3d(ptFrom, ptTo);
                        // Mirror the polyline across the X axis
                        plMirror.TransformBy(Matrix3d.Mirroring(ln));

                        // add the new object to the block table record

                        btr.AppendEntity(plMirror);
                        trans.AddNewlyCreatedDBObject(plMirror, true);


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
        [CommandMethod("MoveObject")]
        public static void MoveObject()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            // start a transaction
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    // open block table for read
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    // open the block table record modelspace for write
                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    // Create a circle that is at 2,2 with a radius of 0.5
                    using(Circle c1 = new Circle())
                    {
                        c1.Center = new Point3d(2, 2, 0);
                        c1.Radius = 0.5;
                        
                        // Create a matrix and move the circle using a vector
                        Point3d startPt = new Point3d(0, 0, 0);
                        Vector3d destVector = startPt.GetVectorTo(new Point3d(2, 0, 0)); // vectot (2,0,0)생성
                        c1.TransformBy(Matrix3d.Displacement(destVector));

                        // Add the new object to the block table record
                        btr.AppendEntity(c1);
                        trans.AddNewlyCreatedDBObject(c1, true);

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
        [CommandMethod("EraseObject")]
        public static void EraseObject()
        {
            // db랑 doc 선언 
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            // start a transaction
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    // open block table for read
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    // open the block table record modelspace for write
                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    // Poly line 생성 
                    using (Polyline pl = new Polyline())
                    {
                        // vertex index외 속성 지정
                        pl.AddVertexAt(0, new Point2d(2, 4), 0, 0, 0);
                        pl.AddVertexAt(1, new Point2d(4, 2), 0, 0, 0);
                        pl.AddVertexAt(2, new Point2d(6, 4), 0, 0, 0);
                        // add the new object to the block table record
                        btr.AppendEntity(pl);
                        trans.AddNewlyCreatedDBObject(pl, true);
                        // 전체 화면 보여주는 명령어 (Command 창에 그대로 전송)
                        // Poly line 생성 후에 해당 객체를 Zoom In (화면에 꽉차게)
                        doc.SendStringToExecute("._zoom e ", false, false, false);
                        //update the display and display an alert message
                        doc.Editor.Regen();
                        // Message 창 출력
                        Application.ShowAlertDialog("Erase the newly added polyline");
                        pl.Erase(true);
                           
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
        [CommandMethod("MultipleCopy")]
        public static void MutipleCopy()
        {
            // db랑 doc 선언 
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            // start a transaction
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                // try catch 설정
                try
                {
                    // open block table for read
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    // open the block table record modelspace for write
                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    // Original cicle 생성 
                    

                    using (Circle c1 = new Circle())
                    {
                        c1.Center = new Point3d(0, 0, 0);
                        c1.Radius = 5;
                        // the new object BlockTableRecord
                        btr.AppendEntity(c1);
                        trans.AddNewlyCreatedDBObject(c1, true);
                        using (Circle c2 = new Circle())
                        {
                            c2.Center = new Point3d(0, 0, 0);
                            c2.Radius = 7;
                            btr.AppendEntity(c2);
                            trans.AddNewlyCreatedDBObject(c2, true);
                            DBObjectCollection col = new DBObjectCollection();
                            // c1,c2 collection 개체에 추가
                            col.Add(c1);
                            col.Add(c2);

                            // foreach loop
                            // collecton 개체에 들어있는 c1,c2를 꺼내 색변경 후 20만큼 우측으로 이동
                            foreach (Entity acEnt in col)
                            {
                                Entity ent;
                                ent = acEnt.Clone() as Entity;
                                ent.ColorIndex = 1;

                                // create matrix and move each copied 20 units to the rights
                                ent.TransformBy(Matrix3d.Displacement(new Vector3d(20, 0, 0)));
                                // Add newly cloned object
                                btr.AppendEntity(ent);
                                trans.AddNewlyCreatedDBObject(ent, true);

                            }
                            trans.Commit();

                        }
                    }

                }
                catch (System.Exception ex)
                {

                    doc.Editor.WriteMessage("Error" + ex.Message);
                    trans.Abort();
                }
            }
        }
        // Cad Command 창에 입력할 명령어 정의
        [CommandMethod("SingleCopy")]
        // void (리턴 값 없음) 함수 실행
        public static void SingleCopy()
        {
            // db랑 doc 선언 
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            // start a transaction
            using (Transaction trans= db.TransactionManager.StartTransaction())
            {
                // try catch 설정
                try
                {
                    // open block table for read
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    // open the block table record modelspace for write
                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace],OpenMode.ForWrite) as BlockTableRecord;
                    // create a circle that is 2,3, with a radius 4.25
                    using(Circle c1 = new Circle())
                    {
                        c1.Center = new Point3d(2, 3, 0);
                        c1.Radius = 4.25;
                        // Add new object to the block table record
                        btr.AppendEntity(c1);
                        trans.AddNewlyCreatedDBObject(c1, true);
                        //create a copy of the cicle  and change its radius
                        Circle c1Clone = c1.Clone() as Circle;
                        c1Clone.Radius = 1;
                        // add the cloned circle
                        btr.AppendEntity(c1Clone);
                        trans.AddNewlyCreatedDBObject(c1Clone, true);


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
