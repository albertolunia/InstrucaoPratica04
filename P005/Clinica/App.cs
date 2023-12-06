using System.Globalization;
namespace Namespace;
public static class App
{
    public static List<Paciente> pacientes = new List<Paciente>();
    public static List<Medico> medicos = new List<Medico>();
    public static List<Atendimento> atendimentos = new List<Atendimento>();
    public static List<Exame> exames = new List<Exame>();
    public static List<PlanoDeSaude> planos = new List<PlanoDeSaude>();
    public static void Init(){
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
        
        int op = -1;
        do{
            Console.WriteLine("<----------MENU---------->");
            Console.WriteLine("1- Adicionar Paciente");
            Console.WriteLine("2- Remover Paciente");
            Console.WriteLine("3- Adicionar Médico");
            Console.WriteLine("4- Remover Médico");
            Console.WriteLine("5- Adicionar Exame");
            Console.WriteLine("6- Remover Exame");
            Console.WriteLine("7- Atendimentos");
            Console.WriteLine("8- Relatorios");
            Console.WriteLine("9- Adicionar Plano de  Saude");
            Console.WriteLine("10- Remover Plano de Saude");
            Console.WriteLine("11- Adicionar Pagamento");
            Console.WriteLine("0- Sair");
            op = Int32.Parse(Console.ReadLine() ?? "-1");
            switch(op){
                case 1:
                    try{addPaciente();}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 2:
                    try{removePaciente();}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 3:
                    try{addMedico();}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 4:
                    try{removeMedico();}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 5:
                    try{addExame();}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 6:
                    try{removeExame();}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 7:
                    Atendimentos();
                    break;
                case 8:
                    Relatorio();
                    break;  
                case 9:
                    try{addPlano();}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 10:
                    try{removePlano();}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;   
                case 11:
                    try{addPagamento();}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;     
            }
        }while(op != 0);        
    }
    public static void Atendimentos(){
        int op = -1;
        do{
            Console.WriteLine("<----------ATENDIMENTOS---------->");
            Console.WriteLine("1- Adicionar Atendimento");
            Console.WriteLine("2- Remover Atendimento");
            Console.WriteLine("3- Iniciar Atendimento");
            Console.WriteLine("4- Finalizar Atendimento");
            Console.WriteLine("5- Adicionar Exames");
            Console.WriteLine("0- Sair");
            op = Int32.Parse(Console.ReadLine() ?? "-1");
            switch(op){
                case 1:
                    try{addAtendimento();}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 2:
                    try{removeAtendimento();}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 3:
                    try{iniciarAtendimento();}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 4:
                    try{encerrarAtendimento();}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 5:
                    try{adicionarExames();}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
            }
        }while(op != 0); 
    }
    public static void Relatorio(){
        int op = -1;
        do{
            Console.WriteLine("<----------RELATÓRIOS---------->");
            Console.WriteLine("1- Médicos com idade entre dois valores");
            Console.WriteLine("2- Pacientes com idade entre dois valores");
            Console.WriteLine("3- Pacientes com o mesmo sexo");
            Console.WriteLine("4- Pacientes em ordem alfabética");
            Console.WriteLine("5- Pacientes com o mesmo sintoma");
            Console.WriteLine("6- Aniversariantes do mês");
            Console.WriteLine("7- Atendimentos em aberto");
            Console.WriteLine("8- Médicos com atendimentos concluídos");
            Console.WriteLine("9- Atendimento com a mesma suspeita ou diagnóstico");
            Console.WriteLine("10- Top10 exames mais pedidos");
            Console.WriteLine("0- Sair");
            op = Int32.Parse(Console.ReadLine() ?? "-1");
            switch(op){
                case 1:
                    Relatorios.medicosIdades(medicos);
                    break;
                case 2:
                    Relatorios.pacientesIdades(pacientes);
                    break;
                case 3:
                    Relatorios.pacientesSexo(pacientes);
                    break;
                case 4:
                    Relatorios.pacientesOrdenado(pacientes);
                    break;
                case 5:
                    Relatorios.pacientesSintoma(pacientes);
                    break;
                case 6:
                    Relatorios.aniversariantes(pacientes, medicos);
                    break;
                case 7:
                    Relatorios.atendimentosAbertos(atendimentos);
                    break;
                case 8:
                    Relatorios.medicosAtendimento(atendimentos, medicos);
                    break;
                case 9:
                    Relatorios.diagnosticoOuSuspeita(atendimentos);
                    break;
                case 10:
                    Relatorios.examesMaisUtilizados(atendimentos, exames);
                    break;
            }
        }while(op != 0);    
    }
    public static void addPlano(){
        Console.WriteLine($"Informe o titulo do plano:");
        string titulo = Console.ReadLine()!;
        if (planos.Exists(x => x.Titulo == titulo)){
            throw new Exception("Plano ja adicionado");
        }
        Console.WriteLine($"Digite o valor mensal");
        double valor  = double.Parse(Console.ReadLine() ?? "0");
        PlanoDeSaude novoPlano = new PlanoDeSaude();
        novoPlano.Titulo = titulo;
        novoPlano.ValorMensal =  valor;
        planos.Add(novoPlano);
    }
    public static void removePlano(){
        int i, indice;
        i = 0;
        foreach (var plano in planos){
            Console.WriteLine($"Plano: {++i} Título: {plano.Titulo}, Valor mensal: {plano.ValorMensal}");
        }
        Console.WriteLine("Informe o índice do plano que deseja remover");
        indice = Int32.Parse(Console.ReadLine() ?? "0");
        planos.Remove(planos[indice - 1]);
    }

