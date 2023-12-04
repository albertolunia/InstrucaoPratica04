namespace pogDev;

public class Consultorio{


    public static void adicionaPaciente(List<Paciente> Pacientes){
        Console.WriteLine("CADASTRO DE PACIENTE");
        Console.WriteLine("Digite o nome");
        string nome = Console.ReadLine()!;
        Console.WriteLine("Digite o CPF");
        string cpf = Console.ReadLine()!;
        if(Pacientes.Any(x => x.Cpf == cpf))
            throw new ArgumentException("Paciente já existe");
        Console.WriteLine("Digite a data de nascimento ");
        string dataDeNascimentoString = Console.ReadLine()!;
        DateTime dataDeNascimento;
        if(DateTime.TryParse(dataDeNascimentoString, out DateTime data)){
            dataDeNascimento = data;
        }
        else{
            throw new Exception("Data invalida");
        }
        Console.WriteLine("Digite o sexo");
        string sexo = Console.ReadLine()!;
        string opcao = "s";
        List<string> sintomas = new List<string>();
        while(opcao != "n"){
            Console.WriteLine("Digite o sintoma");
            string sintoma = Console.ReadLine()!.ToLower();
            if(sintomas.Contains(sintoma))
                Console.WriteLine("Sintoma repetido");   
            else
                sintomas.Add(sintoma);
            Console.WriteLine($"Dejeja adicionar mais sintomas? (s/n)");
            opcao = Console.ReadLine()!.ToLower();
                 
        }
            Console.WriteLine("Paciente Adicionado");
            Pacientes.Add(new Paciente(nome,cpf,dataDeNascimento,sexo,sintomas));
    }


    public static void adicionaMedico(List<Medico> Medicos){
        Console.WriteLine("CADASTRO DE MEDICOS");
        Console.WriteLine("Digite o nome");
        string nome = Console.ReadLine()!;
        Console.WriteLine("Digite o CPF");
        string cpf = Console.ReadLine()!;
        if(Medicos.Any(x => x.Cpf == cpf))
            throw new ArgumentException("Medico já existe");
        Console.WriteLine("Digite o CRM");
        string crm = Console.ReadLine()!;
        if(Medicos.Any(x => x.Crm == crm))
            throw new ArgumentException("Medico já existe");
        Console.WriteLine("Digite a data de nascimento ");
        string dataDeNascimentoString = Console.ReadLine()!;
        DateTime dataDeNascimento;
        if(DateTime.TryParse(dataDeNascimentoString, out DateTime data)){
            dataDeNascimento = data;
        }
        else{
            throw new Exception("Data invalida");
        }
            Medicos.Add(new Medico(nome,cpf,dataDeNascimento,crm));
    }

    public static void removePaciente(List<Paciente> Pacientes){
        Console.WriteLine("REMOVENDO PACIENTES");
        Console.WriteLine("Digite o cpf");
        string cpf = Console.ReadLine()!;
        
        if(Pacientes.Exists(x => x.Cpf == cpf)){
            Pacientes.Remove(Pacientes.Single(x => x.Cpf == cpf));
        }
        else{
            throw new Exception("Paciente não encontrado");
        }
    }

    public static void removeMedico(List<Medico> Medicos){
        Console.WriteLine("REMOVENDO MEDICOS");
        Console.WriteLine("Digite o cpf");
        string cpf = Console.ReadLine()!;
        if(Medicos.Exists(x => x.Cpf == cpf)){
            Medicos.Remove(Medicos.Single(x => x.Cpf == cpf));
        }
        else{
            throw new Exception("Médico não encontrado");
        }
    }

    public static void adicionaExame(List<Exame> Exames){
        Console.WriteLine("CADASTRO DE EXAMES");
        Console.WriteLine("Digite o nome");
        string nome = Console.ReadLine()!;
        if(Exames.Any(x => x.Nome == nome))
            throw new Exception("Exame já existe");
        Console.WriteLine("Digite a descricao");
        string descricao = Console.ReadLine()!;
        Console.WriteLine("Digite o local");
        string local = Console.ReadLine()!;
        Console.WriteLine("Digite o preço");
        float preco = float.Parse(Console.ReadLine()!);

        Exames.Add(new Exame(nome,descricao,local,preco));
        
    }
    public static void removeExame(List<Exame> Exames){
        Console.WriteLine("REMOVE EXAMES");
        Console.WriteLine("Digite o nome");
        string nome = Console.ReadLine()!;
        if(Exames.Exists(x => x.Nome == nome))
            Exames.Remove(Exames.Single(x => x.Nome == nome));
        else
            throw new Exception("Exame não encontrado");
    }


