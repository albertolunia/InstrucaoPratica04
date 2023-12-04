namespace pogDev;

public class Atendimento{
    private Paciente pacienteAtendido;
    private Medico medicoAtendente;
    private DateTime inicio;
    private DateTime fim;
    private List<(Exame, string)> examesResultados;
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
    public DateTime Inicio{
        get{
            return inicio;
        }
        set{
            inicio = value;
        }
    }
    public DateTime Fim{
        get{
            return fim;
        }
        set{
            fim = value;
        }
    }
    public List<(Exame,string)> ExamesResultados{
        get{
            return examesResultados;
        }
        set{
            examesResultados = value;
        }
    }
    public string Diagnostico{
        get{
            return diagnostico;
        }
        set{
            diagnostico = value;
        }
    }
    public string Suspeita{
        get{
            return suspeita;
        }
        set{
            suspeita = value;
        }
    }
    public float Preco{
        get{
            return preco;
        }
        set{
            preco = value;
        }
    }

    public Atendimento(){
        this.examesResultados = new List<(Exame, string)>();
        this.finalizada = false;
    }


    public void iniciaAtendimento(Medico medico, Paciente paciente, List<Exame> examesSolicitados, float preco, string suspeita){
        this.inicio = DateTime.Now;
        this.medicoAtendente = medico;
        this.pacienteAtendido = paciente;
        this.preco = preco;
        this.suspeita = suspeita;
        foreach(Exame exame in examesSolicitados){
            this.examesResultados.Add((exame,""));
        }
    }

    public void finalizaAtendimento(List<string> resultadosExames, string diagnostico){
        this.fim = DateTime.Now;
        this.finalizada = true;
        this.diagnostico = diagnostico;
        int i = 0;

        if(resultadosExames.Count == this.examesResultados.Count){
            foreach(string resultado in resultadosExames){
                this.examesResultados[i] = (this.examesResultados[i].Item1, resultado);
                i++;
            }
        }else
            throw new Exception("Quantidade de resultados não bate com a quantidade de exames");
    }

    public void imprimeAtendimentoAberto(){
        Console.WriteLine($"Medico: {this.medicoAtendente.Nome}, CRM: {this.medicoAtendente.Crm}, Paciente: {this.pacienteAtendido.Nome}, CPF: {this.pacienteAtendido.Cpf}, Inicio {this.Inicio}");
        Console.WriteLine($"Suspeita: {this.suspeita}");
        Console.Write("Exames: ");
        foreach((Exame,string) exame in this.ExamesResultados){
            Console.Write($"{exame.Item1.Nome}, ");
        }
        Console.WriteLine($"");
    }

}
