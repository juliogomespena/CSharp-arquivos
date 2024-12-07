namespace ByteBankIO.Models;

public class ContaCorrente
{
    public ContaCorrente(int agencia, int numero, decimal saldo, Cliente titular)
    {
        Agencia = agencia;
        Numero = numero;
        Saldo = saldo;
        Titular = titular;
    }

    public int Numero { get; }
    public int Agencia { get; }
    public decimal Saldo { get; private set; }
    public Cliente Titular { get; set; }

    public static ContaCorrente CreateAccount(string account)
    {
        //Exemplo account: 207,1211,845.22,Thiago Monteiro,53280146933,Esteticista
        string[] accountInfo = account.Split(',');

        var agenciaInfo = int.TryParse(accountInfo[0], out int agencia) ? agencia : throw new ArgumentException($"Número de agência \"{accountInfo[0]}\" inválido!");
        var numeroInfo = int.TryParse(accountInfo[1], out int numero) ? numero : throw new ArgumentException($"Número de conta \"{accountInfo[1]}\" inválido!");
        var saldoInfo = decimal.TryParse(accountInfo[2].Replace('.', ','), out decimal saldo) ? saldo : throw new ArgumentException($"Saldo para conta/agência {numero}/{agencia} inválido!");
        var nome = accountInfo[3].Split(' ', 2);
        var cpf = accountInfo[4];
        var profissao = accountInfo[5];

        return new ContaCorrente(agencia, numero, saldo, new Cliente(nome[0],nome[1], cpf, profissao));
    }

    public void Deposit(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("Valor de deposito deve ser maior que zero.", nameof(valor));
        }

        Saldo += valor;
    }

    public void Withdrawn(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("Valor de saque deve ser maior que zero.", nameof(valor));
        }

        if (valor > Saldo)
        {
            throw new InvalidOperationException("Saldo insuficiente.");
        }

        Saldo += valor;
    }

    public override string ToString()
    {
        return $"- Titular: {Titular.Nome} {Titular.Sobrenome}\n" +
               $"- CPF: {Titular.CPF}\n" +
               $"- Profissão: {Titular.Profissao}\n" +
               $"- Número da conta: {Numero}\n" +
               $"- Agência: {Agencia}\n" +
               $"- Saldo: R${Saldo.ToString("F2")}\n";
    }
}
