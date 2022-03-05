using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorCondominios.DAL.Migrations
{
    public partial class criacaoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FUNCOES",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCOES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MESES",
                columns: table => new
                {
                    MesId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MESES", x => x.MesId);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    CPF = table.Column<string>(maxLength: 30, nullable: false),
                    Foto = table.Column<string>(nullable: false),
                    PrimeiroAcesso = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_FUNCOES_RoleId",
                        column: x => x.RoleId,
                        principalTable: "FUNCOES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ALUGUEIS",
                columns: table => new
                {
                    AluguelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(nullable: false),
                    MesId = table.Column<int>(nullable: false),
                    Ano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALUGUEIS", x => x.AluguelId);
                    table.ForeignKey(
                        name: "FK_ALUGUEIS_MESES_MesId",
                        column: x => x.MesId,
                        principalTable: "MESES",
                        principalColumn: "MesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HISTORICO_RECURSOS",
                columns: table => new
                {
                    HistoricoRecursosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Dia = table.Column<int>(nullable: false),
                    MesId = table.Column<int>(nullable: false),
                    Ano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORICO_RECURSOS", x => x.HistoricoRecursosId);
                    table.ForeignKey(
                        name: "FK_HISTORICO_RECURSOS_MESES_MesId",
                        column: x => x.MesId,
                        principalTable: "MESES",
                        principalColumn: "MesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "APARTAMENTOS",
                columns: table => new
                {
                    ApartamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(nullable: false),
                    Andar = table.Column<int>(nullable: false),
                    Foto = table.Column<string>(nullable: false),
                    MoradorId = table.Column<string>(nullable: true),
                    ProprietarioId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APARTAMENTOS", x => x.ApartamentoId);
                    table.ForeignKey(
                        name: "FK_APARTAMENTOS_USUARIOS_MoradorId",
                        column: x => x.MoradorId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_APARTAMENTOS_USUARIOS_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_USUARIOS_UserId",
                        column: x => x.UserId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_USUARIOS_UserId",
                        column: x => x.UserId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_FUNCOES_RoleId",
                        column: x => x.RoleId,
                        principalTable: "FUNCOES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_USUARIOS_UserId",
                        column: x => x.UserId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_USUARIOS_UserId",
                        column: x => x.UserId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EVENTOS",
                columns: table => new
                {
                    EventoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENTOS", x => x.EventoId);
                    table.ForeignKey(
                        name: "FK_EVENTOS_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SERVICOS",
                columns: table => new
                {
                    ServicoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICOS", x => x.ServicoId);
                    table.ForeignKey(
                        name: "FK_SERVICOS_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VEICULOS",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    Marca = table.Column<string>(maxLength: 30, nullable: false),
                    Cor = table.Column<string>(maxLength: 20, nullable: false),
                    Placa = table.Column<string>(maxLength: 20, nullable: false),
                    UsuarioId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEICULOS", x => x.VeiculoId);
                    table.ForeignKey(
                        name: "FK_VEICULOS_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    PagamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(nullable: true),
                    AluguelId = table.Column<int>(nullable: false),
                    DataPagemento = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.PagamentoId);
                    table.ForeignKey(
                        name: "FK_Pagamentos_ALUGUEIS_AluguelId",
                        column: x => x.AluguelId,
                        principalTable: "ALUGUEIS",
                        principalColumn: "AluguelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamentos_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SERVICO_PREDIOS",
                columns: table => new
                {
                    ServicoPredioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicoId = table.Column<int>(nullable: false),
                    DataExecucao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICO_PREDIOS", x => x.ServicoPredioId);
                    table.ForeignKey(
                        name: "FK_SERVICO_PREDIOS_SERVICOS_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "SERVICOS",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FUNCOES",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "403b9628-3ce2-4323-845b-88db50457110", "31d59d42-9e3b-4218-9d14-8a4dd212a4bf", "Morador do prédio", "Morador", "MORADOR" },
                    { "ff966b36-018a-477e-8898-57a3a56a3ebb", "3d6bd0a7-c11e-4590-bcc1-68593d536c15", "Síndico do prédio", "Sindico", "SINDICO" },
                    { "e75d8187-a973-47a4-a4dd-3824966faeeb", "04278b1c-c4f0-4c17-8f74-7285d4ac9fd8", "Administrador do prédio", "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "MESES",
                columns: new[] { "MesId", "Nome" },
                values: new object[,]
                {
                    { 1, "Janeiro" },
                    { 2, "Fevereiro" },
                    { 3, "Março" },
                    { 4, "Abril" },
                    { 5, "Maio" },
                    { 6, "Junho" },
                    { 7, "Julho" },
                    { 8, "Agosto" },
                    { 9, "Setembro" },
                    { 10, "Outubro" },
                    { 11, "Novembro" },
                    { 12, "Dezembro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALUGUEIS_MesId",
                table: "ALUGUEIS",
                column: "MesId");

            migrationBuilder.CreateIndex(
                name: "IX_APARTAMENTOS_MoradorId",
                table: "APARTAMENTOS",
                column: "MoradorId");

            migrationBuilder.CreateIndex(
                name: "IX_APARTAMENTOS_ProprietarioId",
                table: "APARTAMENTOS",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EVENTOS_UsuarioId",
                table: "EVENTOS",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "FUNCOES",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_RECURSOS_MesId",
                table: "HISTORICO_RECURSOS",
                column: "MesId");

            migrationBuilder.CreateIndex(
                name: "IX_MESES_Nome",
                table: "MESES",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_AluguelId",
                table: "Pagamentos",
                column: "AluguelId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_UsuarioId",
                table: "Pagamentos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICO_PREDIOS_ServicoId",
                table: "SERVICO_PREDIOS",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICOS_UsuarioId",
                table: "SERVICOS",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_CPF",
                table: "USUARIOS",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "USUARIOS",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "USUARIOS",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VEICULOS_Placa",
                table: "VEICULOS",
                column: "Placa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VEICULOS_UsuarioId",
                table: "VEICULOS",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APARTAMENTOS");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EVENTOS");

            migrationBuilder.DropTable(
                name: "HISTORICO_RECURSOS");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "SERVICO_PREDIOS");

            migrationBuilder.DropTable(
                name: "VEICULOS");

            migrationBuilder.DropTable(
                name: "FUNCOES");

            migrationBuilder.DropTable(
                name: "ALUGUEIS");

            migrationBuilder.DropTable(
                name: "SERVICOS");

            migrationBuilder.DropTable(
                name: "MESES");

            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
