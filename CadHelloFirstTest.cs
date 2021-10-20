using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;


// CAD API 연습 Test 
// 참조 추가 : 1) AcCoreMgd.dll 2) AcDbMgd.dll 3) AcMgd.dll
namespace CadHello
{
    public class LeaveTheDoorOpen
    {
        [CommandMethod("RPA_HELLO_LONG")]
        public void Hello1()
        {
            var doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            var editor = doc.Editor;
            for (int i =1;i<100001;i++)
            {
                editor.WriteMessage("\n {0}",i); // 화면에 출력하기
            }
            editor.WriteMessage("\nDLL 동작완료");
            
        }
        [CommandMethod("RPA_HELLO_SHORT")]
        public void Hello2()
        {
            var doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            var editor = doc.Editor;
            for (int i = 1; i < 1001; i++)
            {
                editor.WriteMessage("\n {0}", i); // 화면에 출력하기
            }
            editor.WriteMessage("\nDLL 동작완료");

        }
    }
}
