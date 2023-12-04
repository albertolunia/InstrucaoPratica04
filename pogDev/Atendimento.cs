namespace pogDev;

public class Atendimento{
    private Paciente pacienteAtendido;
    private Medico medicoAtendente;
    private DateTime inicio;
    private DateTime fim;
    private List<(Exame, string)> examesResultado;
    private float preco;
    private string diagnostico;
    private string suspeita;

    private Boolean finalizada;


    public Paciente PacienteAtendido{
        get{
            return pacienteAtendido;
        }
        set{
            pacienteAtendido = value;
        }
    }

    public Medico MedicoAtendente{
        get{
            return medicoAtendente;
        }
        set{
            medicoAtendente = value;
        }
    }

    public Boolean Finalizada{
        get{
            return finalizada;
        }
        set{
            finalizada = value;
        }
}

    public Atendimento(){
        List<(Exame, string)> examesResultado = new List<(Exame, string)>();
        this.finalizada = false;
    }

    public void iniciaAtendimento(Medico medico, Paciente paciente, List<Exame> examesSolicitados, float preco, string suspeita){
        this.inicio = DateTime.Now;
        this.medicoAtendente = medico;
        this.PacienteAtendido = paciente;
        this.preco = preco;
        this.suspeita = suspeita;
        foreach(Exame exame in examesSolicitados){
            this.examesResultado.Add((exame,""));
        }
    }

    public void finalizaAtendimento(List<string> resultadosExames, string diagnostico){
        this.fim = DateTime.Now;
        this.finalizada = true;
        this.diagnostico = diagnostico;
        int i = 0;

        if(resultadosExames.Count == this.examesResultado.Count){
            foreach(string resultado in resultadosExames){
                this.examesResultado[i] = (this.examesResultado[i].Item1, resultado);
                i++;
            }
        }else
            throw new Exception("Quantidade de resultados não bate com a quantidade de exames");
        
        
        
    }
}
