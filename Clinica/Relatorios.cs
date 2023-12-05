namespace Clinica;
using System;
using System.Collections.Generic;
using System.Linq;

public class Relatorios {
public static void MedicosPorIdade(List<Medico> medicos){
    
        DateTime dataAtual = DateTime.Now;
            Console.WriteLine($"Digite a idade mínima");
            int idadeMinima = int.Parse(Console.ReadLine()!);
            Console.WriteLine($"Digite a idade máxima");
            int idadeMaxima = int.Parse(Console.ReadLine()!);
        var medicosFiltrados = medicos
            .Where(medico => (dataAtual.Year - medico.DataNascimento.Year) >= idadeMinima
                             && (dataAtual.Year - medico.DataNascimento.Year) <= idadeMaxima)
            .OrderBy(medico => medico.Nome)
            .ToList();

        Console.WriteLine($"Relatório de Médicos entre {idadeMinima} e {idadeMaxima} anos:");

        foreach (var medico in medicosFiltrados)
        {
            Console.WriteLine($"Nome: {medico.Nome}, Idade: {dataAtual.Year - medico.DataNascimento.Year} anos, CPF: {medico.CPF}, CRM: {medico.CRM}");
        }
    }

public static void IdadePaciente(List<Paciente> pacientes){

            DateTime dataAtual = DateTime.Now;
            Console.WriteLine($"Digite a idade mínima");
            int idadeMinima = int.Parse(Console.ReadLine()!);
            Console.WriteLine($"Digite a idade máxima");
            int idadeMaxima = int.Parse(Console.ReadLine()!);

            var pacientesFiltrados = pacientes
                .Where(paciente => (dataAtual.Year - paciente.DataNascimento.Year) >= idadeMinima
                                 && (dataAtual.Year - paciente.DataNascimento.Year) <= idadeMaxima)
                .OrderBy(paciente => paciente.Nome);

            Console.WriteLine($"Relatório de Pacientes entre {idadeMinima} e {idadeMaxima} anos:");

            foreach (var paciente in pacientesFiltrados)
            {
                Console.WriteLine($"Nome: {paciente.Nome}, Idade: {(dataAtual.Year - paciente.DataNascimento.Year)} anos");
            }
}

public static void PacientesPorSexo(List<Paciente> pacientes)
{
    Console.Write("Digite o sexo do paciente: ");
    string sexo = Console.ReadLine()!;

    var pacientesPorSexo = pacientes.Where(p => p.Sexo.ToLower() == sexo.ToLower()).ToList();

    Console.WriteLine($"Relatório de Pacientes com o sexo {sexo}:");
    
    foreach (var paciente in pacientesPorSexo)
    {
        Console.WriteLine($"Nome: {paciente.Nome}, Data de nascimento: {paciente.DataNascimento}, CPF: {paciente.CPF}, Sexo: {paciente.Sexo}");

        if (paciente.Sintomas.Any())
        {
            Console.Write("Sintomas: ");
            foreach (var sintoma in paciente.Sintomas)
            {
                Console.Write($"{sintoma}, ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Sem sintomas registrados.");
        }
    }
    
}
public static void PacientesOrdemAlfabetica(List<Paciente> pacientes)
{
    var pacientesOrdenados = pacientes.OrderBy(p => p.Nome).ToList();

    Console.WriteLine("Relatório de Pacientes em Ordem Alfabética:");

    foreach (var paciente in pacientesOrdenados)
    {
        Console.WriteLine($"Nome: {paciente.Nome}, Data de nascimento: {paciente.DataNascimento}, CPF: {paciente.CPF}, Sexo: {paciente.Sexo}");

        if (paciente.Sintomas.Any())
        {
            Console.Write("Sintomas: ");
            foreach (var sintoma in paciente.Sintomas)
            {
                Console.Write($"{sintoma}, ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Sem sintomas registrados.");
        }
    }
}
public static void PacientesPorSintoma(List<Paciente> pacientes)
{
    Console.Write("Digite o texto a ser buscado nos sintomas: ");
    string textoBuscado = Console.ReadLine()!.ToLower();

    var pacientesComSintoma = pacientes
        .Where(p => p.Sintomas.Any(sintoma => sintoma.ToLower().Contains(textoBuscado)))
        .ToList();

    Console.WriteLine($"Relatório de Pacientes cujos sintomas contêm '{textoBuscado}':");

    foreach (var paciente in pacientesComSintoma)
    {
        Console.WriteLine($"Nome: {paciente.Nome}, Data de nascimento: {paciente.DataNascimento}, CPF: {paciente.CPF}, Sexo: {paciente.Sexo}");

        if (paciente.Sintomas.Any())
        {
            Console.Write("Sintomas: ");
            foreach (var sintoma in paciente.Sintomas)
            {
                Console.Write($"{sintoma}, ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Sem sintomas registrados.");
        }
    }
}
public static void AniversariantesDoMes(List<Medico> medicos, List<Paciente> pacientes, int mes)
    {
        Console.WriteLine($"Digite o mês dos aniversários");
        mes = int.Parse(Console.ReadLine()!);
        
        
        var aniversariantes = medicos.Cast<Pessoa>().Concat(pacientes.Cast<Pessoa>())
            .Where(pessoa => pessoa.DataNascimento.Month == mes)
            .OrderBy(pessoa => pessoa.DataNascimento.Day)
            .ThenBy(pessoa => pessoa.Nome)
            .ToList();

        Console.WriteLine($"Relatório de Médicos e Pacientes Aniversariantes do Mês {mes}:");

        foreach (var pessoa in aniversariantes)
        {
            if (pessoa is Medico medico)
            {
                Console.WriteLine($"Médico - Nome: {medico.Nome}, Data de Nascimento: {medico.DataNascimento:dd/MM}, CPF: {medico.CPF}, CRM: {medico.CRM}");
            }
            else if (pessoa is Paciente paciente)
            {
                Console.WriteLine($"Paciente - Nome: {paciente.Nome}, Data de Nascimento: {paciente.DataNascimento:dd/MM}, CPF: {paciente.CPF}, Sexo: {paciente.Sexo}");

                if (paciente.Sintomas.Any())
                {
                    Console.Write("Sintomas: ");
                    foreach (var sintoma in paciente.Sintomas)
                    {
                        Console.Write($"{sintoma}, ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Sem sintomas registrados.");
                }
            }
        }
}
public static void AtendimentosEmAberto(List<Atendimento> atendimentos)
    {
        Console.WriteLine("Relatório de Atendimentos em Aberto (sem finalizar)");

        var atendimentosEmAberto = atendimentos.Where(x => !x.Finalizado).OrderByDescending(x => x.Inicio);

        foreach (var atendimento in atendimentosEmAberto)
        {
            Console.WriteLine($"Data de Início: {atendimento.Inicio}");
            Console.WriteLine($"Suspeita Inicial: {atendimento.SuspeitaInicial}");
            Console.WriteLine($"Médico: {atendimento._medico.Nome} (CRM: {atendimento._medico.CRM})");
            Console.WriteLine($"Paciente: {atendimento._paciente.Nome} (CPF: {atendimento._paciente.CPF})");
            Console.WriteLine("Exames:");

            foreach (var exameResultado in atendimento.ExamesResultado)
            {
                Console.WriteLine($"- {exameResultado.Item1.Titulo}: {exameResultado.Item2}");
            }

            Console.WriteLine();
        }
    }
    public static void MedicosPorAtendimentosConcluidos(List<Atendimento> atendimentos, List<Medico> medicos)
    {
        Console.WriteLine("Relatório de Médicos em Ordem Decrescente da Quantidade de Atendimentos Concluídos");

        var medicoAtendimentosConcluidos = medicos.OrderByDescending(medico =>
            atendimentos.Count(atendimento => atendimento._medico == medico && atendimento.Finalizado)
        );

        foreach (var medico in medicoAtendimentosConcluidos)
        {
            var atendimentosConcluidos = atendimentos.Count(atendimento => atendimento._medico == medico && atendimento.Finalizado);

            Console.WriteLine($"Médico: {medico.Nome} (CRM: {medico.CRM})");
            Console.WriteLine($"Atendimentos Concluídos: {atendimentosConcluidos}");
            Console.WriteLine();
        }
    }
    public static void AtendimentosPorPalavraChave(List<Atendimento> atendimentos){
        Console.WriteLine($"Digite a palavra chave:");
        string palavraChave =  Console.ReadLine()!;
        
        Console.WriteLine($"Relatório de Atendimentos com Palavra-chave: '{palavraChave}'");

        var atendimentosFiltrados = atendimentos.Where(atendimento =>
            atendimento.SuspeitaInicial.Contains(palavraChave, StringComparison.OrdinalIgnoreCase) ||
            atendimento.DiagnosticoFinal.Contains(palavraChave, StringComparison.OrdinalIgnoreCase)
        );

        foreach (var atendimento in atendimentosFiltrados)
        {
            Console.WriteLine($"Paciente: {atendimento._paciente.Nome} (CPF: {atendimento._paciente.CPF})");
            Console.WriteLine($"Médico: {atendimento._medico.Nome} (CRM: {atendimento._medico.CRM})");
            Console.WriteLine($"Data de Início: {atendimento.Inicio}");
            Console.WriteLine($"Suspeita Inicial: {atendimento.SuspeitaInicial}");
            Console.WriteLine($"Diagnóstico Final: {atendimento.DiagnosticoFinal}");
            Console.WriteLine();
        }
    }
    public static void Top10Exames(List<Atendimento> atendimentos)
    {
        Console.WriteLine("Relatório dos 10 Exames Mais Utilizados:");
        var todosExames = atendimentos.SelectMany(atendimento => atendimento.ExamesResultado.Select(exame => exame.Item1));
        var examesAgrupados = todosExames.GroupBy(exame => exame)
        .Select(grupo => new { Exame = grupo.Key, Quantidade = grupo.Count() })
        .OrderByDescending(item => item.Quantidade)
        .Take(10);

        foreach (var item in examesAgrupados)
        {
            Console.WriteLine($"Exame: {item.Exame.Titulo} - Quantidade: {item.Quantidade}");
        }
    }
public static void menuRelatorios(List<Atendimento> atendimentos, List<Exame> exames, List<Paciente> pacientes, List<Medico> medicos)
        {
            string escolha = "";
            while (escolha!="0")
            {
                Console.WriteLine("------Menu de Relatórios------");
                Console.WriteLine("1. Médicos com idade entre dois valores.");
                Console.WriteLine("2. Pacientes com idade entre dois valores.");
                Console.WriteLine("3. Pacientes do sexo informado pelo usuário.");
                Console.WriteLine("4. Pacientes em ordem alfabética.");
                Console.WriteLine("5. Pacientes cujos sintomas contenham texto informado pelo usuário.");
                Console.WriteLine("6. Médicos e Pacientes aniversariantes do mês informado.");
                Console.WriteLine("7. Atendimentos em aberto (sem finalizar) em ordem decrescente pela data de início.");
                Console.WriteLine("8. Médicos em ordem decrescente da quantidade de atendimentos concluídos.");
                Console.WriteLine("9. Atendimentos cuja suspeita ou diagnóstico final contenham determinada palavra.");
                Console.WriteLine("10. Os 10 exames mais utilizados nos atendimentos.");
                Console.WriteLine("0. Sair");

                Console.Write("Escolha uma opção: ");
                escolha = Console.ReadLine()!;

                switch (escolha)
                {
                    case "1":
                        Relatorios.MedicosPorIdade(medicos);
                        break;
                    case "2":

                        Relatorios.IdadePaciente(pacientes);
                        break;
                    case "3":
                        
                        Relatorios.PacientesPorSexo(pacientes);
                        break;
                    case "4":
                        
                        Relatorios.PacientesOrdemAlfabetica(pacientes);
                        break;
                    case "5":
                       
                        Relatorios.PacientesPorSintoma(pacientes);
                        break;
                    case "6":
                       
                        Relatorios.AniversariantesDoMes(medicos, pacientes, 5);
                        break;
                    case "7":
                        
                        Relatorios.AtendimentosEmAberto(atendimentos);
                        break;
                    case "8":
                        
                        Relatorios.MedicosPorAtendimentosConcluidos(atendimentos, medicos);
                        break;
                    case "9":
                        
                        Relatorios.AtendimentosPorPalavraChave(atendimentos);
                        break;
                    case "10":
                        
                        Relatorios.Top10Exames(atendimentos);
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
}
