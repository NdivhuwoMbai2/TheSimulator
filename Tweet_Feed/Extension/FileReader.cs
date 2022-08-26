using System.Text;

namespace Tweet_Feed.Extension
{ 
    public static class FileReader
    {
        public static List<string> ReadFile(string path)
        {
            try
            {
                using (var sr = new StreamReader(path, Encoding.ASCII))
                {
                    List<string> list=new List<string>();
                    var line = sr.ReadLine();
                    while (line != null)
                    {
                        list.Add(line);
                        line = sr.ReadLine();
                    }
                    sr.Close();
                    return list;
                } 
            }
            catch (Exception e)
            {
                throw new Exception("Exception: " + e.Message);
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                //add logger
                Console.WriteLine("Executing finally block.");
            }
        }
        public static string[] SplitFeed(string line, string separator)
        {
            return line.Split(separator);
        }
    } 
}