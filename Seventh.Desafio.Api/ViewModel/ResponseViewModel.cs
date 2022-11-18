using System.Text.Json;

namespace Seventh.Desafio.Api.ViewModel;

public class ResponseViewModel : ResponseViewModel<string?>
{
    public ResponseViewModel() : base("An unknown error has occurred") { }

    public ResponseViewModel(string message) : base(message) { }
}

public class ResponseViewModel<T>
{
    public ResponseViewModel() { }

    public ResponseViewModel(T data, string? message = null)
    {
        Succeeded = true;
        Message = message ?? string.Empty;
        Data = data;
    }

    public ResponseViewModel(string message)
    {
        Succeeded = false;
        Message = message;
    }

    public virtual bool Succeeded { get; set; } = false;

    public virtual string? Message { get; set; }

    public virtual Dictionary<string, string>? Errors { get; set; }

    public virtual T? Data { get; set; }

    public string GetString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions()
        {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        });
    }
}