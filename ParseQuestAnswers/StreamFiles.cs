using System.IO;

namespace ParseQuestAnswers
{
    internal class StreamFiles
    {
        public void CreationFile(string nameFile)
        { 
            StreamWriter sw = new StreamWriter(nameFile);
        }
    }
}
