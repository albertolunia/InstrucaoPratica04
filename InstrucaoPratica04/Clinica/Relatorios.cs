using System.Runtime.CompilerServices;

namespace Namespace;
public class Relatorios
{
    public static void medicosIdades(List<Medico> medicos){
        Console.WriteLine("Informe a idade mínima do intervalo que deseja observar");
        int idadeMin = Int32.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("Informe a idade máxima do intervalo que deseja observar");
        int idadeMax = Int32.Parse(Console.ReadLine() ?? "100");
        var idadesEntre = medicos.Where(m => m.getIdade() > idadeMin && m.getIdade() < idadeMax).ToList();
        foreach ( var medico in idadesEntre){
            Console.WriteLine($"Nome: {medico.Nome} CPF: {medico.CPF} CRM: {medico.CRM} Idade: {medico.getIdade()}");
        }   
    }

    public static void pacientesIdades(List<Paciente> pacientes){
        Console.WriteLine("Informe a idade mínima do intervalo que deseja observar");
        int idadeMin = Int32.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("Informe a idade máxima do intervalo que deseja observar");
        int idadeMax = Int32.Parse(Console.ReadLine() ?? "100");
        var idadesEntre = pacientes.Where(p => p.getIdade() > idadeMin && p.getIdade() < idadeMax).ToList();
        foreach ( var paciente in idadesEntre){
            Console.WriteLine($"Nome: {paciente.Nome} CPF: {paciente.CPF} Sexo: {paciente.Sexo} Idade: {paciente.getIdade()}");
            Console.WriteLine("Sintomas: ");
            foreach (var s in paciente.Sintomas){
                Console.Write($"{s}\t");
            }
            Console.WriteLine();
        }   
    }

    public static void pacientesSexo(List<Paciente> pacientes){
        Console.WriteLine("Informe o sexo dos pacientes que deseja observar");
        string sexo = (Console.ReadLine() ?? "FEMININO").ToUpper();
        var sexoPacientes = pacientes.Where(p => p.Sexo == sexo).ToList();
        foreach ( var paciente in sexoPacientes){
            Console.WriteLine($"Nome: {paciente.Nome} CPF: {paciente.CPF} Idade: {paciente.getIdade()}");
            Console.WriteLine("Sintomas: ");
            foreach (var s in paciente.Sintomas){
                Console.Write($"{s}\t");
            }
            Console.WriteLine();
        }
    }

    public static void pacientesOrdenado(List<Paciente> pacientes){
        var pacientesOrdenados = pacientes.OrderBy(p => p.Nome).ToList();
        foreach ( var paciente in pacientesOrdenados){
            Console.WriteLine($"Nome: {paciente.Nome} CPF: {paciente.CPF} Sexo: {paciente.Sexo} Idade: {paciente.getIdade()}");
            Console.WriteLine("Sintomas: ");
            foreach (var s in paciente.Sintomas){
                Console.Write($"{s}\t");
            }
            Console.WriteLine();
        }
    }

    public static void pacientesSintoma(List<Paciente> pacientes){
        Console.WriteLine("Informe o sintoma dos pacientes que deseja observar");
        string sintoma = Console.ReadLine() ?? "dor";
        var pacientesSintomas = pacientes.Where(p => p.Sintomas.Exists(s => s.Contains(sintoma)));
        foreach ( var paciente in pacientesSintomas){
            Console.WriteLine($"Nome: {paciente.Nome} CPF: {paciente.CPF} Sexo: {paciente.Sexo} Idade: {paciente.getIdade()}");
            Console.WriteLine("Sintomas: ");
            foreach (var s in paciente.Sintomas){
                Console.Write($"{s}\t");
            }
            Console.WriteLine();
        }
    }

