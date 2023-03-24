using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b5bf462-3b06-40da-896a-26a3289adc74");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "27e587d2-c9af-421b-b74d-7e7064fbcf32", "04dafb4d-8af5-4dce-91f6-795f86dc896c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "27e587d2-c9af-421b-b74d-7e7064fbcf32", "14e7b52a-aec2-43bc-83d3-08249c7aa1dc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "27e587d2-c9af-421b-b74d-7e7064fbcf32", "24f90856-769d-46c5-94b4-4f41c7b43f1d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "27e587d2-c9af-421b-b74d-7e7064fbcf32", "34ffea3f-aea4-46ab-b3b4-9eac8be940bb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "27e587d2-c9af-421b-b74d-7e7064fbcf32", "d1e82f2e-2ee5-4db4-8ffc-19608be9071d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "27e587d2-c9af-421b-b74d-7e7064fbcf32", "d7dced28-953e-4d47-8bfb-5473c26d0659" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "27e587d2-c9af-421b-b74d-7e7064fbcf32", "d944f498-f940-4e4c-ac03-ac6beb5e7ff3" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d7ba3ab-e676-4f3d-a1aa-d9d484f2d0cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27e587d2-c9af-421b-b74d-7e7064fbcf32");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04dafb4d-8af5-4dce-91f6-795f86dc896c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14e7b52a-aec2-43bc-83d3-08249c7aa1dc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24f90856-769d-46c5-94b4-4f41c7b43f1d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34ffea3f-aea4-46ab-b3b4-9eac8be940bb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1e82f2e-2ee5-4db4-8ffc-19608be9071d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d7dced28-953e-4d47-8bfb-5473c26d0659");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d944f498-f940-4e4c-ac03-ac6beb5e7ff3");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b5bf462-3b06-40da-896a-26a3289adc74", "1b5bf462-3b06-40da-896a-26a3289adc74", "Admin", "ADMIN" },
                    { "27e587d2-c9af-421b-b74d-7e7064fbcf32", "27e587d2-c9af-421b-b74d-7e7064fbcf32", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConfirmationEmailToken", "ConfirmationEmailTokenExpirationDate", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "04dafb4d-8af5-4dce-91f6-795f86dc896c", 0, "d1e6290b-5f9a-4f3c-8133-b4ddc1e98817", "", null, "User", "yevhen.pasichnyk@oa.edu.ua", true, false, null, "Eugen", "YEVHEN.PASICHNYK@OA.EDU.UA", "YEVHEN.PASICHNYK@OA.EDU.UA", "AQAAAAEAACcQAAAAEL7ISe6zaYw0ZuVo+RDGohahhHYlblMffunBJvSEDzjCDwuNmLasIQQI3tbNtaQADg==", null, false, new DateTimeOffset(new DateTime(2022, 11, 19, 16, 37, 59, 791, DateTimeKind.Unspecified).AddTicks(7027), new TimeSpan(0, 0, 0, 0, 0)), "7a48b0d1-fd51-4b50-9c08-1dd720a21d73", "Pasichnyk", false, "yevhen.pasichnyk@oa.edu.ua" },
                    { "14e7b52a-aec2-43bc-83d3-08249c7aa1dc", 0, "106b5f7d-f733-43f5-8ae5-bf168c73cbd8", "", null, "User", "pashunskyi@gmail.com", true, false, null, "Volodya", "PASHUNSKYI@GMAIL.COM", "PASHUNSKYI@GMAIL.COM", "AQAAAAEAACcQAAAAEGotg8aYFgC23vkoOUPoO7AJWzKDEm/yfbyNzGEkwleQjTk8I0oghzrkYxdIkTsArQ==", null, false, new DateTimeOffset(new DateTime(2022, 11, 19, 16, 37, 59, 791, DateTimeKind.Unspecified).AddTicks(7037), new TimeSpan(0, 0, 0, 0, 0)), "dd20779b-58ad-4a15-88b3-139372d79332", "Pashunskyi", false, "pashunskyi@gmail.com" },
                    { "24f90856-769d-46c5-94b4-4f41c7b43f1d", 0, "a68b1123-391c-4b04-9d0f-435a980161fe", "", null, "User", "mapourse@gmail.com", true, false, null, "Maryna", "MAPOURSE@GMAIL.COM", "MAPOURSE@GMAIL.COM", "AQAAAAEAACcQAAAAEN0vWMI6GON+VnvzZMLDiK0UNUmX9go1XdK9/Y4pPI6L5YLHz7x2QrPzExWWboC04w==", null, false, new DateTimeOffset(new DateTime(2022, 11, 19, 16, 37, 59, 791, DateTimeKind.Unspecified).AddTicks(7020), new TimeSpan(0, 0, 0, 0, 0)), "29c17d01-46a8-44ca-82fa-9835cf544366", "Kernychna", false, "mapourse@gmail.com" },
                    { "34ffea3f-aea4-46ab-b3b4-9eac8be940bb", 0, "62ac16d2-a379-43de-bc2b-df040845ed75", "", null, "User", "antonina.loboda@oa.edu.ua", true, false, null, "Antonina", "ANTONINA.LOBODA@OA.EDU.UA", "ANTONINA.LOBODA@OA.EDU.UA", "AQAAAAEAACcQAAAAEA55NeDvcluNWRKPCWSBoxgL32JNunDAEtH8t05KWI6Uha6VRhr9LPB9MVuj4UxdSQ==", null, false, new DateTimeOffset(new DateTime(2022, 11, 19, 16, 37, 59, 791, DateTimeKind.Unspecified).AddTicks(7044), new TimeSpan(0, 0, 0, 0, 0)), "16412fcc-317f-41ea-b3e6-017384f1c3d4", "Loboda", false, "antonina.loboda@oa.edu.ua" },
                    { "8d7ba3ab-e676-4f3d-a1aa-d9d484f2d0cb", 0, "2adf3c54-369d-4960-a876-afa9f42d083f", "", null, "User", "andrewchepeliuk@gmail.com", true, false, null, "Andrii", "ANDREWCHEPELIUK@GMAIL.COM", "ANDREWCHEPELIUK@GMAIL.COM", "AQAAAAEAACcQAAAAEH/9jDNsM+Nz/+bV6+6tqpSkYd8lpYUjSzCbfgMyDQITZ9FLIpc9y+R2g/qbrmlc2A==", null, false, new DateTimeOffset(new DateTime(2022, 11, 19, 16, 37, 59, 791, DateTimeKind.Unspecified).AddTicks(7012), new TimeSpan(0, 0, 0, 0, 0)), "5ca4b5e1-082b-4845-8864-bf5281bddb5e", "Chepeliuk", false, "andrewchepeliuk@gmail.com" },
                    { "d1e82f2e-2ee5-4db4-8ffc-19608be9071d", 0, "fc7f8266-2bb2-489b-a386-a1f284d9326c", "", null, "User", "chorrny228@gmail.com", true, false, null, "Vadym", "CHORRNY228@GMAIL.COM", "CHORRNY228@GMAIL.COM", "AQAAAAEAACcQAAAAEO55GUCXEzF4rwKDOxaMNde1BuYNRAr4FJ58hnNbijcumwdDdlW7DNG2L3sIAMknYw==", null, false, new DateTimeOffset(new DateTime(2022, 11, 19, 16, 37, 59, 791, DateTimeKind.Unspecified).AddTicks(6988), new TimeSpan(0, 0, 0, 0, 0)), "8cf5bb96-a442-4e71-9113-6644df60eaa6", "Chorrny", false, "chorrny228@gmail.com" },
                    { "d7dced28-953e-4d47-8bfb-5473c26d0659", 0, "18efd2f6-ff70-4d24-86c3-940328ad1150", "", null, "User", "sergeyeremenko@gmail.com", true, false, null, "Sergey", "SERGEYEREMENKO@GMAIL.COM", "SERGEYEREMENKO@GMAIL.COM", "AQAAAAEAACcQAAAAEGq+8B9fO8fvY3pKkLyrc1Zp9mlCEjgN+WRFP0M40Rs3jgSsMkCbvdmVXqt+QSQd/w==", null, false, new DateTimeOffset(new DateTime(2022, 11, 19, 16, 37, 59, 791, DateTimeKind.Unspecified).AddTicks(7053), new TimeSpan(0, 0, 0, 0, 0)), "c04d9b79-5679-4537-a146-8b4f06b64728", "Eremenko", false, "sergeyeremenko@gmail.com" },
                    { "d944f498-f940-4e4c-ac03-ac6beb5e7ff3", 0, "febb2472-3a29-41a0-ba72-701d7c437193", "", null, "User", "oppaiarchmaster@gmail.com", true, false, null, "Vlad", "OPPAIARCHMASTER@GMAIL.COM", "OPPAIARCHMASTER@GMAIL.COM", "AQAAAAEAACcQAAAAEANvIctVVcgYKLmLl/NFo7EK150jwPyVKUEDE4SUR8s7t1lUw89RJ4HSh5eMqanQ9Q==", null, false, new DateTimeOffset(new DateTime(2022, 11, 19, 16, 37, 59, 791, DateTimeKind.Unspecified).AddTicks(7001), new TimeSpan(0, 0, 0, 0, 0)), "2a926588-f90c-4c87-8869-d6e892f9b7f6", "Sievostyanov", false, "oppaiarchmaster@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "27e587d2-c9af-421b-b74d-7e7064fbcf32", "04dafb4d-8af5-4dce-91f6-795f86dc896c" },
                    { "27e587d2-c9af-421b-b74d-7e7064fbcf32", "14e7b52a-aec2-43bc-83d3-08249c7aa1dc" },
                    { "27e587d2-c9af-421b-b74d-7e7064fbcf32", "24f90856-769d-46c5-94b4-4f41c7b43f1d" },
                    { "27e587d2-c9af-421b-b74d-7e7064fbcf32", "34ffea3f-aea4-46ab-b3b4-9eac8be940bb" },
                    { "27e587d2-c9af-421b-b74d-7e7064fbcf32", "d1e82f2e-2ee5-4db4-8ffc-19608be9071d" },
                    { "27e587d2-c9af-421b-b74d-7e7064fbcf32", "d7dced28-953e-4d47-8bfb-5473c26d0659" },
                    { "27e587d2-c9af-421b-b74d-7e7064fbcf32", "d944f498-f940-4e4c-ac03-ac6beb5e7ff3" }
                });
        }
    }
}
