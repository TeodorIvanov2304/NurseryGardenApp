using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NurseryGardenApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b609661-3914-498c-bf5c-0dcdc91b0587");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("10b1bb97-f221-4af3-b9ca-41fae9e39d68"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d658363-f294-4d28-b268-e4845aa6db46"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6fd3fe78-a825-401d-9260-702284bf6b85"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("71526bc9-029f-41f6-ae09-d394b594f9ba"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a3b17a61-12b6-4563-8cae-f233619075ab"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f81ee543-23e5-4bfd-842c-90b12a9018f0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fd5e206d-716f-4a5b-8fe0-88435dbd80e2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a5993258-bd25-4747-b121-159b76bb9c2b");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is category deleted or not");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DiscountId", "ImageUrl", "IsDeleted", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("249d6662-901c-427b-b8d5-f610903a7f26"), 8, "Dracaena marginata, also known as the Madagascar Dragon Tree, is a popular and striking plant that's native to Madagascar, Mauritius, and other islands in the Indian Ocean. This plant belongs to the Asparagaceae family and features long, thin, and pointed leaves that are often edged in red or pink.", null, "https://www.thespruce.com/thmb/xIs5C_juOFJ7ETNCO5wZJesYgLQ=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/grow-dracaena-marginata-indoors-1902749-2-983c52a2805144d899408949969a5728.jpg", false, "Dracaena marginata", 20.00m, 10 },
                    { new Guid("707e660b-ac92-4b02-915c-0f25b655e1f9"), 8, "Native to Southeast Asia, the Hoya Kerrii Variegata is a succulent-like vine that grows slowly but can eventually produce long tendrils with clusters of star-shaped, fragrant flowers under optimal conditions.", null, "https://www.happysunrize.com/cdn/shop/products/image_2626eda1-facb-413e-91b4-1ea441e7e028_1024x1024@2x.heic?v=1662041725", false, "Hoya", 5.00m, 20 },
                    { new Guid("79ff38f4-888f-42e0-83ba-0b2b4d20bd67"), 2, "Thuja occidentalis, also known as northern white-cedar, eastern white-cedar, or arborvitae, is an evergreen coniferous tree, in the cypress family Cupressaceae, which is native to eastern Canada and much of the north-central and northeastern United States. It is widely cultivated as an ornamental plant.", 1, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Thuja_occidentalis_L_0aoh6YZf2tc7.jpg", false, "Arborvitae", 5.00m, 100 },
                    { new Guid("9dfa880d-1d5d-4b22-a0b8-068abe7bfde5"), 1, "Platanus orientalis, commonly called oriental plane tree or oriental sycamore, is a deciduous, usually single-trunk tree with distinctive, flaky, brown-gray-cream bark, large maple-like leaves and spherical fruiting balls that persist into winter.", 1, "https://uzbbg.uz/storage/Picturel1.png", false, "Oriental Plane", 25.00m, 10 },
                    { new Guid("eaece287-3734-4d2d-94a7-48dea2f8b4f9"), 1, "A large, deciduous tree growing up to 20–40m tall. Also known as common oak, this species grows and matures to form a broad and spreading crown with sturdy branches beneath. Look out for: its distinctive round-lobed leaves with short leaf stalks (petioles). Identified in winter by: rounded buds in clusters.", null, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Quercus_robur_form_P_UnT1nhYxVeT2.jpe", false, "English oak", 25.00m, 5 },
                    { new Guid("feeced0e-8dff-44bc-abd7-07127abe4049"), 3, "Periwinkle (Vinca minor) is an excellent evergreen groundcover with dark green foliage. Oblong to ovate leaves are opposite, simple, ½ to 2 inches long, glossy, with a short petiole. They exude a milky juice when broken. Flowers are purple, blue or white depending on the cultivar.", null, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Catharanthus_roseus__oHpudZ0x1u7F.jpeg", false, "Periwinkle", 2.00m, 1000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("249d6662-901c-427b-b8d5-f610903a7f26"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("707e660b-ac92-4b02-915c-0f25b655e1f9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("79ff38f4-888f-42e0-83ba-0b2b4d20bd67"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9dfa880d-1d5d-4b22-a0b8-068abe7bfde5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eaece287-3734-4d2d-94a7-48dea2f8b4f9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("feeced0e-8dff-44bc-abd7-07127abe4049"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5b609661-3914-498c-bf5c-0dcdc91b0587", 0, "aa123144-99d3-492b-bb49-be4f9f3f5a1f", "user@niakakvafirma.com", true, "John", "Doe", false, null, "USER@NIAKAKVAFIRMA.COM", "REGULARUSER", "AQAAAAIAAYagAAAAEG8P4Qd6g+FSMqI/FOPBv3TgX2QFGGSb7q7A7L+xCoy8zNS1XwEyDPE6bIlpxVBIxg==", null, false, "44bae4d9-65de-40ec-b33a-715828028976", false, "regularUser" },
                    { "a5993258-bd25-4747-b121-159b76bb9c2b", 0, "5b204bb2-cac3-49f5-aacb-f0ddd8da9f99", "manager@niakakvafirma.com", true, "The", "Manager", false, null, "MANAGER@NIAKAKVAFIRMA.COM", "MANAGERUSER", "AQAAAAIAAYagAAAAEJMrll6X/j+VGB4eBQN7z3/lnY1/KCNXZgYfW2coa4VqOOLLw9GculUq660k/LGo4Q==", null, false, "21b14f49-2ec6-45a6-9c90-1a90d08f05fc", false, "managerUser" }
                });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DiscountId", "ImageUrl", "IsDeleted", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("2d658363-f294-4d28-b268-e4845aa6db46"), 8, "Native to Southeast Asia, the Hoya Kerrii Variegata is a succulent-like vine that grows slowly but can eventually produce long tendrils with clusters of star-shaped, fragrant flowers under optimal conditions.", null, "https://www.happysunrize.com/cdn/shop/products/image_2626eda1-facb-413e-91b4-1ea441e7e028_1024x1024@2x.heic?v=1662041725", false, "Hoya", 5.00m, 20 },
                    { new Guid("6fd3fe78-a825-401d-9260-702284bf6b85"), 1, "A large, deciduous tree growing up to 20–40m tall. Also known as common oak, this species grows and matures to form a broad and spreading crown with sturdy branches beneath. Look out for: its distinctive round-lobed leaves with short leaf stalks (petioles). Identified in winter by: rounded buds in clusters.", null, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Quercus_robur_form_P_UnT1nhYxVeT2.jpe", false, "English oak", 25.00m, 5 },
                    { new Guid("71526bc9-029f-41f6-ae09-d394b594f9ba"), 3, "Periwinkle (Vinca minor) is an excellent evergreen groundcover with dark green foliage. Oblong to ovate leaves are opposite, simple, ½ to 2 inches long, glossy, with a short petiole. They exude a milky juice when broken. Flowers are purple, blue or white depending on the cultivar.", null, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Catharanthus_roseus__oHpudZ0x1u7F.jpeg", false, "Periwinkle", 2.00m, 1000 },
                    { new Guid("a3b17a61-12b6-4563-8cae-f233619075ab"), 8, "Dracaena marginata, also known as the Madagascar Dragon Tree, is a popular and striking plant that's native to Madagascar, Mauritius, and other islands in the Indian Ocean. This plant belongs to the Asparagaceae family and features long, thin, and pointed leaves that are often edged in red or pink.", null, "https://www.thespruce.com/thmb/xIs5C_juOFJ7ETNCO5wZJesYgLQ=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/grow-dracaena-marginata-indoors-1902749-2-983c52a2805144d899408949969a5728.jpg", false, "Dracaena marginata", 20.00m, 10 },
                    { new Guid("f81ee543-23e5-4bfd-842c-90b12a9018f0"), 2, "Thuja occidentalis, also known as northern white-cedar, eastern white-cedar, or arborvitae, is an evergreen coniferous tree, in the cypress family Cupressaceae, which is native to eastern Canada and much of the north-central and northeastern United States. It is widely cultivated as an ornamental plant.", 1, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Thuja_occidentalis_L_0aoh6YZf2tc7.jpg", false, "Arborvitae", 5.00m, 100 },
                    { new Guid("fd5e206d-716f-4a5b-8fe0-88435dbd80e2"), 1, "Platanus orientalis, commonly called oriental plane tree or oriental sycamore, is a deciduous, usually single-trunk tree with distinctive, flaky, brown-gray-cream bark, large maple-like leaves and spherical fruiting balls that persist into winter.", 1, "https://uzbbg.uz/storage/Picturel1.png", false, "Oriental Plane", 25.00m, 10 }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CreatedAt", "Department", "UserId", "WorkPhoneNumber" },
                values: new object[] { new Guid("10b1bb97-f221-4af3-b9ca-41fae9e39d68"), new DateTime(2024, 12, 5, 16, 40, 14, 921, DateTimeKind.Utc).AddTicks(3312), "Sales", "a5993258-bd25-4747-b121-159b76bb9c2b", "+3592912233" });
        }
    }
}
