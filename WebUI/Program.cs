using ApiAccess.Abstract;
using ApiAccess.Base;
using Shared.Helpers.Abstract;
using Shared.Helpers.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region DependencyInjection
builder.Services.AddScoped<IRequestService, RequestManager>();
builder.Services.AddScoped<INewsApiRequest, NewsApiRequest>();
builder.Services.AddScoped<IWriterApiRequest, WriterApiRequest>();
builder.Services.AddScoped<ICategoryApiRequest, CategoryApiRequest>();
builder.Services.AddScoped<ICommentApiRequest, CommentApiRequest>();
builder.Services.AddScoped<ICommonApiRequest, CommonApiRequest>();
builder.Services.AddScoped<ISlideApiRequest, SlideApiRequest>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
