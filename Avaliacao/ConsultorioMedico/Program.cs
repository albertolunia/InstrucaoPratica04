using ConsultorioMedico;

class Programa{
    public static void Main(string[] args)
    {
        //Instanciando os objetos
        Requisitos requisitos = new();
        Paciente paciente = new();
        Medico medico = new();
        List<Atendimento> atendimentos = requisitos.AtendimentosEmAndamento;

        Exame exame1 = new Exame("Exame de Sangue", 25, "", "Sala 1");
        Exame exame2 = new Exame("Exame de Urina", 30, "", "Sala 2");
        Exame exame3 = new Exame("Ultrassonografia", 300, "", "Sala 3");
        Exame exame4 = new Exame("Ressonância Magnética", 500, "", "Sala 4");
        Exame exame5 = new Exame("Tomografia Computadorizada", 600, "", "Sala 5");


        requisitos.AddExame(exame1);
        requisitos.AddExame(exame2);
        requisitos.AddExame(exame3);
        requisitos.AddExame(exame4);
        requisitos.AddExame(exame5);

        //Testando se insere pacientes e medicos
        paciente = new Paciente{
            Nome = "João",
            DataNascimento = "29111999",
            Cpf = "99999999999",
            Sexo = "M",
            Sintomas = "Dor de cabeça e Gripe"
        };

        requisitos.CadastrarPaciente(paciente);

        medico = new Medico{
            Nome = "José",
            DataNascimento = "29111980",
            Cpf = "12345678910",
            Crm = "123456"
        };

        requisitos.CadastrarMedico(medico);

        Console.WriteLine("\n---------------------------------------------\n");

        requisitos.IniciarAtendimento(paciente, medico, paciente.Sintomas);

        requisitos.SolicitarExame(exame1, atendimentos[0]);
        requisitos.SolicitarExame(exame2, atendimentos[0]);
        requisitos.SolicitarExame(exame3, atendimentos[0]);

        

        requisitos.ListarAtendimentosEmAberto();

        requisitos.ImprimirExamesMaisUtilizados();

        requisitos.FinalizarAtendimento(atendimentos[0], "Virose");

        requisitos.MedicosEmOrdemDecrescenteAtendimentosConcluidos();

    }

}