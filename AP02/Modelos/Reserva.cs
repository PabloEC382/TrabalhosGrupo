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

    private bool Validar(ConfiguracaoReserva configuracao)
    {
        ErrosDeValidacao.Clear();

        if (Capacidade <= 0)
            ErrosDeValidacao.Add("Capacidade deve ser maior que zero.");
        if (Capacidade >= 40)
            ErrosDeValidacao.Add("Capacidade deve ser menor que 40 alunos.");

        if (string.IsNullOrWhiteSpace(Descricao))
            ErrosDeValidacao.Add("Descrição não pode ser vazia.");

        if (!configuracao.ValidarConfiguracao(_data, _hora))
            ErrosDeValidacao.AddRange(configuracao.ErrosDeValidacao);

        return ErrosDeValidacao.Count == 0;
    }

    public void RegistrarData(DateTime data)
    {
        _data = data;
    }

    public void RegistrarHora(TimeSpan hora)
    {
        _hora = hora;
    }

    public void RegistrarCapacidade(int capacidade)
    {
        Capacidade = capacidade;
    }

    public bool ValidarReserva(ConfiguracaoReserva configuracao)
    {
        return Validar(configuracao);
    }

    public override string ToString()
    {
        return $"Data: {_data:dd/MM/yyyy}\nHora: {_hora}\nDescrição: {Descricao}\nCapacidade: {Capacidade}";
    }
}
