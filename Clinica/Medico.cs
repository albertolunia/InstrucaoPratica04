namespace Clinica;

public class Medico: Pessoa {
    private string crm;

    public string CRM{
        get {return crm;}
        set {crm = value;}
    }
    public void pegaDadosMedico(List <Medico> medicos){

        Console.WriteLine($"Digite o nome do medico:");
        string Nome = Console.ReadLine()!;
        this.Nome = Nome;
        Console.WriteLine($"Digite a data de nascimento:");
        DateTime DataNascimento = DateTime.Parse(Console.ReadLine()!);
        this.DataNascimento = DataNascimento;
        Console.WriteLine($"Digite o CPF (Apenas numeros):");
        string CPF = Console.ReadLine()!;
        if(medicos.Any(medi => medi.CPF == CPF)){

            throw new Exception("Este CPF já existe no sistema");

        } else {
            this.CPF = CPF;
            if ((CPF.Length == 11)&&(CPF.All(char.IsDigit))){}

            else{

                throw new Exception("Erro!");
            }
        }
        Console.WriteLine($"Digite o CRM");
        string CRM = Console.ReadLine()!;
        if(medicos.Any(medi => medi.CRM == CRM)){

            throw new Exception("Este CRM já existe no sistema");
        }
        this.CRM = CRM;
        //medicos.Add(this);
        Console.WriteLine($"Médico adicionado com sucesso!");
    }
}