using Microsoft.EntityFrameworkCore.Migrations;

namespace Triskele.Config.Dal.Migrations
{
    public partial class RemoveModulesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configurations_Modules",
                schema: "cfg",
                table: "Configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_Servers_Modules_ModuleId",
                schema: "cfg",
                table: "Servers");

            migrationBuilder.DropTable(
                name: "Modules",
                schema: "cfg");

            migrationBuilder.DropIndex(
                name: "IX_Servers_ModuleId",
                schema: "cfg",
                table: "Servers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Configurations",
                schema: "cfg",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "ModuleId",
                schema: "cfg",
                table: "Servers");
            
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                schema: "cfg",
                table: "Configurations",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "ApiProviderName",
                schema: "cfg",
                table: "Configurations",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

             //Fix Data
            migrationBuilder.Sql("UPDATE cfg.Configurations SET ApiProviderName = \'\' WHERE ModuleId = 1");
            migrationBuilder.Sql("UPDATE cfg.Configurations SET ApiProviderName = \'Triskele.Account\' WHERE ModuleId = 2");
            migrationBuilder.Sql("UPDATE cfg.Configurations SET ApiProviderName = \'Triskele.OAuth\' WHERE ModuleId = 3");
            migrationBuilder.Sql("UPDATE cfg.Configurations SET ApiProviderName = \'Triskele.Captcha\' WHERE ModuleId = 4");
            migrationBuilder.Sql("UPDATE cfg.Configurations SET ApiProviderName = \'Triskele.Configuration\' WHERE ModuleId = 5");
            migrationBuilder.Sql("UPDATE cfg.Configurations SET ApiProviderName = \'Triskele.Logging\' WHERE ModuleId = 6");
            migrationBuilder.Sql("UPDATE cfg.Configurations SET ApiProviderName = \'Triskele.File\' WHERE ModuleId = 7");
            migrationBuilder.Sql("UPDATE cfg.Configurations SET ApiProviderName = \'ComfyPost\' WHERE ModuleId = 11");
            migrationBuilder.Sql("UPDATE cfg.Configurations SET ApiProviderName = \'Asa.General\' WHERE ModuleId = 21");
            migrationBuilder.Sql("UPDATE cfg.Configurations SET ApiProviderName = \'Asa.General.Accountancy\' WHERE ModuleId = 24");

            migrationBuilder.DropColumn(
                name: "ModuleId",
                schema: "cfg",
                table: "Configurations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Configurations",
                schema: "cfg",
                table: "Configurations",
                columns: new[] { "ConfigKey", "ApiProviderName" });

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_ApiProviderName",
                schema: "cfg",
                table: "Configurations",
                column: "ApiProviderName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Configurations",
                schema: "cfg",
                table: "Configurations");

            migrationBuilder.DropIndex(
                name: "IX_Configurations_ApiProviderName",
                schema: "cfg",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "ApiProviderName",
                schema: "cfg",
                table: "Configurations");

            migrationBuilder.AlterColumn<int>(
                name: "ServerId",
                schema: "cfg",
                table: "Servers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ModuleId",
                schema: "cfg",
                table: "Servers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                schema: "cfg",
                table: "Configurations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 512);

            migrationBuilder.AddColumn<int>(
                name: "ModuleId",
                schema: "cfg",
                table: "Configurations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Configurations",
                schema: "cfg",
                table: "Configurations",
                columns: new[] { "ConfigKey", "ModuleId" });

            migrationBuilder.CreateTable(
                name: "Modules",
                schema: "cfg",
                columns: table => new
                {
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleId);
                });

            migrationBuilder.InsertData(
                schema: "cfg",
                table: "Modules",
                columns: new[] { "ModuleId", "Name" },
                values: new object[,]
                {
                    { 1, "Share" },
                    { 2, "Triskele.Account" },
                    { 3, "Triskele.OAuth" },
                    { 4, "Triskele.Captcha" },
                    { 5, "Triskele.Configuration" },
                    { 6, "Triskele.Logging" }
                });

            migrationBuilder.InsertData(
                schema: "cfg",
                table: "Configurations",
                columns: new[] { "ConfigKey", "ModuleId", "Value" },
                values: new object[,]
                {
                    { "ApplicationSettings:FacebookApiClientId", 1, "939663442907604" },
                    { "Serilog:Enrich:0", 1, "FromLogContext" },
                    { "Serilog:Enrich:1", 1, "WithExceptionDetails" },
                    { "Serilog:Enrich:2", 1, "WithMachineName" },
                    { "Serilog:MinimumLevel:Default", 1, "Verbose" },
                    { "Serilog:MinimumLevel:Override:Microsoft", 1, "Warning" },
                    { "Serilog:MinimumLevel:Override:Microsoft.AspNetCore.Localization", 1, "Error" },
                    { "Serilog:Using:0", 1, "Serilog.Sinks.Async" },
                    { "Serilog:Using:1", 1, "Serilog.Sinks.Http" },
                    { "Serilog:WriteTo:0:Args:configure:0:Args:requestUri", 1, "http://localhost:3825/api/Logger" },
                    { "Serilog:WriteTo:0:Args:configure:0:Name", 1, "Http" },
                    { "Serilog:WriteTo:0:Name", 1, "Async" },
                    { "ApplicationSettings:ApiProviderName", 2, "Triskele.Account" },
                    { "ApplicationSettings:ApiProviderName", 3, "Triskele.OAuth" },
                    { "ApplicationSettings:ApiProviderName", 4, "Triskele.Captcha" },
                    { "ApplicationSettings:SecurityInformation:EmailConfirmationNeed", 4, "Optional" },
                    { "ApplicationSettings:SecurityInformation:PhoneNoConfirmationNeed", 4, "Required" },
                    { "Captcha:BackgroundColor", 4, "" },
                    { "Captcha:CaptchaCharCount", 4, "6" },
                    { "Captcha:Font", 4, "" },
                    { "Captcha:GeneratorType", 4, "Triskele.Captcha.Common.CaptchaProvider.Providers.FarsiAlpahbeticNumberProvider, Tirskele.Captcha.Common" },
                    { "Captcha:ImageHeight", 4, "60" },
                    { "Captcha:ImageWidth", 4, "230" },
                    { "Captcha:RepositoryRedisConnectionString", 4, "127.0.0.1,password=1234,defaultDatabase=2" },
                    { "Captcha:RepositoryTTLMinutes", 4, "3" },
                    { "Captcha:RepositoryType", 4, "Triskele.Captcha.RedisRepository.CaptchaRedisRepository, Triskele.Captcha.RedisRepository" },
                    { "JwtIssuerOptions:ValidFor", 1, "1.00:00:00" },
                    { "ApplicationSettings:ApiProviderName", 5, "Triskele.Configuration" },
                    { "JwtIssuerOptions:SigningAlgorithm", 1, "HS512" },
                    { "IpRateLimiting:EnableEndpointRateLimiting", 1, "TRUE" },
                    { "ApplicationSettings:FacebookApiClientSecret", 1, "ce19021f905c7f41197ab4d46931eef6" },
                    { "ApplicationSettings:GoogleApiClientId", 1, "215015690999-le2j9hqhpre5cdaosd9lour7ttgmal1u.apps.googleusercontent.com" },
                    { "ApplicationSettings:GoogleApiClientSecret", 1, "LwCGHpmcqdTfCMS_0pmnLuTu" },
                    { "ApplicationSettings:OAuthServiceUrl", 1, "http://localhost:1494" },
                    { "ApplicationSettings:OutputCacheRedisConnectionString", 1, "127.0.0.1,password=1234,defaultDatabase=1" },
                    { "ApplicationSettings:SecurityInformation:CanSignInWithEmail", 1, "TRUE" },
                    { "ApplicationSettings:SecurityInformation:CanSignInWithPhoneNo", 1, "TRUE" },
                    { "ApplicationSettings:SecurityInformation:MaxFailedAccessAttemptsBeforeCaptcha", 1, "5" },
                    { "ApplicationSettings:SecurityInformation:MaxFailedAccessAttemptsBeforeLockout", 1, "15" },
                    { "ApplicationSettings:SecurityInformation:MaxSessionCount", 1, "0" },
                    { "ApplicationSettings:SecurityInformation:MaxUserSessionCount", 1, "0" },
                    { "ApplicationSettings:SecurityInformation:PasswordRequireDigit", 1, "FALSE" },
                    { "ApplicationSettings:SecurityInformation:PasswordRequiredLength", 1, "4" },
                    { "ApplicationSettings:SecurityInformation:PasswordRequireLowercase", 1, "FALSE" },
                    { "ApplicationSettings:SecurityInformation:PasswordRequireNonLetterOrDigit", 1, "FALSE" },
                    { "ApplicationSettings:SecurityInformation:PasswordRequireUppercase", 1, "FALSE" },
                    { "ApplicationSettings:SecurityInformation:SessionRevokeTime", 1, "30" },
                    { "ApplicationSettings:SessionCookieDomain", 1, ".localhost.com" },
                    { "ApplicationSettings:SessionManagementRedisConnectionString", 1, "127.0.0.1,password=1234,defaultDatabase=0" },
                    { "ApplicationSettings:SmtpHost", 1, "mydomain.smtp.com" },
                    { "ApplicationSettings:StatsDServer", 1, "10.10.10.45" },
                    { "CaptchaSettings:SecretKey", 1, "6LcnIoUUAAAAAJ4nYmyGu4ZvaOuYE-qJSGl321lE" },
                    { "CaptchaSettings:SiteKey", 1, "6LcnIoUUAAAAADy7cQAfYJcPqmOYIrnRAPS2Cp52" },
                    { "CaptchaSettings:ValidatorType", 1, "Triskele.Common.Web.Captcha.ReCaptchaValidator, Triskele.Common.Web" },
                    { "ConnectionStrings:AccountModel", 1, "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Triskele.Auth;Integrated Security=True;" },
                    { "JwtIssuerOptions:Issuer", 1, "oauth.mecp.ir" },
                    { "ApplicationSettings:ApiProviderName", 6, "Triskele.Logging" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servers_ModuleId",
                schema: "cfg",
                table: "Servers",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_ModuleId",
                schema: "cfg",
                table: "Configurations",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configurations_Modules_ModuleId",
                schema: "cfg",
                table: "Configurations",
                column: "ModuleId",
                principalSchema: "cfg",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servers_Modules_ModuleId",
                schema: "cfg",
                table: "Servers",
                column: "ModuleId",
                principalSchema: "cfg",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
