namespace Dos2Cyr
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    class Program
    {
        private static void Init()
        {
            Console.Title = "Dos 2 Cyrillic";
            Console.OutputEncoding = System.Text.Encoding.GetEncoding("Cyrillic");
            Console.InputEncoding = System.Text.Encoding.GetEncoding("Cyrillic");
        }

        static void Main(string[] args)
        {
            Program.Init();

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
                                byte[] bytes = System.Text.Encoding.Default.GetBytes(line);

                                for (int i = 0; i < bytes.Length; i++)
                                {
                                    if (bytes[i] >= 127 && bytes[i] <= 191)
                                    {
                                        bytes[i] += (byte)64;
                                    }
                                }

                                var convertedString = System.Text.Encoding.Default.GetString(bytes);

                                output.AppendLine(convertedString);
                            }
                        }

                        string directory = Path.GetDirectoryName(file);
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        string extension = Path.GetExtension(file);

                        File.WriteAllText(directory + Path.DirectorySeparatorChar + fileName + "_converted" + extension, output.ToString(), Encoding.Default);

                        Console.WriteLine(string.Format("File {0}{1} has been successfully converted!", fileName, extension));
                    }
                }
            }
        }
    }
}