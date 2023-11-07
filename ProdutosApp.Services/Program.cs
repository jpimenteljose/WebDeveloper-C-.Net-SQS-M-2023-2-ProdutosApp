var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//criando a política de CORS do projeto
builder.Services.AddCors(
          config => config.AddPolicy("DefaultPolicy", builder =>
          {
              builder.AllowAnyOrigin()  // qualquer dominio poderá acessar a API
                     .AllowAnyMethod()  // permitir POST, PUT, DELETE, GET
                     .AllowAnyHeader(); // aceitar parametros de cabeçalho de requisição
          })
          );

var app = builder.Build();

// Este IF é usado para exibir o Swagger somente em Desenvolvimento (Local)
//if (app.Environment.IsDevelopment())   
//{
    // Configure the HTTP request pipeline.
    //app.UseSwagger();
    //app.UseSwaggerUI();
//}

// Para usar também em Produção (no servidor), retiramos o IF
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
