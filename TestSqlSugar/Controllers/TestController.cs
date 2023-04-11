using Microsoft.AspNetCore.Mvc;
using StringUtils;
using TestSqlSugar.Models.TestList;

namespace TestSqlSugar.Controllers
{
    public class TestController : Controller
    {
        public IActionResult TestS()
        {
            string[] strings= { "123" ,"11","22"};
            string s = String.Join(";", strings);
            return View("TestS",s);
        }

        public IActionResult TestList()
        {
            List<TestA> tas = new List<TestA>()
            {
                new TestA(){id=1,name="张三",age=18,ClassId=1},
                new TestA(){id=2,name="李四",age=28,ClassId=2},
                new TestA(){id=3,name="王五",age=20,ClassId=1},
                new TestA(){id=4,name="赵六",age=25,ClassId=1},
            };
            List<TestB> tbs = new List<TestB>()
            {
                new TestB(){ClassId=1,CName="201教室"},
                new TestB(){ClassId=2,CName="202教室"},
                new TestB(){ClassId=3,CName="203教室"},
                new TestB(){ClassId=4,CName="204教室"},
            };

            var ab = (from a in tas
                     join b in tbs
                     on a.ClassId equals b.ClassId
                     select new TestA
                     {
                         id = a.id,
                         name = a.name,
                         age = a.age,
                         ClassId = a.ClassId,
                         //CName=b.CName
                     }).ToList();
            return View("TestList",ab);
        }
    }
}
