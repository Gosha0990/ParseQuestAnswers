using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseQuestAnswers
{
    [Table(Name = "QuestAnswers")]
    internal class QuestAnswers
    {
        [Column( IsDbGenerated = true)]
        public int EmpDepNum { get; set; }
        [Column(IsDbGenerated =true)]
        public int EmpDepPos { get; set; }
        [Column(IsPrimaryKey = true)]
        public DateTime AnswerDate { get; set; }  
        [Column]
        public string SessionId { get; set; }
    }
}
