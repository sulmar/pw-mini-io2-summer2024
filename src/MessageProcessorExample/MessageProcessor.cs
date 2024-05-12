namespace MessageProcessorExample;

// Abstract Handler
public abstract class MessageHandler
{
    private MessageHandler next;

    public void SetNext(MessageHandler handler)
    {
        this.next = handler;
    }

    public virtual void Handle(Message message)
    {
        if (next != null)
            next.Handle(message);
    }
}

public class ValidatorMessageHandler : MessageHandler
{
    public override void Handle(Message message)
    {
        if (string.IsNullOrEmpty(message.From)
            || string.IsNullOrEmpty(message.Title)
            || string.IsNullOrEmpty(message.Body)
           )
            throw new ArgumentException();
        
        base.Handle(message);
    }
}

public class WhitelistMessageHandler : MessageHandler
{
    private List<string> whiteList = new List<string>();

    public WhitelistMessageHandler()
    {
        whiteList = new List<string>()
        {
            "a@domain.com",
            "b@domain.com"
        };
    }
    
    public override void Handle(Message message)
    {
        if (!whiteList.Contains(message.From))
            throw new InvalidOperationException();
        
        base.Handle(message);
    }
}

public class OrderMessageHandler : MessageHandler
{
    public override void Handle(Message message)
    {
        if (!message.Title.Contains("ORDER"))
            throw new FormatException();
        
        base.Handle(message);
    }
}

public class DbMessageHandler : MessageHandler
{
    private readonly IMessageRepository _repository;

    public DbMessageHandler(IMessageRepository repository)
    {
        _repository = repository;
    }
    public override void Handle(Message message)
    {
        _repository.Add(message);
     
        base.Handle(message);
    }
}

public interface IMessageRepository
{
    public void Add(Message message);
}

public class MessageProcessor
{
    private readonly MessageHandler _messageHandler;

    public MessageProcessor(MessageHandler messageHandler)
    {
        _messageHandler = messageHandler;
        
        // var validator = new ValidatorMessageHandler();
        // MessageHandler whitelist = new WhitelistMessageHandler();
        // var order = new OrderMessageHandler();
        // var db = new DbMessageHandler(null);
        //
        // validator.SetNext(whitelist);
        // whitelist.SetNext(order);
        // order.SetNext(db);

    }
    
    public void Process(Message message)
    {
       _messageHandler.Handle(message);        
    }
}

public class Message
{
    public string From { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public Message(string from, string title, string body)
    {
        From = from;
        Title = title;
        Body = body;
    }
}