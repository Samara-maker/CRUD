

using CRUD.utilitario;
using CRUD.mapeamento;
using CRUD.DAO;
//try
//{
//    Aluno a = new Aluno();

//    a.nome = "Sam";
//    a.CPF = "05800132275";
//    a.DataNasc = new DateOnly(2006, 05, 11);
//    a.sexo = "F";
//    a.altura = 160;
//    a.telefone = "69 993697530";


//    AlunoDAO aDAO = new AlunoDAO();
//    aDAO.Cadastrar(a);
//    //aDAO.Alterar(a);
//    //aDAO.Delete(a);

//    foreach(Aluno aa in aDAO.BuscarTodos())
//    {
//        Console.WriteLine(aa.nome);
//    }

//}catch(Exception ex)
//{
//    Console.WriteLine("ERRO" + ex.Message);
//}

//Console.WriteLine("olá");
//Conexao.Conectar();

//try
//{
//    Funcionario a = new Funcionario();

//    a.nome = "Sam";
//    a.telefone = "69993697530";
//    a.dataAdmissao = new DateOnly(2025, 05, 11);
//    a.dataNasc = new DateOnly(2006, 05, 11);
//    a.email = "samarahespanhol@gmail.com";


//    FuncionarioDAO aDAO = new FuncionarioDAO();
//    aDAO.Cadastrar(a);
//    //aDAO.Alterar(a);
//    //aDAO.Delete(a);

//    foreach (Funcionario aa in aDAO.BuscarTodos())
//    {
//        Console.WriteLine(aa.nome);
//    }

//}
//catch (Exception ex)
//{
//    Console.WriteLine("ERRO" + ex.Message);
//}

//Console.WriteLine("olá");
//Conexao.Conectar();

try
{
    Plano a = new Plano();

    a.descricao = "m";
    a.ValorSugerido = 6;
    a.atv = false;


    PlanoDAO aDAO = new PlanoDAO();
    //aDAO.Cadastrar(a);
    //aDAO.Alterar(a);
    //aDAO.Delete(a);

    foreach (Plano aa in aDAO.BuscarTodos())
    {
        Console.WriteLine(aa.descricao);
    }

}
catch (Exception ex)
{
    Console.WriteLine("ERRO" + ex.Message);
}

Console.WriteLine("olá");
Conexao.Conectar();