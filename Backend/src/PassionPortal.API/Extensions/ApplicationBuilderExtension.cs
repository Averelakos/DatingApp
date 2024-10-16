namespace PassionPortal.API;

public static class ApplicationBuilderExtension
{
    public static void Configure(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(x => 
            x.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:4200", "https://localhost:4200")); // To accept request from the angular
        app.UseHttpsRedirection();
        
    }
}
