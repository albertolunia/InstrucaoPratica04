namespace Namespace;

public class Atendimento
{
    public DateTime Inicio{get; set;}
    public string SuspeitaInicial{get; set;}
    public List<(Exame exame, string resultado)> Exames{get; set;}
    public float Valor{get; set;}
    private DateTime _fim;
    public DateTime Fim{
        get{
            return this._fim;
        }
        set{
            if(this.Inicio > this._fim){
                throw new Exception("Data inválida");
            }
        }
    }
    public Medico MedicoResponsavel{get; set;}
    public Paciente Paciente{get; set;}
    public string DiagnosticoFinal{get; set;}
    public Atendimento(){
        this.Exames = new List<(Exame exame, string resultado)>();
        this._fim = DateTime.MaxValue;
        this.Inicio = DateTime.MinValue;
    }
}
