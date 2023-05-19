using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Document_DocumentId",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_DocumentId",
                table: "History");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbeb8b04-446a-4e07-9c1e-6c53329b1978");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b00aebe5-a5f4-480b-b607-52b234081e5e", "0c412794-c9af-4ca9-a8b8-7cf16c0afd46" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b00aebe5-a5f4-480b-b607-52b234081e5e", "80b1c072-2c3e-45c7-91c6-9020ff9f3f40" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b00aebe5-a5f4-480b-b607-52b234081e5e", "9cc8acf2-2286-4a02-9943-ebf2843d1756" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b00aebe5-a5f4-480b-b607-52b234081e5e", "a8624235-eaba-46dc-a12c-fa07cce18295" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b00aebe5-a5f4-480b-b607-52b234081e5e", "be1792b7-8292-4fdd-bbd4-2a5b3d7202af" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b00aebe5-a5f4-480b-b607-52b234081e5e", "d1a6d0b8-0087-4bd7-911c-090af2910cfe" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b00aebe5-a5f4-480b-b607-52b234081e5e", "ed195f85-4d97-4ff9-8c55-c3d4d41edfd5" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a645399-fe2a-432d-bdb5-95ac327f9cea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b00aebe5-a5f4-480b-b607-52b234081e5e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c412794-c9af-4ca9-a8b8-7cf16c0afd46");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80b1c072-2c3e-45c7-91c6-9020ff9f3f40");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9cc8acf2-2286-4a02-9943-ebf2843d1756");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8624235-eaba-46dc-a12c-fa07cce18295");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be1792b7-8292-4fdd-bbd4-2a5b3d7202af");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1a6d0b8-0087-4bd7-911c-090af2910cfe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed195f85-4d97-4ff9-8c55-c3d4d41edfd5");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "History");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "History",
                newName: "ContentId");

            migrationBuilder.AlterColumn<string>(
                name: "TranslateText",
                table: "History",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TranslateText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<long>(type: "bigint", nullable: false),
                    DocumentId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Content_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "56975a9c-c590-4324-a04a-c5ce6dc0335f", "56975a9c-c590-4324-a04a-c5ce6dc0335f", "User", "USER" },
                    { "63bdd2f0-2d81-444e-aa52-fbfb5a74c7f2", "63bdd2f0-2d81-444e-aa52-fbfb5a74c7f2", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConfirmationEmailToken", "ConfirmationEmailTokenExpirationDate", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "16558e6c-5ecd-44b6-ad29-247232bd6903", 0, "a765f4ba-4f12-4a77-bce3-626a995a9b6c", "", null, "User", "sergeyeremenko@gmail.com", true, false, null, "Sergey", "SERGEYEREMENKO@GMAIL.COM", "SERGEYEREMENKO@GMAIL.COM", "AQAAAAEAACcQAAAAEGJdonKA1Obi9x2yFRooXi/9Evn0FPkk2uk/OGTdIoLmvHwfNOLX70n1Ix/GZwPkGw==", null, false, new DateTimeOffset(new DateTime(2023, 5, 8, 12, 27, 31, 293, DateTimeKind.Unspecified).AddTicks(5048), new TimeSpan(0, 0, 0, 0, 0)), "ed32ca9a-2798-4b54-8384-657f44bd0d2c", "Eremenko", false, "sergeyeremenko@gmail.com" },
                    { "35086e20-69d2-4488-bd68-c5a510fdd45e", 0, "851dabfe-fb86-4aeb-8b9b-417a0b12b10d", "", null, "User", "andrewchepeliuk@gmail.com", true, false, null, "Andrii", "ANDREWCHEPELIUK@GMAIL.COM", "ANDREWCHEPELIUK@GMAIL.COM", "AQAAAAEAACcQAAAAEAPkONQvPiJrMYr7oRQQL8CEwjOmd469VDUwiCq42cu/HvJ4uCHsvUPRWTK/ToveAA==", null, false, new DateTimeOffset(new DateTime(2023, 5, 8, 12, 27, 31, 293, DateTimeKind.Unspecified).AddTicks(5002), new TimeSpan(0, 0, 0, 0, 0)), "b5b20984-6049-475d-812c-462cf7312810", "Chepeliuk", false, "andrewchepeliuk@gmail.com" },
                    { "36e64350-6379-4b15-b2ef-dbc4e6e18ed4", 0, "0bc5cc49-2729-4957-b236-e150f1ba9fa8", "", null, "User", "antonina.loboda@oa.edu.ua", true, false, null, "Antonina", "ANTONINA.LOBODA@OA.EDU.UA", "ANTONINA.LOBODA@OA.EDU.UA", "AQAAAAEAACcQAAAAEAnF74+kw89lKujR1+GuNYWh7vdtpZteJzjYo4j9rn6zdW46EYxy9WtYYI1MTykxNA==", null, false, new DateTimeOffset(new DateTime(2023, 5, 8, 12, 27, 31, 293, DateTimeKind.Unspecified).AddTicks(5040), new TimeSpan(0, 0, 0, 0, 0)), "faf1ddb9-090b-42ee-832d-a5f3fb90bbd7", "Loboda", false, "antonina.loboda@oa.edu.ua" },
                    { "7b61f66e-8b8c-4b0e-8403-eb6810bbf0ac", 0, "08d0ba3c-117e-4c67-a72d-d59c6850f2ee", "", null, "User", "yevhen.pasichnyk@oa.edu.ua", true, false, null, "Eugen", "YEVHEN.PASICHNYK@OA.EDU.UA", "YEVHEN.PASICHNYK@OA.EDU.UA", "AQAAAAEAACcQAAAAEEfDjsXbSNzu+UCtyq5EXMUdKcj+KlLxL5pkvzbdd08Ft23e9z/Pjg4VIazR9PT+7Q==", null, false, new DateTimeOffset(new DateTime(2023, 5, 8, 12, 27, 31, 293, DateTimeKind.Unspecified).AddTicks(5022), new TimeSpan(0, 0, 0, 0, 0)), "bedfd3c7-0f74-4a88-a48d-6e158b9c7b63", "Pasichnyk", false, "yevhen.pasichnyk@oa.edu.ua" },
                    { "9111842c-ac00-4f78-961a-350ab59f3a0c", 0, "ba7395d9-1755-4676-81f2-1f12a8790c76", "", null, "User", "oppaiarchmaster@gmail.com", true, false, null, "Vlad", "OPPAIARCHMASTER@GMAIL.COM", "OPPAIARCHMASTER@GMAIL.COM", "AQAAAAEAACcQAAAAELAg5H6Q/lI6y2AZvQUNV5puKkfxqnb3rEgG7S/ymlJ4WbL0EhZWlG48VHTTPlKP0A==", null, false, new DateTimeOffset(new DateTime(2023, 5, 8, 12, 27, 31, 293, DateTimeKind.Unspecified).AddTicks(4993), new TimeSpan(0, 0, 0, 0, 0)), "029adab5-8bf1-4985-bd51-397d5e6d64c8", "Sievostyanov", false, "oppaiarchmaster@gmail.com" },
                    { "e0dd0771-57a4-4eb4-aa6f-2dcaa5f3fe7e", 0, "5f297eb0-e020-479c-a096-5562426fbba7", "", null, "User", "chorrny228@gmail.com", true, false, null, "Vadym", "CHORRNY228@GMAIL.COM", "CHORRNY228@GMAIL.COM", "AQAAAAEAACcQAAAAEDyhqQR6i/0WgNDom6RqZJVM8O17dEYbAJUheouObHNQp4pe7ZAj3KExmEFy/oDpmA==", null, false, new DateTimeOffset(new DateTime(2023, 5, 8, 12, 27, 31, 293, DateTimeKind.Unspecified).AddTicks(4977), new TimeSpan(0, 0, 0, 0, 0)), "e7c3fca5-e860-45dc-b50a-499a7126cd06", "Chorrny", false, "chorrny228@gmail.com" },
                    { "e64b20fa-6ec3-4245-bcb6-9264a810d024", 0, "20b0a0d9-af82-45ed-8699-9650f1956104", "", null, "User", "pashunskyi@gmail.com", true, false, null, "Volodya", "PASHUNSKYI@GMAIL.COM", "PASHUNSKYI@GMAIL.COM", "AQAAAAEAACcQAAAAEDzTSUyJ0+KQEay1PhD7VRZpXPD6CsBtaBiKJBP1tGv5DRPEL69z6I/o5b0xEfkQPQ==", null, false, new DateTimeOffset(new DateTime(2023, 5, 8, 12, 27, 31, 293, DateTimeKind.Unspecified).AddTicks(5030), new TimeSpan(0, 0, 0, 0, 0)), "4ecc4224-79bd-41f8-9eba-e595cdd9d23b", "Pashunskyi", false, "pashunskyi@gmail.com" },
                    { "ff488499-ed60-4381-a1d1-1adced6b5e82", 0, "f743bb59-ab27-433a-b45d-ea9141bc0f95", "", null, "User", "mapourse@gmail.com", true, false, null, "Maryna", "MAPOURSE@GMAIL.COM", "MAPOURSE@GMAIL.COM", "AQAAAAEAACcQAAAAEOUBfxi52jqB1IrC7D96P1AKh6E9HQARAxq0QWPlAmoeTfueVn7o92NBMcsPi6RTnA==", null, false, new DateTimeOffset(new DateTime(2023, 5, 8, 12, 27, 31, 293, DateTimeKind.Unspecified).AddTicks(5013), new TimeSpan(0, 0, 0, 0, 0)), "cc47efb2-0528-4f09-92b5-a40c27fb9b23", "Kernychna", false, "mapourse@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "56975a9c-c590-4324-a04a-c5ce6dc0335f", "16558e6c-5ecd-44b6-ad29-247232bd6903" },
                    { "56975a9c-c590-4324-a04a-c5ce6dc0335f", "36e64350-6379-4b15-b2ef-dbc4e6e18ed4" },
                    { "56975a9c-c590-4324-a04a-c5ce6dc0335f", "7b61f66e-8b8c-4b0e-8403-eb6810bbf0ac" },
                    { "56975a9c-c590-4324-a04a-c5ce6dc0335f", "9111842c-ac00-4f78-961a-350ab59f3a0c" },
                    { "56975a9c-c590-4324-a04a-c5ce6dc0335f", "e0dd0771-57a4-4eb4-aa6f-2dcaa5f3fe7e" },
                    { "56975a9c-c590-4324-a04a-c5ce6dc0335f", "e64b20fa-6ec3-4245-bcb6-9264a810d024" },
                    { "56975a9c-c590-4324-a04a-c5ce6dc0335f", "ff488499-ed60-4381-a1d1-1adced6b5e82" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_ContentId",
                table: "History",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Content_DocumentId",
                table: "Content",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Content_UserId",
                table: "Content",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Content_ContentId",
                table: "History",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Content_ContentId",
                table: "History");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropIndex(
                name: "IX_History_ContentId",
                table: "History");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63bdd2f0-2d81-444e-aa52-fbfb5a74c7f2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "56975a9c-c590-4324-a04a-c5ce6dc0335f", "16558e6c-5ecd-44b6-ad29-247232bd6903" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "56975a9c-c590-4324-a04a-c5ce6dc0335f", "36e64350-6379-4b15-b2ef-dbc4e6e18ed4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "56975a9c-c590-4324-a04a-c5ce6dc0335f", "7b61f66e-8b8c-4b0e-8403-eb6810bbf0ac" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "56975a9c-c590-4324-a04a-c5ce6dc0335f", "9111842c-ac00-4f78-961a-350ab59f3a0c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "56975a9c-c590-4324-a04a-c5ce6dc0335f", "e0dd0771-57a4-4eb4-aa6f-2dcaa5f3fe7e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "56975a9c-c590-4324-a04a-c5ce6dc0335f", "e64b20fa-6ec3-4245-bcb6-9264a810d024" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "56975a9c-c590-4324-a04a-c5ce6dc0335f", "ff488499-ed60-4381-a1d1-1adced6b5e82" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35086e20-69d2-4488-bd68-c5a510fdd45e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56975a9c-c590-4324-a04a-c5ce6dc0335f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16558e6c-5ecd-44b6-ad29-247232bd6903");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "36e64350-6379-4b15-b2ef-dbc4e6e18ed4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b61f66e-8b8c-4b0e-8403-eb6810bbf0ac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9111842c-ac00-4f78-961a-350ab59f3a0c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0dd0771-57a4-4eb4-aa6f-2dcaa5f3fe7e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e64b20fa-6ec3-4245-bcb6-9264a810d024");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff488499-ed60-4381-a1d1-1adced6b5e82");

            migrationBuilder.RenameColumn(
                name: "ContentId",
                table: "History",
                newName: "Number");

            migrationBuilder.AlterColumn<string>(
                name: "TranslateText",
                table: "History",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<long>(
                name: "DocumentId",
                table: "History",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "History",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b00aebe5-a5f4-480b-b607-52b234081e5e", "b00aebe5-a5f4-480b-b607-52b234081e5e", "User", "USER" },
                    { "cbeb8b04-446a-4e07-9c1e-6c53329b1978", "cbeb8b04-446a-4e07-9c1e-6c53329b1978", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConfirmationEmailToken", "ConfirmationEmailTokenExpirationDate", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0c412794-c9af-4ca9-a8b8-7cf16c0afd46", 0, "456b0f02-ea2e-41e1-8f49-7f126765e4a6", "", null, "User", "mapourse@gmail.com", true, false, null, "Maryna", "MAPOURSE@GMAIL.COM", "MAPOURSE@GMAIL.COM", "AQAAAAEAACcQAAAAEHUpz7yKu77sf7lwtFNhvW1ihU/i7FyubQ3rmdl6w1x1plwvWwAZJTbfXh1Hk9aQ1A==", null, false, new DateTimeOffset(new DateTime(2023, 3, 5, 18, 29, 28, 518, DateTimeKind.Unspecified).AddTicks(8307), new TimeSpan(0, 0, 0, 0, 0)), "d83f1149-1622-4791-afea-bbc3bdb93131", "Kernychna", false, "mapourse@gmail.com" },
                    { "1a645399-fe2a-432d-bdb5-95ac327f9cea", 0, "4b09aff7-78b3-4cc0-85bf-0b8da5059705", "", null, "User", "andrewchepeliuk@gmail.com", true, false, null, "Andrii", "ANDREWCHEPELIUK@GMAIL.COM", "ANDREWCHEPELIUK@GMAIL.COM", "AQAAAAEAACcQAAAAEEjVwF774L7LfHFIsUGQn+UKD/vG6quI9+2fj7pcFgkTVt04IqUx35ljiwMwbolyPA==", null, false, new DateTimeOffset(new DateTime(2023, 3, 5, 18, 29, 28, 518, DateTimeKind.Unspecified).AddTicks(8299), new TimeSpan(0, 0, 0, 0, 0)), "140b4ca5-d407-44d3-a9de-91fb3f5629de", "Chepeliuk", false, "andrewchepeliuk@gmail.com" },
                    { "80b1c072-2c3e-45c7-91c6-9020ff9f3f40", 0, "7a702345-d004-4f3c-b51b-a94e1a9505f7", "", null, "User", "sergeyeremenko@gmail.com", true, false, null, "Sergey", "SERGEYEREMENKO@GMAIL.COM", "SERGEYEREMENKO@GMAIL.COM", "AQAAAAEAACcQAAAAEOenEG7Ldi6Gx/NyoasgGfQkv0VgkZMtFV4pbsTK2sxAWQ5T0Ao9E0JSTc4xgFe3mg==", null, false, new DateTimeOffset(new DateTime(2023, 3, 5, 18, 29, 28, 518, DateTimeKind.Unspecified).AddTicks(8343), new TimeSpan(0, 0, 0, 0, 0)), "d6dcf2ed-09fc-4862-b94c-8a27e14a9266", "Eremenko", false, "sergeyeremenko@gmail.com" },
                    { "9cc8acf2-2286-4a02-9943-ebf2843d1756", 0, "6e8e34b1-c68f-4495-ae50-8c4a1ff6a097", "", null, "User", "oppaiarchmaster@gmail.com", true, false, null, "Vlad", "OPPAIARCHMASTER@GMAIL.COM", "OPPAIARCHMASTER@GMAIL.COM", "AQAAAAEAACcQAAAAEJzDGK6qqufXMRHXf/wKaiIR7f7oMcuDAtXg1TMcajrkpLMwpoEBYKJI2l7KFm9HRg==", null, false, new DateTimeOffset(new DateTime(2023, 3, 5, 18, 29, 28, 518, DateTimeKind.Unspecified).AddTicks(8290), new TimeSpan(0, 0, 0, 0, 0)), "b0b77299-2b23-4046-972e-614557e09f84", "Sievostyanov", false, "oppaiarchmaster@gmail.com" },
                    { "a8624235-eaba-46dc-a12c-fa07cce18295", 0, "d8a58ca8-1d19-4c08-9a80-9059c12db38d", "", null, "User", "antonina.loboda@oa.edu.ua", true, false, null, "Antonina", "ANTONINA.LOBODA@OA.EDU.UA", "ANTONINA.LOBODA@OA.EDU.UA", "AQAAAAEAACcQAAAAEMBI5LbFBzGtTN5TKps6+1hmpTqyr/g74p2Zk0JcZb02BHMaC39GL23iKnfb+aR7Jw==", null, false, new DateTimeOffset(new DateTime(2023, 3, 5, 18, 29, 28, 518, DateTimeKind.Unspecified).AddTicks(8335), new TimeSpan(0, 0, 0, 0, 0)), "dfe588fd-31b7-4144-a5c8-796735c080d7", "Loboda", false, "antonina.loboda@oa.edu.ua" },
                    { "be1792b7-8292-4fdd-bbd4-2a5b3d7202af", 0, "f3a9ba44-d8ac-475b-bb6f-e1c9f92b81fe", "", null, "User", "chorrny228@gmail.com", true, false, null, "Vadym", "CHORRNY228@GMAIL.COM", "CHORRNY228@GMAIL.COM", "AQAAAAEAACcQAAAAEILI+H6r6KaaUain/dhY4xHAP46NTbCYuzZWn0qKAOY+iciYWPmvk+ePFvDfVPRTSw==", null, false, new DateTimeOffset(new DateTime(2023, 3, 5, 18, 29, 28, 518, DateTimeKind.Unspecified).AddTicks(8264), new TimeSpan(0, 0, 0, 0, 0)), "f312be24-fcf1-4886-a3a3-49665e2fc9ae", "Chorrny", false, "chorrny228@gmail.com" },
                    { "d1a6d0b8-0087-4bd7-911c-090af2910cfe", 0, "97052a4b-a5d5-4c89-a3cc-7001110383a4", "", null, "User", "pashunskyi@gmail.com", true, false, null, "Volodya", "PASHUNSKYI@GMAIL.COM", "PASHUNSKYI@GMAIL.COM", "AQAAAAEAACcQAAAAEE6thMG52XD7iYFso7nIYJKITKn8WPKaApiV3b4rN5Ni8P7DoAX8vPCws+je1wSXnA==", null, false, new DateTimeOffset(new DateTime(2023, 3, 5, 18, 29, 28, 518, DateTimeKind.Unspecified).AddTicks(8325), new TimeSpan(0, 0, 0, 0, 0)), "6ea17917-0723-4dcd-98ac-e13bc2aa66aa", "Pashunskyi", false, "pashunskyi@gmail.com" },
                    { "ed195f85-4d97-4ff9-8c55-c3d4d41edfd5", 0, "3fef2921-5a4a-45c5-8fed-2e9731b46b85", "", null, "User", "yevhen.pasichnyk@oa.edu.ua", true, false, null, "Eugen", "YEVHEN.PASICHNYK@OA.EDU.UA", "YEVHEN.PASICHNYK@OA.EDU.UA", "AQAAAAEAACcQAAAAEOH4RzcIXffhQ6FIiPVYeVHq1a9wydAmglKiPuakMCmGD11aXIgTRzzSzq61LwMMew==", null, false, new DateTimeOffset(new DateTime(2023, 3, 5, 18, 29, 28, 518, DateTimeKind.Unspecified).AddTicks(8318), new TimeSpan(0, 0, 0, 0, 0)), "f4ee6919-4c5e-43dc-b266-2b1b609d9fee", "Pasichnyk", false, "yevhen.pasichnyk@oa.edu.ua" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b00aebe5-a5f4-480b-b607-52b234081e5e", "0c412794-c9af-4ca9-a8b8-7cf16c0afd46" },
                    { "b00aebe5-a5f4-480b-b607-52b234081e5e", "80b1c072-2c3e-45c7-91c6-9020ff9f3f40" },
                    { "b00aebe5-a5f4-480b-b607-52b234081e5e", "9cc8acf2-2286-4a02-9943-ebf2843d1756" },
                    { "b00aebe5-a5f4-480b-b607-52b234081e5e", "a8624235-eaba-46dc-a12c-fa07cce18295" },
                    { "b00aebe5-a5f4-480b-b607-52b234081e5e", "be1792b7-8292-4fdd-bbd4-2a5b3d7202af" },
                    { "b00aebe5-a5f4-480b-b607-52b234081e5e", "d1a6d0b8-0087-4bd7-911c-090af2910cfe" },
                    { "b00aebe5-a5f4-480b-b607-52b234081e5e", "ed195f85-4d97-4ff9-8c55-c3d4d41edfd5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_DocumentId",
                table: "History",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Document_DocumentId",
                table: "History",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
