using ByteBankIO.Models;
using System.Text;

namespace ByteBankIO.IO;

internal class ByteBankOut
{
    public static string CreateAccountsFile(List<ContaCorrente> accounts)
    {
        DateTime now = DateTime.Now;
        var filePath = $"accounts{now.ToString("dd-MM-yyyy-HH-mm")}.csv";

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        using (var streamWriter = new StreamWriter(fileStream))
        {
            foreach (var account in accounts)
            {
                string fileLine = $"{account.Agencia},{account.Numero},{account.Saldo},{account.Titular.Nome} {account.Titular.Sobrenome},{account.Titular.CPF},{account.Titular.Profissao}";
                streamWriter.WriteLine(fileLine);
            }
        }
        return filePath;
    }
}
