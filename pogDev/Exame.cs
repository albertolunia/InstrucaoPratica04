namespace pogDev;

public class Exame{

private float valor;

private string nome;
private string descricao;
private string local;
public string Nome{
    get{
    return nome;
    }set{
        nome = value;
    }
}
public string Descricao{
    get{
    return descricao;
    }
    set{
        descricao = value;
    }
}

public string Local{
    get{
    return local;
    }set{
        local = value;
    }
}
public float Valor{
    get{
        return valor;
    }
    set{
        if(value<0){
            throw new Exception("Preço negativo");
        }
        else{
            valor = value;
        }
    }
}
public Exame(string nome,string descricao, string local, float preco){
    this.nome = nome;
    this.descricao = descricao;
    this.local = local;
    if(preco<0)
        throw new Exception("Preço negativo");
    else
        this.valor = preco;
}

}
