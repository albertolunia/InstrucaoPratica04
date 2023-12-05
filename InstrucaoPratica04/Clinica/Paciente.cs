namespace Namespace;
public class Paciente : Pessoa
{
    private string _sexo;
    public string Sexo{
        get{
            return this._sexo;
        }
        set{
            if(value != "FEMININO" && value != "MASCULINO"){
                throw new Exception("Valor inválido");
            }
            else{
                this._sexo = value;
            }
        }
    }
    public List<string> Sintomas {get; set;}
   
}
