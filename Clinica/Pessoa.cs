using System.Security.Cryptography;

namespace Clinica;

public class Pessoa{
    protected string nome, cpf;
    protected DateTime dataNascimento;

    public string Nome{
        get {return nome;}
        set {nome = value;}
    }
    public string CPF{
        get {return cpf;}
        set {cpf = value;}
    }
    public DateTime DataNascimento{
        get {return dataNascimento;}
        set {dataNascimento = value;}
    }
    
}
