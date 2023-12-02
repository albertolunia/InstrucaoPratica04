/*1. Médicos com idade entre dois valores.
2. Pacientes com idade entre dois valores.
3. Pacientes do sexo informado pelo usuário.
4. Pacientes em ordem alfabética.
5. Pacientes cujos sintomas contenha texto informado pelo usuário.
6. Médicos e Pacientes aniversariantes do mês informado.
7. Atendimentos em aberto (sem finalizar) em ordem decrescente pela
data de início.
8. Médicos em ordem decrescente da quantidade de atendimentos
concluídos.
9. Atendimentos cuja suspeita ou diagnóstico final contenham
determinada palavra.
10. Os 10 exames mais utilizados nos atendimentos.
*/
namespace ConsultorioMedico{
    class Menu{


        public static void ImprimirMenuPrincipal(){
            Console.WriteLine("1. Cadastro.");
            Console.WriteLine("2. Relatórios.");
            Console.WriteLine("3. Sair.");
            Console.Write("Digite a opção desejada: ");
        }

        public static void ImprimirMenuCadastro(){
            Console.WriteLine("1. Cadastrar médico.");
            Console.WriteLine("2. Cadastrar paciente.");
            Console.WriteLine("3. Cadastrar atendimento.");
            Console.WriteLine("4. Cadastrar exames.");
            Console.WriteLine("5. Sair.");
            Console.Write("Digite a opção desejada: ");
        }
        public static void ImprimirMenuRelatorios(){
            Console.WriteLine("1. Médicos com idade entre dois valores.");
            Console.WriteLine("2. Pacientes com idade entre dois valores.");
            Console.WriteLine("3. Pacientes do sexo informado pelo usuário.");
            Console.WriteLine("4. Pacientes em ordem alfabética.");
            Console.WriteLine("5. Pacientes cujos sintomas contenha texto informado pelo usuário.");
            Console.WriteLine("6. Médicos e Pacientes aniversariantes do mês informado.");
            Console.WriteLine("7. Atendimentos em aberto (sem finalizar) em ordem decrescente pela data de início.");
            Console.WriteLine("8. Médicos em ordem decrescente da quantidade de atendimentos concluídos.");
            Console.WriteLine("9. Atendimentos cuja suspeita ou diagnóstico final contenham determinada palavra.");
            Console.WriteLine("10. Os 10 exames mais utilizados nos atendimentos.");
            Console.WriteLine("11. Sair");
            Console.Write("Digite a opção desejada: ");
        }
    }
}