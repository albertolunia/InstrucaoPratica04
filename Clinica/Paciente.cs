namespace Clinica;

public class Paciente: Pessoa {
    private string sexo;
    private List <string> sintomas;

    public List <string> Sintomas {
        get {return sintomas;}
        set {sintomas = value;}
    }
    public string Sexo{
        get {return sexo;}
        set {sexo = value;}
    }
    public Paciente():base(){
        this.sintomas = new List<string>();
    }
    public void pegaDadosPaciente(List <Paciente> pacientes){
    Console.WriteLine($"Digite o nome do paciente:");
    Nome = Console.ReadLine()!;
    this.Nome = Nome;
    Console.WriteLine($"Digite a data de nascimento:");
    DataNascimento = DateTime.Parse(Console.ReadLine()!);
    this.DataNascimento = DataNascimento;
    Console.WriteLine($"Digite o CPF do paciente:");
    CPF = Console.ReadLine()!;
    if(pacientes.Any(paci => paci.CPF == CPF)){
        throw new Exception("Este CPF já existe no sistema");
    } else {
        if ((CPF.Length == 11)&&(CPF.All(char.IsDigit))){
            this.CPF = CPF;
        }
        else{
            throw new Exception("Erro!");
        }
    }
    Console.WriteLine($"Digite o sexo do paciente (feminino/masculino)");
    sexo = Console.ReadLine()!.ToLower();
    if (sexo.Equals("masculino")||sexo.Equals("feminino")){
        this.Sexo = sexo;
    } else {
        throw new Exception("Erro, informe um sexo válido");
    }
    int opcao;
    Console.WriteLine($"O paciente aprsenta algum sintoma? (1 - sim/ 2 - não)");
    opcao = int.Parse(Console.ReadLine()!);
    while (opcao != 2){
    Console.WriteLine($"Digite os sintomas do paciente");
    string novoSintoma = Console.ReadLine()!;
    sintomas.Add(novoSintoma);
    Console.WriteLine($"Deseja adicionar um novo sintoma? 1-sim, 2-não");
    opcao = int.Parse(Console.ReadLine()!);
    }
    this.Sintomas = sintomas;
    
    Console.WriteLine($"Paciente adicionado com sucesso!");
    
    }
}
