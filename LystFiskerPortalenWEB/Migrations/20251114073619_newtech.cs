using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LystFiskerPortalenWEB.Migrations
{
    /// <inheritdoc />
    public partial class newtech : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Blank", "Blank" });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 2, "En af de mest klassiske rigs i både salt- og ferskvand. Et lod sidder nederst, og 1–3 kroge sidder på korte forfang (”trembler”) over loddet.", "Paternoster-rig" },
                    { 3, "Et kuglelod glider frit på hovedlinen foran en perle og en svirvel. Herefter kommer et langt forfang med en enkeltkrog.", "Carolina-rig" },
                    { 4, "Ligner Carolina-rigget, men loddet sidder direkte foran agnen (typisk med en lille gummistopper). Agnen (ofte en softbait) kan rigges ”weedless”.", "Texas-rig" },
                    { 5, "Et lod trækkes frit på hovedlinen, enten gennem et rør eller et glidelod, før en svirvel og et forfang.", "Glidende bundrig" },
                    { 6, "En aflange kasteflåd (bombarda) monteres på linen, så man kan kaste selv små fluer eller lette agn meget langt.", "Bombarda-rig" },
                    { 7, "En enkeltkrog bindes på linen, og loddet sidder i enden. Krogen kan justeres i præcis den ønskede højde.", "Drop-shot-rig" },
                    { 8, "Krogen bindes på en speciel måde, hvor agnen (fx boilies) sidder på en lille “hair” efter krogen og ikke direkte på krogen.", "Hair-rig" },
                    { 9, "Et simpelt rig med flåd, stopperknuder, lodder og krog.", "Float-rig" },
                    { 10, "Bruges især til dødagn, hvor et spinnerblad eller rotator tilføjes for at give en livlig gang.", "Spinner-rig" },
                    { 11, "Specialiseret bundrig med korte forfang og farvede perler/spinnerblade, ofte med to kroge.", "Fladfiskerig" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "gay", "Dennis" });
        }
    }
}