    public static void cadastraAtendimento(List<Paciente> Pacientes, List<Medico> Medicos, List<Exame> Exames, List<Atendimento> Atendimentos){
        Console.WriteLine("INICIA ATENDIMENTO");
        Console.WriteLine("Digite o cpf do paciente");
        string cpf = Console.ReadLine()!;
        Paciente paciente;
        if(Pacientes.Exists(x => x.Cpf == cpf)){
            paciente = Pacientes.Single(x => x.Cpf == cpf);
        }
        else{
            throw new Exception("Paciente não encontrado");
        }

        Console.WriteLine("Digite o crm do medico");
        string crm = Console.ReadLine()!;
        Medico medico;
        if(Medicos.Exists(x => x.Crm == crm)){
            medico = Medicos.Single(x => x.Crm == crm);
        }
        else{
            throw new Exception("Médico não encontrado");
        }
        Console.WriteLine($"Dados os sintomas:");
        foreach(string sintoma in paciente.Sintomas){
            Console.WriteLine($"{sintoma}");              
        }
        Console.WriteLine("Digite a suspeita inicial");
        string suspeita = Console.ReadLine()!;
        
        Console.WriteLine("Dado a lista de Exames Disponiveis:");
        foreach(Exame exame in Exames){
            Console.WriteLine($"{exame.Nome}");
        }
        List<Exame> examesSolicitados = new List<Exame>();
        string opcao;
        Console.WriteLine($"Deseja Solicitar exames? (s/n)");
        opcao = Console.ReadLine()!.ToLower();
        while(opcao != "n"){
            Console.WriteLine("Digite o nome do exame");
            string nome = Console.ReadLine()!.ToLower();
            if(Exames.Any(x => x.Nome ==  nome)){
                examesSolicitados.Add(Exames.Single(x => x.Nome ==  nome)); 
                Console.WriteLine($"Exame Adicionado");
            }
            else
               throw new Exception("Exame não cadastrado no sistema");
            Console.WriteLine($"Deseja solicitar mais exames?");
            opcao = Console.ReadLine()!.ToLower();        
        }
        
        Console.WriteLine($"Digite o preco do atendimento");
        float preco = float.Parse(Console.ReadLine()!);

        Atendimento atendimento = new Atendimento();
        atendimento.iniciaAtendimento(medico, paciente, examesSolicitados, preco, suspeita);
        Atendimentos.Add(  atendimento );
    }

    public static void finalizaAtendimento(List<Atendimento> Atendimentos){
        Console.WriteLine("FINALIZA ATENDIMENTO");

        Atendimentos = Atendimentos.Where(x => !x.Finalizada).ToList();
        Console.WriteLine("Digite o cpf do paciente");
        string cpf = Console.ReadLine()!;

        if(Atendimentos.Any(x=> x.PacienteAtendido.Cpf == cpf)){
            Atendimentos = Atendimentos.Where(x => x.PacienteAtendido.Cpf == cpf).ToList();
            Atendimento atendimento;
            Console.WriteLine("Digite o crm do medico");
            string crm = Console.ReadLine()!;

            if(Atendimentos.Any(x => x.MedicoAtendente.Crm == crm)){
                Atendimentos = Atendimentos.Where(x => x.MedicoAtendente.Crm == crm).ToList();
            }
            else{
                throw new Exception("Medico não possui atendimentos");
            }
            atendimento = Atendimentos.Single();
           
            List<string> resultados = new List<string>();
            string resultado;
            foreach((Exame,string) exame in atendimento.ExamesResultados){
                Console.WriteLine($"Digite o resultado do Exame: {exame.Item1.Nome}");
                resultado = Console.ReadLine()!;
                resultados.Add(resultado);
            }

            Console.WriteLine($"Dados os resultados, digite o diagnostico");
            string diagnostico = Console.ReadLine()!;          
            atendimento.finalizaAtendimento(resultados,diagnostico);
        }
        else
            throw new Exception("Paciente não possui atendimentos");
    }



    public static void menu(List<Paciente> Pacientes, List<Medico> Medicos, List<Exame> Exames, List<Atendimento> Atendimentos){
    int opcao;
    do
    {
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1. Adicionar Paciente");
        Console.WriteLine("2. Adicionar Médico");
        Console.WriteLine("3. Remover Paciente");
        Console.WriteLine("4. Remover Médico");
        Console.WriteLine("5. Adicionar Exame");
        Console.WriteLine("6. Remover Exame");
        Console.WriteLine("7. Cadastrar Atendimento");
        Console.WriteLine("8. Finalizar Atendimento");
        Console.WriteLine("9. Menu Relatorios");

        opcao = int.Parse(Console.ReadLine() ?? "0");

        try
        {
            switch (opcao)
            {
                case 1:
                    try{
                        Consultorio.adicionaPaciente(Pacientes);
                    } catch (Exception e){
                        Console.WriteLine($"Erro ao adicionar paciente: {e.Message}");
                    }
                    break;
                case 2:
                    try{
                        Consultorio.adicionaMedico(Medicos);
                    }catch (Exception e){
                        Console.WriteLine($"Erro ao adicionar médico: {e.Message}");
                    }
                    break;
                case 3:
                    try{
                        Consultorio.removePaciente(Pacientes);
                    }catch (Exception e){
                        Console.WriteLine($"Erro ao remover paciente: {e.Message}");
                    }
                    break;
                case 4:
                    try{
                        Consultorio.removeMedico(Medicos);
                    }catch (Exception e){
                        Console.WriteLine($"Erro ao remover médico: {e.Message}");
                    }
                    break;
                case 5:
                    try{
                        Consultorio.adicionaExame(Exames);
                    }catch (Exception e){
                        Console.WriteLine($"Erro ao adicionar exame: {e.Message}");
                    }
                    break;
                case 6:
                    try{
                        Consultorio.removeExame(Exames);
                    }catch (Exception e) {
                        Console.WriteLine($"Erro ao remover exame: {e.Message}");
                    }
                    break;
                case 7:
                    try{
                        Consultorio.cadastraAtendimento(Pacientes, Medicos, Exames, Atendimentos);
                    } catch (Exception e) {
                        Console.WriteLine($"Erro ao cadastrar atendimento: {e.Message}");
                    }
                    break;
                case 8:
                    try{
                        Consultorio.finalizaAtendimento(Atendimentos);
                    }catch (Exception e){
                        Console.WriteLine($"Erro ao finalizar atendimento: {e.Message}");
                    }
                    break;
                case 9:
                    Console.WriteLine("Encerrando o programa..."); //menu relatorios
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Digite um número válido.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }

    } while (opcao != 0);
    }

}