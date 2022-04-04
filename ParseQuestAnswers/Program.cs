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
            Console.WriteLine(resSql.ParseSql(connetionstring));
            Console.ReadLine();
        }
    }
}
