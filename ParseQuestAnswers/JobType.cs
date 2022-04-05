using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseQuestAnswers
{
    [Table(Name = "JobType")]
    internal class JobType
    {
        [Column(IsDbGenerated = true)]
        public int Jobid { get; set; }

        [Column(IsDbGenerated = true)]
        public string JobName { get; set; }

    }
}
