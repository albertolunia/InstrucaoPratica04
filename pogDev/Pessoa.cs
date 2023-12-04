namespace pogDev;

public class Pessoa{
    protected String nome;
    protected DateTime dataDeNascimento;
    protected string cpf;
    public string Nome{
        get{
            return nome;
        }
        set{
            nome = value;
        }
    }

    public virtual void imprimeInfo(){
        Console.WriteLine($"Nome: {this.Nome}, CPF: {this.Cpf}");
    }

    public int Idade{
        get{
            DateTime hoje = DateTime.Today;
            int idade = hoje.Year - this.dataDeNascimento.Year;

            if (this.dataDeNascimento.Date > hoje.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }
    }

    public DateTime DataDeNascimento{
        get{
            return dataDeNascimento;
        }
        set{
            dataDeNascimento = value;
        }
    }

    public string Cpf{
        get{
        return cpf;
        }set{
            if ((value.Length==11)||value.All(char.IsDigit))
                cpf = value;
            else
                throw new ArgumentException("CPF invalido");
            
        }
    }

    public Pessoa(string nome, string cpf, DateTime dataDeNascimento){
        this.nome = nome;

        if ((cpf.Length==11)&&cpf.All(char.IsDigit))
                this.cpf = cpf;
            else
                throw new ArgumentException("CPF invalido");

        this.dataDeNascimento = dataDeNascimento;
    }
}