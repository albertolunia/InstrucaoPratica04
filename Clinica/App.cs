using System.Globalization;
namespace Namespace;
public class App
{
    public static void addPaciente(List<Paciente>pacientes, List<PlanoDeSaude> planos){
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
            Console.WriteLine($"Plano: {i++} Título: {plano.Titulo}, Valor mensal: {plano.ValorMensal}");
        }
        Console.WriteLine("Informe o plano do paciente");
        indice = Int32.Parse(Console.ReadLine() ?? "0");
        paciente.Plano = planos[indice - 1];

        paciente.Pagamentos = new List<IPagamento>();
        
        pacientes.Add(paciente);

    }
    public static void removePaciente(List<Paciente> pacientes){
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
    public static void addMedico(List<Medico>medicos){
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
    public static void removeMedico(List<Medico> medicos){
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
    public static void listarMedicos(List<Medico> medicos){
        Console.WriteLine("LISTA DE MÉDICOS");
        foreach(var medico in medicos){
            Console.WriteLine($"Nome: {medico.Nome}, CRM: {medico.CRM}");
        }
    }
    public static void addAtendimento(List<Atendimento> atendimentos, List<Paciente> pacientes, List<Medico> medicos){
        string cpf, crm;
        float valor;
        Console.WriteLine("Informe o CPF do paciente para o atendimento");
        cpf = Console.ReadLine() ?? "";
        if(!pacientes.Exists(p => p.CPF == cpf)){
            throw new Exception("Paciente não cadastrado, por favor cadastre primeiro e depois marque o atendimento");
        }
        App.listarMedicos(medicos);
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
    public static void removeAtendimento(List<Atendimento> atendimentos, List<Paciente> pacientes){
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
    public static void iniciarAtendimento(List<Atendimento> atendimentos, List<Paciente> pacientes){
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
    public static void encerrarAtendimento(List<Atendimento> atendimentos, List<Paciente> pacientes){
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
    public static void addExame(List<Exame> exames){
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
    public static void removeExame(List<Exame> exames){
        int i, indice;
        i = 0;
        foreach (var exame in exames){
            Console.WriteLine($"Exame: {i++} Título: {exame.Titulo} Descrição: {exame.Descricao} Valor: {exame.Valor} Local: {exame.Local}");
        }
        Console.WriteLine("Informe o índice do exame que deseja remover");
        indice = Int32.Parse(Console.ReadLine() ?? "0");
        exames.Remove(exames[indice - 1]);
    }
    public static void adicionarExames(List<Atendimento> atendimentos, List<Paciente> pacientes, List<Exame> exames){
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

    public static void addPlano(List<PlanoDeSaude> planos){
        Console.WriteLine($"Informe o titulo do plano:");
        string titulo = Console.ReadLine()!;
        if (planos.Exists(x => x.Titulo == titulo)){
            throw new Exception("Plano ja adicionado");
        }
        Console.WriteLine($"Digite o valor mensal");
        double.tryParse( Console.ReadLine(), valor);
        PlanoDeSaude novoPlano = new Plano();
        novoPlano.Titulo = titulo;
        novoPlano.ValorMensal =  valor;
        planos.Add(novoPlano);
    }

    public static void removePlano(List<PlanoDeSaude> planos){
        int i, indice;
        i = 0;
        foreach (var plano in planos){
            Console.WriteLine($"Plano: {i++} Título: {plano.Titulo}, Valor mensal: {plano.ValorMensal}");
        }
        Console.WriteLine("Informe o índice do plano que deseja remover");
        indice = Int32.Parse(Console.ReadLine() ?? "0");
        planos.Remove(planos[indice - 1]);
    }
}
