using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

int GCD(int a, int b)
{
    while(b!= 0)
    {
        int temp = b;
        b = a % b;
        a = temp;
    }

    return a;
}

app.MapGet("/shababaffanul_gmail_com", (string? x, string? y) =>
{
    if(!int.TryParse(x, out int x_nat) || !int.TryParse(y,out int y_nat))
        return Results.Text("NaN", "text/plain");
    if(x_nat <= 0 || y_nat <= 0)
        return Results.Text("NaN", "text/plain");
    
    int gcd = GCD(x_nat, y_nat);
    int lcm = (x_nat / gcd) * y_nat;

    return Results.Text(lcm.ToString(), "text/plain");
});

app.Run();