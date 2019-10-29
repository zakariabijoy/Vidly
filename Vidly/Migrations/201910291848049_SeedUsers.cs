namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'77ce9336-3dcf-4134-a632-fb11c3801fe6', N'guest', N'AP0ZG8LkjjXEdiGrzymnTMBAAL/a3go5cT1Pgp8FyhcWeLpO3UtfJ4cVPqedTNGXUg==', N'535a6cda-1cfd-4787-a19b-4936655129e1', N'ApplicationUser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'8520536e-a783-4c4e-a73c-5d0ec44fcc75', N'admin', N'AIL6kjtkkkOwvMJjacq6sAyvbxg7ASIjn5aXjI9Ju8WE0CwUWWt5t5JnndGJJCF3/g==', N'3ded7830-e1c5-46cf-8af1-dac0b8789c0f', N'ApplicationUser')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'01acd310-0b5e-418b-9f79-616ee3efe5d0', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8520536e-a783-4c4e-a73c-5d0ec44fcc75', N'01acd310-0b5e-418b-9f79-616ee3efe5d0')

");
        }
        
        public override void Down()
        {
        }
    }
}
