using System.Runtime.CompilerServices;

namespace Clinica;

public class Atendimento{
    private DateTime inicio, fim;
    private string suspeitaInicial, diagnosticoFinal;
    private float valor;
    private List<(Exame, string)> examesResultado;
    private Medico medico;
    private Paciente paciente;
    private Boolean finalizado;

    public Paciente _paciente{
        get {return paciente;}
        set {paciente = value;}
    }
     public Medico _medico{
        get {return medico;}
        set {medico = value;}
    }
    public Boolean Finalizado{
        get {return finalizado;}
        set {finalizado = value;}
    }
    public List <(Exame, string)> ExamesResultado{
        get {return examesResultado;}
        set {examesResultado = value;}
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
    public void inicioAtendimento(List <Atendimento> atendimentos, List<Medico> medicos, List<Paciente> pacientes){
        Finalizado = false;
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

        Console.WriteLine($"Digite o CPF do paciente que participará da consulta");
        string cpf = Console.ReadLine()!;

        if(pacientes.Any(paci => paci.CPF == cpf)){
            paciente = pacientes.Single(med => med.CPF == cpf);
        }
        else{
            throw new Exception("Este paciente não existe no sistema");
        }
        atendimentos.Add(this);
    }

    public void final(List<string> resultados, string diagnostico){
        int i = 0;
        List<(Exame,string)> examesComResultados = new List<(Exame, string)>();
        foreach((Exame,string) exame in this.examesResultado){
            examesComResultados.Add((exame.Item1, resultados[i]));
            i++;
        }
        this.ExamesResultado = examesComResultados;
        this.Finalizado = true;
        this.Fim = DateTime.Now;
        this.DiagnosticoFinal = diagnostico;
    }

    public static void FinalizarAtendimento(List<Atendimento> atendimentos)
        {
            atendimentos = atendimentos.Where(x => !x.Finalizado).ToList();

            Console.WriteLine("Digite o CPF do paciente:");
            string cpfPaciente = Console.ReadLine()!;

            if (atendimentos.Any(x => x.paciente.CPF == cpfPaciente))
            {
                atendimentos = atendimentos.Where(x => x.paciente.CPF == cpfPaciente).ToList();

                Atendimento atendimento;
                Console.WriteLine("Digite o CRM do médico:");
                string crmMedico = Console.ReadLine()!;

                if (atendimentos.Any(x => x.medico.CRM == crmMedico))
                {
                    atendimentos = atendimentos.Where(x => x.medico.CRM == crmMedico).ToList();

                    atendimento = atendimentos.Single();

                    List<string> resultados = new List<string>();
                    string resultado;
                    for(int i=0;i<atendimento.ExamesResultado.Count();i++){
                        Console.WriteLine($"Digite o resultado do exame {atendimento.ExamesResultado[i].Item1.Titulo}:");
                        resultado = Console.ReadLine()!;
                        resultados.Add(resultado);
                    }
                    foreach ((Exame, string) exame in atendimento.ExamesResultado)
                    {
                        Console.WriteLine($"Digite o resultado do exame {exame.Item1.Titulo}:");
                        resultado = Console.ReadLine()!;
                        resultados.Add(resultado);
                    }

                    Console.WriteLine("Dado os resultados, digite o diagnóstico:");
                    string diagnostico = Console.ReadLine()!;

                    try
                    {
                        atendimento.final(resultados, diagnostico);
                        Console.WriteLine("Atendimento finalizado com sucesso.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao finalizar o atendimento: {ex.Message}");
                    }
                }
                else
                {
                    throw new Exception("Médico não possui atendimentos.");
                }
            }
            else
            {
                throw new Exception("Paciente não possui atendimentos.");
            }
        }
}
