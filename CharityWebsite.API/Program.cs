using CharityWebsite.Core.Common;
using CharityWebsite.Core.Repository;
using CharityWebsite.Core.Service;
using CharityWebsite.Infra.Common;
using CharityWebsite.Infra.Repository;
using CharityWebsite.Infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Text;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddCors(corsOptions =>
{

    corsOptions.AddPolicy("policy",
    builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });


});





// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IDbContext, DbContext>();


builder.Services.AddScoped<IProblemreportRepository, ProblemreportRepository>();
builder.Services.AddScoped<IProblemreportService, ProblemreportService>();
builder.Services.AddScoped<ICharityRepository, CharityRepository>();
builder.Services.AddScoped<ICharityService, CharityService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IDonationFormRepository,DonationFormRepository>();
builder.Services.AddScoped<IDonationFormService, DonationFormService>();
builder.Services.AddScoped<ICharityCategoryRepository,CharityCategoryRepository>();
builder.Services.AddScoped<ICharityCategoryService, CharityCategoryService>();
builder.Services.AddScoped<ICharityCategoryService, CharityCategoryService>();
builder.Services.AddScoped<IDonationRepository,DonationRepository>();
builder.Services.AddScoped<IDonationService, DonationService>(); 
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IContactMessageRepository, ContactMessageRepository>();
builder.Services.AddScoped<IContactMessageService, ContactMessageService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService,PaymentService>();



builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = false,
           ValidateAudience = false,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey@ApiCharity123456"))
       };
   });




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("policy");

app.MapControllers();


app.Run();
