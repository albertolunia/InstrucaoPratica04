namespace Clinica;

public class Relatorios
{
Medico medico = new Medico();
    Paciente paciente = new Paciente();

public void RelatorioIdadeMedico(){

    Console.WriteLine("Digite a idade mínima:");
    int minimo = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite a idade máxima:");
    int maximo = int.Parse(Console.ReadLine());
    //fazer validação ppra idade

    var MedicoPorIdade = medico.DadosMedico.Where(p => p.Idade >= minimo && p.Idade<= maximo);

    Console.WriteLine($"Medicos com idade entre {minimo} e {maximo}:");
        foreach (var med in paciente.DadosMedico)
            {
                Console.WriteLine($"Nome: {med.Nome}, Data de nascimento: {med.DataNascimento}, CPF: {med.CPF}, Sexo:{med.Sexo}, Sintomas:{med.Sintomas} ");
            } 
}

   public void RelatorioIdadePaciente(){
    Console.WriteLine("Digite a idade mínima:");
    int minimo = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite a idade máxima:");
    int maximo = int.Parse(Console.ReadLine());
    //fazer validação ppra idade

    var PacientePorIdade = paciente.DadosPaciente.Where(p => p.Idade >= minimo && p.Idade<= maximo);

    Console.WriteLine($"Medicos com idade entre {minimo} e {maximo}:");
        foreach (var pac in paciente.DadosPaciente)
            {
                Console.WriteLine($"Nome: {pac.Nome}, Data de nascimento: {pac.DataNascimento}, CPF: {pac.CPF}, Sexo:{pac.Sexo}, Sintomas:{pac.Sintomas} ");
            } 
}

public void PacienteSexo(){
    string sexo;

    Console.Write("Digite o sexo do paciente");
    sexo = Console.ReadLine();

    var PacientePorSexo = paciente.DadosPaciente.Where(p => p.Sexo == sexo).ToList();

    Console.WriteLine($"Pacientes com o sexo {sexo}");
    foreach (var Paciente in paciente.DadosPaciente)
    {
        Console.WriteLine($"Nome: {Paciente.Nome}, Data de nascimento: {Paciente.DataNascimento}, CPF: {Paciente.CPF}, Sexo:{Paciente.Sexo}, Sintomas:{Paciente.Sintomas} ");
    } 

}
public void PacienteOrdemAlfabetica(){

}
public void PacienteSintoma(){
    string sintoma;

    Console.Write("Digite o sexo do paciente");
    sintoma = Console.ReadLine();

    var PacientePorSintoma = paciente.DadosPaciente.Where(p => p.Sintomas == sintoma).ToList();

    Console.WriteLine($"Paciente com o sexo {sintoma}");
    foreach (var Paciente in paciente.DadosPaciente)
    {
        Console.WriteLine($"Nome: {Paciente.Nome}, Data de nascimento: {Paciente.DataNascimento}, CPF: {Paciente.CPF}, Sexo:{Paciente.Sexo}, Sintomas:{Paciente.Sintomas} ");
    } 
}
}
