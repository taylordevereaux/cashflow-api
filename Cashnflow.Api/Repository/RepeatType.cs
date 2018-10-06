using System;
using System.Collections.Generic;

namespace Cashnflow.Api.Repository
{
    public partial class RepeatType
    {
        public RepeatType()
        {
            RepeatTransaction = new HashSet<RepeatTransaction>();
        }

        public int RepeatTypeId { get; set; }
        public string RepeatTypeConstant { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<RepeatTransaction> RepeatTransaction { get; set; }
    }
}
