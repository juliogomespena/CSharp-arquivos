using System;
using System.Text;

namespace ByteBankIO.IO;

internal class ByteBankIn
{
    public static List<string> ReadAccountsFromFile(string filePath)
    {
        List<string> accountsList = new();

        using (var fileStream = new FileStream(filePath, FileMode.Open))
        {
            var reader = new StreamReader(fileStream);

            while (!reader.EndOfStream) // Ler todo o arquivo até o fim do fluxo, linha a linha
            {
                var line = reader.ReadLine();
                if (line != null)
                {
                    accountsList.Add(line);
                }
            }

            //readResult = reader.ReadToEnd(); // Ler arquivo inteiro

            //readResult = reader.ReadLine(); // Ler uma linha

            //int firstByte = reader.Read(); // Ler o primeiro byte

            //Modo de leitura controlado por byte
            //var buffer = new byte[1024]; //1kb
            //var bufferControl = -1;
            //var utf8 = new UTF8Encoding();

            //do
            //{
            //    bufferControl = accounts.Read(buffer, 0, buffer.Length);
            //    readResult += utf8.GetString(buffer, 0, bufferControl);

            //} while (bufferControl != 0);         
        }
        return accountsList;
    }
}
