using Business.Abstract;
using Business.Base;
using DataAccess.Abstract.Repository;
using DataAccess.Base.Repository;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddDbContext<NewsContext>(context => context.UseSqlServer("sql baðlantýsý yapýlacak"));

#region DependencyInjection
//DB CONTEXT START
builder.Services.AddScoped<DbContext, NewsContext>();
//DB CONTEXT START

//DATA ACCESS START
builder.Services.AddScoped<IRepository<News>, GenericRepository<News>>();
builder.Services.AddScoped<IRepository<Category>, GenericRepository<Category>>();
builder.Services.AddScoped<IRepository<Comment>, GenericRepository<Comment>>();
builder.Services.AddScoped<IRepository<Writer>, GenericRepository<Writer>>();
builder.Services.AddScoped<IRepository<Slide>, GenericRepository<Slide>>();
//DATA ACCESS FINISH

//BUSINESS START
builder.Services.AddScoped<INewsService, NewsManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IWriterService, WriterManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ISlideService, SlideManager>();
//BUSINESS FINISH

#endregion

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
