namespace pogDev;

public class Relatorios{
    public static void pacienteIdade(List<Paciente> Pacientes){
        Console.WriteLine("Digite a idade minima");
        int idadeInf = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Digite a idade maxima");
        int idadeSup = int.Parse(Console.ReadLine()!);
        if(idadeInf>idadeSup){
            throw new Exception("Idade minima maior que a idade maxima");
        }
        Console.WriteLine($"Pacientes com idade entre {idadeInf} a {idadeSup} anos");
        
        List<Paciente> relatorio = new List<Paciente>();
        relatorio = Pacientes.Where(x => (x.Idade>=idadeInf)&&(x.Idade<=idadeSup)).ToList();
        foreach(Paciente paciente in relatorio){
            paciente.imprimeInfo();
        }
    }

    public static void medicosIdade(List<Medico> Medicos){
        Console.WriteLine("Digite a idade minima");
        int idadeInf = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Digite a idade maxima");
        int idadeSup = int.Parse(Console.ReadLine()!);
        if(idadeInf>idadeSup){
            throw new Exception("Idade minima maior que a idade maxima");
        }
        Console.WriteLine($"Medicos com idade entre {idadeInf} a {idadeSup} anos");
        List<Medico> relatorio = new List<Medico>();
        relatorio = Medicos.Where(x => (x.Idade>idadeInf)&&(x.Idade<idadeSup)).ToList();
        foreach(Medico medico in relatorio){
            medico.imprimeInfo();
        }
    }

    public static void pacientesSexo(List<Paciente> Pacientes){
        Console.WriteLine($"Digite o sexo que deseja verificar");
        string sexo = Console.ReadLine()!;
        Console.WriteLine($"Pacientes com sexo definido como {sexo}");
        List<Paciente> relatorio = new List<Paciente>();
        relatorio = Pacientes.Where(x => (x.Sexo.Equals(sexo))).ToList();
        foreach(Paciente paciente in relatorio){
            paciente.imprimeInfo();
        }
    }

    public static void pacientesOrdemAlfabetica(List<Paciente> Pacientes){
        Console.WriteLine("Pacientes em Ordem alfabetica");

        List<Paciente> relatorio = new List<Paciente>();
        relatorio = Pacientes.OrderBy(x => x.Nome).ToList();
        foreach(Paciente paciente in relatorio){
            paciente.imprimeInfo();
        }
    }

    public static void pacientesComSintomas(List<Paciente> Pacientes){
        Console.WriteLine($"Digite o sintoma que deseja verificar");
        string sintoma = Console.ReadLine()!;
        List<Paciente> relatorio = new List<Paciente>();
        relatorio = Pacientes.Where(x => x.Sintomas.Any(s => s == sintoma)).ToList();
        foreach(Paciente paciente in relatorio){
            paciente.imprimeInfo();
        }
    }

    public static void aniversariosNoMes(List<Pessoa> Pessoas){
        Console.WriteLine("Digite o numero do mês: ");
        int mes = int.Parse(Console.ReadLine()!);
        Console.WriteLine($"Pacientes e Medicos que fazem aniversario no mes {mes}");
        
        List<Pessoa> relatorio = new List<Pessoa>();
        relatorio = Pessoas.Where(x => x.DataDeNascimento.Month == mes).ToList();
        foreach(Pessoa pessoa in relatorio){
            pessoa.imprimeInfo();
        }
    }


    public static void atendimentosEmAberto(List<Atendimento> Atendimentos){
        List<Atendimento> AtendimentosEmAberto = Atendimentos.Where(x => !x.Finalizada).ToList();
        List<Atendimento> relatorio = AtendimentosEmAberto.OrderBy(x => x.Inicio).ToList();
        foreach(Atendimento atendimento in relatorio){
            atendimento.imprimeAtendimentoAberto();
        }
    }

