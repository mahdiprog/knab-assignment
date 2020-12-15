﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Triskele.Config.Infra.Persistence;

namespace Triskele.Config.Dal.Migrations
{
    [DbContext(typeof(ConfigModel))]
    [Migration("20190602073123_MailConfigs")]
    partial class MailConfigs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("cfg")
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Triskele.Config.Dal.Models.Configuration", b =>
                {
                    b.Property<string>("ConfigKey")
                        .HasMaxLength(100);

                    b.Property<int>("ModuleId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("ConfigKey", "ModuleId");

                    b.HasIndex("ModuleId");

                    b.ToTable("Configurations");

                    b.HasData(
                        new
                        {
                            ConfigKey = "ApplicationSettings:ApiProviderName",
                            ModuleId = 2,
                            Value = "Triskele.Account"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:ApiProviderName",
                            ModuleId = 3,
                            Value = "Triskele.OAuth"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:ApiProviderName",
                            ModuleId = 4,
                            Value = "Triskele.Captcha"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:ApiProviderName",
                            ModuleId = 5,
                            Value = "Triskele.Configuration"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:ApiProviderName",
                            ModuleId = 6,
                            Value = "Triskele.Logging"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:FacebookApiClientId",
                            ModuleId = 1,
                            Value = "939663442907604"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:FacebookApiClientSecret",
                            ModuleId = 1,
                            Value = "ce19021f905c7f41197ab4d46931eef6"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:GoogleApiClientId",
                            ModuleId = 1,
                            Value = "215015690999-le2j9hqhpre5cdaosd9lour7ttgmal1u.apps.googleusercontent.com"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:GoogleApiClientSecret",
                            ModuleId = 1,
                            Value = "LwCGHpmcqdTfCMS_0pmnLuTu"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:OAuthServiceUrl",
                            ModuleId = 1,
                            Value = "http://localhost:1494"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:OutputCacheRedisConnectionString",
                            ModuleId = 1,
                            Value = "127.0.0.1,password=1234,defaultDatabase=1"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SecurityInformation:CanSignInWithEmail",
                            ModuleId = 1,
                            Value = "TRUE"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SecurityInformation:CanSignInWithPhoneNo",
                            ModuleId = 1,
                            Value = "TRUE"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SecurityInformation:EmailConfirmationNeed",
                            ModuleId = 4,
                            Value = "Optional"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SecurityInformation:MaxFailedAccessAttemptsBeforeCaptcha",
                            ModuleId = 1,
                            Value = "5"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SecurityInformation:MaxFailedAccessAttemptsBeforeLockout",
                            ModuleId = 1,
                            Value = "15"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SecurityInformation:MaxSessionCount",
                            ModuleId = 1,
                            Value = "0"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SecurityInformation:MaxUserSessionCount",
                            ModuleId = 1,
                            Value = "0"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SecurityInformation:PasswordRequireDigit",
                            ModuleId = 1,
                            Value = "FALSE"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SecurityInformation:PasswordRequiredLength",
                            ModuleId = 1,
                            Value = "4"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SecurityInformation:PasswordRequireLowercase",
                            ModuleId = 1,
                            Value = "FALSE"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SecurityInformation:PasswordRequireNonLetterOrDigit",
                            ModuleId = 1,
                            Value = "FALSE"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SecurityInformation:PasswordRequireUppercase",
                            ModuleId = 1,
                            Value = "FALSE"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SecurityInformation:PhoneNoConfirmationNeed",
                            ModuleId = 4,
                            Value = "Required"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SecurityInformation:SessionRevokeTime",
                            ModuleId = 1,
                            Value = "30"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SessionCookieDomain",
                            ModuleId = 1,
                            Value = ".localhost.com"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SessionManagementRedisConnectionString",
                            ModuleId = 1,
                            Value = "127.0.0.1,password=1234,defaultDatabase=0"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:SmtpHost",
                            ModuleId = 1,
                            Value = "mydomain.smtp.com"
                        },
                        new
                        {
                            ConfigKey = "ApplicationSettings:StatsDServer",
                            ModuleId = 1,
                            Value = "10.10.10.45"
                        },
                        new
                        {
                            ConfigKey = "Captcha:BackgroundColor",
                            ModuleId = 4,
                            Value = ""
                        },
                        new
                        {
                            ConfigKey = "Captcha:CaptchaCharCount",
                            ModuleId = 4,
                            Value = "6"
                        },
                        new
                        {
                            ConfigKey = "Captcha:Font",
                            ModuleId = 4,
                            Value = ""
                        },
                        new
                        {
                            ConfigKey = "Captcha:GeneratorType",
                            ModuleId = 4,
                            Value = "Triskele.Captcha.Common.CaptchaProvider.Providers.FarsiAlpahbeticNumberProvider, Tirskele.Captcha.Common"
                        },
                        new
                        {
                            ConfigKey = "Captcha:ImageHeight",
                            ModuleId = 4,
                            Value = "60"
                        },
                        new
                        {
                            ConfigKey = "Captcha:ImageWidth",
                            ModuleId = 4,
                            Value = "230"
                        },
                        new
                        {
                            ConfigKey = "Captcha:RepositoryRedisConnectionString",
                            ModuleId = 4,
                            Value = "127.0.0.1,password=1234,defaultDatabase=2"
                        },
                        new
                        {
                            ConfigKey = "Captcha:RepositoryTTLMinutes",
                            ModuleId = 4,
                            Value = "3"
                        },
                        new
                        {
                            ConfigKey = "Captcha:RepositoryType",
                            ModuleId = 4,
                            Value = "Triskele.Captcha.RedisRepository.CaptchaRedisRepository, Triskele.Captcha.RedisRepository"
                        },
                        new
                        {
                            ConfigKey = "CaptchaSettings:SecretKey",
                            ModuleId = 1,
                            Value = "6LcnIoUUAAAAAJ4nYmyGu4ZvaOuYE-qJSGl321lE"
                        },
                        new
                        {
                            ConfigKey = "CaptchaSettings:SiteKey",
                            ModuleId = 1,
                            Value = "6LcnIoUUAAAAADy7cQAfYJcPqmOYIrnRAPS2Cp52"
                        },
                        new
                        {
                            ConfigKey = "CaptchaSettings:ValidatorType",
                            ModuleId = 1,
                            Value = "Triskele.Common.Web.Captcha.ReCaptchaValidator, Triskele.Common.Web"
                        },
                        new
                        {
                            ConfigKey = "ConnectionStrings:AccountModel",
                            ModuleId = 1,
                            Value = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Triskele.Auth;Integrated Security=True;"
                        },
                        new
                        {
                            ConfigKey = "IpRateLimiting:EnableEndpointRateLimiting",
                            ModuleId = 1,
                            Value = "TRUE"
                        },
                        new
                        {
                            ConfigKey = "JwtIssuerOptions:Issuer",
                            ModuleId = 1,
                            Value = "oauth.mecp.ir"
                        },
                        new
                        {
                            ConfigKey = "JwtIssuerOptions:SigningAlgorithm",
                            ModuleId = 1,
                            Value = "HS512"
                        },
                        new
                        {
                            ConfigKey = "JwtIssuerOptions:ValidFor",
                            ModuleId = 1,
                            Value = "1.00:00:00"
                        },
                        new
                        {
                            ConfigKey = "Serilog:Enrich:0",
                            ModuleId = 1,
                            Value = "FromLogContext"
                        },
                        new
                        {
                            ConfigKey = "Serilog:Enrich:1",
                            ModuleId = 1,
                            Value = "WithExceptionDetails"
                        },
                        new
                        {
                            ConfigKey = "Serilog:Enrich:2",
                            ModuleId = 1,
                            Value = "WithMachineName"
                        },
                        new
                        {
                            ConfigKey = "Serilog:MinimumLevel:Default",
                            ModuleId = 1,
                            Value = "Verbose"
                        },
                        new
                        {
                            ConfigKey = "Serilog:MinimumLevel:Override:Microsoft",
                            ModuleId = 1,
                            Value = "Warning"
                        },
                        new
                        {
                            ConfigKey = "Serilog:MinimumLevel:Override:Microsoft.AspNetCore.Localization",
                            ModuleId = 1,
                            Value = "Error"
                        },
                        new
                        {
                            ConfigKey = "Serilog:Using:0",
                            ModuleId = 1,
                            Value = "Serilog.Sinks.Async"
                        },
                        new
                        {
                            ConfigKey = "Serilog:Using:1",
                            ModuleId = 1,
                            Value = "Serilog.Sinks.Http"
                        },
                        new
                        {
                            ConfigKey = "Serilog:WriteTo:0:Args:configure:0:Args:requestUri",
                            ModuleId = 1,
                            Value = "http://localhost:3825/api/Logger"
                        },
                        new
                        {
                            ConfigKey = "Serilog:WriteTo:0:Args:configure:0:Name",
                            ModuleId = 1,
                            Value = "Http"
                        },
                        new
                        {
                            ConfigKey = "Serilog:WriteTo:0:Name",
                            ModuleId = 1,
                            Value = "Async"
                        });
                });

