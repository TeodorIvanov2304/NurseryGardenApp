using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NurseryGardenApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityValidationAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("07a0819a-6fe9-4454-8322-794f80b17753"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0f7b5da2-44f2-47d5-b308-4e30eb40d44d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2561d4e1-bf0e-4cde-bf68-ac6fd70a9e3b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("45b4fd9f-9162-4304-8aab-16b56a2acea5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("64de6d10-d6f9-4be7-8def-c1acf2298155"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ed6c9963-ebc5-4fb0-b941-5c8d7f9d2f84"));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DiscountId", "ImageUrl", "IsDeleted", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("50517ceb-5ee7-4a95-85f6-82309ccad6f1"), 2, "Thuja occidentalis, also known as northern white-cedar, eastern white-cedar, or arborvitae, is an evergreen coniferous tree, in the cypress family Cupressaceae, which is native to eastern Canada and much of the north-central and northeastern United States. It is widely cultivated as an ornamental plant.", 1, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Thuja_occidentalis_L_0aoh6YZf2tc7.jpg", false, "Arborvitae", 5.00m, 100 },
                    { new Guid("77b86504-f509-493e-bb4d-40505b20b01b"), 1, "A large, deciduous tree growing up to 20–40m tall. Also known as common oak, this species grows and matures to form a broad and spreading crown with sturdy branches beneath. Look out for: its distinctive round-lobed leaves with short leaf stalks (petioles). Identified in winter by: rounded buds in clusters.", null, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Quercus_robur_form_P_UnT1nhYxVeT2.jpe", false, "English oak", 25.00m, 5 },
                    { new Guid("7dc93fb6-10e0-4c4e-b242-4a7fde0f1dd0"), 3, "Periwinkle (Vinca minor) is an excellent evergreen groundcover with dark green foliage. Oblong to ovate leaves are opposite, simple, ½ to 2 inches long, glossy, with a short petiole. They exude a milky juice when broken. Flowers are purple, blue or white depending on the cultivar.", null, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Catharanthus_roseus__oHpudZ0x1u7F.jpeg", false, "Periwinkle", 2.00m, 1000 },
                    { new Guid("805e1227-47c3-4ed6-9217-54dd03ee1c59"), 1, "Platanus orientalis, commonly called oriental plane tree or oriental sycamore, is a deciduous, usually single-trunk tree with distinctive, flaky, brown-gray-cream bark, large maple-like leaves and spherical fruiting balls that persist into winter.", 1, "https://uzbbg.uz/storage/Picturel1.png", false, "Oriental Plane", 25.00m, 10 },
                    { new Guid("b231a294-28ce-4fdf-8e88-b7a4cacf83e3"), 8, "Native to Southeast Asia, the Hoya Kerrii Variegata is a succulent-like vine that grows slowly but can eventually produce long tendrils with clusters of star-shaped, fragrant flowers under optimal conditions.", null, "https://www.happysunrize.com/cdn/shop/products/image_2626eda1-facb-413e-91b4-1ea441e7e028_1024x1024@2x.heic?v=1662041725", false, "Hoya", 5.00m, 20 },
                    { new Guid("b9c4e10e-4217-440e-99d5-1739b543c6b5"), 8, "Dracaena marginata, also known as the Madagascar Dragon Tree, is a popular and striking plant that's native to Madagascar, Mauritius, and other islands in the Indian Ocean. This plant belongs to the Asparagaceae family and features long, thin, and pointed leaves that are often edged in red or pink.", null, "https://www.thespruce.com/thmb/xIs5C_juOFJ7ETNCO5wZJesYgLQ=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/grow-dracaena-marginata-indoors-1902749-2-983c52a2805144d899408949969a5728.jpg", false, "Dracaena marginata", 20.00m, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("50517ceb-5ee7-4a95-85f6-82309ccad6f1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("77b86504-f509-493e-bb4d-40505b20b01b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7dc93fb6-10e0-4c4e-b242-4a7fde0f1dd0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("805e1227-47c3-4ed6-9217-54dd03ee1c59"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b231a294-28ce-4fdf-8e88-b7a4cacf83e3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b9c4e10e-4217-440e-99d5-1739b543c6b5"));

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
                    { new Guid("07a0819a-6fe9-4454-8322-794f80b17753"), 8, "Dracaena marginata, also known as the Madagascar Dragon Tree, is a popular and striking plant that's native to Madagascar, Mauritius, and other islands in the Indian Ocean. This plant belongs to the Asparagaceae family and features long, thin, and pointed leaves that are often edged in red or pink.", null, "https://www.thespruce.com/thmb/xIs5C_juOFJ7ETNCO5wZJesYgLQ=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/grow-dracaena-marginata-indoors-1902749-2-983c52a2805144d899408949969a5728.jpg", false, "Dracaena marginata", 20.00m, 10 },
                    { new Guid("0f7b5da2-44f2-47d5-b308-4e30eb40d44d"), 1, "A large, deciduous tree growing up to 20–40m tall. Also known as common oak, this species grows and matures to form a broad and spreading crown with sturdy branches beneath. Look out for: its distinctive round-lobed leaves with short leaf stalks (petioles). Identified in winter by: rounded buds in clusters.", null, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Quercus_robur_form_P_UnT1nhYxVeT2.jpe", false, "English oak", 25.00m, 5 },
                    { new Guid("2561d4e1-bf0e-4cde-bf68-ac6fd70a9e3b"), 2, "Thuja occidentalis, also known as northern white-cedar, eastern white-cedar, or arborvitae, is an evergreen coniferous tree, in the cypress family Cupressaceae, which is native to eastern Canada and much of the north-central and northeastern United States. It is widely cultivated as an ornamental plant.", 1, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Thuja_occidentalis_L_0aoh6YZf2tc7.jpg", false, "Arborvitae", 5.00m, 100 },
                    { new Guid("45b4fd9f-9162-4304-8aab-16b56a2acea5"), 3, "Periwinkle (Vinca minor) is an excellent evergreen groundcover with dark green foliage. Oblong to ovate leaves are opposite, simple, ½ to 2 inches long, glossy, with a short petiole. They exude a milky juice when broken. Flowers are purple, blue or white depending on the cultivar.", null, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Catharanthus_roseus__oHpudZ0x1u7F.jpeg", false, "Periwinkle", 2.00m, 1000 },
                    { new Guid("64de6d10-d6f9-4be7-8def-c1acf2298155"), 1, "Platanus orientalis, commonly called oriental plane tree or oriental sycamore, is a deciduous, usually single-trunk tree with distinctive, flaky, brown-gray-cream bark, large maple-like leaves and spherical fruiting balls that persist into winter.", 1, "https://uzbbg.uz/storage/Picturel1.png", false, "Oriental Plane", 25.00m, 10 },
                    { new Guid("ed6c9963-ebc5-4fb0-b941-5c8d7f9d2f84"), 8, "Native to Southeast Asia, the Hoya Kerrii Variegata is a succulent-like vine that grows slowly but can eventually produce long tendrils with clusters of star-shaped, fragrant flowers under optimal conditions.", null, "https://www.happysunrize.com/cdn/shop/products/image_2626eda1-facb-413e-91b4-1ea441e7e028_1024x1024@2x.heic?v=1662041725", false, "Hoya", 5.00m, 20 }
                });
        }
    }
}
