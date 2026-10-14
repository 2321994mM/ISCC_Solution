using System.Collections.Generic;

namespace ISCC.Application.ImCommitteeFinalResult.Dtos
{
    public class CustomOptionLongId
    {
        public long? Value { get; set; }
        public string DisplayText { get; set; }
    }

    public class CustomOptionLongId2
    {

        public long? Value { get; set; }
        public string DisplayText { get; set; }
    }

    public class Record2
    {
        public CustomOptionLongId Record { get; set; }

    }
}
