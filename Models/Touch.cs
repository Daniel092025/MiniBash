namespace MiniBash.Models
{

    
        public static class Touch
        {
            public static void Run(string path)
            {

                if (string.IsNullOrEmpty(path)) { Console.WriteLine("Touch mangler filnavn"); return; }
                File.Create(path).Close();
            
            }
        }
}