    public static void medicosQuantidadeAtendimentos(List<Atendimento> Atendimentos, List<Medico> Medicos){
        Atendimentos = Atendimentos.Where(x => x.Finalizada).ToList();
        List<(int, Medico)> atendimentosPorMedico = new List<(int,Medico)>();
        foreach(Medico medico in Medicos){
            int quantidade  = Atendimentos.Where( x => x.MedicoAtendente.Cpf == medico.Cpf).Count();
            atendimentosPorMedico.Add((quantidade, medico));
        }
        List<(int, Medico)> relatorio = new List<(int, Medico)>();
        relatorio = atendimentosPorMedico.OrderBy(x => -x.Item1).ToList();
        foreach((int, Medico) quantidadeMedico in atendimentosPorMedico){
            Console.Write($"Num Atendimentos - {quantidadeMedico.Item1}, ");
            quantidadeMedico.Item2.imprimeInfo();
        }
    }

    public static void verificaSuspeitaDiagnostico(List<Atendimento> Atendimentos){
        Console.WriteLine($"Digite a palavra que deseja procurar");
        string palavra = Console.ReadLine()!;
        List<Atendimento> relatorio = Atendimentos.Where(x => (x.Diagnostico == palavra)||(x.Suspeita == palavra)).ToList();
        foreach (Atendimento atendimento in relatorio){
            atendimento.imprimeAtendimentoAberto();
        }
        
    } 

    public static void top10Exames(List<Atendimento> Atendimentos, List<Exame> Exames){
        List<(int, Exame)> examesPorAtendimento = new List<(int,Exame)>();
        foreach(Exame exame in Exames){
            int quantidade = 0;
            foreach(Atendimento atendimento in Atendimentos){
                if(atendimento.ExamesResultados.Any(x => x.Item1.Nome == exame.Nome))
                    quantidade++;
            }    
            examesPorAtendimento.Add((quantidade,exame));        
        }
        List<(int,Exame)> relatorio = examesPorAtendimento.OrderBy(x => -x.Item1).ToList();
        for (int i=0;(i<relatorio.Count())||(i<10);i++){
            Console.WriteLine($"{i+1} - Num de solicitacoes: {relatorio[i].Item1}, Nome do exame: {relatorio[i].Item2.Nome}");
        }
    }

    public static void menuRelatorios(List<Paciente> pacientes, List<Medico> medicos, List<Atendimento> atendimentos, List<Exame> exames)
    {
        int opcao;
        do
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Pacientes por idade");
            Console.WriteLine("2 - Médicos por idade");
            Console.WriteLine("3 - Pacientes por sexo");
            Console.WriteLine("4 - Pacientes em ordem alfabética");
            Console.WriteLine("5 - Pacientes com sintomas");
            Console.WriteLine("6 - Aniversários no mês");
            Console.WriteLine("7 - Atendimentos em aberto");
            Console.WriteLine("8 - Médicos e quantidade de atendimentos");
            Console.WriteLine("9 - Verifica suspeita de diagnóstico");
            Console.WriteLine("10 - Top 10 exames");
            Console.WriteLine("0 - Sair");

            opcao = int.Parse(Console.ReadLine()!);

            switch (opcao)
            {
                case 1:
                    Relatorios.pacienteIdade(pacientes);
                    break;
                case 2:
                    Relatorios.medicosIdade(medicos);
                    break;
                case 3:
                    Relatorios.pacientesSexo(pacientes);
                    break;
                case 4:
                    Relatorios.pacientesOrdemAlfabetica(pacientes);
                    break;
                case 5:
                    Relatorios.pacientesComSintomas(pacientes);
                    break;
                case 6:
                    List<Pessoa> pessoas = new List<Pessoa>();
                    pessoas.AddRange(pacientes);
                    pessoas.AddRange(medicos);
                    Relatorios.aniversariosNoMes(pessoas);
                    break;
                case 7:
                    Relatorios.atendimentosEmAberto(atendimentos);
                    break;
                case 8:
                    Relatorios.medicosQuantidadeAtendimentos(atendimentos, medicos);
                    break;
                case 9:
                    Relatorios.verificaSuspeitaDiagnostico(atendimentos);
                    break;
                case 10:
                    Relatorios.top10Exames(atendimentos, exames);
                    break;
                case 0:
                    Console.WriteLine("Saindo do menu...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        } while (opcao != 0);
    }
}

