﻿using VATHelper.Database;
using VATHelper.Interfaces;
using VATHelper.Workers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<ITransactionWorker, TransactionWorker>();
builder.Services.AddTransient<ITransactionInputTransformer, TransactionTransformer>();
builder.Services.AddHttpClient();
builder.Services.AddControllers();

// Adding the DbContext
builder.Services.AddDbContext<TransactionContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

