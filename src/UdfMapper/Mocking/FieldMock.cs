using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Text;

namespace UdfMapper.Mocking
{
    public class FieldMock : Field
    {
        public BoYesNoEnum IsNull() => Value == null ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;

        public int SetNullValue()
        {
            Value = null;
            return 0;
        }

        public string Name { get; set; }

        public BoFieldTypes Type { get; set; }

        public int Size { get; set; }

        public object Value { get; set; }

        public string Description { get; set; }

        public string ValidValue { get; set; }

        public ValidValues ValidValues { get; set; }

        public BoFldSubTypes SubType { get; set; }

        public string LinkedTable { get; set; }

        public string DefaultValue { get; set; }

        public BoYesNoEnum Mandatory { get; set; }

        public int FieldID { get; set; }

        public string Table { get; set; }
    }
}
