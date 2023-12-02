namespace pogDev;

public class Paciente : Pessoa{
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
