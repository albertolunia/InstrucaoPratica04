
namespace ConsultorioMedico
{
    class Requisitos{
        List<Paciente> pacientes = new();
        List<Medico> medicos = new();
        List<Atendimento> atendimentosEmAndamento = new();
        List<Atendimento> atendimentosFinalizados = new();
        List<Exame> exames = new();

        public void AddExame(Exame exame)
        {
            try
            {
                if (exame == null)
                    throw new Exception("Exame inválido!!!");
                if (exame.Titulo == "")
                    throw new Exception("Título inválido!!!");
                if (exame.Valor <= 0)
                    throw new Exception("Valor inválido!!!");
                if (exame.Local == "")
                    throw new Exception("Local inválido!!!");
                if (exames.Any(e => e.Titulo == exame.Titulo))
                    throw new Exception("Exame já cadastrado!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            exames.Add(exame);
        }

        public Requisitos(){
            Paciente paciente = new();
            Medico medico = new();
            List<Exame> exames = new();
            List<Atendimento> atendimentosEmAndamento = new();
            List<Atendimento> atendimentosFinalizados = new();
        }
        
        public List<Atendimento> AtendimentosEmAndamento{
            get{
                return atendimentosEmAndamento;
            }
        }

        public List<Atendimento> AtendimentosFinalizados{
            get{
                return atendimentosFinalizados;
            }
        }

        public Medico getMedico(string cpf)
        {
            medicos = MedicosDisponiveis;
            try
            {
                foreach (Medico medico in medicos)
                {
                    if (medico.Cpf == cpf)
                    {
                        return medico;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            return null;
            
        }

        public Paciente getPaciente(string cpf){
            pacientes = PacientesDisponiveis;
            try{
                foreach (Paciente paciente in pacientes)
                    if (paciente.Cpf == cpf)
                        return paciente;
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
            return null;

        }

        public void CadastrarPaciente(Paciente paciente){
            try{
                if (paciente.CalcularIdade() < 0)
                    throw new Exception("Data de nascimento inválida!!!");
                if (paciente.Sexo != "M" && paciente.Sexo != "m" && paciente.Sexo != "F" && paciente.Sexo != "f")
                    throw new Exception("Sexo inválido!!!");
                if (paciente.Sintomas == "")
                    throw new Exception("Sintomas inválidos!!!");
                if (paciente.Cpf.Length != 11)
                    throw new Exception("CPF inválido!!!");
                if (paciente.DataNascimento.Length != 8)
                    throw new Exception("Data de nascimento inválida!!!");
                if (paciente.Nome == "")
                    throw new Exception("Nome inválido!!!");
                if (!pacientes.Any(p => p.Cpf == paciente.Cpf)){
                    pacientes.Add(paciente);
                    Console.WriteLine("\nPaciente cadastrado com sucesso!!!");
                    Console. ReadKey(true);
                }
                else{
                    Console.WriteLine("\nPaciente já cadastrado!!!");
                    Console. ReadKey(true);
                }
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
                Console. ReadKey(true);
            }
        }

        public void CadastrarMedico(Medico medico){
            try{
                if (medico.CalcularIdade() < 0)
                    throw new Exception("Data de nascimento inválida!!!");
                if (medico.Crm == "")
                    throw new Exception("CRM inválido!!!");
                if (medico.Cpf.Length != 11)
                    throw new Exception("CPF inválido!!!");
                if (medico.DataNascimento.Length != 8)
                    throw new Exception("Data de nascimento inválida!!!");
                if (medico.Nome == "")
                    throw new Exception("Nome inválido!!!");
                if (!medicos.Any(m => m.Cpf == medico.Cpf) && !medicos.Any(m => m.Crm == medico.Crm)){
                    medicos.Add(medico);
                    Console.WriteLine("\nMédico cadastrado com sucesso!!!");
                    Console. ReadKey(true);
                }
                else{
                    Console.WriteLine("\nMédico já cadastrado!!!");
                    Console. ReadKey(true);
                }
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

        public void ListarPacientes(){
            Console.WriteLine("\nLista de pacientes:\n");
            foreach (Paciente paciente in pacientes)
                Console.WriteLine($"Nome: {paciente.Nome} | CPF: {FormatarCPF(paciente.Cpf)} | Data de Nascimento: {FormatarData(paciente.DataNascimento)} | Sexo: {paciente.Sexo} | Sintomas: {paciente.Sintomas}");
            Console. ReadKey(true);
        }

        public void ListarMedicos(){
            Console.WriteLine("\nLista de medicos:\n");
            foreach (Medico medico in medicos)
                Console.WriteLine($"Nome: {medico.Nome} | CPF: {FormatarCPF(medico.Cpf)} | Data de Nascimento: {FormatarData(medico.DataNascimento)} | CRM: {medico.Crm}");
            Console. ReadKey(true);
        }

        private string FormatarCPF(string cpf){
            return cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
        }

        private string FormatarData(string data){
            return data.Insert(2, "/").Insert(5, "/");
        }

        public void MedicosEntreIdade(int idade1, int idade2)
        {
            var medicosEntreIdade = medicos.Where(m => m.CalcularIdade() >= idade1 && m.CalcularIdade() <= idade2).ToList();
            Console.WriteLine($"\nLista de medicos entre as idades({idade1} e {idade2}):\n");
            foreach (Medico medico in medicosEntreIdade)
                Console.WriteLine($"Nome: {medico.Nome} | CPF: {FormatarCPF(medico.Cpf)} | Data de Nascimento: {FormatarData(medico.DataNascimento)} | CRM: {medico.Crm}");
            Console. ReadKey(true);
        }

        public void PacientesEntreIdade(int idade1, int idade2)
        {
            var pacientesEntreIdade = pacientes.Where(p => p.CalcularIdade() >= idade1 && p.CalcularIdade() <= idade2).ToList();
            Console.WriteLine($"\nLista de pacientes entre as idades({idade1} e {idade2}):\n");
            foreach (Paciente paciente in pacientesEntreIdade)
                Console.WriteLine($"Nome: {paciente.Nome} | CPF: {FormatarCPF(paciente.Cpf)} | Data de Nascimento: {FormatarData(paciente.DataNascimento)} | Sexo: {paciente.Sexo} | Sintomas: {paciente.Sintomas}");
            Console. ReadKey(true);
        }

        public void PacientesDoSexo(string sexo){
            var pacientesDoSexo = pacientes.Where(p => p.Sexo == sexo).ToList();
            Console.WriteLine($"\nLista de pacientes do sexo({sexo}):\n");
            foreach (Paciente paciente in pacientesDoSexo)
                Console.WriteLine($"Nome: {paciente.Nome} | CPF: {FormatarCPF(paciente.Cpf)} | Data de Nascimento: {FormatarData(paciente.DataNascimento)} | Sexo: {paciente.Sexo} | Sintomas: {paciente.Sintomas}");
            Console. ReadKey(true);
        }

        public void ListarPacientesEmOrdem(){
            Console.WriteLine("\nLista de pacientes em ordem alfabética:\n");
            foreach (Paciente paciente in pacientes.OrderBy(p => p.Nome))
                Console.WriteLine($"Nome: {paciente.Nome} | CPF: {FormatarCPF(paciente.Cpf)} | Data de Nascimento: {FormatarData(paciente.DataNascimento)} | Sexo: {paciente.Sexo} | Sintomas: {paciente.Sintomas}");
            Console. ReadKey(true);
        }

        public void PacientesComSintomas(string sintoma){
            var pacientesComSintomas = pacientes.Where(p => p.Sintomas.Contains(sintoma)).ToList();
            Console.WriteLine($"\nLista de pacientes com sintomas({sintoma}):\n");
            foreach (Paciente paciente in pacientesComSintomas)
                Console.WriteLine($"Nome: {paciente.Nome} | CPF: {FormatarCPF(paciente.Cpf)} | Data de Nascimento: {FormatarData(paciente.DataNascimento)} | Sexo: {paciente.Sexo} | Sintomas: {paciente.Sintomas}");
            Console. ReadKey(true);
        }

        public void AniversariantesDoMes(int mes){
            var pacientesAniversariantesDoMes = pacientes.Where(p => int.Parse(p.DataNascimento.Substring(2, 2)) == mes).ToList();
            var medicosAniversariantesDoMes = medicos.Where(m => int.Parse(m.DataNascimento.Substring(2, 2)) == mes).ToList();
            Console.WriteLine($"\nLista de pacientes aniversariantes do mês({mes}):\n");
            foreach (Paciente paciente in pacientesAniversariantesDoMes)
                Console.WriteLine($"Nome: {paciente.Nome} | CPF: {FormatarCPF(paciente.Cpf)} | Data de Nascimento: {FormatarData(paciente.DataNascimento)} | Sexo: {paciente.Sexo} | Sintomas: {paciente.Sintomas}");
            Console.WriteLine($"\nLista de medicos aniversariantes do mês({mes}):\n");
            foreach (Medico medico in medicosAniversariantesDoMes)
                Console.WriteLine($"Nome: {medico.Nome} | CPF: {FormatarCPF(medico.Cpf)} | Data de Nascimento: {FormatarData(medico.DataNascimento)} | CRM: {medico.Crm}");
            Console. ReadKey(true);
        }

        public void IniciarAtendimento(Paciente paciente, Medico medico, string suspeitaInicial){
            try{
                if (paciente == null)
                    throw new Exception("Paciente inválido!!!");
                if (medico == null)
                    throw new Exception("Médico inválido!!!");
                if (suspeitaInicial == "")
                    throw new Exception("Suspeita inicial inválida!!!");
                if (!pacientes.Any(p => p.Cpf == paciente.Cpf))
                    throw new Exception("Paciente não cadastrado!!!");
                if (!medicos.Any(m => m.Cpf == medico.Cpf))
                    throw new Exception("Médico não cadastrado!!!");
                Atendimento atendimento = new(paciente, medico, suspeitaInicial);
                atendimentosEmAndamento.Add(atendimento);
                Console.WriteLine($"\nAtendimento iniciado às {atendimento.InicioAtendimento}!!!");
                Console.WriteLine($"Suspeita inicial: {atendimento.SuspeitaInicial}");
                Console. ReadKey(true);
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
                Console. ReadKey(true);
            }
        }

        public void SolicitarExame(Exame exame, Atendimento atendimento){
            try{
                if (exame == null)
                    throw new Exception("Exame inválido!!!");
                if (atendimento == null)
                    throw new Exception("Atendimento inválido!!!");
                if (!exames.Any(e => e.Titulo == exame.Titulo))
                    throw new Exception("Exame não cadastrado!!!");
                if (!atendimentosEmAndamento.Any(a => a.InicioAtendimento == atendimento.InicioAtendimento))
                    throw new Exception("Atendimento não iniciado!!!");
                atendimento.ExamesResultado.Add((exame, ""));
                Console.WriteLine($"\nExame {exame.Titulo} adicionado ao atendimento!!!");
                Console. ReadKey(true);
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
                Console. ReadKey(true);
            }
        }

        public void FinalizarAtendimento(Atendimento atendimento, string diagnosticoFinal){
            try{
                if (atendimento == null)
                    throw new Exception("Atendimento inválido!!!");
                if (diagnosticoFinal == "")
                    throw new Exception("Diagnóstico final inválido!!!");
                if (!atendimentosEmAndamento.Any(a => a.InicioAtendimento == atendimento.InicioAtendimento))
                    throw new Exception("Atendimento não iniciado!!!");
                atendimento.FimAtendimento = DateTime.Now;
                atendimento.DiagnosticoFinal = diagnosticoFinal;
                atendimento.Valor = atendimento.ExamesResultado.Sum(e => e.Item1.Valor);
                atendimentosFinalizados.Add(atendimento);
                atendimentosEmAndamento.Remove(atendimento);
                Console.WriteLine($"\nAtendimento finalizado às {atendimento.FimAtendimento}!!!");
                Console.WriteLine($"Valor: {atendimento.Valor}");
                Console. ReadKey(true);
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
                Console. ReadKey(true);
            }
        }

        public void ListarAtendimentosEmAberto(){
            var atendimentosEmAberto = atendimentosEmAndamento.OrderByDescending(a => a.InicioAtendimento);
            foreach (var atendimento in atendimentosEmAberto)
            {
                Console.WriteLine($"\nPaciente: {atendimento.PacienteAtendido.Nome}");
                Console.WriteLine($"Médico: {atendimento.MedicoResponsavel.Nome}");
                Console.WriteLine($"Início: {atendimento.InicioAtendimento}");
                Console.WriteLine($"Suspeita inicial: {atendimento.SuspeitaInicial}");
                Console.WriteLine("----------------------------------");
            }
            Console. ReadKey(true);
        }

        public void MedicosEmOrdemDecrescenteAtendimentosConcluidos()
        {
            var medicosOrdenados = medicos.OrderByDescending(m => atendimentosFinalizados.Count(a => a.MedicoResponsavel == m));
            foreach (var medico in medicosOrdenados)
            {
                Console.WriteLine($"\nMédico: {medico.Nome}");
                Console.WriteLine($"Quantidade de atendimentos concluídos: {atendimentosFinalizados.Count(a => a.MedicoResponsavel == medico)}");
                Console.WriteLine("----------------------------------");
            }
            Console. ReadKey(true);
        }

        public void AtendimentosComPalavra(string palavra)
        {
            var atendimentos = atendimentosEmAndamento.Concat(atendimentosFinalizados).ToList();
            var atendimentosComPalavra = atendimentos.Where(a => a.SuspeitaInicial.Contains(palavra) || a.DiagnosticoFinal.Contains(palavra)).ToList();
            foreach (var atendimento in atendimentosComPalavra)
            {
                Console.WriteLine($"\nPaciente: {atendimento.PacienteAtendido.Nome}");
                Console.WriteLine($"Médico: {atendimento.MedicoResponsavel.Nome}");
                Console.WriteLine($"Início: {atendimento.InicioAtendimento}");
                Console.WriteLine($"Suspeita inicial: {atendimento.SuspeitaInicial}");
                Console.WriteLine($"Diagnóstico final: {atendimento.DiagnosticoFinal}");
                Console.WriteLine("----------------------------------");
            }
            Console. ReadKey(true);
        }

        public void ImprimirExamesMaisUtilizados()
{
            var examesEmAndamento = atendimentosEmAndamento.SelectMany(a => a.ExamesResultado);
            var examesFinalizados = atendimentosFinalizados.SelectMany(a => a.ExamesResultado);
            var exames = examesEmAndamento.Concat(examesFinalizados).ToList();

            var examesAgrupados = exames.GroupBy(e => e.Item1.Titulo).ToList();
            var examesOrdenados = examesAgrupados.OrderByDescending(e => e.Count());
            foreach (var exame in examesOrdenados)
            {
                Console.WriteLine($"Exame: {exame.Key}");
                Console.WriteLine($"Quantidade de vezes utilizado: {exame.Count()}");
                Console.WriteLine("----------------------------------");
            }
            Console. ReadKey(true);
        }
        public List<Exame> ExamesDisponiveis{
            get{
                return exames;
            }
        }

        public List<Medico> MedicosDisponiveis{
            get{
                return medicos;
            }
        }

        public List<Paciente> PacientesDisponiveis{
            get{
                return pacientes;
            }
        }

        public void RemoverExame(string exame){
            try{
                if (exame == "")
                    throw new Exception("Exame inválido!!!");
                if (!exames.Any(e => e.Titulo == exame))
                    throw new Exception("Exame não cadastrado!!!");
                exames.Remove(exames.First(e => e.Titulo == exame));
                Console.WriteLine("\nExame removido com sucesso!!!");
                Console. ReadKey(true);
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
                Console. ReadKey(true);
            }
        }

        public void RemoverMedico(string medico){
            try{
                if (medico == "")
                    throw new Exception("Médico inválido!!!");
                if (!medicos.Any(m => m.Cpf == medico))
                    throw new Exception("Médico não cadastrado!!!");
                medicos.Remove(medicos.First(m => m.Cpf == medico));
                Console.WriteLine("\nMédico removido com sucesso!!!");
                Console. ReadKey(true);
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
                Console. ReadKey(true);
            }
        }

        public void RemoverPaciente(string paciente){
            try{
                if (paciente == "")
                    throw new Exception("Paciente inválido!!!");
                if (!pacientes.Any(p => p.Cpf == paciente))
                    throw new Exception("Paciente não cadastrado!!!");
                pacientes.Remove(pacientes.First(p => p.Cpf == paciente));
                Console.WriteLine("\nPaciente removido com sucesso!!!");
                Console. ReadKey(true);
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
                Console. ReadKey(true);
            }
        }
    }
}