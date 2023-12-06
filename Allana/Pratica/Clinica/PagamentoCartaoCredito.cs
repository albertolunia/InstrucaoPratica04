namespace Namespace;

public class PagamentoCartaoCredito : IPagamento{
    private string _descricao;
    private double _valorBruto;
    private double _desconto;
    private DateTime _data;
    public string Descricao{
        get{
            return this._descricao;
        }
        set{
            this._descricao = value;
        }
    }
    public double Desconto {
        get{
            return this._desconto;
        }
        set{
            this._desconto = value;
        }
    }
    public DateTime Data {
        get{
            return this._data;
        }
        set{
            this._data = value;
        }
    }
    public double ValorBruto { 
        get{
            return this._valorBruto;
        }
        set{
            this._valorBruto = value;
        }
    }
    public PagamentoCartaoCredito(double valorBruto){
        this._descricao = "Cartao de Crédito";
        this._desconto = 0.1;
        this._valorBruto = valorBruto;
    }
    public void ReceberPagamento(){
        double pagamento = this._valorBruto - this._valorBruto * this._desconto;
        Console.WriteLine("Recebido o pagamento de " + pagamento + " utilizando " + this._descricao);
    }
}