using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaVeterinaria.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Celular = table.Column<string>(nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    Bairro = table.Column<string>(nullable: false),
                    Rua = table.Column<string>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeEspecie = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EspecieId = table.Column<int>(nullable: false),
                    ProprietarioId = table.Column<int>(nullable: false),
                    AnimalId = table.Column<int>(nullable: false),
                    ValorConsulta = table.Column<double>(nullable: false),
                    pago = table.Column<bool>(nullable: false),
                    Sintomas = table.Column<string>(nullable: true),
                    VeterinarioId = table.Column<int>(nullable: false),
                    MedicamentoId = table.Column<int>(nullable: false),
                    DataConsulta = table.Column<DateTime>(nullable: false),
                    CaixaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_Especies_EspecieId",
                        column: x => x.EspecieId,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veterinarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Celular = table.Column<string>(nullable: false),
                    Registro = table.Column<int>(nullable: false),
                    ConsultaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veterinarios_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeDoExame = table.Column<string>(nullable: false),
                    AnimalId = table.Column<int>(nullable: false),
                    ProprietarioId = table.Column<int>(nullable: false),
                    EspecieId = table.Column<int>(nullable: false),
                    ValorExame = table.Column<double>(nullable: false),
                    Realizado = table.Column<bool>(nullable: false),
                    CaixaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exames_Especies_EspecieId",
                        column: x => x.EspecieId,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeMedicamento = table.Column<string>(maxLength: 60, nullable: true),
                    DescricaoMedicamento = table.Column<string>(maxLength: 120, nullable: true),
                    AnimalId = table.Column<int>(nullable: false),
                    ProprietarioId = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeAnimal = table.Column<string>(maxLength: 60, nullable: false),
                    Idade = table.Column<int>(nullable: false),
                    DescricaoEspecie = table.Column<string>(maxLength: 60, nullable: true),
                    Sexo = table.Column<string>(maxLength: 1, nullable: true),
                    EspecieId = table.Column<int>(nullable: false),
                    Peso = table.Column<float>(nullable: false),
                    Altura = table.Column<string>(nullable: false),
                    ProprietarioId = table.Column<int>(nullable: false),
                    CaixaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_Especies_EspecieId",
                        column: x => x.EspecieId,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proprietarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeProprietario = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    CaixaId = table.Column<int>(nullable: true),
                    ConsultaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proprietarios_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Caixas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<double>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    ConsultaId = table.Column<int>(nullable: false),
                    AnimalId = table.Column<int>(nullable: false),
                    ProprietarioId = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caixas_Proprietarios_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Proprietarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_CaixaId",
                table: "Animal",
                column: "CaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_EspecieId",
                table: "Animal",
                column: "EspecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ProprietarioId",
                table: "Animal",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Caixas_ProprietarioId",
                table: "Caixas",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_AnimalId",
                table: "Consultas",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_CaixaId",
                table: "Consultas",
                column: "CaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_EspecieId",
                table: "Consultas",
                column: "EspecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MedicamentoId",
                table: "Consultas",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_ProprietarioId",
                table: "Consultas",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_VeterinarioId",
                table: "Consultas",
                column: "VeterinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_AnimalId",
                table: "Exames",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_CaixaId",
                table: "Exames",
                column: "CaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_EspecieId",
                table: "Exames",
                column: "EspecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_ProprietarioId",
                table: "Exames",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_AnimalId",
                table: "Medicamentos",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_ProprietarioId",
                table: "Medicamentos",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietarios_CaixaId",
                table: "Proprietarios",
                column: "CaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietarios_ConsultaId",
                table: "Proprietarios",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Veterinarios_ConsultaId",
                table: "Veterinarios",
                column: "ConsultaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Caixas_CaixaId",
                table: "Consultas",
                column: "CaixaId",
                principalTable: "Caixas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Proprietarios_ProprietarioId",
                table: "Consultas",
                column: "ProprietarioId",
                principalTable: "Proprietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Animal_AnimalId",
                table: "Consultas",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Medicamentos_MedicamentoId",
                table: "Consultas",
                column: "MedicamentoId",
                principalTable: "Medicamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Veterinarios_VeterinarioId",
                table: "Consultas",
                column: "VeterinarioId",
                principalTable: "Veterinarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exames_Caixas_CaixaId",
                table: "Exames",
                column: "CaixaId",
                principalTable: "Caixas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exames_Proprietarios_ProprietarioId",
                table: "Exames",
                column: "ProprietarioId",
                principalTable: "Proprietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exames_Animal_AnimalId",
                table: "Exames",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamentos_Proprietarios_ProprietarioId",
                table: "Medicamentos",
                column: "ProprietarioId",
                principalTable: "Proprietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamentos_Animal_AnimalId",
                table: "Medicamentos",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Caixas_CaixaId",
                table: "Animal",
                column: "CaixaId",
                principalTable: "Caixas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Proprietarios_ProprietarioId",
                table: "Animal",
                column: "ProprietarioId",
                principalTable: "Proprietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proprietarios_Caixas_CaixaId",
                table: "Proprietarios",
                column: "CaixaId",
                principalTable: "Caixas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Caixas_CaixaId",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Caixas_CaixaId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Proprietarios_Caixas_CaixaId",
                table: "Proprietarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Especies_EspecieId",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Especies_EspecieId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Proprietarios_ProprietarioId",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Proprietarios_ProprietarioId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicamentos_Proprietarios_ProprietarioId",
                table: "Medicamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Animal_AnimalId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicamentos_Animal_AnimalId",
                table: "Medicamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Medicamentos_MedicamentoId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Veterinarios_VeterinarioId",
                table: "Consultas");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Exames");

            migrationBuilder.DropTable(
                name: "Caixas");

            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "Proprietarios");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "Veterinarios");

            migrationBuilder.DropTable(
                name: "Consultas");
        }
    }
}
