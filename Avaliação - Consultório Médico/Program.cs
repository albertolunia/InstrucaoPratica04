using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class Medico
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string CRM { get; set; }
    }

    class Paciente
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public List<string> Sintomas { get; set; }
    }

    class Exame
    {
        public string Titulo { get; set; }
        public float Valor { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
    }

    class Atendimento
    {
        public DateTime Inicio { get; set; }
        public string SuspeitaInicial { get; set; }
        public List<(Exame, string)> ListaExamesResultado { get; set; }
        public float Valor { get; set; }
        public DateTime Fim { get; set; }
        public Medico MedicoResponsavel { get; set; }
        public Paciente Paciente { get; set; }
        public string DiagnosticoFinal { get; set; }
    }

    class Consultorio
    {
        static List<Medico> medicos = new List<Medico>();
        static List<Paciente> pacientes = new List<Paciente>();
        static List<Atendimento> atendimentos = new List<Atendimento>();
        static List<Exame> exames = new List<Exame>();

        public static void AdicionarMedico()
        {
            Console.Write("Nome do Médico: ");
            string nome = Console.ReadLine();

            Console.Write("Data de Nascimento (dd/mm/aaaa): ");
            DateTime dataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("CPF do Médico: ");
            string cpf = Console.ReadLine();

            Console.Write("CRM do Médico: ");
            string crm = Console.ReadLine();

            medicos.Add(new Medico
            {
                Nome = nome,
                DataNascimento = dataNascimento,
                CPF = cpf,
                CRM = crm
            });
            Console.WriteLine("Médico adicionado com sucesso!");
        }

        public static void AdicionarPaciente()
        {
            Console.Write("Nome do Paciente: ");
            string nome = Console.ReadLine();

            Console.Write("Data de Nascimento (dd/mm/aaaa): ");
            DateTime dataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("CPF do Paciente: ");
            string cpf = Console.ReadLine();

            Console.Write("Sexo do Paciente: ");
            string sexo = Console.ReadLine();

            Console.Write("Sintomas do Paciente (separados por vírgula): ");
            List<string> sintomas = Console.ReadLine().Split(',').Select(s => s.Trim()).ToList();

            pacientes.Add(new Paciente
            {
                Nome = nome,
                DataNascimento = dataNascimento,
                CPF = cpf,
                Sexo = sexo,
                Sintomas = sintomas
            });
            Console.WriteLine("Paciente adicionado com sucesso!");
        }

        public static void IniciarAtendimento()
        {
            Console.WriteLine("Selecione o Médico para o Atendimento:");
            ListarMedicos();

            int escolhaMedico = int.Parse(Console.ReadLine());
            Medico medico = medicos[escolhaMedico - 1];

            Console.WriteLine("Selecione o Paciente para o Atendimento:");
            ListarPacientes();

            int escolhaPaciente = int.Parse(Console.ReadLine());
            Paciente paciente = pacientes[escolhaPaciente - 1];

            Console.Write("Suspeita Inicial: ");
            string suspeitaInicial = Console.ReadLine();

            Atendimento novoAtendimento = new Atendimento
            {
                Inicio = DateTime.Now,
                SuspeitaInicial = suspeitaInicial,
                MedicoResponsavel = medico,
                Paciente = paciente,
                ListaExamesResultado = new List<(Exame, string)>()
            };

            atendimentos.Add(novoAtendimento);
            Console.WriteLine("Atendimento iniciado com sucesso!");
        }

        public static void FinalizarAtendimento()
        {
            Console.WriteLine("Selecione o Atendimento a ser finalizado:");
            ListarAtendimentosEmAberto();

            int escolhaAtendimento = int.Parse(Console.ReadLine());
            Atendimento atendimento = atendimentos[escolhaAtendimento - 1];

            if (atendimento.Inicio > DateTime.Now)
            {
                throw new Exception("Data final do atendimento deve ser posterior à data inicial.");
            }

            Console.Write("Diagnóstico Final: ");
            string diagnosticoFinal = Console.ReadLine();

            atendimento.Fim = DateTime.Now;
            atendimento.DiagnosticoFinal = diagnosticoFinal;
            Console.WriteLine("Atendimento finalizado com sucesso!");
        }

        public static void AdicionarExame()
        {
            // Lógica para adicionar exame
            Console.Write("Título do Exame: ");
            string titulo = Console.ReadLine();

            Console.Write("Valor do Exame: ");
            float valor = float.Parse(Console.ReadLine());

            Console.Write("Descrição do Exame: ");
            string descricao = Console.ReadLine();

            Console.Write("Local do Exame: ");
            string local = Console.ReadLine();

            exames.Add(new Exame
            {
                Titulo = titulo,
                Valor = valor,
                Descricao = descricao,
                Local = local
            });
            Console.WriteLine("Exame adicionado com sucesso!");
        }

        public static void ListarMedicos()
        {
            Console.WriteLine("Lista de Médicos:");
            for (int i = 0; i < medicos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {medicos[i].Nome}");
            }
        }

        public static void ListarPacientes()
        {
            Console.WriteLine("Lista de Pacientes:");
            for (int i = 0; i < pacientes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pacientes[i].Nome}");
            }
        }

        public static void ListarAtendimentosEmAberto()
        {
            Console.WriteLine("Atendimentos em Aberto:");
            for (int i = 0; i < atendimentos.Count; i++)
            {
                if (atendimentos[i].Fim == default(DateTime))
                {
                    Console.WriteLine($"{i + 1}. Paciente: {atendimentos[i].Paciente.Nome}, Médico: {atendimentos[i].MedicoResponsavel.Nome}");
                }
            }
        }

        public static void MedicosEntreIdades(int idadeMinima, int idadeMaxima)
        {
            var medicosEntreIdades = medicos.Where(m => (DateTime.Now.Year - m.DataNascimento.Year) >= idadeMinima && (DateTime.Now.Year - m.DataNascimento.Year) <= idadeMaxima).ToList();
            foreach (var medico in medicosEntreIdades)
            {
                Console.WriteLine($"Médico: {medico.Nome}, Idade: {DateTime.Now.Year - medico.DataNascimento.Year}");
            }
        }

        public static void PacientesEntreIdades(int idadeMinima, int idadeMaxima)
        {
            var pacientesEntreIdades = pacientes.Where(p => (DateTime.Now.Year - p.DataNascimento.Year) >= idadeMinima && (DateTime.Now.Year - p.DataNascimento.Year) <= idadeMaxima).ToList();
            foreach (var paciente in pacientesEntreIdades)
            {
                Console.WriteLine($"Paciente: {paciente.Nome}, Idade: {DateTime.Now.Year - paciente.DataNascimento.Year}");
            }
        }

        public static void PacientesPorSexo(string sexo)
        {
            var pacientesPorSexo = pacientes.Where(p => p.Sexo.ToLower() == sexo.ToLower()).ToList();
            foreach (var paciente in pacientesPorSexo)
            {
                Console.WriteLine($"Paciente: {paciente.Nome}, Sexo: {paciente.Sexo}");
            }
        }

        public static void PacientesOrdemAlfabetica()
        {
            var pacientesOrdenados = pacientes.OrderBy(p => p.Nome).ToList();
            foreach (var paciente in pacientesOrdenados)
            {
                Console.WriteLine($"Paciente: {paciente.Nome}");
            }
        }

        public static void PacientesPorSintomas(string textoSintomas)
        {
            var pacientesComSintomas = pacientes.Where(p => p.Sintomas.Any(s => s.ToLower().Contains(textoSintomas.ToLower()))).ToList();
            foreach (var paciente in pacientesComSintomas)
            {
                Console.WriteLine($"Paciente: {paciente.Nome}, Sintomas: {string.Join(", ", paciente.Sintomas)}");
            }
        }

        public static void AniversariantesDoMes(int mes)
        {
            var medicosAniversariantes = medicos.Where(m => m.DataNascimento.Month == mes).ToList();
            var pacientesAniversariantes = pacientes.Where(p => p.DataNascimento.Month == mes).ToList();

            Console.WriteLine($"Aniversariantes do Mês {mes}:");

            foreach (var medico in medicosAniversariantes)
            {
                Console.WriteLine($"Médico aniversariante: {medico.Nome}");
            }

            foreach (var paciente in pacientesAniversariantes)
            {
                Console.WriteLine($"Paciente aniversariante: {paciente.Nome}");
            }
        }

        public static void AtendimentosEmAberto()
        {
            var atendimentosAbertos = atendimentos.Where(a => a.Fim == default(DateTime)).OrderByDescending(a => a.Inicio).ToList();
            foreach (var atendimento in atendimentosAbertos)
            {
                Console.WriteLine($"Atendimento em aberto - Início: {atendimento.Inicio}, Paciente: {atendimento.Paciente.Nome}");
            }
        }

        public static void MedicosOrdemAtendimentosConcluidos()
        {
            var medicosOrdenados = medicos.OrderByDescending(m => atendimentos.Count(a => a.MedicoResponsavel == m && a.Fim != default(DateTime))).ToList();
            foreach (var medico in medicosOrdenados)
            {
                Console.WriteLine($"Médico: {medico.Nome}, Quantidade de Atendimentos Concluídos: {atendimentos.Count(a => a.MedicoResponsavel == medico && a.Fim != default(DateTime))}");
            }
        }

        public static void AtendimentosPorPalavraChave(string palavraChave)
        {
            var atendimentosComPalavraChave = atendimentos.Where(a => a.SuspeitaInicial.ToLower().Contains(palavraChave.ToLower()) || a.DiagnosticoFinal.ToLower().Contains(palavraChave.ToLower())).ToList();
            foreach (var atendimento in atendimentosComPalavraChave)
            {
                Console.WriteLine($"Atendimento - Suspeita: {atendimento.SuspeitaInicial}, Diagnóstico Final: {atendimento.DiagnosticoFinal}");
            }
        }

        public static void Top10ExamesUtilizados()
        {
            var examesUtilizados = atendimentos.SelectMany(a => a.ListaExamesResultado).GroupBy(e => e.Item1).OrderByDescending(g => g.Count()).Take(10);

            Console.WriteLine("Top 10 Exames mais Utilizados:");

            foreach (var exame in examesUtilizados)
            {
                Console.WriteLine($"Exame: {exame.Key.Titulo}, Quantidade: {exame.Count()}");
            }
        }

         static void Main() {
            while (true) {
            Console.WriteLine("\n=== Menu Principal ===");
            Console.WriteLine("1. Adicionar Médico");
            Console.WriteLine("2. Adicionar Paciente");
            Console.WriteLine("3. Iniciar Atendimento");
            Console.WriteLine("4. Finalizar Atendimento");
            Console.WriteLine("5. Adicionar Exame");
            Console.WriteLine("6. Listar Médicos");
            Console.WriteLine("7. Listar Pacientes");
            Console.WriteLine("8. Listar Atendimentos em Aberto");
            Console.WriteLine("9. Médicos entre idades");
            Console.WriteLine("10. Pacientes entre idades");
            Console.WriteLine("11. Pacientes por sexo");
            Console.WriteLine("12. Pacientes em ordem alfabética");
            Console.WriteLine("13. Pacientes por sintomas");
            Console.WriteLine("14. Aniversariantes do Mês");
            Console.WriteLine("15. Listar Atendimentos em Aberto");
            Console.WriteLine("16. Médicos por atendimentos concluídos");
            Console.WriteLine("17. Atendimentos por palavra-chave");
            Console.WriteLine("18. Top 10 Exames Utilizados");

            Console.Write("\nEscolha uma opção (ou 's' para sair): ");
            string escolha = Console.ReadLine();

            switch (escolha) {
                case "1":
                    Consultorio.AdicionarMedico();
                    break;
                case "2":
                    Consultorio.AdicionarPaciente();
                    break;
                case "3":
                    Consultorio.IniciarAtendimento();
                    break;
                case "4":
                    Consultorio.FinalizarAtendimento();
                    break;
                case "5":
                    Consultorio.AdicionarExame();
                    break;
                case "6":
                    Consultorio.ListarMedicos();
                    break;
                case "7":
                    Consultorio.ListarPacientes();
                    break;
                case "8":
                    Consultorio.ListarAtendimentosEmAberto();
                    break;
                case "9":
                    Console.Write("Idade mínima: ");
                    int idadeMinima = int.Parse(Console.ReadLine());
                    Console.Write("Idade máxima: ");
                    int idadeMaxima = int.Parse(Console.ReadLine());
                    Consultorio.MedicosEntreIdades(idadeMinima, idadeMaxima);
                    break;
                case "10":
                    Console.Write("Idade mínima: ");
                    idadeMinima = int.Parse(Console.ReadLine());
                    Console.Write("Idade máxima: ");
                    idadeMaxima = int.Parse(Console.ReadLine());
                    Consultorio.PacientesEntreIdades(idadeMinima, idadeMaxima);
                    break;
                case "11":
                    Console.Write("Informe o sexo: ");
                    string sexo = Console.ReadLine();
                    Consultorio.PacientesPorSexo(sexo);
                    break;
                case "12":
                    Consultorio.PacientesOrdemAlfabetica();
                    break;
                case "13":
                    Console.Write("Digite os sintomas: ");
                    string textoSintomas = Console.ReadLine();
                    Consultorio.PacientesPorSintomas(textoSintomas);
                    break;
                case "14":
                    Console.Write("Informe o mês: ");
                    int mes = int.Parse(Console.ReadLine());
                    Consultorio.AniversariantesDoMes(mes);
                    break;
                case "15":
                    Consultorio.AtendimentosEmAberto();
                    break;
                case "16":
                    Consultorio.MedicosOrdemAtendimentosConcluidos();
                    break;
                case "17":
                    Console.Write("Digite a palavra-chave: ");
                    string palavraChave = Console.ReadLine();
                    Consultorio.AtendimentosPorPalavraChave(palavraChave);
                    break;
                case "18":
                    Consultorio.Top10ExamesUtilizados();
                    break;
                case "s":
                    Console.WriteLine("Encerrando o programa.");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
}