using ByteBankIO.IO;
using ByteBankIO.Models;


namespace ByteBankIO;

class Program
{
    static void Main(string[] args)
    {
        string? fileName;
        List<string> accountsInfo;
        List<ContaCorrente> accounts = new();

        #region Reading accounts from file
        Console.Write("Digite o nome do arquivo de contas: ");

        while (true)
        {
            fileName = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(fileName))
            {
                Console.WriteLine("Digite um nome para o arquivo ou 'sair' para encerrar!");
                continue;
            }
            if (fileName.ToLower() == "sair")
                Environment.Exit(0);

            try
            {
                accountsInfo = ByteBankIn.ReadAccountsFromFile(fileName);
                Console.WriteLine("Leitura realizada com sucesso!\n");
                break;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Arquivo não encontrado! Verifique o nome do arquivo e tente novamente ou digite 'sair' para encerrar.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Acesso ao arquivo negado! Verifique as permissões e tente novamente ou digite 'sair' para encerrar.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}. Tente novamente ou digite 'sair' para encerrar.");
            }
        }
        #endregion

        #region Converting accounts info strings to objects
        foreach (string account in accountsInfo)
        {
            try
            {
                accounts.Add(ContaCorrente.CreateAccount(account));
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"Erro ao criar conta corrente! {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }
        }
        Console.WriteLine("Contas criadas com sucesso!\n");
        #endregion

        foreach (var account in accounts)
        {
            Console.WriteLine(account.ToString());
            Console.WriteLine();
        }
    }
}