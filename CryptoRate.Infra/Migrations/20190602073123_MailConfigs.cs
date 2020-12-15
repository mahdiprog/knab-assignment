using Microsoft.EntityFrameworkCore.Migrations;

namespace Triskele.Config.Dal.Migrations
{
    public partial class MailConfigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [cfg].[Configurations]([ConfigKey],[Value],[ModuleId]) " +
                                 "SELECT 'EmailSettings:EmailConfirmTemplate', 'd-111dbcc0e567451bb11430bdf33fe27b',1 " +
                                 "WHERE NOT EXISTS(SELECT * " +
                                 "FROM [cfg].[Configurations] " +
                                 "WHERE ConfigKey = 'EmailSettings:EmailConfirmTemplate')", true);

            migrationBuilder.Sql("INSERT INTO [cfg].[Configurations]([ConfigKey],[Value],[ModuleId]) " +
                                 "SELECT 'EmailSettings:ResetPasswordTemplate', 'd-b959475e555a48a78f7890d9efebea2c',1 " +
                                 "WHERE NOT EXISTS(SELECT * " +
                                 "FROM [cfg].[Configurations] " +
                                 "WHERE ConfigKey = 'EmailSettings:ResetPasswordTemplate')", true);
            
            migrationBuilder.Sql("INSERT INTO [cfg].[Configurations]([ConfigKey],[Value],[ModuleId]) " +
                                 "SELECT 'EmailSettings:Key', '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',1 " +
                                 "WHERE NOT EXISTS(SELECT * " +
                                 "FROM [cfg].[Configurations] " +
                                 "WHERE ConfigKey = 'EmailSettings:Key')", true);

            migrationBuilder.Sql("INSERT INTO [cfg].[Configurations]([ConfigKey],[Value],[ModuleId]) " +
                                 "SELECT 'EmailSettings:FromAddress', 'noreply@comfypost.com',1 " +
                                 "WHERE NOT EXISTS(SELECT * " +
                                 "FROM [cfg].[Configurations] " +
                                 "WHERE ConfigKey = 'EmailSettings:FromAddress')", true);

            migrationBuilder.Sql("INSERT INTO [cfg].[Configurations]([ConfigKey],[Value],[ModuleId]) " +
                                 "SELECT 'EmailSettings:FromName', 'ComfyPost',1 " +
                                 "WHERE NOT EXISTS(SELECT * " +
                                 "FROM [cfg].[Configurations] " +
                                 "WHERE ConfigKey = 'EmailSettings:FromName')", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
