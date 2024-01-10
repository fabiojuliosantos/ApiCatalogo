using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
         mb.Sql("INSERT INTO PRODUTOS(NOME, DESCRICAO, PRECO, IMAGEMURL, ESTOQUE, DATACADASTRO, CATEGORIAID) " +
             "VALUES ('Notebook Lenovo Ideapad3', 'Notebook com 8GB de Ram e Ryzen7 5700U', 3000.00, 'laptop.jpg', 10, getdate(), 1)");

         mb.Sql("INSERT INTO PRODUTOS(NOME, DESCRICAO, PRECO, IMAGEMURL, ESTOQUE, DATACADASTRO, CATEGORIAID) " +
             "VALUES ('Kit teclado e mouse', 'Kit teclado e mouse logitech mk220', 150.00, 'perifericos.jpg', 37, getdate(), 3)");

         mb.Sql("INSERT INTO PRODUTOS(NOME, DESCRICAO, PRECO, IMAGEMURL, ESTOQUE, DATACADASTRO, CATEGORIAID) " +
             "VALUES ('Motorola moto e20', 'Smartphone Motorola Moto e20', 650.50, 'smartphone.jpg', 5, getdate(), 2)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
