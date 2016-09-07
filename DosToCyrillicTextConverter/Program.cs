namespace DosToCyrillicTextConverter
{
    using Helpers;
    using System;
    using System.IO;
    using System.Text;

    internal class Program
    {
        public static void Main(string[] args)
        {
            Program.InitConsoleWindow();

            while (true)
            {
                Console.Write("Enter path: ");

                string path = Console.ReadLine();
                string[] files = Directory.GetFiles(path);

                foreach (var file in files)
                {
                    if (File.Exists(file))
                    {
                        StringBuilder output = new StringBuilder();

                        using (StreamReader reader = new StreamReader(file, Encoding.Default))
                        {
                            while (!reader.EndOfStream)
                            {
                                string line = reader.ReadLine();

                                var convertedString = CyrillicHelper.ConvertString(line);

                                output.AppendLine(convertedString);
                            }
                        }

                        string directory = Path.GetDirectoryName(file);
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        string extension = Path.GetExtension(file);

                        File.WriteAllText(string.Format("{0}{1}{2}_converted{3}", directory, Path.DirectorySeparatorChar, fileName, extension), output.ToString(), Encoding.Default);

                        Console.WriteLine(string.Format("File {0}{1} has been successfully converted!", fileName, extension));
                    }
                }
            }
        }

        private static void InitConsoleWindow()
        {
            Console.Title = "DOS To Cyrillic Text Converter v1.0.0";
            Console.OutputEncoding = Encoding.GetEncoding("Cyrillic");
            Console.InputEncoding = Encoding.GetEncoding("Cyrillic");
        }
    }
}