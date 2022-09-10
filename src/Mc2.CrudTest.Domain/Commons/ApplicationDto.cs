namespace Mc2.CrudTest.Domain.Commons;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Enums;


public abstract class ApplicationDto
{
    protected ApplicationDto(Status status, string message = null)
    {
        Status = status;
        Message = message;
    }

    [JsonIgnore]
    [IgnoreDataMember]
    public Status Status { get; }

    [JsonIgnore]
    [IgnoreDataMember]
    public string Message { get; }
}