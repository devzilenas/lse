using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShareEasyModel
{
    public class TokenTypeConfiguration
    {
        public int TokenTypeConfigurationId { get; set; }
        public int TokenTypeId { get; set; }
        public bool Enabled { get; set; }
        public int DefaultValidForDurationDimId { get; set; }
        public int DefaultValidForDuration { get; set; }
    }
}
