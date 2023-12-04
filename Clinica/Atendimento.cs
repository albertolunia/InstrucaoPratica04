using System.Runtime.CompilerServices;

namespace Clinica;

public class Atendimento{
    private DateTime inicio, fim;
    private string suspeitaInicial, diagnosticoFinal;
    private float valor;
    private List<(Exame, string)> listaExamesResultado;
    private Medico medico;
    private Paciente paciente;

    public List <(Exame, string)> ListaExamesResultado{
        get {return listaExamesResultado;}
        set {listaExamesResultado = value;}
    }
    public DateTime Inicio{
        get {return inicio;}
        set {inicio = value;}
    }
    public DateTime Fim{
        get {return fim;}
        set {fim = value;}
    }
    public string SuspeitaInicial{
        get {return suspeitaInicial;}
        set {suspeitaInicial = value;}
    }
    public string DiagnosticoFinal{
        get {return diagnosticoFinal;}
        set {diagnosticoFinal = value;}
    }
    public float Valor{
        get {return valor;}
        set {valor = value;}
    }
    public void incioAtendimento(List <Atendimento> atendimentos, List<Medico> medicos, List<Paciente> pacientes){

        inicio = DateTime.Now;
        Console.WriteLine($"Digite a suspeita inicial:");
        suspeitaInicial = Console.ReadLine()!;
        Console.WriteLine($"Digite o valor da consulta:");
        valor = float.Parse(Console.ReadLine()!);
        Console.WriteLine($"Digite o CPF do médico que realizará o atendimento");
        string CPF = Console.ReadLine()!;
    
        if(medicos.Any(med => med.CPF == CPF)){
            medico = medicos.Single(med => med.CPF == CPF);
        }
        else{
            throw new Exception("Este médico não existe no sistema");
        }

        Console.WriteLine($"Digite o CPF do paciente que particiipará da consulta");
        string cpf = Console.ReadLine()!;

        if(pacientes.Any(paci => paci.CPF == cpf)){
            paciente = pacientes.Single(med => med.CPF == cpf);
        }
        else{
            throw new Exception("Este paciente não existe no sistema");
        }
        atendimentos.Add(this);
    }
    public void fimAtendimento(List <Atendimento> antendimentos){
        fim = DateTime.Now;
        Console.WriteLine($"Digite o diagnóstico final:");
        diagnosticoFinal = Console.ReadLine()!; 
    }
}
