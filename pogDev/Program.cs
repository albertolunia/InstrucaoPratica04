﻿
Hospital h = new Hospital();
try{
h.adicionaMedico(new Medico("joao","12345678901","2000/12/03","2"));
h.adicionaMedico(new Medico("maria","12345678921","1998/2/1","1"));
h.adicionaPaciente(new Paciente("jorge","00222211111","2000/2/1","masculino",""));
h.adicionaPaciente(new Paciente("jorga","00222211111","2001/4/1","feminino","gosta de programar"));
h.MedicosIdade(18,30);
h.AniversariosNoMes(3);
h.PacientesComSintomas();
h.PacientesOrdemAlfabetica();
h.PacientesSexo("masculino");
}
catch(Exception e){
    Console.WriteLine(e);
    Console.ReadLine(); //espera o enter
    
}

class Pessoa{
    protected String nome;
    protected DateTime dataDeNascimento;
    protected string cpf;
    public string Nome{
        get{
            return nome;
        }
        set{
            nome = value;
        }
    }
    public DateTime DataDeNascimento{
        get{
            return dataDeNascimento;
        }
        set{
            dataDeNascimento = value;
        }
    }
    public string Cpf{
        get{
        return cpf;
        }set{
            if ((value.Length==11)||value.All(char.IsDigit))
                cpf = value;
            else
                throw new ArgumentException("CPF invalido");
            
        }
    }

    public Pessoa(string nome, string cpf, string dataDeNascimento){
        this.nome = nome;
        if ((cpf.Length==11)||cpf.All(char.IsDigit))
                this.cpf = cpf;
            else
                throw new ArgumentException("CPF invalido");
        this.dataDeNascimento = DateTime.Parse(dataDeNascimento);
    }
}

class Medico : Pessoa{
    private string crm;
    public string Crm{
        get{
            return crm;
        }
        set{
            crm = value;
        }
    }
        public Medico(string nome,string cpf,string dataDeNascimento,string crm) : base(nome,cpf,dataDeNascimento){
        this.crm = crm;
        
    }
}

class Paciente : Pessoa{
    private string sexo;
    private string sintomas;
    public string Sexo{
        get{
            return sexo;
        }
        set{
            if((value.ToLower().Equals("masculino"))||(value.ToLower().Equals("feminino")))
                sexo = value.ToLower();
            else
                throw new Exception("Sexo invalido");
        }
    }
    public string Sintomas{
        get{
            return sintomas;
        }
        set{
            sintomas = value;
        }
    }


    public Paciente(string nome,string cpf,string dataDeNascimento,string sexo,string sintomas):base(nome,cpf,dataDeNascimento){
        
        this.sintomas = sintomas;
        if((sexo.Equals("masculino"))||(sexo.Equals("feminino")))
            this.sexo = sexo;
        else
            throw new Exception("Sexo invalido");
    }

}

class Hospital{
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