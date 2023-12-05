using Clinica;

    List<Paciente>pacientes = new List<Paciente>();
    List<Medico>medicos = new List<Medico>();
    List<Exame>exames = new List<Exame>();
    List <Atendimento>atendimentos = new List<Atendimento>();
    
    int opcao;

    do{
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Inserir Médico");
        Console.WriteLine("2. Remover Médico");
        Console.WriteLine("3. Inserir Paciente");
        Console.WriteLine("4. Remover Paciente");
        Console.WriteLine("5. Adicionar Exame");
        Console.WriteLine("6. Remover Exame");
        Console.WriteLine("7. Iniciar Atendimento");
        Console.WriteLine("8. Finalizar Atendimento");
        Console.WriteLine("9. Gerar Relatórios");
        Console.WriteLine("10. Sair");
        Console.Write("Escolha uma opção: ");

        if (int.TryParse(Console.ReadLine(), out opcao)){
            try
                {
                switch (opcao) {
                    case 1:
                        Consultorio.addMedico(medicos);
                        break;
                    case 2:
                        Consultorio.removeMedico(medicos);
                        break;
                    case 3:
                        Consultorio.addPaciente(pacientes);
                        break;
                    case 4:
                        Consultorio.removePaciente (pacientes);   
                        break;
                    case 5:
                        Consultorio.addExame(exames);
                        break;
                    case 6:
                        Consultorio.removeExame(exames);
                        break;
                    case 7:
                        Atendimento atendimento = new Atendimento();
                        atendimento.inicioAtendimento(atendimentos,medicos,pacientes);
                        break;
                    case 8:
                        Atendimento.FinalizarAtendimento(atendimentos);
                        break;
                    case 9:
                        Relatorios.menuRelatorios(atendimentos, exames, pacientes, medicos);
                        break;
                    case 10:
                        Console.WriteLine("Saindo do programa");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                    }
                     }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
                } else {
                    Console.WriteLine("Por favor, digite um número válido.");
                }
            Console.WriteLine();

    } while (opcao != 10);
