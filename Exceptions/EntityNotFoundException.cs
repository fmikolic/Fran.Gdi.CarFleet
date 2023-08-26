using System.Text.Json;

namespace Fran.Gdi.CarFleet.Exceptions;

public class EntityNotFoundException : Exception
{
    public object Query { get; }

    public EntityNotFoundException(object query)
    : base($"Entity not found! Query: {GetExceptionMessage(query)}.")
    {
    }

    private static string GetExceptionMessage(object query)
    {
        if (query is string queryString)
        {
            return queryString;
        }

        return JsonSerializer.Serialize(query);
    }
}
