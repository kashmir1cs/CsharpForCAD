using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;


namespace CadCsharpExercise01
{
    public class Class1
    {
        // 원 두개 객체 생성하기 
        // 원#1 - 좌표 : (0,0,0), 반지름 : 5, color : red
        // 원#2 - 좌표 : (10,10,0), 반지름 : 2 
        // 원#3 - 좌표 : (30,30,0), 반지름 : 5 ,color : blue
        [CommandMethod("CopyX")]
        public static void CopyExercise()
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
                    using (Circle c1= new Circle())
                    {

                        // 원 두개 객체 생성하기 
                        // 원#1 - 좌표 : (0,0,0), 반지름 : 5, color : red
                        // 원#2 - 좌표 : (10,10,0), 반지름 : 2 
                        // 원#3 - 좌표 : (30,30,0), 반지름 : 5 ,color : blue
                        // circle #1,#2 #3에 대한 속성 지정 및 block table에 추가
                        c1.Center = new Point3d(0, 0, 0);
                        c1.ColorIndex = 1;
                        c1.Radius = 5;

                        btr.AppendEntity(c1);
                        trans.AddNewlyCreatedDBObject(c1, true);
                        Circle c2 = new Circle();
                        c2.Center = new Point3d(10, 10, 0);
                        c2.Radius = 2;
                        btr.AppendEntity(c2);
                        trans.AddNewlyCreatedDBObject(c2, true);
                        Circle c3 = new Circle();
                        c3.Center = new Point3d(30, 30, 0);
                        c3.Radius = 5;
                        c3.ColorIndex = 5;
                        btr.AppendEntity(c3);
                        trans.AddNewlyCreatedDBObject(c3, true);
                        // collection에 추가 
                        DBObjectCollection col = new DBObjectCollection();
                        col.Add(c1);
                        col.Add(c2);
                        col.Add(c3);
                        foreach(Circle cir in col)
                        {
                            if(cir.Radius==2)
                            {
                                Circle c4 = cir.Clone() as Circle; //c2 객체 복사한 새로운 클래스 생성
                                c4.ColorIndex = 3;
                                c4.Radius = 10;
                                // block table record에  새로운 object 추가 
                                btr.AppendEntity(c4);
                                trans.AddNewlyCreatedDBObject(c4, true);

                            }

                        }


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