            modelBuilder.Entity("Triskele.Config.Dal.Models.Module", b =>
                {
                    b.Property<int>("ModuleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("ModuleId");

                    b.ToTable("Modules");

                    b.HasData(
                        new
                        {
                            ModuleId = 1,
                            Name = "Share"
                        },
                        new
                        {
                            ModuleId = 2,
                            Name = "Triskele.Account"
                        },
                        new
                        {
                            ModuleId = 3,
                            Name = "Triskele.OAuth"
                        },
                        new
                        {
                            ModuleId = 4,
                            Name = "Triskele.Captcha"
                        },
                        new
                        {
                            ModuleId = 5,
                            Name = "Triskele.Configuration"
                        },
                        new
                        {
                            ModuleId = 6,
                            Name = "Triskele.Logging"
                        });
                });

            modelBuilder.Entity("Triskele.Config.Dal.Models.Server", b =>
                {
                    b.Property<int>("ServerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<int>("ModuleId");

                    b.HasKey("ServerId");

                    b.HasIndex("ModuleId");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("Triskele.Config.Dal.Models.Configuration", b =>
                {
                    b.HasOne("Triskele.Config.Dal.Models.Module", "Module")
                        .WithMany("Configurations")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Triskele.Config.Dal.Models.Server", b =>
                {
                    b.HasOne("Triskele.Config.Dal.Models.Module", "Module")
                        .WithMany("Servers")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