    public static void aniversariantes(List<Paciente> pacientes, List<Medico> medicos){
        Console.WriteLine("Informe qual mês dos aniversariantes que deseja observar (Indique o mês como número)");
        int mes = Int32.Parse(Console.ReadLine() ?? "0");
        var pacientesAniversariantes = pacientes.Where(p => p.dataNascimento.Month == mes).ToList();
        var medicosAniversariantes = medicos.Where(m => m.dataNascimento.Month == mes).ToList();
        Console.WriteLine("Pacientes Aniversariantes:");
        foreach ( var paciente in pacientesAniversariantes){
            Console.WriteLine($"Nome: {paciente.Nome} CPF: {paciente.CPF} Sexo: {paciente.Sexo} Idade: {paciente.getIdade()} Sintomas: {paciente.Sintomas}");
        }
        Console.WriteLine("Médicos Aniversariantes:");
        foreach ( var medico in medicosAniversariantes){
            Console.WriteLine($"Nome: {medico.Nome} CPF: {medico.CPF} CRM: {medico.CRM} Idade: {medico.getIdade()}");
        } 
    }
    public static void atendimentosAbertos(List<Atendimento> atendimentos){
        var atendimentosAbertos = atendimentos.Where(a=> a.Inicio != DateTime.MinValue).ToList().OrderByDescending(a => a.Inicio);
        Console.WriteLine("Atendimentos Em Aberto:");
        foreach ( var atendimento in atendimentosAbertos){
            Console.WriteLine($"Paciente: {atendimento.Paciente.Nome} Médico: {atendimento.MedicoResponsavel.Nome} Data de Início: {atendimento.Inicio}");
        } 
    }
    public static void medicosAtendimento(List<Atendimento> atendimentos, List<Medico> medicos){
        List<(int qtd, Medico medico)> quantidadesMedicos = new List<(int qtd, Medico medico)>();
        foreach (var medico in medicos){
            var quantidade = atendimentos.Where(a => a.MedicoResponsavel == medico && a.Fim != DateTime.MaxValue).Count();
            quantidadesMedicos.Add((quantidade, medico));
        }
        var ordenado = quantidadesMedicos.OrderByDescending(t => t.qtd).ToList();
        foreach(var tupla in ordenado){
            Console.WriteLine($"Médico: {tupla.medico.Nome} Atendimentos concluídos: {tupla.qtd}");
        }
    }
    public static void diagnosticoOuSuspeita(List<Atendimento> atendimentos){
        string palavra;
        Console.WriteLine("Informe qual a palavra que deseja observar nos diagnósticos e suspeitas");
        palavra = Console.ReadLine() ?? "";
        Console.WriteLine("Atendimentos: ");
        if(atendimentos.Exists(a => a.Fim != DateTime.MaxValue)){
            var diagnosticos = atendimentos.Where(a => a.DiagnosticoFinal.Contains(palavra)).ToList();
            foreach(var atendimento in diagnosticos){
                Console.WriteLine($"Paciente: {atendimento.Paciente.Nome} Médico: {atendimento.MedicoResponsavel.Nome} Data: {atendimento.Inicio} Suspeita Inicial: {atendimento.SuspeitaInicial} Diagnóstico Final: {atendimento.DiagnosticoFinal}");
            }
        }
        if(atendimentos.Exists(a => a.Inicio != DateTime.MinValue)){
            var suspeitas = atendimentos.Where(a => a.SuspeitaInicial.Contains(palavra)).ToList();
            foreach(var atendimento in suspeitas){
                Console.WriteLine($"Paciente: {atendimento.Paciente.Nome} Médico: {atendimento.MedicoResponsavel.Nome} Data: {atendimento.Inicio} Suspeita Inicial: {atendimento.SuspeitaInicial} Diagnóstico Final: {atendimento.DiagnosticoFinal}");
            }
        }
    }
    public static void examesMaisUtilizados(List<Atendimento> atendimentos, List<Exame> exames){
        List<(int qtd, Exame exame)> examesQuantidades = new List<(int qtd, Exame exame)>();
        foreach (var ex in exames){
            var quantidade = atendimentos.Where(a => a.Exames.Exists(e => e.exame == ex)).Count();
            examesQuantidades.Add((quantidade, ex));
        }
        var top10 = examesQuantidades.OrderByDescending(e => e.qtd).ToList();
        int i = 0;
        foreach(var tupla in top10){
            Console.WriteLine($"Título: {tupla.exame.Titulo} Quantidade de Pedidos: {tupla.qtd}");
            if(i == 10){
                break;
            }
        }
    }
    
}
