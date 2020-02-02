using System;
using System.Collections.Generic;
using System.Text;
using Xam.SqlHelper.Attributes;

namespace Xam.SqlHelper.Sample.Models
{
    public class ExampleItem
    {
        public int Id { get; set; }

        [IncludeField]
        public string Title { get; set; }

        [IncludeField]
        public DateTime CreatedDate { get; set; }

        public int OtherItemId { get; set; }
    }
}
