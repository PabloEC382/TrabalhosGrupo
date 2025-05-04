
namespace _AP02.Modelos;

public class ConfiguracaoReserva
{
    private DateTime _dataMinima;
    private DateTime _dataMaxima;
    private TimeSpan _horaMinima;
    private TimeSpan _horaMaxima;

    public DateTime DataMinima => _dataMinima;
    public DateTime DataMaxima => _dataMaxima;
    public TimeSpan HoraMinima => _horaMinima;
    public TimeSpan HoraMaxima => _horaMaxima;

    public List<string> ErrosDeValidacao = [];

    public ConfiguracaoReserva(DateTime dataMinima, DateTime dataMaxima, TimeSpan horaMinima, TimeSpan horaMaxima)
    {
        var erros = new List<string>();

        if (dataMinima >= dataMaxima)
            erros.Add($"A Data Mínima ({dataMinima:dd/MM/yyyy}) deve ser menor que a Data Máxima ({dataMaxima:dd/MM/yyyy}).");

        if (horaMinima >= horaMaxima)
            erros.Add($"A Hora Mínima ({horaMinima}) deve ser menor que a Hora Máxima ({horaMaxima}).");

        if (erros.Count > 0)
            throw new ArgumentException(string.Join("\n", erros));

        _dataMinima = dataMinima;
        _dataMaxima = dataMaxima;
        _horaMinima = horaMinima;
        _horaMaxima = horaMaxima;
    }

    public bool ValidarConfiguracao(DateTime data, TimeSpan hora)
    {
        var erros = new List<string>();

        if (data < _dataMinima)
            erros.Add($"Data {data:dd/MM/yyyy} deve ser no mínimo {_dataMinima:dd/MM/yyyy}.");

        if (data > _dataMaxima)
            erros.Add($"Data {data:dd/MM/yyyy} deve ser no máximo {_dataMaxima:dd/MM/yyyy}.");

        if (hora < _horaMinima)
            erros.Add($"Hora {hora} deve ser no mínimo {_horaMinima}.");

        if (hora > _horaMaxima)
            erros.Add($"Hora {hora} deve ser no máximo {_horaMaxima}.");

        return erros.Count == 0;
    }

    public override string ToString()
    {
        return $"Datas permitidas: {_dataMinima:dd/MM/yyyy} a {_dataMaxima:dd/MM/yyyy}\n" +
               $"Horários permitidos: {_horaMinima} a {_horaMaxima}";
    }
}
