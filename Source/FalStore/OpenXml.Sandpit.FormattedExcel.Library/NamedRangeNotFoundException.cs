using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Sandpit.FormattedExcel.Library
{
    public class NamedRangeNotFoundException : ApplicationException
    {
        public NamedRangeNotFoundException(string message) : base(message)
        {
        }

        public NamedRangeNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
