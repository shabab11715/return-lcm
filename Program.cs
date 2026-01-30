using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System.Numerics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

BigInteger GCD(BigInteger a, BigInteger b)
{
    while (b != 0)
    {
        var temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

app.MapGet("/shababaffanul_gmail_com", (string? x, string? y) =>
{
    if (!BigInteger.TryParse(x, out var x_nat) || !BigInteger.TryParse(y, out var y_nat))
        return Results.Text("NaN", "text/plain");

    if (x_nat <= 0 || y_nat <= 0)
        return Results.Text("NaN", "text/plain");

    var gcd = GCD(x_nat, y_nat);
    var lcm = (x_nat / gcd) * y_nat;

    return Results.Text(lcm.ToString(), "text/plain");
});

app.Run();