using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

long GCD(long a, long b)
{
    while(b!= 0)
    {
        long temp = b;
        b = a % b;
        a = temp;
    }

    return a;
}

app.MapGet("/shababaffanul_gmail_com", (string? x, string? y) =>
{
    if(!long.TryParse(x, out long x_nat) || !long.TryParse(y,out long y_nat))
        return Results.Text("NaN", "text/plain");
    if(x_nat <= 0 || y_nat <= 0)
        return Results.Text("NaN", "text/plain");
    
    long gcd = GCD(x_nat, y_nat);
    long lcm = (x_nat / gcd) * y_nat;

    return Results.Text(lcm.ToString(), "text/plain");
});

app.Run();