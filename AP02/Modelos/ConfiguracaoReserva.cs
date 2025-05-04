namespace _AP02.Modelos;

public class ConfiguracaoReserva
{
    private DateTime _dataMinima = DateTime.Today.AddDays(1);
    private DateTime _dataMaxima = DateTime.Today.AddDays(30);
    private TimeSpan _horaMinima = new(8, 0, 0);
    private TimeSpan _horaMaxima = new(17, 30, 0);

    public DateTime DataMinima => _dataMinima;
    public DateTime DataMaxima => _dataMaxima;
    public TimeSpan HoraMinima => _horaMinima;
    public TimeSpan HoraMaxima => _horaMaxima;

    public List<string> ErrosDeValidacao = [];

    public bool ValidarConfiguracao(DateTime data, TimeSpan hora)
    {
        ErrosDeValidacao.Clear();

        if (data < _dataMinima)
            ErrosDeValidacao.Add($"Data {data:dd/MM/yyyy} deve ser no mínimo {_dataMinima:dd/MM/yyyy}");

        if (data > _dataMaxima)
            ErrosDeValidacao.Add($"Data {data:dd/MM/yyyy} deve ser no máximo {_dataMaxima:dd/MM/yyyy}");

        if (hora < _horaMinima)
            ErrosDeValidacao.Add($"Hora {hora} deve ser no mínimo {_horaMinima}");

        if (hora > _horaMaxima)
            ErrosDeValidacao.Add($"Hora {hora} deve ser no máximo {_horaMaxima}");

        return ErrosDeValidacao.Count == 0;
    }

    public override string ToString()
    {
        return $"Datas permitidas: {_dataMinima:dd/MM/yyyy} a {_dataMaxima:dd/MM/yyyy}\n" +
               $"Horários permitidos: {_horaMinima} a {_horaMaxima}";
    }
}
