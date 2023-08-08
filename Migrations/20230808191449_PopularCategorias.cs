using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lanches.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Categorias(CategoriaNome,Descricao) VALUES ('Normal','Lanche feito com ingredientes normais')");
            mb.Sql("INSERT INTO Categorias(CategoriaNome,Descricao) VALUES ('Natural','Lanche feito com ingredientes naturais')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Categorias");
        }
    }
}
