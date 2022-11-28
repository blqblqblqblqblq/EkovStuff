using API.Examples;
using Services;
using Services.Interfaces;
using Swashbuckle.AspNetCore.Filters;
using Vanilla.Data;
using Vanilla.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<VanillaContext>(options =>
//{
//    var connetionString = builder.Configuration.GetConnectionString("DefaultConnection");
//    options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
//});
builder.Services.AddDbContext<VanillaContext>();
builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddScoped<ILegalEntityRepository, LegalEntityRepository>();
builder.Services.AddScoped<IMembershipGroupRepository, MembershipGroupRepository>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IMembershipGroupService, MembershipGroupService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s => s.ExampleFilters());
builder.Services.AddSwaggerExamplesFromAssemblyOf<CreateTenantRequestExample>();
builder.Services.AddSwaggerExamplesFromAssemblyOf<CreateMembershipGroupRequestExample>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
