namespace ByteBankIO.Models;

public class Cliente
{
    public Cliente(string nome, string cpf, string profissao)
    {
        Nome = nome;
        CPF = cpf;
        Profissao = profissao;
    }

    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Profissao { get; set; }
}
