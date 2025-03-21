namespace FridaysForks.AsyncApi.Models.V3;

public class OperationReply
{
    public ReferenceOrValue<OperationReplyAddress> Address { get; set; } // Operation Reply Address Object | Reference Object
    public Reference<Channel> Channel { get; set; } // Reference Object
    public List<Reference<Message>> Messages { get; set; }  // List of Reference Objects
}