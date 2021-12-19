using Microsoft.EntityFrameworkCore.Migrations;

namespace DQuiz.Database.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "OrderSequence",
                startValue: 6L);

            migrationBuilder.CreateTable(
                name: "QuestionTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR OrderSequence"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnswerTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    IsTrue = table.Column<bool>(type: "bit", nullable: false),
                    ChosenCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerTable_QuestionTable_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "QuestionTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetricTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrueCount = table.Column<int>(type: "int", nullable: false),
                    FalseCount = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetricTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetricTable_QuestionTable_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "QuestionTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "QuestionTable",
                columns: new[] { "Id", "Order", "Text" },
                values: new object[,]
                {
                    { 1, 1, "Star Wars evreninde Anakin Skywalker'ın ustası kimdir?" },
                    { 2, 2, "Metal Gear Solid serisinde Naked Snake, Big Boss ünvanını nasıl kazanmıştır?" },
                    { 3, 3, "Final Fantasy 7 Remake oyununda kahramanlarımız kaderi değiştirdiğinde, \"The Price of Freedom is Steep\" repliğiye akıllara kazınan ve ölmesi gerekirken ölmeyen karakter hangisidir?" },
                    { 4, 4, "Nier Replicant oyununda Devola ve Popola'nın tavernada söylediği şarkının adı nedir?" },
                    { 5, 5, "Silent Hill 2 oyununda kahramanımızın eşine tıpatıp benzeyen ve kahramanımızı cezalandırmak için gönderilen karakterin adı nedir?" }
                });

            migrationBuilder.InsertData(
                table: "UserTable",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "12345", "GAIH" });

            migrationBuilder.InsertData(
                table: "AnswerTable",
                columns: new[] { "Id", "ChosenCount", "IsTrue", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1, 0, false, 1, "Adi Gallia" },
                    { 19, 0, false, 5, "Angela" },
                    { 18, 0, true, 5, "Maria" },
                    { 17, 0, false, 5, "Laura" },
                    { 16, 0, true, 4, "Song of The Ancient" },
                    { 15, 0, false, 4, "Deep Crimson Foe" },
                    { 14, 0, false, 4, "Kaine Escape" },
                    { 13, 0, false, 4, "The Prestigious Mask" },
                    { 12, 0, false, 3, "Noctis" },
                    { 20, 0, false, 5, "Eileen" },
                    { 10, 0, false, 3, "Sephiroth" },
                    { 11, 0, false, 3, "Cloud" },
                    { 8, 0, false, 2, "Ocelot ile olan mücadelesini kazanarak" },
                    { 7, 0, false, 2, "Ünlü bilim adamı Sokolov'u Ruslardan kaçırarak" },
                    { 6, 0, false, 2, "Eski mentörü olan Boss'u Amerika'ya teslim ederek" },
                    { 5, 0, true, 2, "Eski mentörü olan Boss'u öldürerek" },
                    { 4, 0, false, 1, "Sheev Palpatine" },
                    { 3, 0, true, 1, "Obi-Wan Kenobi" },
                    { 2, 0, false, 1, "Mace Windu" },
                    { 9, 0, true, 3, "Zack Fair" }
                });

            migrationBuilder.InsertData(
                table: "MetricTable",
                columns: new[] { "Id", "FalseCount", "QuestionId", "TrueCount" },
                values: new object[,]
                {
                    { 2, 0, 2, 0 },
                    { 3, 0, 3, 0 },
                    { 1, 0, 1, 0 },
                    { 4, 0, 4, 0 },
                    { 5, 0, 5, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerTable_QuestionId",
                table: "AnswerTable",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_MetricTable_QuestionId",
                table: "MetricTable",
                column: "QuestionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerTable");

            migrationBuilder.DropTable(
                name: "MetricTable");

            migrationBuilder.DropTable(
                name: "UserTable");

            migrationBuilder.DropTable(
                name: "QuestionTable");

            migrationBuilder.DropSequence(
                name: "OrderSequence");
        }
    }
}
