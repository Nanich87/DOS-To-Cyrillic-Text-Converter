namespace DosToCyrillicTextConverter.Helpers
{
    using System.Text;

    public static class CyrillicHelper
    {
        public static string ConvertString(string input)
        {
            byte[] bytes = Encoding.Default.GetBytes(input);

            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] >= 127 && bytes[i] <= 191)
                {
                    bytes[i] += (byte)64;
                }
            }

            string output = Encoding.Default.GetString(bytes);

            return output;
        }
    }
}