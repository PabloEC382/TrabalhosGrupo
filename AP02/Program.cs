using System.Globalization;
using _AP02.Modelos;

CultureInfo culturaBrasileira = new("pt-BR");

DateTime? dataMinima = null, dataMaxima = null;
TimeSpan? horaMinima = null, horaMaxima = null;

Console.WriteLine("Configuração da Reserva:");

while (dataMinima == null)
{
    Console.Write("Informe a Data Mínima (dd/MM/yyyy): ");
    var entrada = Console.ReadLine();
    if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", culturaBrasileira, DateTimeStyles.None, out var data))
    {
        dataMinima = data;
    }
    else
    {
        Console.WriteLine($"Data inválida: {entrada}. Tente novamente.");
    }
}

while (dataMaxima == null)
{
    Console.Write("Informe a Data Máxima (dd/MM/yyyy): ");
    var entrada = Console.ReadLine();
    if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", culturaBrasileira, DateTimeStyles.None, out var data) && data > dataMinima)
    {
        dataMaxima = data;
    }
    else
    {
        Console.WriteLine($"Data inválida ou menor que a Data Mínima ({dataMinima:dd/MM/yyyy}). Tente novamente.");
    }
}

while (horaMinima == null)
{
    Console.Write("Informe a Hora Mínima (HH:mm): ");
    var entrada = Console.ReadLine();
    if (TimeSpan.TryParseExact(entrada, "hh\\:mm", culturaBrasileira, out var hora))
    {
        horaMinima = hora;
    }
    else
    {
        Console.WriteLine($"Hora inválida: {entrada}. Tente novamente.");
    }
}

while (horaMaxima == null)
{
    Console.Write("Informe a Hora Máxima (HH:mm): ");
    var entrada = Console.ReadLine();
    if (TimeSpan.TryParseExact(entrada, "hh\\:mm", culturaBrasileira, out var hora) && hora > horaMinima)
    {
        horaMaxima = hora;
    }
    else
    {
        Console.WriteLine($"Hora inválida ou menor que a Hora Mínima ({horaMinima}). Tente novamente.");
    }
}

ConfiguracaoReserva configuracao;
try
{
    configuracao = new ConfiguracaoReserva((DateTime)dataMinima, (DateTime)dataMaxima, (TimeSpan)horaMinima, (TimeSpan)horaMaxima);
    Console.WriteLine("\nConfiguração registrada com sucesso:");
    Console.WriteLine(configuracao);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"\nErro na configuração:\n{ex.Message}");
    return;
}

Reserva? reservaValida = null;

while (reservaValida == null)
{
    Console.WriteLine("\nCadastro da Reserva:");

    DateTime? dataReserva = null;
    while (dataReserva == null)
    {
        Console.Write("Informe a Data da Reserva (dd/MM/yyyy): ");
        var entrada = Console.ReadLine();
        if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", culturaBrasileira, DateTimeStyles.None, out var data))
        {
            dataReserva = data;
        }
        else
        {
            Console.WriteLine($"Data inválida: {entrada}. Tente novamente.");
        }
    }

    TimeSpan? horaReserva = null;
    while (horaReserva == null)
    {
        Console.Write("Informe a Hora da Reserva (HH:mm): ");
        var entrada = Console.ReadLine();
        if (TimeSpan.TryParseExact(entrada, "hh\\:mm", culturaBrasileira, out var hora))
        {
            horaReserva = hora;
        }
        else
        {
            Console.WriteLine($"Hora inválida: {entrada}. Tente novamente.");
        }
    }

    string descricao;
    do
    {
        Console.Write("Informe a Descrição da Reserva: ");
        descricao = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(descricao))
        {
            Console.WriteLine("A descrição não pode ser nula ou vazia. Tente novamente.");
        }
    } while (string.IsNullOrWhiteSpace(descricao));

    int capacidade;
    while (true)
    {
        Console.Write("Informe a Capacidade da Sala: ");
        var entrada = Console.ReadLine();
        if (int.TryParse(entrada, out capacidade) && capacidade > 0 && capacidade < 40)
        {
            break;
        }
        Console.WriteLine($"Capacidade inválida: {entrada}. Deve ser maior que 0 e menor que 40.");
    }

    try
    {
        reservaValida = new Reserva((DateTime)dataReserva, (TimeSpan)horaReserva, descricao, capacidade, configuracao);
        Console.WriteLine("\nReserva registrada com sucesso:");
        Console.WriteLine(reservaValida);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"\nErro ao registrar reserva:\n{ex.Message}");
        Console.WriteLine("Tente novamente.");
    }
}
