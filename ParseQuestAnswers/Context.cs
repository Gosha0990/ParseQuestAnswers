using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data.Linq;

namespace ParseQuestAnswers
{
    internal class Context
    {
        public string ParseSql(string contextString)
        {
            var file = new StreamWriter("testlinq.txt");
            var db = new DataContext(contextString);
            var dataTime = new DateTime(2022, 3, 1);
            var quest = db.GetTable<QuestAnswers>()                          
                          .Where(n => n.AnswerDate > dataTime)
                          .OrderBy(n => n.EmpDepPos)
                          .GroupBy(n => n.EmpDepNum)                          
                          .Select(n => n);
            string resSql = null;
            string sessionId = null;
            int empDepNum = 0;
            int hell = 0;
            int rack = 0;
            int kitchen = 0;
            int rest = 0;
            foreach (var item in quest)
            {
                foreach (var i in item)
                {
                    if(sessionId == null)
                        sessionId = i.SessionId;
                    if (sessionId != i.SessionId)
                    {                                           
                        switch(i.EmpDepPos)
                        {
                            case 0:
                                hell = hell + 1;
                                break;
                            case 1:
                                rack = rack + 1;
                                break;
                            case 2:
                                kitchen = kitchen + 1;
                                break;
                            case 3:
                                rest = rest + 1;
                                break;
                            default:
                                break;
                        }
                        empDepNum = i.EmpDepNum;
                        sessionId = i.SessionId;
                    }
                }
                resSql = String.Format("Подразделение: {0}, Зал: {1}, Стойка: {2}, Кухня: {3}, Rest: {4}",empDepNum,hell,rack,kitchen,rest);
                hell = 0;
                rack = 0;
                kitchen = 0;
                rest = 0;
                file.WriteLine(resSql);
                file.WriteLine("--------------------------------------------------------");
            }
            
            return "Nice";
        }
    }
}
