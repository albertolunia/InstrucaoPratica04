using ConsultorioMedico;

class Programa{
    public static void Main(string[] args)
    {
        //Instanciando os objetos
        Requisitos requisitos = new();
        Paciente paciente = new();
        Medico medico = new();
        List<Atendimento> atendimentos = requisitos.AtendimentosEmAndamento;
        List<Exame> exames = requisitos.ExamesDisponiveis;
        int opcao = 0;

        Exame exame1 = new Exame("Exame de Sangue", 25, "", "Sala 1");
        Exame exame2 = new Exame("Exame de Urina", 30, "", "Sala 2");
        Exame exame3 = new Exame("Ultrassonografia", 300, "", "Sala 3");
        Exame exame4 = new Exame("Ressonância Magnética", 500, "", "Sala 4");
        Exame exame5 = new Exame("Tomografia Computadorizada", 600, "", "Sala 5");
        Exame exame6 = new Exame("Exame de Fezes", 20, "", "Sala 6");
        Exame exame7 = new Exame("Colonoscopia", 400, "", "Sala 7");
        Exame exame8 = new Exame("Endoscopia", 350, "", "Sala 8");
        Exame exame9 = new Exame("Eletrocardiograma", 100, "", "Sala 9");
        Exame exame10 = new Exame("Eletroencefalograma", 150, "", "Sala 10");


        requisitos.AddExame(exame1);
        requisitos.AddExame(exame2);
        requisitos.AddExame(exame3);
        requisitos.AddExame(exame4);
        requisitos.AddExame(exame5);
        requisitos.AddExame(exame6);
        requisitos.AddExame(exame7);
        requisitos.AddExame(exame8);
        requisitos.AddExame(exame9);
        requisitos.AddExame(exame10);

        do{
            Console.Clear();
            Console.WriteLine("--------Consultório Médico--------");
            Console.WriteLine("--------Escolha sua opção de Menu--------");
            Menu.ImprimirMenuPrincipal();
            
            try{
                opcao = int.Parse(Console.ReadLine());
            }catch(FormatException){
                Console.WriteLine("\n--------Digite apenas números!--------");
                opcao = 0;
                Console. ReadKey(true);
            }
            switch(opcao){
                case 1:
                    do{
                        Console.Clear();
                        Menu.ImprimirMenuCadastro();
                        try{
                            opcao = int.Parse(Console.ReadLine());
                        }catch(FormatException){
                            Console.WriteLine("\n--------Digite apenas números!--------");
                            opcao = 0;
                            Console. ReadKey(true);
                        }

                        switch(opcao){
                            case 1:
                                try{
                                    Console.Write("Digite o nome do médico: ");
                                    string nome = Console.ReadLine();
                                    Console.Write("Digite a data de nascimento do médico: ");
                                    string dataNascimento = Console.ReadLine();
                                    Console.Write("Digite o CPF do médico: ");
                                    string cpf = Console.ReadLine();
                                    Console.Write("Digite o CRM do médico: ");
                                    string crm = Console.ReadLine();
                                    medico = new Medico(nome, dataNascimento, cpf, crm);
                                    requisitos.CadastrarMedico(medico);
                                    Console. ReadKey(true);

                                    
                                }catch(FormatException){
                                    Console.WriteLine("Erro de digitação!");
                                    Console. ReadKey(true);
                                }
                                break;
                            case 2:
                            try{
                                Console.Write("Digite o nome do paciente: ");
                                string nomePaciente = Console.ReadLine();
                                Console.Write("Digite a data de nascimento do paciente: ");
                                string dataNascimentoPaciente = Console.ReadLine();
                                Console.Write("Digite o CPF do paciente: ");
                                string cpfPaciente = Console.ReadLine();
                                Console.Write("Digite o sexo do paciente: ");
                                string sexo = Console.ReadLine();
                                Console.Write("Digite os sintomas do paciente: ");
                                string sintomas = Console.ReadLine();
                                paciente = new Paciente(nomePaciente, dataNascimentoPaciente, cpfPaciente, sexo, sintomas);
                                requisitos.CadastrarPaciente(paciente);
                                Console. ReadKey(true);
                            }
                            catch(FormatException){
                                Console.WriteLine("Erro de digitação!");
                                Console. ReadKey(true);
                            }
                                break;
                            case 3:
                                try{
                                    Console.Write("Digite o CPF do medico: ");
                                    string cpfMedico = Console.ReadLine();
                                    Console.Write("Digite o CPF do paciente: ");
                                    string cpfPaciente = Console.ReadLine();

                                    Medico medicoAtendimento = requisitos.getMedico(cpfMedico);
                                    Paciente pacienteAtendimento = requisitos.getPaciente(cpfPaciente);

                                    requisitos.IniciarAtendimento(pacienteAtendimento, medicoAtendimento, pacienteAtendimento.Sintomas);
                                    Console. ReadKey(true);
                                }
                                catch(FormatException){
                                    Console.WriteLine("Erro de digitação!");
                                    Console. ReadKey(true);
                                }
                                break;
                            case 4:
                            try{
                                Console.Write("Digite o nome do exame: ");
                                string nomeExame = Console.ReadLine();
                                Console.Write("Digite o valor do exame: ");
                                double valorExame = double.Parse(Console.ReadLine());
                                Console.Write("Digite a sala do exame: ");
                                string salaExame = Console.ReadLine();
                                Exame exame = new Exame(nomeExame, valorExame, "", salaExame);
                                requisitos.AddExame(exame);
                            }
                            catch(FormatException){
                                Console.WriteLine("Erro de digitação!");
                                Console. ReadKey(true);
                            }
                                break;
                            case 5:
                                try{
                                    Console.Write("Digite o CPF do médico: ");
                                    string cpfMedico = Console.ReadLine();
                                    requisitos.RemoverMedico(cpfMedico);
                                    Console. ReadKey(true);
                                }
                                catch(FormatException){
                                    Console.WriteLine("Erro de digitação!");
                                    Console. ReadKey(true);
                                }
                                break;
                            case 6:
                                try{
                                    Console.Write("Digite o CPF do paciente: ");
                                    string cpfPaciente = Console.ReadLine();
                                    requisitos.RemoverPaciente(cpfPaciente);
                                    Console. ReadKey(true);
                                }
                                catch(FormatException){
                                    Console.WriteLine("Erro de digitação!");
                                    Console. ReadKey(true);
                                }
                                break;
                            case 7:
                                try{
                                    Console.Write("Digite o nome do exame: ");
                                    string nomeExame = Console.ReadLine();
                                    requisitos.RemoverExame(nomeExame);
                                    Console. ReadKey(true);
                                }
                                catch(FormatException){
                                    Console.WriteLine("Erro de digitação!");
                                    Console. ReadKey(true);
                                }
                                break;
                            case 8:
                                Console.WriteLine("Saindo...");
                                break;
                        }
                    }while(opcao != 8);
                break;

                case 2:
                    do{

                        Console.Clear();
                        Menu.ImprimirMenuRelatorios();
                        try{
                            opcao = int.Parse(Console.ReadLine());
                        }catch(FormatException){
                            Console.WriteLine("\n--------Digite apenas números!--------");
                            Console. ReadKey(true);
                            opcao = 0;
                        }

                        switch(opcao){
                            case 1:
                                try{
                                    Console.Write("Digite a idade do medico 1: ");
                                    int idade1 = int.Parse(Console.ReadLine());
                                    Console.Write("Digite a idade do medico 2: ");
                                    int idade2 = int.Parse(Console.ReadLine());
                                    requisitos.MedicosEntreIdade(idade1, idade2);
                                    Console. ReadKey(true);
                                }catch(FormatException){
                                    Console.WriteLine("Digite apenas números!");
                                    Console. ReadKey(true);
                                }
                                break;
                            case 2:
                                try{
                                    Console.Write("Digite a idade do paciente 1: ");
                                    int idade1 = int.Parse(Console.ReadLine());
                                    Console.Write("Digite a idade do paciente 2: ");
                                    int idade2 = int.Parse(Console.ReadLine());
                                    requisitos.PacientesEntreIdade(idade1, idade2);
                                    Console. ReadKey(true);
                                    }catch(FormatException){
                                        Console.WriteLine("Digite apenas números!");
                                        Console. ReadKey(true);
                                    }
                                break;
                            case 3:
                                try{
                                    Console.Write("Digite o sexo do paciente: ");
                                    string sexo = Console.ReadLine();
                                    if(sexo != "M" && sexo != "m" && sexo != "F" && sexo != "f")
                                        throw new Exception("Sexo inválido!");
                                        Console. ReadKey(true);


                                    requisitos.PacientesDoSexo(sexo);
                                    Console. ReadKey(true);
                                    }catch(FormatException){
                                        Console.WriteLine("Erro de digitação!");
                                        Console. ReadKey(true);

                                    }
                                break;
                            case 4:
                                requisitos.ListarPacientesEmOrdem();
                                Console. ReadKey(true);

                                break;
                            case 5:
                                try{
                                    Console.Write("Digite o sintoma: ");
                                    string sintoma = Console.ReadLine();
                                    requisitos.PacientesComSintomas(sintoma);
                                    Console. ReadKey(true);
                                }
                                catch(FormatException){
                                    Console.WriteLine("Erro de digitação!");
                                    Console. ReadKey(true);
                                }
                                break;
                            case 6:
                                Console.Write("Digite o mês: ");
                                int mes = int.Parse(Console.ReadLine());
                                requisitos.AniversariantesDoMes(mes);
                                Console. ReadKey(true);
                                break;
                            case 7:
                                requisitos.ListarAtendimentosEmAberto();
                                Console. ReadKey(true);
                                break;
                            case 8:
                                requisitos.MedicosEmOrdemDecrescenteAtendimentosConcluidos();
                                Console. ReadKey(true);
                                break;
                            case 9:
                                try{
                                    Console.Write("Insira o nome da suspeita ou do diagnostico: ");
                                    string palavra = Console.ReadLine();
                                    requisitos.AtendimentosComPalavra(palavra);
                                    Console. ReadKey(true);
                                }
                                catch(FormatException){
                                    Console.WriteLine("Erro de digitação!");
                                    Console. ReadKey(true);
                                }
                                break;
                            case 10:
                                requisitos.ImprimirExamesMaisUtilizados();
                                Console. ReadKey(true);
                                break;
                            case 11:
                                Console.WriteLine("Saindo...");
                                break;
                            default:
                                Console.WriteLine("Opção inválida!");
                                break;
                        }
                    }while(opcao != 11);
                break;
            }
        }while(opcao != 3);
    }
}