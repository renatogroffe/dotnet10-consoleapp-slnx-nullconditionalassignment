using ConsoleAppNullConditionalAssignment.Models;
using System.Runtime.InteropServices;
using System.Text.Json;

Console.WriteLine("***** Testes com C# 14 + .NET 10 | Null-conditional assignment *****");
Console.WriteLine($"Versao do .NET em uso: {RuntimeInformation
    .FrameworkDescription} - Ambiente: {Environment.MachineName} - Kernel: {Environment
    .OSVersion.VersionString}");

var produtos = new List<Produto?>
{
    new Produto() { Id = Guid.NewGuid().ToString(), Nome = "Produto 1", Preco = 10.0},
    null,
    new Produto() { Id = Guid.NewGuid().ToString(), Nome = "Produto 3", Preco = 30.0}
};

Console.WriteLine();
Console.WriteLine("Dados antes do reajuste:");
Console.WriteLine(JsonSerializer.Serialize(produtos,
    new JsonSerializerOptions { WriteIndented = true }));

Console.WriteLine();
Console.WriteLine("Aplicando reajustes...");
Console.WriteLine();
foreach (var produto in produtos)
{
    AplicarReajuste(produto, 10);
    Console.WriteLine($"Produto: {produto?.Nome}, Preço: {produto?.Preco}");
}

static void AplicarReajuste(Produto? produto, double percentual)
{
    produto?.Preco += produto?.Preco * percentual / 100;
}