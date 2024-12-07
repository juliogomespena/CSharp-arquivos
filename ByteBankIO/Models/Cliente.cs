namespace ByteBankIO.Models;

public class Cliente
{
    public Cliente(string nome, string sobrenome, string cpf, string profissao)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        CPF = cpf;
        Profissao = profissao;
    }

    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string CPF { get; set; }
    public string Profissao { get; set; }
}
