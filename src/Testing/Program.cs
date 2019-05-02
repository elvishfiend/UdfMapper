using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var field = new UdfMapper.Mocking.FieldMock
            {
                Name = "U_Test"
            };

            var fields = new UdfMapper.Mocking.FieldsMock();
            
            fields.FieldCollection.Add(field);

            new UdfMapper.ReflectionMapper()
                .MapTo(new { U_Test = "1234" }, fields);

            Debug.Assert((string)field.Value == "1234");
        }
    }
}
