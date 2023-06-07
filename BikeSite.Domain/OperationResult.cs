namespace BikeSite.Domain;

public class OperationResult<T>
{
    public bool Success { get; set; }
    public string Error { get; set; }
    public T Value { get; set; }
}