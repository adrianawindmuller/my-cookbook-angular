using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCookbook.Infrastructure.Data.Migrations
{
    public partial class seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 1,
                columns: new[] { "Ingredients", "PreparationMode" },
                values: new object[] { "1/2 xícara (chá) de óleo /n3 cenouras médias raladas /n4 ovos \n2 xícaras(chá) de açúcar \n2 e 1 / 2 xícaras(chá) de farinha de trigo\n1 colher(sopa) de fermento em pó", "Em um liquidificador, adicione a cenoura, os ovos e o óleo, depois misture. \nAcrescente o açúcar e bata novamente por 5 minutos. \nEm uma tigela ou na batedeira, \nadicione a farinha de trigo e depois misture novamente. \nAcrescente o fermento e misture lentamente com uma colher. \nAsse em um forno preaquecido a 180° C por aproximadamente 40 minutos." });

            migrationBuilder.UpdateData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 2,
                columns: new[] { "Ingredients", "PreparationMode" },
                values: new object[] { "1 caixa de leite condensado \n1 colher(sopa) de margarina sem sal \n7 colheres(sopa) de achocolatado ou 4 colheres(sopa) de chocolate em pó \nchocolate granulado", "Em uma panela funda, acrescente o leite condensado, a margarina e o chocolate em pó. \nCozinhe em fogo médio e mexa até que o brigadeiro comece a desgrudar da panela. \nDeixe esfriar e faça pequenas bolas com a mão passando a massa no chocolate granulado." });

            migrationBuilder.UpdateData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 3,
                columns: new[] { "Ingredients", "PreparationMode" },
                values: new object[] { "250 g de abóbora moranga \n3 dentes de alho \n1 / 2 cebola cortada em cubinhos \nFio de óleo", "Descasque a abobora , corte-a em cubos. \nEm uma panela de pressão coloque o oleo, junte os alhos amassados e a cebola em cubinhos e deixe dourar, acrescente uma pitada de urucum os cubinhos de tempero e refogue a abobora. \nPonha aproximadamente 750 ml de água, feche a panela e deixe cozinhar por 20 minutos. \nDesligue o fogo, bata o conteudo com o mixter ou liquidificador até obter um creme homogêneo. \nVolte este creme ao fogo por mais 5 minutos, se ficar muito grosso acrescente um pouco de água e corrija o sal \nSirva, \nsalpicando a cebolinha, acompanhada de trorradas." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 1,
                columns: new[] { "Ingredients", "PreparationMode" },
                values: new object[] { "1/2 xícara (chá) de óleo /n3 cenouras médias raladas /n4 ovos /n2 xícaras(chá) de açúcar /n2 e 1 / 2 xícaras(chá) de farinha de trigo/n1 colher(sopa) de fermento em pó", "Em um liquidificador, adicione a cenoura, os ovos e o óleo, depois misture. /nAcrescente o açúcar e bata novamente por 5 minutos. /nEm uma tigela ou na batedeira, /nadicione a farinha de trigo e depois misture novamente. /nAcrescente o fermento e misture lentamente com uma colher. /nAsse em um forno preaquecido a 180° C por aproximadamente 40 minutos." });

            migrationBuilder.UpdateData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 2,
                columns: new[] { "Ingredients", "PreparationMode" },
                values: new object[] { "1 caixa de leite condensado /n1 colher(sopa) de margarina sem sal /n7 colheres(sopa) de achocolatado ou 4 colheres(sopa) de chocolate em pó /nchocolate granulado", "Em uma panela funda, acrescente o leite condensado, a margarina e o chocolate em pó. /nCozinhe em fogo médio e mexa até que o brigadeiro comece a desgrudar da panela. /nDeixe esfriar e faça pequenas bolas com a mão passando a massa no chocolate granulado." });

            migrationBuilder.UpdateData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 3,
                columns: new[] { "Ingredients", "PreparationMode" },
                values: new object[] { "250 g de abóbora moranga /n3 dentes de alho /n1 / 2 cebola cortada em cubinhos /nFio de óleo", "Descasque a abobora , corte-a em cubos. /nEm uma panela de pressão coloque o oleo, junte os alhos amassados e a cebola em cubinhos e deixe dourar, acrescente uma pitada de urucum os cubinhos de tempero e refogue a abobora. /nPonha aproximadamente 750 ml de água, feche a panela e deixe cozinhar por 20 minutos. /nDesligue o fogo, bata o conteudo com o mixter ou liquidificador até obter um creme homogêneo. /nVolte este creme ao fogo por mais 5 minutos, se ficar muito grosso acrescente um pouco de água e corrija o sal /nSirva, /nsalpicando a cebolinha, acompanhada de trorradas." });
        }
    }
}
