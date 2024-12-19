using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NurseryGardenApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0575ef0c-713d-419b-a407-166438e086bd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("986e9bc7-e727-4ce2-a2ee-a6d3da9b53d8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a12e478f-136b-4e82-bb60-c2b13ecea579"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d620a151-34a4-42e8-a404-660673fc3e3e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e4974c82-5b78-4ca7-9ed2-61ec9ec2d725"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f0a20a95-764c-4d8d-8018-9fa2cf4d7ed8"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is this order deleted?");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DiscountId", "ImageUrl", "IsDeleted", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("177d656f-6e09-4333-82c3-8ab415a2ffc6"), 8, "Dracaena marginata, also known as the Madagascar Dragon Tree, is a popular and striking plant that's native to Madagascar, Mauritius, and other islands in the Indian Ocean. This plant belongs to the Asparagaceae family and features long, thin, and pointed leaves that are often edged in red or pink.", null, "https://www.thespruce.com/thmb/xIs5C_juOFJ7ETNCO5wZJesYgLQ=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/grow-dracaena-marginata-indoors-1902749-2-983c52a2805144d899408949969a5728.jpg", false, "Dracaena marginata", 20.00m, 10 },
                    { new Guid("6f7cf90d-60a5-406c-aa5b-e35783e6b998"), 1, "Platanus orientalis, commonly called oriental plane tree or oriental sycamore, is a deciduous, usually single-trunk tree with distinctive, flaky, brown-gray-cream bark, large maple-like leaves and spherical fruiting balls that persist into winter.", 1, "https://uzbbg.uz/storage/Picturel1.png", false, "Oriental Plane", 25.00m, 10 },
                    { new Guid("9729fda6-6a64-4319-986d-b9d72c80becd"), 2, "Thuja occidentalis, also known as northern white-cedar, eastern white-cedar, or arborvitae, is an evergreen coniferous tree, in the cypress family Cupressaceae, which is native to eastern Canada and much of the north-central and northeastern United States. It is widely cultivated as an ornamental plant.", 1, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Thuja_occidentalis_L_0aoh6YZf2tc7.jpg", false, "Arborvitae", 5.00m, 100 },
                    { new Guid("9c666ff7-9f3a-4a66-9015-9560b426f1c0"), 1, "A large, deciduous tree growing up to 20–40m tall. Also known as common oak, this species grows and matures to form a broad and spreading crown with sturdy branches beneath. Look out for: its distinctive round-lobed leaves with short leaf stalks (petioles). Identified in winter by: rounded buds in clusters.", null, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Quercus_robur_form_P_UnT1nhYxVeT2.jpe", false, "English oak", 25.00m, 5 },
                    { new Guid("e07c2d5e-a932-4590-9630-61b38031bf05"), 8, "Native to Southeast Asia, the Hoya Kerrii Variegata is a succulent-like vine that grows slowly but can eventually produce long tendrils with clusters of star-shaped, fragrant flowers under optimal conditions.", null, "https://www.happysunrize.com/cdn/shop/products/image_2626eda1-facb-413e-91b4-1ea441e7e028_1024x1024@2x.heic?v=1662041725", false, "Hoya", 5.00m, 20 },
                    { new Guid("f063d31d-352d-47fb-8bc9-e9506e6c81a1"), 3, "Periwinkle (Vinca minor) is an excellent evergreen groundcover with dark green foliage. Oblong to ovate leaves are opposite, simple, ½ to 2 inches long, glossy, with a short petiole. They exude a milky juice when broken. Flowers are purple, blue or white depending on the cultivar.", null, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Catharanthus_roseus__oHpudZ0x1u7F.jpeg", false, "Periwinkle", 2.00m, 1000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("177d656f-6e09-4333-82c3-8ab415a2ffc6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f7cf90d-60a5-406c-aa5b-e35783e6b998"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9729fda6-6a64-4319-986d-b9d72c80becd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c666ff7-9f3a-4a66-9015-9560b426f1c0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e07c2d5e-a932-4590-9630-61b38031bf05"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f063d31d-352d-47fb-8bc9-e9506e6c81a1"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DiscountId", "ImageUrl", "IsDeleted", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("0575ef0c-713d-419b-a407-166438e086bd"), 1, "A large, deciduous tree growing up to 20–40m tall. Also known as common oak, this species grows and matures to form a broad and spreading crown with sturdy branches beneath. Look out for: its distinctive round-lobed leaves with short leaf stalks (petioles). Identified in winter by: rounded buds in clusters.", null, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Quercus_robur_form_P_UnT1nhYxVeT2.jpe", false, "English oak", 25.00m, 5 },
                    { new Guid("986e9bc7-e727-4ce2-a2ee-a6d3da9b53d8"), 2, "Thuja occidentalis, also known as northern white-cedar, eastern white-cedar, or arborvitae, is an evergreen coniferous tree, in the cypress family Cupressaceae, which is native to eastern Canada and much of the north-central and northeastern United States. It is widely cultivated as an ornamental plant.", 1, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Thuja_occidentalis_L_0aoh6YZf2tc7.jpg", false, "Arborvitae", 5.00m, 100 },
                    { new Guid("a12e478f-136b-4e82-bb60-c2b13ecea579"), 8, "Dracaena marginata, also known as the Madagascar Dragon Tree, is a popular and striking plant that's native to Madagascar, Mauritius, and other islands in the Indian Ocean. This plant belongs to the Asparagaceae family and features long, thin, and pointed leaves that are often edged in red or pink.", null, "https://www.thespruce.com/thmb/xIs5C_juOFJ7ETNCO5wZJesYgLQ=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/grow-dracaena-marginata-indoors-1902749-2-983c52a2805144d899408949969a5728.jpg", false, "Dracaena marginata", 20.00m, 10 },
                    { new Guid("d620a151-34a4-42e8-a404-660673fc3e3e"), 3, "Periwinkle (Vinca minor) is an excellent evergreen groundcover with dark green foliage. Oblong to ovate leaves are opposite, simple, ½ to 2 inches long, glossy, with a short petiole. They exude a milky juice when broken. Flowers are purple, blue or white depending on the cultivar.", null, "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Catharanthus_roseus__oHpudZ0x1u7F.jpeg", false, "Periwinkle", 2.00m, 1000 },
                    { new Guid("e4974c82-5b78-4ca7-9ed2-61ec9ec2d725"), 1, "Platanus orientalis, commonly called oriental plane tree or oriental sycamore, is a deciduous, usually single-trunk tree with distinctive, flaky, brown-gray-cream bark, large maple-like leaves and spherical fruiting balls that persist into winter.", 1, "https://uzbbg.uz/storage/Picturel1.png", false, "Oriental Plane", 25.00m, 10 },
                    { new Guid("f0a20a95-764c-4d8d-8018-9fa2cf4d7ed8"), 8, "Native to Southeast Asia, the Hoya Kerrii Variegata is a succulent-like vine that grows slowly but can eventually produce long tendrils with clusters of star-shaped, fragrant flowers under optimal conditions.", null, "https://www.happysunrize.com/cdn/shop/products/image_2626eda1-facb-413e-91b4-1ea441e7e028_1024x1024@2x.heic?v=1662041725", false, "Hoya", 5.00m, 20 }
                });
        }
    }
}
