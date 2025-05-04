namespace _AP02.Modelos;

public class Reserva
{
    private DateTime _data;
    private TimeSpan _hora;

    public DateTime Data => _data;
    public TimeSpan Hora => _hora;
    public string Descricao { get; set; }
    public int Capacidade { get; set; }

    public List<string> ErrosDeValidacao = [];

    public Reserva(DateTime data, TimeSpan hora, string descricao, int capacidade, ConfiguracaoReserva configuracao)
    {
        _data = data;
        _hora = hora;
        Descricao = descricao;
        Capacidade = capacidade;

        if (!Validar(configuracao))
        {
            throw new ArgumentException(string.Join("\n", ErrosDeValidacao));
        }
    }

    public bool Validar(ConfiguracaoReserva config)
    {
        if (_data < config.DataMinima)
            ErrosDeValidacao.Add($"A data {_data:dd/MM/yyyy} deve ser no mínimo {config.DataMinima:dd/MM/yyyy}");

        if (_data > config.DataMaxima)
            ErrosDeValidacao.Add($"A data {_data:dd/MM/yyyy} deve ser no máximo {config.DataMaxima:dd/MM/yyyy}");

        if (_hora < config.HoraMinima)
            ErrosDeValidacao.Add($"A hora {_hora} deve ser no mínimo {config.HoraMinima}");

        if (_hora > config.HoraMaxima)
            ErrosDeValidacao.Add($"A hora {_hora} deve ser no máximo {config.HoraMaxima}");

        if (string.IsNullOrWhiteSpace(Descricao))
            ErrosDeValidacao.Add("Descrição da sala não pode ser vazia.");

        if (Capacidade <= 0)
            ErrosDeValidacao.Add("Capacidade deve ser maior que zero.");

        return ErrosDeValidacao.Count == 0;
    }

    public override string ToString()
    {
        return $"Data: {_data:dd/MM/yyyy}\nHora: {_hora}\nDescrição: {Descricao}\nCapacidade: {Capacidade}";
    }
}
