using ConsultorioMedico;

class Programa{
    public static void Main(string[] args)
    {
        //Instanciando os objetos
        Requisitos requisitos = new();
        Paciente paciente = new();
        Medico medico = new();

        //Testando se insere pacientes e medicos
        paciente = new Paciente{
            Nome = "João",
            DataNascimento = "29111999",
            Cpf = "99999999999",
            Sexo = "M",
            Sintomas = "Dor de cabeça e Gripe"
        };

        requisitos.CadastrarPaciente(paciente);

        paciente = new Paciente{
            Nome = "Maria",
            DataNascimento = "21022001",
            Cpf = "99993999999",
            Sexo = "F",
            Sintomas = "Colica"
        };

        requisitos.CadastrarPaciente(paciente);

        paciente = new Paciente{
            Nome = "Alberto",
            DataNascimento = "30012013",
            Cpf = "99993999991",
            Sexo = "M",
            Sintomas = "Dor de barriga"
        };

        requisitos.CadastrarPaciente(paciente);

        medico = new Medico{
            Nome = "José",
            DataNascimento = "29111980",
            Cpf = "12345678910",
            Crm = "123456"
        };

        requisitos.CadastrarMedico(medico);

        medico = new Medico{
            Nome = "Ana",
            DataNascimento = "21022001",
            Cpf = "12345678911",
            Crm = "123457"
        };

        requisitos.CadastrarMedico(medico);

        requisitos.ListarPacientes();
        requisitos.ListarMedicos();

        //Testando se insere pacientes com o mesmo CPF

        Console.WriteLine("\nTestando se é possivel inserir pacientes e medicos duplicados");
        requisitos.CadastrarPaciente(paciente);

        //Testando se insere medicos com o mesmo CPF

        requisitos.CadastrarMedico(medico);

        //Testando se insere medicos com o mesmo CRM

        medico.Cpf = "12312312312";
        requisitos.CadastrarMedico(medico);

        Console.WriteLine("\n---------------------------------------------\n");
        Console.WriteLine("Relatorios:\n");
        Console.WriteLine("Relatorio: Médicos com idades entre dois valores:");
        requisitos.MedicosEntreIdade(20, 30);

        Console.WriteLine("\nRelatorio: Pacientes com idades entre dois valores:");
        requisitos.PacientesEntreIdade(20, 30);

        Console.WriteLine("\nRelatorio: Pacientes do sexo informado pelo usuario:");
        requisitos.PacientesDoSexo("M");

        Console.WriteLine("\nRelatorio: Pacientes em ordem alfabética:");
        requisitos.ListarPacientesEmOrdem();

        Console.WriteLine("\nRelatorio: Pacientes cujos sintomas contenha texto informado pelo usuário");
        requisitos.PacientesComSintomas("Dor de cabeça");

        Console.WriteLine("\nRelatorio: Médicos e Pacientes aniversariantes do mês informado:");
        requisitos.AniversariantesDoMes(11);

        Console.WriteLine("\n---------------------------------------------\n");
        Console.WriteLine("Testanto exceções:\n");

        paciente = new Paciente{
            Nome = "Maria",
            DataNascimento = "21022001",
            Cpf = "999939999999999",
            Sexo = "x",
            Sintomas = "Colica"
        };
        
        requisitos.CadastrarPaciente(paciente);

        medico = new Medico{
            Nome = "Ana",
            DataNascimento = "21022001",
            Cpf = "12312345678911",
            Crm = "123457"
        };

        requisitos.CadastrarMedico(medico);

    }
}