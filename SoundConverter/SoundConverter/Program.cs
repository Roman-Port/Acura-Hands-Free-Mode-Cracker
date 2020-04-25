using System;
using System.IO;

namespace SoundConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = "const unsigned char voicedata_data[][$REPLACE_MAX] PROGMEM = {";
            string output2 = "const unsigned int voicedata_length[] = {";
            int max = 0;
            for(int i = 0; i<10; i++)
            {
                byte[] data = File.ReadAllBytes(@"C:\Users\Roman\Desktop\Voice Test\" + i + ".raw");
                output += "\n{";
                foreach (byte b in data)
                    output += b.ToString() + ",";
                output = output.TrimEnd(',');
                output += "},";
                output2 += data.Length.ToString() + ",";
                if (data.Length > max)
                    max = data.Length;
            }
            output2 = output2.TrimEnd(',') + "};";
            output += "\n};";
            output = output.Replace("$REPLACE_MAX", max.ToString());
            File.WriteAllText("output.txt", output2 + "\n\n" + output);
        }
    }
}
