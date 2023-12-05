namespace Clinica;

public class Consultorio{
    public static void addPaciente (List<Paciente> pacientes){
        Paciente paciente = new Paciente();
        try{
        paciente.pegaDadosPaciente(pacientes);
        pacientes.Add(paciente);
        } catch(Exception e){
            Console.WriteLine(e);
            Consultorio.addPaciente(pacientes);
        }
    }

    public static void addMedico (List<Medico> medicos){
    Medico medico = new Medico();
        try{
        medico.pegaDadosMedico(medicos);
        medicos.Add(medico);
        } catch(Exception e){
            Console.WriteLine(e);
            Consultorio.addMedico(medicos);
        }
    }
    public static void removeMedico(List<Medico> medicos){

    Console.WriteLine($"Digite o CPF do médico que deseja remover");
    string CPF = Console.ReadLine()!;
    
    if(medicos.Any(med => med.CPF == CPF)){
            medicos.Remove(medicos.Single(med => med.CPF == CPF));
        }
        else{
            throw new Exception("Este médico não existe no sistema");
        }
    }

    public static void removePaciente(List<Paciente> pacientes){

    Console.WriteLine($"Digite o CPF do paciente que deseja remover");
    string CPF = Console.ReadLine()!;

    if(pacientes.Any(paci => paci.CPF == CPF)){
            pacientes.Remove(pacientes.Single(med => med.CPF == CPF));
        }
        else{
            throw new Exception("Este paciente não existe no sistema");
        }
    }

    public static void addExame (List<Exame> exames){
    Exame exame = new Exame();
        try{
        exame.DadosExame(exames);
        } catch(Exception e) {
            Console.WriteLine(e);
            Consultorio.addExame(exames);
        }
    }

    public static void removeExame(List<Exame> exames){

    for (int i = 0; i < exames.Count; i++) {
    var exame = exames[i];
    Console.WriteLine($"Exame: {i} Título: {exame.Titulo} Descrição: {exame.Descricao} Valor: {exame.Preco} Local: {exame.Local}");
    }

    Console.WriteLine($"Digite o número do exame que deseja remover");
    int numero = int.Parse(Console.ReadLine()!);
    exames.Remove(exames[numero]);
    }
    
}


