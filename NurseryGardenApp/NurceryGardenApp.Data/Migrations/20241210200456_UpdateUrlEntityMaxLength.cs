using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NurseryGardenApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUrlEntityMaxLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5156e139-0269-4bef-ae99-50197a37de5a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("541be969-ab1f-4dfc-aa3d-406fdc1befc4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7f4c782b-9e3f-4766-9679-12d5105666f7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("82607ede-b458-4b53-b79b-ccdc59506b51"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("92cb6335-5d14-4a04-9286-1bed45675a5a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a35e9942-2841-44dc-b0b8-ede47e5d7738"));

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                comment: "Product quantity",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "URL of the image",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "URL of the image");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DiscountId", "ImageUrl", "IsDeleted", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("0bd7efaf-7fda-4c57-b26e-24eadc1d4253"), 1, "A large, deciduous tree growing up to 20–40m tall. Also known as common oak, this species grows and matures to form a broad and spreading crown with sturdy branches beneath. Look out for: its distinctive round-lobed leaves with short leaf stalks (petioles). Identified in winter by: rounded buds in clusters.", null, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Quercus_robur_form_P_UnT1nhYxVeT2.jpe", false, "English oak", 25.00m, 5 },
                    { new Guid("164ca069-dec0-4b5f-b989-513a0d6d701f"), 8, "Dracaena marginata, also known as the Madagascar Dragon Tree, is a popular and striking plant that's native to Madagascar, Mauritius, and other islands in the Indian Ocean. This plant belongs to the Asparagaceae family and features long, thin, and pointed leaves that are often edged in red or pink.", null, "https://www.thespruce.com/thmb/xIs5C_juOFJ7ETNCO5wZJesYgLQ=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/grow-dracaena-marginata-indoors-1902749-2-983c52a2805144d899408949969a5728.jpg", false, "Dracaena marginata", 20.00m, 10 },
                    { new Guid("58306a77-00e9-44cc-a2bb-97af98cd3cd6"), 8, "Native to Southeast Asia, the Hoya Kerrii Variegata is a succulent-like vine that grows slowly but can eventually produce long tendrils with clusters of star-shaped, fragrant flowers under optimal conditions.", null, "https://www.happysunrize.com/cdn/shop/products/image_2626eda1-facb-413e-91b4-1ea441e7e028_1024x1024@2x.heic?v=1662041725", false, "Hoya", 5.00m, 20 },
                    { new Guid("7b6973c3-079b-489d-97ff-a9829de0b776"), 3, "Periwinkle (Vinca minor) is an excellent evergreen groundcover with dark green foliage. Oblong to ovate leaves are opposite, simple, ½ to 2 inches long, glossy, with a short petiole. They exude a milky juice when broken. Flowers are purple, blue or white depending on the cultivar.", null, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Catharanthus_roseus__oHpudZ0x1u7F.jpeg", false, "Periwinkle", 2.00m, 1000 },
                    { new Guid("7dce096e-4270-4dda-8446-6691380c3ca3"), 2, "Thuja occidentalis, also known as northern white-cedar, eastern white-cedar, or arborvitae, is an evergreen coniferous tree, in the cypress family Cupressaceae, which is native to eastern Canada and much of the north-central and northeastern United States. It is widely cultivated as an ornamental plant.", 1, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Thuja_occidentalis_L_0aoh6YZf2tc7.jpg", false, "Arborvitae", 5.00m, 100 },
                    { new Guid("ce242121-fb7f-476b-9b21-b938245f388a"), 1, "Platanus orientalis, commonly called oriental plane tree or oriental sycamore, is a deciduous, usually single-trunk tree with distinctive, flaky, brown-gray-cream bark, large maple-like leaves and spherical fruiting balls that persist into winter.", 1, "https://uzbbg.uz/storage/Picturel1.png", false, "Oriental Plane", 25.00m, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0bd7efaf-7fda-4c57-b26e-24eadc1d4253"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("164ca069-dec0-4b5f-b989-513a0d6d701f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("58306a77-00e9-44cc-a2bb-97af98cd3cd6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7b6973c3-079b-489d-97ff-a9829de0b776"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7dce096e-4270-4dda-8446-6691380c3ca3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ce242121-fb7f-476b-9b21-b938245f388a"));

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Product quantity");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                comment: "URL of the image",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "URL of the image");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DiscountId", "ImageUrl", "IsDeleted", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("5156e139-0269-4bef-ae99-50197a37de5a"), 1, "Platanus orientalis, commonly called oriental plane tree or oriental sycamore, is a deciduous, usually single-trunk tree with distinctive, flaky, brown-gray-cream bark, large maple-like leaves and spherical fruiting balls that persist into winter.", 1, "https://uzbbg.uz/storage/Picturel1.png", false, "Oriental Plane", 25.00m, 10 },
                    { new Guid("541be969-ab1f-4dfc-aa3d-406fdc1befc4"), 2, "Thuja occidentalis, also known as northern white-cedar, eastern white-cedar, or arborvitae, is an evergreen coniferous tree, in the cypress family Cupressaceae, which is native to eastern Canada and much of the north-central and northeastern United States. It is widely cultivated as an ornamental plant.", 1, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Thuja_occidentalis_L_0aoh6YZf2tc7.jpg", false, "Arborvitae", 5.00m, 100 },
                    { new Guid("7f4c782b-9e3f-4766-9679-12d5105666f7"), 3, "Periwinkle (Vinca minor) is an excellent evergreen groundcover with dark green foliage. Oblong to ovate leaves are opposite, simple, ½ to 2 inches long, glossy, with a short petiole. They exude a milky juice when broken. Flowers are purple, blue or white depending on the cultivar.", null, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Catharanthus_roseus__oHpudZ0x1u7F.jpeg", false, "Periwinkle", 2.00m, 1000 },
                    { new Guid("82607ede-b458-4b53-b79b-ccdc59506b51"), 1, "A large, deciduous tree growing up to 20–40m tall. Also known as common oak, this species grows and matures to form a broad and spreading crown with sturdy branches beneath. Look out for: its distinctive round-lobed leaves with short leaf stalks (petioles). Identified in winter by: rounded buds in clusters.", null, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Quercus_robur_form_P_UnT1nhYxVeT2.jpe", false, "English oak", 25.00m, 5 },
                    { new Guid("92cb6335-5d14-4a04-9286-1bed45675a5a"), 8, "Dracaena marginata, also known as the Madagascar Dragon Tree, is a popular and striking plant that's native to Madagascar, Mauritius, and other islands in the Indian Ocean. This plant belongs to the Asparagaceae family and features long, thin, and pointed leaves that are often edged in red or pink.", null, "https://www.thespruce.com/thmb/xIs5C_juOFJ7ETNCO5wZJesYgLQ=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/grow-dracaena-marginata-indoors-1902749-2-983c52a2805144d899408949969a5728.jpg", false, "Dracaena marginata", 20.00m, 10 },
                    { new Guid("a35e9942-2841-44dc-b0b8-ede47e5d7738"), 8, "Native to Southeast Asia, the Hoya Kerrii Variegata is a succulent-like vine that grows slowly but can eventually produce long tendrils with clusters of star-shaped, fragrant flowers under optimal conditions.", null, "https://www.happysunrize.com/cdn/shop/products/image_2626eda1-facb-413e-91b4-1ea441e7e028_1024x1024@2x.heic?v=1662041725", false, "Hoya", 5.00m, 20 }
                });
        }
    }
}
