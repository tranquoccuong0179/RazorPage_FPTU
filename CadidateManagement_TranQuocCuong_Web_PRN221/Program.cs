using CadidateManagement_TranQuocCuong_Web_PRN221.Hubs;
using Candidate_Repository;
using Candidate_Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<ICandidateProfileService, CandidateProfileService>();
builder.Services.AddScoped<ICandidateProfileRepository, CandidateProfileRepository>();
builder.Services.AddScoped<IJobPostingRepository, JobPostingRepository>();
builder.Services.AddScoped<IJobPostingService, JobPostingService>();
builder.Services.AddScoped<IHRAccountRepository, HRAccountRepository>();
builder.Services.AddScoped<IHRAccountService, HRAccountService>();
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
