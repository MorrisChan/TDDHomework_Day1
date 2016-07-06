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
            return new List<ProductModel>
            {
                new ProductModel { Id = 1, Cost = 1, Revenue= 11, SellPrice=21 },
                new ProductModel { Id = 2, Cost = 2, Revenue= 12, SellPrice=22 },
                new ProductModel { Id = 3, Cost = 3, Revenue= 13, SellPrice=23 },
                new ProductModel { Id = 4, Cost = 4, Revenue= 14, SellPrice=24 },
                new ProductModel { Id = 5, Cost = 5, Revenue= 15, SellPrice=25 },
                new ProductModel { Id = 6, Cost = 6, Revenue= 16, SellPrice=26 },
                new ProductModel { Id = 7, Cost = 7, Revenue= 17, SellPrice=27 },
                new ProductModel { Id = 8, Cost = 8, Revenue= 18, SellPrice=28 },
                new ProductModel { Id = 9, Cost = 9, Revenue= 19, SellPrice=29 },
                new ProductModel { Id = 10, Cost = 10, Revenue= 20, SellPrice=30 },
                new ProductModel { Id = 11, Cost = 11, Revenue= 21, SellPrice=31 } 
            };
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
            //should be 6, 15, 24, 21
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
            //should be 50, 66, 60
            var expected = GetExpectedSet(11, 11, size);
            //act
            var actual = target.GetSectionResult(GetData(), size, "Revenue");

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}