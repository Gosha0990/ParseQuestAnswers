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
            var resSql = new Context();
            var resSql1 = new TestLinqToSql();
            Console.WriteLine(resSql.ParseSql(connetionstring));
            Console.WriteLine(resSql1.GetResultParseSql(connetionstring));
            Console.ReadLine();
        }
    }
}
