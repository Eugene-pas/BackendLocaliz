using Core.Constants;
using Core.Entities.UserEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.SeedData
{

    public static class SeedData
    {
        #region Users

        private static readonly string VADIM_ID = Guid.NewGuid().ToString();
        private static readonly string VLAD_ID = Guid.NewGuid().ToString();
        private static readonly string ANDREW_ID = Guid.NewGuid().ToString();
        private static readonly string MARYNA_ID = Guid.NewGuid().ToString();
        private static readonly string EUGEN_ID = Guid.NewGuid().ToString();
        private static readonly string VOLODYA_ID = Guid.NewGuid().ToString();
        private static readonly string ANTONINA_ID = Guid.NewGuid().ToString();
        private static readonly string SERGEY_ID = Guid.NewGuid().ToString();

        #endregion

        #region Roles

        private static readonly string ROLE_USER_ID = Guid.NewGuid().ToString();
        private static readonly string ROLE_ADMIN_ID = Guid.NewGuid().ToString();     

        #endregion                

        private static readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public static void Seed(this ModelBuilder builder)
        {          
            SeedIdentityRole(builder);           
            SeedUser(builder);
            SeedIdentityUserRole(builder);        
        }

        #region SeedUser

        public static void SeedUser(ModelBuilder builder)
        {
            var userVadim = new User()
            {
                Id = VADIM_ID,
                Name = "Vadym",
                Surname = "Chorrny",
                UserName = "chorrny228@gmail.com",
                NormalizedEmail = "chorrny228@gmail.com".ToUpper(),
                EmailConfirmed = true,
                NormalizedUserName = "chorrny228@gmail.com".ToUpper(),
                Email = "chorrny228@gmail.com",
                ConfirmationEmailToken = ""
            };
            var userVlad = new User()
            {
                Id = VLAD_ID,
                Name = "Vlad",
                Surname = "Sievostyanov",
                UserName = "oppaiarchmaster@gmail.com",
                NormalizedEmail = "oppaiarchmaster@gmail.com".ToUpper(),
                EmailConfirmed = true,
                NormalizedUserName = "oppaiarchmaster@gmail.com".ToUpper(),
                Email = "oppaiarchmaster@gmail.com",
                ConfirmationEmailToken = ""
            };
            var userAndrew = new User()
            {
                Id = ANDREW_ID,
                Name = "Andrii",
                Surname = "Chepeliuk",
                UserName = "andrewchepeliuk@gmail.com",
                NormalizedEmail = "andrewchepeliuk@gmail.com".ToUpper(),
                EmailConfirmed = true,
                NormalizedUserName = "andrewchepeliuk@gmail.com".ToUpper(),
                Email = "andrewchepeliuk@gmail.com",
                ConfirmationEmailToken = ""
            };
            var userMaryna = new User()
            {
                Id = MARYNA_ID,
                Name = "Maryna",
                Surname = "Kernychna",
                UserName = "mapourse@gmail.com",
                NormalizedEmail = "mapourse@gmail.com".ToUpper(),
                EmailConfirmed = true,
                NormalizedUserName = "mapourse@gmail.com".ToUpper(),
                Email = "mapourse@gmail.com",
                ConfirmationEmailToken = ""
            };
            var userEugen = new User()
            {
                Id = EUGEN_ID,
                Name = "Eugen",
                Surname = "Pasichnyk",
                UserName = "yevhen.pasichnyk@oa.edu.ua",
                NormalizedEmail = "yevhen.pasichnyk@oa.edu.ua".ToUpper(),
                EmailConfirmed = true,
                NormalizedUserName = "yevhen.pasichnyk@oa.edu.ua".ToUpper(),
                Email = "yevhen.pasichnyk@oa.edu.ua",
                ConfirmationEmailToken = ""
            };
            var userVolodya = new User()
            {
                Id = VOLODYA_ID,
                Name = "Volodya",
                Surname = "Pashunskyi",
                UserName = "pashunskyi@gmail.com",
                NormalizedEmail = "pashunskyi@gmail.com".ToUpper(),
                EmailConfirmed = true,
                NormalizedUserName = "pashunskyi@gmail.com".ToUpper(),
                Email = "pashunskyi@gmail.com",
                ConfirmationEmailToken = ""
            };
            var userAntonina = new User()
            {
                Id = ANTONINA_ID,
                Name = "Antonina",
                Surname = "Loboda",
                UserName = "antonina.loboda@oa.edu.ua",
                NormalizedEmail = "antonina.loboda@oa.edu.ua".ToUpper(),
                EmailConfirmed = true,
                NormalizedUserName = "antonina.loboda@oa.edu.ua".ToUpper(),
                Email = "antonina.loboda@oa.edu.ua",
                ConfirmationEmailToken = ""
            };
            var userSergey = new User()
            {
                Id = SERGEY_ID,
                Name = "Sergey",
                Surname = "Eremenko",
                UserName = "sergeyeremenko@gmail.com",
                NormalizedEmail = "sergeyeremenko@gmail.com".ToUpper(),
                EmailConfirmed = true,
                NormalizedUserName = "sergeyeremenko@gmail.com".ToUpper(),
                Email = "sergeyeremenko@gmail.com",
                ConfirmationEmailToken = ""
            };
            userVadim.PasswordHash = _passwordHasher
                .HashPassword(userVadim, "Password_1");
            userVlad.PasswordHash = _passwordHasher
                .HashPassword(userVlad, "Password_1");
            userAndrew.PasswordHash = _passwordHasher
                .HashPassword(userAndrew, "Password_1");
            userMaryna.PasswordHash = _passwordHasher
                .HashPassword(userMaryna, "Password_1");
            userEugen.PasswordHash = _passwordHasher
                .HashPassword(userEugen, "Password_1");
            userVolodya.PasswordHash = _passwordHasher
                .HashPassword(userVolodya, "Password_1");
            userAntonina.PasswordHash = _passwordHasher
                .HashPassword(userAntonina, "Password_1");
            userSergey.PasswordHash = _passwordHasher
                .HashPassword(userSergey, "Password_1");
            builder.Entity<User>()
                .HasData(
                    userVadim,
                    userVlad,
                    userAndrew,
                    userMaryna,
                    userEugen,
                    userVolodya,
                    userAntonina,
                    userSergey
                    );
        }

        #endregion

        #region SeedIdentityRole

        public static void SeedIdentityRole(ModelBuilder builder) =>
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = ROLE_USER_ID,
                    Name = IdentityRoleNames.User.ToString(),
                    NormalizedName = IdentityRoleNames.User.ToString().ToUpper(),
                    ConcurrencyStamp = ROLE_USER_ID
                },
                new IdentityRole()
                {
                    Id = ROLE_ADMIN_ID,
                    Name = IdentityRoleNames.Admin.ToString(),
                    NormalizedName = IdentityRoleNames.Admin.ToString().ToUpper(),
                    ConcurrencyStamp = ROLE_ADMIN_ID
                });
               

        #endregion

        #region SeedIdentityUserRole

        public static void SeedIdentityUserRole(ModelBuilder builder) =>
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = ROLE_USER_ID,
                    UserId = VADIM_ID
                }, new IdentityUserRole<string>()
                {
                    RoleId = ROLE_USER_ID,
                    UserId = VLAD_ID
                }, new IdentityUserRole<string>()
                {
                    RoleId = ROLE_USER_ID,
                    UserId = VOLODYA_ID
                }, new IdentityUserRole<string>()
                {
                    RoleId = ROLE_USER_ID,
                    UserId = MARYNA_ID
                }, new IdentityUserRole<string>()
                {
                    RoleId = ROLE_USER_ID,
                    UserId = ANTONINA_ID
                },new IdentityUserRole<string>()
                {
                    RoleId = ROLE_USER_ID,
                    UserId = EUGEN_ID
                }, new IdentityUserRole<string>()
                {
                    RoleId = ROLE_USER_ID,
                    UserId = SERGEY_ID
                });

        #endregion

    
    }
}
