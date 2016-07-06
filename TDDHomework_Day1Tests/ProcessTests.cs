using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDHomework_Day1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;

namespace TDDHomework_Day1.Tests
{
    [TestClass()]
    public class ProcessTests
    {
        private List<ProductModel> GetData()
        {
            var range = Enumerable.Range(1, 11);

            return range.Select(item =>
            new ProductModel
            {
                Id = item,
                Cost = item,
                Revenue = item + 10,
                SellPrice = item + 20
            }).ToList();
        }

        private List<int> GetExpectedSet(int begin, int end, int size)
        {
            //建立集合
            var range = Enumerable.Range(begin, end);

            var result = new List<int>();
            for (int i = 0; i < range.Count(); i++)
            {                 
                result.Add(range.Skip(i).Take(size).Sum());
                i += size - 1;
            }
            return result;
        }

        [TestMethod()]
        public void Get_a_group_of_3_by_Cost_field_Test()
        {
            //arrange
            var target = new Process();
            var size = 3;
            var expected = GetExpectedSet(1, 11, size);
            //act
            var actual = target.GetSectionResult(GetData(), size, "Cost");

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void Get_a_group_of_4_by_Revenue_field_Test()
        {
            //arrange
            var target = new Process();
            var size = 4;
            var expected = GetExpectedSet(11, 11, size);
            //act
            var actual = target.GetSectionResult(GetData(), size, "Revenue");

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}