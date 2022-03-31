using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Linq;
using System.IO;

namespace ParseQuestAnswers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connetionstring = @"Data Source=S2010;Initial Catalog=Voiting;Persist Security Info=True;User ID=geyorgy;Password=rYweGhf435!";
            var stFile = new StreamWriter("res.txt");
            DataContext db = new DataContext(connetionstring);
            DateTime dateTime = new DateTime(2022, 3, 1);
            var query = from u in db.GetTable<QuestAnswers>()
                        where u.AnswerDate > dateTime
                        orderby u.EmpDepNum                                             
                        select u;

            var res = new QuestAnswers();
            int i = 1;
            int num = 0;
            foreach (var item in query)
            {
                
                if (num == item.EmpDepNum)
                { 
                    i = i + 1;
                    
                }
                if(num!=item.EmpDepNum)
                {                    
                    num = item.EmpDepNum;
                    i = i / 12;
                    stFile.WriteLine(item.EmpDepNum +"\t" + i);
                    i = 1;
                }
            }
            Console.WriteLine("Good");


            Console.ReadLine();
        }
    }
}
