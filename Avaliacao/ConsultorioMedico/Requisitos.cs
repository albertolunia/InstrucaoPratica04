namespace ConsultorioMedico{
    class Requisitos{
        List<Paciente> pacientes = new();
        List<Medico> medicos = new();

        public Requisitos(){
            Paciente paciente = new();
            Medico medico = new();
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
                if (!pacientes.Any(p => p.Cpf == paciente.Cpf))
                    pacientes.Add(paciente);
                else
                    Console.WriteLine("\nPaciente já cadastrado!!!");
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
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
                if (!medicos.Any(m => m.Cpf == medico.Cpf) && !medicos.Any(m => m.Crm == medico.Crm))
                    medicos.Add(medico);
                else
                    Console.WriteLine("\nMédico já cadastrado!!!");
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

        public void ListarPacientes(){
            Console.WriteLine("\nLista de pacientes:\n");
            foreach (Paciente paciente in pacientes)
                Console.WriteLine($"Nome: {paciente.Nome} | CPF: {FormatarCPF(paciente.Cpf)} | Data de Nascimento: {FormatarData(paciente.DataNascimento)} | Sexo: {paciente.Sexo} | Sintomas: {paciente.Sintomas}");
        }

        public void ListarMedicos(){
            Console.WriteLine("\nLista de medicos:\n");
            foreach (Medico medico in medicos)
                Console.WriteLine($"Nome: {medico.Nome} | CPF: {FormatarCPF(medico.Cpf)} | Data de Nascimento: {FormatarData(medico.DataNascimento)} | CRM: {medico.Crm}");
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
        }

        public void PacientesEntreIdade(int idade1, int idade2)
        {
            var pacientesEntreIdade = pacientes.Where(p => p.CalcularIdade() >= idade1 && p.CalcularIdade() <= idade2).ToList();
            Console.WriteLine($"\nLista de pacientes entre as idades({idade1} e {idade2}):\n");
            foreach (Paciente paciente in pacientesEntreIdade)
                Console.WriteLine($"Nome: {paciente.Nome} | CPF: {FormatarCPF(paciente.Cpf)} | Data de Nascimento: {FormatarData(paciente.DataNascimento)} | Sexo: {paciente.Sexo} | Sintomas: {paciente.Sintomas}");
        }

        public void PacientesDoSexo(string sexo){
            var pacientesDoSexo = pacientes.Where(p => p.Sexo == sexo).ToList();
            Console.WriteLine($"\nLista de pacientes do sexo({sexo}):\n");
            foreach (Paciente paciente in pacientesDoSexo)
                Console.WriteLine($"Nome: {paciente.Nome} | CPF: {FormatarCPF(paciente.Cpf)} | Data de Nascimento: {FormatarData(paciente.DataNascimento)} | Sexo: {paciente.Sexo} | Sintomas: {paciente.Sintomas}");
        }

        public void ListarPacientesEmOrdem(){
            Console.WriteLine("\nLista de pacientes em ordem alfabética:\n");
            foreach (Paciente paciente in pacientes.OrderBy(p => p.Nome))
                Console.WriteLine($"Nome: {paciente.Nome} | CPF: {FormatarCPF(paciente.Cpf)} | Data de Nascimento: {FormatarData(paciente.DataNascimento)} | Sexo: {paciente.Sexo} | Sintomas: {paciente.Sintomas}");
        }

        public void PacientesComSintomas(string sintoma){
            var pacientesComSintomas = pacientes.Where(p => p.Sintomas.Contains(sintoma)).ToList();
            Console.WriteLine($"\nLista de pacientes com sintomas({sintoma}):\n");
            foreach (Paciente paciente in pacientesComSintomas)
                Console.WriteLine($"Nome: {paciente.Nome} | CPF: {FormatarCPF(paciente.Cpf)} | Data de Nascimento: {FormatarData(paciente.DataNascimento)} | Sexo: {paciente.Sexo} | Sintomas: {paciente.Sintomas}");
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
        }
    }
}