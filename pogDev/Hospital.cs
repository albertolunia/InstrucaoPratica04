namespace pogDev;

public class Hospital{
    private List<Paciente> pacientes;
    private List<Medico> medicos;
    private List<Pessoa> pessoas;

    public List<Pessoa> Pessoas{
        get{
            return pessoas;
        }
        set{
            pessoas = value;
        }
    }

    public List<Paciente> Pacientes{
        get{
            return pacientes;
        }
        set{
            pacientes = value;
        }
    }
    public List<Medico> Medicos{
        get{
            return medicos;
        }
        set{
            medicos = value;
        }
    }
    public Hospital(){
        pacientes = new List<Paciente>();
        medicos = new List<Medico>();
        pessoas = new List<Pessoa>();
    }

    public void adicionaPaciente(Paciente novoPaciente){
        if(Pacientes.Any(x => x.Cpf == novoPaciente.Cpf))
            throw new ArgumentException("Paciente ja incluso na lista");
        else
            Pacientes.Add(novoPaciente);
            Pessoas.Add(novoPaciente);
    }
    public void adicionaMedico(Medico novoMedico){
        if(Medicos.Any(x => (x.Cpf == novoMedico.Cpf)||(x.Crm == novoMedico.Crm)))
            throw new ArgumentException("Medico ja incluso na lista");
        else
            Medicos.Add(novoMedico);
            Pessoas.Add(novoMedico);
    }


    public void MedicosIdade(int idadeInf,int idadeSup){
        List<Medico> relatorio = new List<Medico>();
        relatorio = Medicos.Where(x => (DateTime.Now.Year-x.DataDeNascimento.Year>idadeInf)&&(DateTime.Now.Year-x.DataDeNascimento.Year>idadeSup)).ToList();
        foreach(Medico medico in relatorio){
            Console.WriteLine($"Nome: {medico.Nome}, CRM: {medico.Crm}");
        }
    }

    public void PacienteIdade(int idadeInf,int idadeSup){
        List<Paciente> relatorio = new List<Paciente>();
        relatorio = Pacientes.Where(x => (DateTime.Now.Year-x.DataDeNascimento.Year>idadeInf)&&(DateTime.Now.Year-x.DataDeNascimento.Year>idadeSup)).ToList();
        foreach(Paciente paciente in relatorio){
            Console.WriteLine($"Nome: {paciente.Nome}, CPF: {paciente.Cpf}");
        }
    }
    public void PacientesSexo(string sexo){
        List<Paciente> relatorio = new List<Paciente>();
        relatorio = Pacientes.Where(x => (x.Sexo.Equals(sexo))).ToList();
        foreach(Paciente paciente in relatorio){
            Console.WriteLine($"Nome: {paciente.Nome}, CPF: {paciente.Cpf}");
        }
    }

    public void PacientesOrdemAlfabetica(){
        List<Paciente> relatorio = new List<Paciente>();
        relatorio = Pacientes.OrderBy(x => x.Nome).ToList();
        foreach(Paciente paciente in relatorio){
            Console.WriteLine($"Nome: {paciente.Nome}, CPF: {paciente.Cpf}");
        }
    }

    public void PacientesComSintomas(){
        List<Paciente> relatorio = new List<Paciente>();
        relatorio = Pacientes.Where(x => x.Sintomas.Length!=0).ToList();
        foreach(Paciente paciente in relatorio){
            Console.WriteLine($"Nome: {paciente.Nome}, CPF: {paciente.Cpf}");
        }
    }

    public void AniversariosNoMes(int mes){
        List<Pessoa> relatorio = new List<Pessoa>();
        relatorio = Pessoas.Where(x => x.DataDeNascimento.Month == mes).ToList();
        foreach(Pessoa pessoa in relatorio){
            Console.WriteLine($"Nome: {pessoa.Nome}, CPF: {pessoa.Cpf}");
        }
    }

}  
