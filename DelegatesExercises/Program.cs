using System;
using System.Threading.Tasks;
using System.IO;

// Exercício 1: Delegate para Descontos
public delegate decimal CalcularDesconto(decimal precoOriginal);

public class CalculadoraDesconto
{
    public static decimal AplicarDesconto(decimal preco)
    {
        return preco * 0.9m; // 10% de desconto
    }
}

// Exercício 2: Ações Multilíngues
public class Saudador
{
    public static void SaudacaoPortugues(string nome) => Console.WriteLine($"Olá, {nome}!");
    public static void SaudacaoIngles(string nome) => Console.WriteLine($"Hello, {nome}!");
    public static void SaudacaoEspanhol(string nome) => Console.WriteLine($"¡Hola, {nome}!");
}

// Exercício 3: Cálculo de Área
public class CalculadoraArea
{
    public static double CalcularAreaRetangulo(double largura, double altura)
    {
        return largura * altura;
    }
}

// Exercício 4: Monitoramento de Temperatura
public class ArgumentosTemperatura : EventArgs
{
    public double Temperatura { get; }
    public ArgumentosTemperatura(double temperatura)
    {
        Temperatura = temperatura;
    }
}

public class SensorTemperatura
{
    public event EventHandler<ArgumentosTemperatura> TemperaturaExcedida;
    
    protected virtual void OnTemperaturaExcedida(ArgumentosTemperatura e)
    {
        TemperaturaExcedida?.Invoke(this, e);
    }
    
    public void VerificarTemperatura(double temperatura)
    {
        if (temperatura > 100)
        {
            OnTemperaturaExcedida(new ArgumentosTemperatura(temperatura));
        }
    }
}

// Exercício 5: Notificação de Download
public class ArgumentosDownload : EventArgs
{
    public string NomeArquivo { get; }
    public ArgumentosDownload(string nomeArquivo)
    {
        NomeArquivo = nomeArquivo;
    }
}

public class GerenciadorDownload
{
    public event EventHandler<ArgumentosDownload> DownloadConcluido;
    
    protected virtual void OnDownloadConcluido(ArgumentosDownload e)
    {
        DownloadConcluido?.Invoke(this, e);
    }
    
    public async Task BaixarArquivoAsync(string nomeArquivo)
    {
        await Task.Delay(2000); // Simula download
        OnDownloadConcluido(new ArgumentosDownload(nomeArquivo));
    }
}

// Exercício 6: Sistema de Registro
public class Registrador
{
    public void RegistrarNoConsole(string mensagem) => Console.WriteLine($"Console: {mensagem}");
    public void RegistrarNoArquivo(string mensagem) => File.AppendAllText("registro.txt", $"Arquivo: {mensagem}\n");
    public void RegistrarNoBanco(string mensagem) => Console.WriteLine($"Banco de Dados: {mensagem}");
}

// Exercício 7: Registrador Seguro
public class RegistradorSeguro
{
    private Action<string> _delegateRegistro;
    
    public void Registrar(string mensagem)
    {
        _delegateRegistro?.Invoke(mensagem);
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Escolha o exercício (1-7):");
        var escolha = Console.ReadLine();

        switch (escolha)
        {
            case "1":
                Exercicio1();
                break;
            case "2":
                Exercicio2();
                break;
            case "3":
                Exercicio3();
                break;
            case "4":
                Exercicio4();
                break;
            case "5":
                await Exercicio5();
                break;
            case "6":
                Exercicio6();
                break;
            case "7":
                Exercicio7();
                break;
            default:
                Console.WriteLine("Exercício inválido!");
                break;
        }
    }

    static void Exercicio1()
    {
        Console.WriteLine("Digite o preço original:");
        if (decimal.TryParse(Console.ReadLine(), out decimal preco))
        {
            CalcularDesconto calculadoraDesconto = CalculadoraDesconto.AplicarDesconto;
            decimal precoFinal = calculadoraDesconto(preco);
            Console.WriteLine($"Preço com desconto: {precoFinal:C}");
        }
    }

    static void Exercicio2()
    {
        Console.WriteLine("Escolha o idioma (1-Português, 2-Inglês, 3-Espanhol):");
        var escolha = Console.ReadLine();
        Console.WriteLine("Digite seu nome:");
        var nome = Console.ReadLine();

        Action<string> saudacao = escolha switch
        {
            "1" => Saudador.SaudacaoPortugues,
            "2" => Saudador.SaudacaoIngles,
            "3" => Saudador.SaudacaoEspanhol,
            _ => (n) => Console.WriteLine("Idioma não suportado!")
        };

        saudacao(nome);
    }

    static void Exercicio3()
    {
        Console.WriteLine("Digite a largura do retângulo:");
        if (double.TryParse(Console.ReadLine(), out double largura))
        {
            Console.WriteLine("Digite a altura do retângulo:");
            if (double.TryParse(Console.ReadLine(), out double altura))
            {
                Func<double, double, double> calculadoraArea = CalculadoraArea.CalcularAreaRetangulo;
                double area = calculadoraArea(largura, altura);
                Console.WriteLine($"Área do retângulo: {area}");
            }
        }
    }

    static void Exercicio4()
    {
        var sensor = new SensorTemperatura();
        sensor.TemperaturaExcedida += (sender, e) =>
        {
            Console.WriteLine($"ALERTA: Temperatura {e.Temperatura}°C excedeu o limite!");
        };

        Console.WriteLine("Digite a temperatura atual:");
        if (double.TryParse(Console.ReadLine(), out double temperatura))
        {
            sensor.VerificarTemperatura(temperatura);
        }
    }

    static async Task Exercicio5()
    {
        var gerenciador = new GerenciadorDownload();
        gerenciador.DownloadConcluido += (sender, e) =>
        {
            Console.WriteLine($"Download concluído: {e.NomeArquivo}");
        };

        Console.WriteLine("Iniciando download...");
        await gerenciador.BaixarArquivoAsync("arquivo.txt");
    }

    static void Exercicio6()
    {
        var registrador = new Registrador();
        Action<string> registradorMultiplo = registrador.RegistrarNoConsole;
        registradorMultiplo += registrador.RegistrarNoArquivo;
        registradorMultiplo += registrador.RegistrarNoBanco;

        Console.WriteLine("Digite a mensagem para registro:");
        var mensagem = Console.ReadLine();
        registradorMultiplo(mensagem);
    }

    static void Exercicio7()
    {
        var registradorSeguro = new RegistradorSeguro();
        Console.WriteLine("Testando registrador sem métodos associados...");
        registradorSeguro.Registrar("Mensagem de teste");
        
        Console.WriteLine("Adicionando método de registro...");
        registradorSeguro.Registrar("Mensagem após adicionar método");
    }
}
