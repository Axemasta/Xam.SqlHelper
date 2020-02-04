using System;
using System.Collections.Generic;
using System.Text;
using Xam.SqlHelper.Attributes;

namespace Xam.SqlHelper.Sample.Models
{
    public class ExampleItem
    {
        public int Id { get; set; }

        
        public string Title { get; set; }

        [ExcludeField]
        public DateTime CreatedDate { get; set; }

        [ExcludeField]
        public int OtherItemId { get; set; }
    }
}
