using IhkObserver.Observer.Classes;
using IhkObserver.Text.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IhkObserver.Text.Tests.UnitTests
{
    [TestClass]
    class ResultReadWriterTests
    {
        [TestMethod]
        public async Task WriteAndRead()
        {
            List<SubjectMarks> marks = new List<SubjectMarks>
            {
                new SubjectMarks
                {
                    Mark = 1,
                    Points = 12,
                    Subject = "Einszweidrei"
                },

                new SubjectMarks
                {
                    Mark = 2,
                    Points = 63,
                    Subject = "Dei Muada"
                }
            };

            ResultReadWriter readWriter = new ResultReadWriter();
            readWriter.Write(marks);

            IEnumerable<SubjectMarks> results = await readWriter.ReadAsync();
            Assert.AreEqual(marks.Count, results.Count());
            foreach (var item in results)
            {
                Assert.IsTrue(marks.Where(a => a.Mark == item.Mark && a.Points == item.Points && a.Subject == item.Subject).Count() == 1);
            }
        }
    }
}
