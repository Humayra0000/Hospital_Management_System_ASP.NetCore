using BLL.Services;
using DAL;
using DAL.EF;
using DAL.Interfaces;
using DAL.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPatientRepo, PatientRepo>();  
builder.Services.AddScoped<PatientService>();

builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
builder.Services.AddScoped<DoctorService>();

builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();
builder.Services.AddScoped<AppointmentService>();

builder.Services.AddScoped<IBillRepo, BillRepo>();
builder.Services.AddScoped<BillService>();

builder.Services.AddDbContext<PMSContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});

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