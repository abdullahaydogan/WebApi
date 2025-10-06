using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Gerekli servis kayıtları
builder.Services.AddHttpClient(); // GoldPriceService için gerekli
builder.Services.AddScoped<GoldPriceService>();
builder.Services.AddScoped<ProductService>();

// ✅ CORS (Frontend erişimi için)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ CORS middleware'i ekle
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
