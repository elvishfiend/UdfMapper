using SAPbobsCOM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UdfMapper.Mocking
{
    public class FieldsMock : Fields
    {
        public SAPbobsCOM.Field Item(object Index)
        {
            if (Index is string)
            {
                var str = Index as string;
                return FieldCollection.Find(x => x.Name == str);
            }
            
            if (Index is int)
            {
                var num = (int)Index;
                return FieldCollection.Find(x => x.FieldID == num);
            }

            throw new InvalidOperationException("Invalid Index type");
        }

        public IEnumerator GetEnumerator() => FieldCollection.GetEnumerator();

        public int Count => FieldCollection.Count;

        public List<Field> FieldCollection { get; } = new List<Field>();
    }
}
