namespace Clinica;

public class Exame {
    private string titulo, descricao, local;
    private float preco;

    public string Titulo{
        get {return titulo;}
        set {titulo = value;}
    }
    public string Descricao{
        get {return descricao;}
        set {descricao = value;}
    }
    public string Local{
        get {return local;}
        set {local = value;}
    }
    public float Preco{
        get {return preco;}
        set {preco = value;}
    }
    public void DadosExame(List <Exame> exames){
        Console.WriteLine($"Digite o título do exame");
        titulo = Console.ReadLine()!;
        Console.WriteLine($"Digite a descrição do exame");
        descricao = Console.ReadLine()!;
        Console.WriteLine($"Digite o local do exame");
        local = Console.ReadLine()!;
        Console.WriteLine($"Digite o preço do exame");
        preco = float.Parse(Console.ReadLine()!); 

        exames.Add(this);
        Console.WriteLine($"Exame adicionado com sucesso!");
    }
}
