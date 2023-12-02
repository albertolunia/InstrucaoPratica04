namespace pogDev;

public class Consultorio{
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
    public Consultorio(){
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

    public void removePaciente(string cpfPaciente){

    }

    public void removeMedico(string cpfMedico){

    }


}  
