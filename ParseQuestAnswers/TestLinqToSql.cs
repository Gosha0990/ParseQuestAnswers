using System;
using System.Data.Linq;
using System.IO;
using System.Linq;

//Изучить Join в Linq to SQL
namespace ParseQuestAnswers
{
    internal class TestLinqToSql
    {
        public string GetResultParseSql(string connectingString)
        {
            var file = new StreamWriter("TestSqlToLibq.txt");
            var dbQuest = new DataContext(connectingString);
            var dbJob = new DataContext(connectingString);
            var dataTime = new DateTime(2022, 03, 01);
            var quest =
                (from d in dbQuest.GetTable<QuestAnswers>()                
                where (d.AnswerDate > dataTime)
                group d by new { d.EmpDepNum, d.EmpDepPos} into groups
                orderby groups.Key.EmpDepNum, groups.Key.EmpDepPos
                select new { groups.Key.EmpDepNum, groups.Key.EmpDepPos, Count = groups.Count()/12});            
            foreach (var group in quest)
            {
                file.WriteLine(group);
                file.WriteLine("___________________________________________");                
            }  
            file.Close();
            
            return "Nice";
        }
    }
}
