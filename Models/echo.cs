namespace MiniBash.Models
{
    public class Echo
    {
        public static void Repeat(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine("No argument was included");
            }
        }
    }
}