using Microsoft.EntityFrameworkCore.Migrations;

namespace DevPlace.Blog.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticuloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentarios_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "Id", "Contenido", "Descripcion", "Titulo" },
                values: new object[,]
                {
                    { 1, null, "Griffin Beak Eldritch", "Berry" },
                    { 2, null, "Swashbuckler Rye", "Nancy" },
                    { 3, null, "Ivory Bones Sweet", "Eli" },
                    { 4, null, "The Unseen Stafford", "Arnold" },
                    { 5, null, "Toxic Reyson", "Seabury" },
                    { 6, null, "Fearless Cloven", "Rutherford" },
                    { 7, null, "Crow Ridley", "Atherton" },
                    { 8, null, "The Hawk Morris", "Huxford" },
                    { 9, null, "Rigger Quye", "Dwennon" },
                    { 10, null, "Subtle Asema", "Rushford" }
                });

            migrationBuilder.InsertData(
                table: "Commentarios",
                columns: new[] { "Id", "ArticuloId", "Texto" },
                values: new object[,]
                {
                    { 1, 1, "Commandeering a Ship Without Getting Caught" },
                    { 2, 1, "Overthrowing Mutiny" },
                    { 3, 2, "Avoiding Brawls While Drinking as Much Rum as You Desire" },
                    { 4, 2, "Singalong Pirate Hits" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentarios_ArticuloId",
                table: "Commentarios",
                column: "ArticuloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentarios");

            migrationBuilder.DropTable(
                name: "Articulos");
        }
    }
}
