namespace Namespace;
using System.Globalization;
class Program{
    
    static void Main(string[] args){
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
        List<Paciente> pacientes = new List<Paciente>();
        List<Medico> medicos = new List<Medico>();
        List<Atendimento> atendimentos = new List<Atendimento>();
        List<Exame> exames = new List<Exame>();
        int op = -1;
        do{
            Console.WriteLine("<----------MENU---------->");
            Console.WriteLine("1- Adicionar Paciente");
            Console.WriteLine("2- Remover Paciente");
            Console.WriteLine("3- Adicionar Médico");
            Console.WriteLine("4- Remover Médico");
            Console.WriteLine("5- Adicionar Exame");
            Console.WriteLine("6- Remover Exame");
            Console.WriteLine("7- Atendimentos");
            Console.WriteLine("8- Relatorios");
            Console.WriteLine("0- Sair");
            op = Int32.Parse(Console.ReadLine() ?? "-1");
            switch(op){
                case 1:
                    try{App.addPaciente(pacientes);}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 2:
                    try{App.removePaciente(pacientes);}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 3:
                    try{App.addMedico(medicos);}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 4:
                    try{App.removeMedico(medicos);}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 5:
                    try{App.addExame(exames);}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 6:
                    try{App.removeExame(exames);}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 7:
                    Atendimentos(atendimentos, pacientes, medicos, exames);
                    break;
                case 8:
                    Relatorio(atendimentos, pacientes, medicos, exames);
                    break;                    
            }
        }while(op != 0);        
    }
    static public void Atendimentos(List<Atendimento> atendimentos, List<Paciente> pacientes, List<Medico> medicos, List<Exame> exames){
        int op = -1;
        do{
            Console.WriteLine("<----------ATENDIMENTOS---------->");
            Console.WriteLine("1- Adicionar Atendimento");
            Console.WriteLine("2- Remover Atendimento");
            Console.WriteLine("3- Iniciar Atendimento");
            Console.WriteLine("4- Finalizar Atendimento");
            Console.WriteLine("5- Adicionar Exames");
            Console.WriteLine("0- Sair");
            op = Int32.Parse(Console.ReadLine() ?? "-1");
            switch(op){
                case 1:
                    try{App.addAtendimento(atendimentos, pacientes, medicos);}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 2:
                    try{App.removeAtendimento(atendimentos, pacientes);}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 3:
                    try{App.iniciarAtendimento(atendimentos, pacientes);}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 4:
                    try{App.encerrarAtendimento(atendimentos, pacientes);}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
                case 5:
                    try{App.adicionarExames(atendimentos, pacientes, exames);}
                    catch(Exception ex){Console.WriteLine(ex.Message);}
                    break;
            }
        }while(op != 0); 
    }
    static public void Relatorio(List<Atendimento> atendimentos, List<Paciente> pacientes, List<Medico> medicos, List<Exame> exames){
        int op = -1;
        do{
            Console.WriteLine("<----------RELATÓRIOS---------->");
            Console.WriteLine("1- Médicos com idade entre dois valores");
            Console.WriteLine("2- Pacientes com idade entre dois valores");
            Console.WriteLine("3- Pacientes com o mesmo sexo");
            Console.WriteLine("4- Pacientes em ordem alfabética");
            Console.WriteLine("5- Pacientes com o mesmo sintoma");
            Console.WriteLine("6- Aniversariantes do mês");
            Console.WriteLine("7- Atendimentos em aberto");
            Console.WriteLine("8- Médicos com atendimentos concluídos");
            Console.WriteLine("9- Atendimento com a mesma suspeita ou diagnóstico");
            Console.WriteLine("10- Top10 exames mais pedidos");
            Console.WriteLine("0- Sair");
            op = Int32.Parse(Console.ReadLine() ?? "-1");
            switch(op){
                case 1:
                    Relatorios.medicosIdades(medicos);
                    break;
                case 2:
                    Relatorios.pacientesIdades(pacientes);
                    break;
                case 3:
                    Relatorios.pacientesSexo(pacientes);
                    break;
                case 4:
                    Relatorios.pacientesOrdenado(pacientes);
                    break;
                case 5:
                    Relatorios.pacientesSintoma(pacientes);
                    break;
                case 6:
                    Relatorios.aniversariantes(pacientes, medicos);
                    break;
                case 7:
                    Relatorios.atendimentosAbertos(atendimentos);
                    break;
                case 8:
                    Relatorios.medicosAtendimento(atendimentos, medicos);
                    break;
                case 9:
                    Relatorios.diagnosticoOuSuspeita(atendimentos);
                    break;
                case 10:
                    Relatorios.examesMaisUtilizados(atendimentos, exames);
                    break;
            }
        }while(op != 0);    
    }
}