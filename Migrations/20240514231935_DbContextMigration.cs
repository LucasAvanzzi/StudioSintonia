using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioSintoniaPreview.Migrations
{
    /// <inheritdoc />
    public partial class DbContextMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfissaoModels",
                columns: table => new
                {
                    ProfissaoModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfissaoNome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfissaoModels", x => x.ProfissaoModelId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostModelId = table.Column<int>(type: "int", nullable: false),
                    TagNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfissaoModelId = table.Column<int>(type: "int", nullable: false),
                    UsuarioFoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    UsuarioBio = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UsuarioProfissaoNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioModelId);
                    table.ForeignKey(
                        name: "FK_Usuarios_ProfissaoModels_ProfissaoModelId",
                        column: x => x.ProfissaoModelId,
                        principalTable: "ProfissaoModels",
                        principalColumn: "ProfissaoModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModelId = table.Column<int>(type: "int", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Curtidas = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostModelId);
                    table.ForeignKey(
                        name: "FK_Posts_Usuarios_UsuarioModelId",
                        column: x => x.UsuarioModelId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioModelId",
                        onDelete: ReferentialAction.Cascade);

                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    ComentarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioModelId = table.Column<int>(type: "int", nullable: false),
                    PostModelId = table.Column<int>(type: "int", nullable: false),
                    UsuarioNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.ComentarioId);
                    table.ForeignKey(
                        name: "FK_Comentarios_Posts_PostModelId",
                        column: x => x.PostModelId,
                        principalTable: "Posts",
                        principalColumn: "PostModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Usuarios_UsuarioModelId",
                        column: x => x.UsuarioModelId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioModelId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PostModelTag",
                columns: table => new
                {
                    PostagensPostModelId = table.Column<int>(type: "int", nullable: false),
                    TagsTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostModelTag", x => new { x.PostagensPostModelId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_PostModelTag_Posts_PostagensPostModelId",
                        column: x => x.PostagensPostModelId,
                        principalTable: "Posts",
                        principalColumn: "PostModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostModelTag_Tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PostModelId",
                table: "Comentarios",
                column: "PostModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsuarioModelId",
                table: "Comentarios",
                column: "UsuarioModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PostModelTag_TagsTagId",
                table: "PostModelTag",
                column: "TagsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UsuarioModelId",
                table: "Posts",
                column: "UsuarioModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ProfissaoModelId",
                table: "Usuarios",
                column: "ProfissaoModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "PostModelTag");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "ProfissaoModels");
        }
    }
}
