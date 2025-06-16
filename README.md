# Exercícios de C# - Delegates, Events e ASP.NET Core

Este repositório contém as soluções para os exercícios propostos sobre Delegates, Events e ASP.NET Core.

## Estrutura do Projeto

O projeto está organizado em duas partes principais:

1. Console Applications (Exercícios 1-7)
2. ASP.NET Core Web Application (Exercícios 8-12)

## Exercício 1: Implementação de Delegate Personalizado para Descontos

```csharp
public delegate decimal CalculateDiscount(decimal originalPrice);

public class DiscountCalculator
{
    public static decimal ApplyDiscount(decimal price)
    {
        return price * 0.9m; // 10% de desconto
    }
}
```

## Exercício 2: Ações Multilíngues com Action<string>

```csharp
public class LanguageGreeter
{
    public static void PortugueseGreeting(string name) => Console.WriteLine($"Olá, {name}!");
    public static void EnglishGreeting(string name) => Console.WriteLine($"Hello, {name}!");
    public static void SpanishGreeting(string name) => Console.WriteLine($"¡Hola, {name}!");
}
```

## Exercício 3: Cálculo de Área Utilizando Func

```csharp
public class AreaCalculator
{
    public static double CalculateRectangleArea(double width, double height)
    {
        return width * height;
    }
}
```

## Exercício 4: Monitoramento de Temperatura com Evento Personalizado

```csharp
public class TemperatureSensor
{
    public event EventHandler<TemperatureEventArgs> TemperatureExceeded;

    public void CheckTemperature(double temperature)
    {
        if (temperature > 100)
        {
            OnTemperatureExceeded(new TemperatureEventArgs(temperature));
        }
    }
}
```

## Exercício 5: Notificação de Conclusão de Download com Eventos

```csharp
public class DownloadManager
{
    public event EventHandler<DownloadEventArgs> DownloadCompleted;

    public async Task DownloadFileAsync(string fileName)
    {
        await Task.Delay(2000); // Simula download
        OnDownloadCompleted(new DownloadEventArgs(fileName));
    }
}
```

## Exercício 6: Sistema de Registro com Multicast Delegate

```csharp
public class Logger
{
    public void LogToConsole(string message) => Console.WriteLine($"Console: {message}");
    public void LogToFile(string message) => File.AppendAllText("log.txt", $"File: {message}\n");
    public void LogToDatabase(string message) => Console.WriteLine($"Database: {message}");
}
```

## Exercício 7: Garantia de Robustez em Invocação de Delegates

```csharp
public class SafeLogger
{
    private Action<string> _logDelegate;

    public void Log(string message)
    {
        _logDelegate?.Invoke(message);
    }
}
```

## Exercício 8-12: ASP.NET Core Web Application

A aplicação web inclui:

- Páginas Razor para exibição de produtos
- Formulários para cadastro
- Implementação de eventos e delegates
- Estrutura MVC simplificada

### Estrutura do Projeto ASP.NET Core

1. **Pasta Pages**: Contém as páginas Razor (.cshtml) e seus respectivos code-behinds (.cshtml.cs)
2. **Program.cs**: Ponto de entrada da aplicação, configuração de serviços e middleware
3. **Configuração de Serviços**: Realizada no método `ConfigureServices` em Program.cs
4. **Roteamento**: Configurado automaticamente pelo ASP.NET Core baseado na estrutura de pastas

## Como Executar

1. Para os exercícios de console:

   - Navegue até a pasta do exercício
   - Execute `dotnet run`

2. Para a aplicação web:
   - Navegue até a pasta do projeto web
   - Execute `dotnet run`
   - Acesse `https://localhost:5001` ou `http://localhost:5000`

## Requisitos

- .NET 6.0 ou superior
- Visual Studio 2022 ou VS Code
