namespace EventsBookingBackend.Application.Common.Exceptions;

public class AppValidationException(string message) : Exception(message)
{
}