    public static void addPaciente(){
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
        Paciente paciente = new Paciente();
        string nome, cpf, sexo, sintoma;
        List<string> sintomas = new List<string>();

        DateTime nascimento;
        Console.WriteLine("Informe o nome do paciente");
        nome = Console.ReadLine() ?? "";
        paciente.Nome = nome;
        Console.WriteLine("Infome o CPF do paciente");
        cpf = Console.ReadLine()?? "";
        if(pacientes.Exists(p => p.CPF == cpf)){
            throw new Exception("CPF já existe");
        }
        else{
            paciente.CPF = cpf;
        }
        Console.WriteLine("Infome a data de aniversario do paciente");
        nascimento = DateTime.Parse(Console.ReadLine()?? "01/01/2001");
        paciente.dataNascimento = nascimento;
        Console.WriteLine("Informe o sexo do paciente: (Feminino / Masculino)");
        sexo = (Console.ReadLine() ?? "Feminino").ToUpper();
        paciente.Sexo = sexo;
        Console.WriteLine("Informe quais os sintomas do paciente, um por linha, ao encerrar a listagem deixe uma linha em branco");
        do{
            sintoma = Console.ReadLine() ?? "";
            sintomas.Add(sintoma);
        }while(sintoma != "");
        paciente.Sintomas = sintomas;

        int i, indice;
        i = 0;
        foreach (var plano in planos){
            Console.WriteLine($"Plano: {++i} Título: {plano.Titulo}, Valor mensal: {plano.ValorMensal}");
        }
        Console.WriteLine("Informe o plano do paciente");
        indice = Int32.Parse(Console.ReadLine() ?? "1");
        paciente.Plano = planos[indice - 1];

        paciente.Pagamentos = new List<IPagamento>();
        
        pacientes.Add(paciente);

    }
    public static void removePaciente(){
        string cpf;
        Console.WriteLine("Infome o CPF do paciente");
        cpf = Console.ReadLine()?? "";
        if(pacientes.Exists(p => p.CPF == cpf)){
            pacientes.Remove(pacientes.Single(p => p.CPF == cpf));
        }
        else{
            throw new Exception("Paciente inexistente");
        }
    }
    public static void addMedico(){
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
        Medico medico = new Medico();
        string nome, cpf, crm;
        DateTime nascimento;
        Console.WriteLine("Informe o nome do medico");
        nome = Console.ReadLine() ?? "";
        medico.Nome = nome;
        Console.WriteLine("Infome o CPF do medico");
        cpf = Console.ReadLine()?? "";
        if(medicos.Exists(m => m.CPF == cpf)){
            throw new Exception("CPF já existe");
        }
        else{
            medico.CPF = cpf;
        }
        Console.WriteLine("Infome o CRM do medico");
        crm = Console.ReadLine() ?? "";
        if(medicos.Exists(m => m.CRM == crm)){
            throw new Exception("CRM já existe");
        }
        else{
            medico.CRM = crm;
        }
        Console.WriteLine("Infome a data de nascimento do médico");
        nascimento = DateTime.Parse(Console.ReadLine() ?? "01/01/2001");
        medico.dataNascimento = nascimento;
        medicos.Add(medico);

    }
    public static void removeMedico(){
        string crm;
        Console.WriteLine("Infome o CRM do médico");
        crm = Console.ReadLine()?? "";
        if(medicos.Exists(p => p.CRM == crm)){
            medicos.Remove(medicos.Single(p => p.CRM == crm));
        }
        else{
            throw new Exception("Médico inexistente");
        }
    }
    public static void listarMedicos(){
        Console.WriteLine("LISTA DE MÉDICOS");
        foreach(var medico in medicos){
            Console.WriteLine($"Nome: {medico.Nome}, CRM: {medico.CRM}");
        }
    }
    public static void addAtendimento(){
        string cpf, crm;
        float valor;
        Console.WriteLine("Informe o CPF do paciente para o atendimento");
        cpf = Console.ReadLine() ?? "";
        if(!pacientes.Exists(p => p.CPF == cpf)){
            throw new Exception("Paciente não cadastrado, por favor cadastre primeiro e depois marque o atendimento");
        }
        listarMedicos();
        Console.WriteLine("Informe o CRM do médico para o atendimento");
        crm = Console.ReadLine() ?? "";
        if(!medicos.Exists(m => m.CRM == crm)){
            throw new Exception("Médico não existente");
        }
        Console.WriteLine("Informe o valor do atendimento");
        valor = float.Parse(Console.ReadLine() ?? "0");
        Atendimento atendimento = new Atendimento();
        atendimento.Paciente = pacientes.Single(p => p.CPF == cpf);
        atendimento.MedicoResponsavel = medicos.Single(m => m.CRM == crm);
        atendimento.Valor = valor;
        atendimentos.Add(atendimento);
    }
    public static void removeAtendimento(){
        string cpf;
        int i, indice;
        Console.WriteLine("Indique o CPF do paciente cujo atendimento deve ser removido");
        cpf = Console.ReadLine() ?? "";
        if(!pacientes.Exists(p => p.CPF == cpf)){
            throw new Exception("Paciente não foi encontrado");
        }
        if(!atendimentos.Exists(a => a.Paciente == pacientes.Single(p => p.CPF == cpf))){
            throw new Exception("Atendimento não foi encontrado");
        }
        i = 0;
        var atendimentosMarcados = atendimentos.Where(a => a.Paciente == pacientes.Single(p => p.CPF == cpf)).ToList();
        foreach (var atendimento in atendimentosMarcados){
            Console.WriteLine($"Atendimento {i++}: Médico responsável: {atendimento.MedicoResponsavel.Nome}");
        }
        Console.WriteLine("Informe o índice do atendimento que deseja remover");
        indice = Int32.Parse(Console.ReadLine() ?? "0");
        atendimentos.Remove(atendimentos.Single(a => a.Equals(atendimentosMarcados[indice -1])));
        
    }
    public static void iniciarAtendimento(){
        string cpf, suspeita;
        int i, indice;
        Console.WriteLine("Indique o CPF do paciente que será atendido");
        cpf = Console.ReadLine() ?? "";
        if(!pacientes.Exists(p => p.CPF == cpf)){
            throw new Exception("Paciente não foi encontrado");
        }
        if(!atendimentos.Exists(a => a.Paciente == pacientes.Single(p => p.CPF == cpf))){
            throw new Exception("Atendimento não foi marcado, por favor marcar primeiro");
        }
        i = 1;
        var atendimentosMarcados = atendimentos.Where(a => a.Paciente == pacientes.Single(p => p.CPF == cpf) && a.Inicio == DateTime.MinValue).ToList();
        foreach (var atendimento in atendimentosMarcados){
            Console.WriteLine($"Atendimento {i++}: Médico responsável: {atendimento.MedicoResponsavel.Nome}");
        }
        Console.WriteLine("Informe o índice do atendimento que deseja iniciar");
        indice = Int32.Parse(Console.ReadLine() ?? "0");
        foreach (var atendimento in atendimentos){
            if(atendimento == atendimentos[indice -1]){
                atendimento.Inicio = DateTime.Now;
                Console.WriteLine("Informe a suspeita inicial");
                suspeita = Console.ReadLine() ?? "";
                atendimento.SuspeitaInicial = suspeita;
            }
        }
    }
    public static void encerrarAtendimento(){
        string cpf, diagnostico;
        int i, indice;
        Console.WriteLine("Indique o CPF do paciente que foi atendido");
        cpf = Console.ReadLine() ?? "";
        if(!pacientes.Exists(p => p.CPF == cpf)){
            throw new Exception("Paciente não foi encontrado");
        }
        if(!atendimentos.Exists(a => a.Paciente == pacientes.Single(p => p.CPF == cpf))){
            throw new Exception("Atendimento não foi encontrado");
        }
        i = 1;
        var atendimentosMarcados = atendimentos.Where(a => a.Paciente == pacientes.Single(p => p.CPF == cpf) && a.Inicio != DateTime.MinValue && a.Fim == DateTime.MaxValue).ToList();
        foreach (var atendimento in atendimentosMarcados){
            Console.WriteLine($"Atendimento {i++}: Médico responsável: {atendimento.MedicoResponsavel.Nome}");
        }
        Console.WriteLine("Informe o índice do atendimento que deseja encerrar");
        indice = Int32.Parse(Console.ReadLine() ?? "0");
        foreach (var atendimento in atendimentos){
            if(atendimento == atendimentos[indice -1]){
                atendimento.Fim = DateTime.Now;
                Console.WriteLine("Informe o diagnóstico final");
                diagnostico = Console.ReadLine() ?? "";
                atendimento.DiagnosticoFinal = diagnostico;
            }
        }
    }
    public static void addExame(){
        Exame exame = new Exame();
        string titulo, descricao, local;
        float valor;
        Console.WriteLine("Infome o título do exame");
        titulo = Console.ReadLine() ?? "";
        exame.Titulo = titulo;
        Console.WriteLine("Informe o valor do exame");
        valor = float.Parse(Console.ReadLine() ?? "0");
        exame.Valor = valor;
        Console.WriteLine("Informe a descrição do exame");
        descricao = Console.ReadLine() ?? "";
        exame.Descricao = descricao;
        Console.WriteLine("Informe o local do exame");
        local = Console.ReadLine() ?? "";
        exame.Local = local;
        exames.Add(exame);
    }
    public static void removeExame(){
        int i, indice;
        i = 0;
        foreach (var exame in exames){
            Console.WriteLine($"Exame: {i++} Título: {exame.Titulo} Descrição: {exame.Descricao} Valor: {exame.Valor} Local: {exame.Local}");
        }
        Console.WriteLine("Informe o índice do exame que deseja remover");
        indice = Int32.Parse(Console.ReadLine() ?? "0");
        exames.Remove(exames[indice - 1]);
    }
    public static void adicionarExames(){
        string cpf, resultado;
        int i, indiceA, indiceE;
        Console.WriteLine("Indique o CPF do paciente");
        cpf = Console.ReadLine() ?? "";
        if(!pacientes.Exists(p => p.CPF == cpf)){
            throw new Exception("Paciente não foi encontrado");
        }
        if(!atendimentos.Exists(a => a.Paciente == pacientes.Single(p => p.CPF == cpf))){
            throw new Exception("Atendimento não foi encontrado");
        }
        i = 1;
        var atendimentosMarcados = atendimentos.Where(a => a.Paciente == pacientes.Single(p => p.CPF == cpf)).ToList();
        foreach (var atendimento in atendimentosMarcados){
            Console.WriteLine($"Atendimento: {i++} Médico responsável: {atendimento.MedicoResponsavel.Nome}");
        }
        Console.WriteLine("Informe o índice do atendimento que deseja adicionar o exame");
        indiceA = Int32.Parse(Console.ReadLine() ?? "0");
        i = 1;
        foreach (var exame in exames){
            Console.WriteLine($"Exame: {i++} Título: {exame.Titulo} Descrição: {exame.Descricao} Valor: {exame.Valor} Local: {exame.Local}");
        }
        Console.WriteLine("Informe o índice do exame que deseja adicionar ao atendimento");
        indiceE = Int32.Parse(Console.ReadLine() ?? "0");
        foreach (var atendimento in atendimentos){
            if(atendimento == atendimentos[indiceA -1]){
                Console.WriteLine("Informe o resultado do exame");
                resultado = Console.ReadLine() ?? "";
                atendimento.Exames.Add((exames[indiceE - 1], resultado));
            }
        }
    }
    public static void addPagamento(){
        string cpf;
        Console.WriteLine("Informe o CPF do paciente para o pagamento");
        cpf = Console.ReadLine() ?? "";
        if(!pacientes.Exists(p => p.CPF == cpf)){
            throw new Exception("Paciente não cadastrado, por favor cadastre primeiro e depois marque o atendimento");
        }
        else{
            Console.WriteLine("Informe qual o método do pagamento");
            Console.WriteLine("1- Cartão de Crédito");
            Console.WriteLine("2- Boleto Bancário");
            Console.WriteLine("3- Dinehiro em espécie");
            IPagamento pagamento;
            int opcao = Int32.Parse(Console.ReadLine() ?? "1");
            int valor = pacientes.Single(p => p.CPF.Equals(cpf)).Plano.ValorMensal;
            if(opcao == 1){
                pagamento = new PagamentoCartaoCredito(valor);
                Console.WriteLine("Com o " + pagamento.Descricao + " recebe um desconto de " + pagamento.Desconto * 10 + " porcento");
                pagamento.ReceberPagamento();
                pacientes.Single(p => p.CPF.Equals(cpf)).Pagamentos.Add(pagamento);
            }
            if(opcao == 2){
                pagamento = new PagamentoBoletoBancario(valor);
                Console.WriteLine("Com o " + pagamento.Descricao + " recebe um desconto de " + pagamento.Desconto * 10 + " porcento");
                pagamento.ReceberPagamento();
                pacientes.Single(p => p.CPF.Equals(cpf)).Pagamentos.Add(pagamento);
            }
            if(opcao == 3){
                pagamento = new PagamentoDinheiroEspecie(valor);
                Console.WriteLine("Com o " + pagamento.Descricao + " recebe um desconto de " + pagamento.Desconto * 10 + " porcento");
                pagamento.ReceberPagamento();
                pacientes.Single(p => p.CPF.Equals(cpf)).Pagamentos.Add(pagamento);
            }
        }
    }

}
