using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaCategorias : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO CATEGORIAS(NOME, IMAGEMURL) VALUES('laptop', 'https://bit.ly/3NWzsi4')");
            mb.Sql("INSERT INTO CATEGORIAS(NOME, IMAGEMURL) VALUES('smartphone', 'https://bit.ly/3RPQu2t')");
            mb.Sql("INSERT INTO CATEGORIAS(NOME, IMAGEMURL) VALUES('perifericos', 'https://bit.ly/47wodUu')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
        }
    }
}
