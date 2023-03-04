using System.Runtime.Serialization;

namespace SingleDailyBugle.Models;

[Serializable]
public class EditorialException : Exception
{
    public EditorialException()
    {
    }

    public EditorialException(string? message) : base(message)
    {
    }

    public EditorialException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EditorialException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
