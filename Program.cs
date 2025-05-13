
using Asp.Versioning;
using FluentValidation;
using FluentValidation.AspNetCore;
//using MailKit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Twitter.Data;
using Twitter.DTOs.Notification;
using Twitter.Exceptions;
using Twitter.Model;
using Twitter.Services.AuthService_dir;
using Twitter.Services.BlockService_dir;
using Twitter.Services.BookmarkService_dir;
using Twitter.Services.CommentService_dir;
using Twitter.Services.ImgService_dir;
using Twitter.Services.MailService_dir;
using Twitter.Services.NotificationService;
using Twitter.Services.PostService_dir;
using Twitter.Services.ProfileService_dir;
using Twitter.Unit_of_work;
using Twitter.Validators;
using Twitter.Services.MailService_dir;
namespace Twitter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            options.Filters.Add<GlobalExceptionFilter>()
            ).AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<PostDtoValidator>();
            });

            builder.Services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
               
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IBlockService, BlockService>();
            builder.Services.AddScoped<IBookmarkService, BookmarkService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IMailService, MailService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
            builder.Services.AddScoped<IImgService, ImgService>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();
            //builder.Services.AddSingleton<IValidator<NotificationDto>, NotificationValidator>();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

           //
           //
           //
           //
           //
           //
           //
           //
           //
           //


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]))

                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
