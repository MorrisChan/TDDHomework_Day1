using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDHomework_Day1
{
    internal class Process
    {
        internal List<int> GetSectionResult<T>(List<T> data, int size, string field)
        {
            var dataOfField = data.Select(item =>
                { 
                    var property = item.GetType().GetProperty(field);                    
                    return property.GetValue(item) as int?;
                }             
            );

            var result = new List<int>();
            for (int i = 0; i < dataOfField.Count(); i++)
            {
                result.Add(dataOfField.Skip(i).Take(size).Select(item => item.GetValueOrDefault()).Sum());
                i += size - 1;
            }
            return result;            
        }
    }
}
