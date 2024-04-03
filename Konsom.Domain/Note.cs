using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsom.Domain
{
    public class Note : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

        public Guid TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
