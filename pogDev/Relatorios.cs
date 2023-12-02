namespace pogDev;

public class Relatorios{
    public static void PacienteIdade(List<Paciente> Pacientes, int idadeInf, int idadeSup){
        Console.WriteLine($"Pacientes com idade entre {idadeInf} a {idadeSup} anos");
        
        List<Paciente> relatorio = new List<Paciente>();
        relatorio = Pacientes.Where(x => (x.Idade>idadeInf)&&(x.Idade<idadeSup)).ToList();
        foreach(Paciente paciente in relatorio){
            paciente.imprimeInfo();
        }
    }

    public static void MedicosIdade(List<Medico> Medicos, int idadeInf, int idadeSup){
        Console.WriteLine($"Medicos com idade entre {idadeInf} a {idadeSup} anos");
        List<Medico> relatorio = new List<Medico>();
        relatorio = Medicos.Where(x => (x.Idade>idadeInf)&&(x.Idade<idadeSup)).ToList();
        foreach(Medico medico in relatorio){
            medico.imprimeInfo();
        }
    }

    public static void PacientesSexo(List<Paciente> Pacientes,string sexo){
        Console.WriteLine($"Pacientes com sexo definido como {sexo}");
        List<Paciente> relatorio = new List<Paciente>();
        relatorio = Pacientes.Where(x => (x.Sexo.Equals(sexo))).ToList();
        foreach(Paciente paciente in relatorio){
            paciente.imprimeInfo();
        }
    }

    public static void PacientesOrdemAlfabetica(List<Paciente> Pacientes){
        Console.WriteLine("Pacientes em Ordem alfabetica");
        
        List<Paciente> relatorio = new List<Paciente>();
        relatorio = Pacientes.OrderBy(x => x.Nome).ToList();
        foreach(Paciente paciente in relatorio){
            paciente.imprimeInfo();
        }
    }

    public static void PacientesComSintomas(List<Paciente> Pacientes,string sintoma){
        Console.WriteLine($"Lista de Pacientes que apresentam o sintoma: {sintoma}");
        List<Paciente> relatorio = new List<Paciente>();
        relatorio = Pacientes.Where(x => x.Sintomas.Any(s => s == sintoma)).ToList();
        foreach(Paciente paciente in relatorio){
            paciente.imprimeInfo();
        }
    }

    public static void AniversariosNoMes(List<Pessoa> Pessoas,int mes){
        Console.WriteLine($"Pacientes e Medicos que fazem aniversario no mes {mes}");
        
        List<Pessoa> relatorio = new List<Pessoa>();
        relatorio = Pessoas.Where(x => x.DataDeNascimento.Month == mes).ToList();
        foreach(Pessoa pessoa in relatorio){
            pessoa.imprimeInfo();
        }
    }
}
