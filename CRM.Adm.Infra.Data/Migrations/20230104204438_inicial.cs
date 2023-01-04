using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Adm.Infra.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHtml = table.Column<int>(type: "int", nullable: false),
                    CodInterno = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CnpjParametro = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    CnpjConsultado = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    CnpjNumInscricao = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    NomeEmpresarial = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataImportacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PorteEmpresa = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    FatBrutoAnual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
