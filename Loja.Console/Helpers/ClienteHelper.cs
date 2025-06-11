using Loja.Shared.Contexts;
using Loja.Shared.Models;
using static System.Console;

namespace Loja.Console.Helpers;

internal static class ClienteHelper
{
    public static void Cadastrar()
    {
        var cliente = new Cliente();
        MenuHelper.CriarCabecalho("CADASTRO DE CLIENTE");
        Write(" Codigo: ");
        cliente.Id = Convert.ToInt32(ReadLine());

        Write(" Nome:   ");
        cliente.Nome = ReadLine();

        Write(" CPF:  ");
        cliente.Cpf = ReadLine();

        Write(" Email:  ");
        cliente.Email = ReadLine();

        Write(" Celular:  ");
        cliente.Celular = ReadLine();

        MenuHelper.CriarLinha();
        LojaContext.Clientes.Add(cliente);
        Write(" [Enter] para continuar... ");
        ReadLine();
        MenuHelper.MenuCliente();
    }

    public static void Listar()
    {
        MenuHelper.CriarCabecalho("LISTA DE CLIENTES");
        if (LojaContext.Clientes.Count == 0)
        {
            WriteLine(" Nenhum cliente cadastrado.");
        }
        else
        {
            foreach (var cliente in LojaContext.Clientes)
            {
                WriteLine(" " + cliente);
            }
        }
        MenuHelper.CriarLinha();
        Write(" [Enter] para continuar... ");
        ReadLine();
        MenuHelper.MenuCliente();
    }

    public static void Editar()
    {
        MenuHelper.CriarCabecalho("EDITAR CLIENTE");
        Write(" Informe o ID do cliente: ");
        int id = Convert.ToInt32(ReadLine());
        var cliente = LojaContext.Clientes.FirstOrDefault(p => p.Id == id);

        if (cliente == null)
        {
            WriteLine(" Cliente não encontrado.");
        }
        else
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"\n Nome Atual: {cliente.Nome}");
            ForegroundColor = ConsoleColor.White;
            Write(" Novo Nome:  ");
            var nome = ReadLine();
            if (!string.IsNullOrEmpty(nome))
                cliente.Nome = nome;

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"\n Celular Atual: {cliente.Celular}");
            ForegroundColor = ConsoleColor.White;
            Write(" Novo Celular:  ");
            var celular = ReadLine();
            if (!string.IsNullOrEmpty(celular))
                cliente.Celular = celular;

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"\n E-mail Atual: {cliente.Email}");
            ForegroundColor = ConsoleColor.White;
            Write(" Novo E-mail:  ");
            var email = ReadLine();
            if (!string.IsNullOrEmpty(email))
                cliente.Email = email;


            WriteLine("\n Cliente atualizado com sucesso.");
        }
        MenuHelper.CriarLinha();
        Write(" [Enter] para continuar... ");
        ReadLine();
        MenuHelper.MenuCliente();
    }
    
    public static void Excluir()
    {
        MenuHelper.CriarCabecalho("EXCLUIR CLIENTE");
        Write(" Informe o ID do cliente: ");
        int id = Convert.ToInt32(ReadLine());
        var cliente = LojaContext.Clientes.FirstOrDefault(p => p.Id == id);

        if (id == null)
        {
            WriteLine(" Cliente não encontrado.");
        }
        else
        {
            WriteLine(" \n Deseja realmente excluir");
            WriteLine(" " + id);
            Write(" [S] Sim / [N] Não: ");
            var opcao = ReadLine()?.ToUpper();
            if (opcao == "S")
            {
                LojaContext.Clientes.Remove(cliente);
                WriteLine(" Cliente excluído com sucesso.");
            }
        }
        MenuHelper.CriarLinha();
        Write(" [Enter] para continuar... ");
        ReadLine();
        MenuHelper.MenuCliente();
    }
}
