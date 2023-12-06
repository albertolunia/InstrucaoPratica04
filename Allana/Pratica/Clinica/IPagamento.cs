namespace Namespace;

public interface IPagamento{
    string Descricao{get; set;}
    double ValorBruto{get; set;}
    double Desconto {get; set;}
    DateTime Data {get; set;}

    void ReceberPagamento();
}