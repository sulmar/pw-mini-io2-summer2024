namespace MessageProcessorExample;

public interface IMessageRepository
{
    public void Add(Message message);
}

public class MessageProcessor
{
    private List<string> whiteList = new List<string>();

    private readonly IMessageRepository _repository;

    public MessageProcessor(IMessageRepository repository)
    {
        _repository = repository;
        
        whiteList = new List<string>()
        {
            "a@domain.com",
            "b@domain.com"
        };
    }
    public void Process(Message message)
    {
        if (string.IsNullOrEmpty(message.From)
            || string.IsNullOrEmpty(message.Title)
            || string.IsNullOrEmpty(message.Body)
            )
            throw new ArgumentException();

        if (!whiteList.Contains(message.From))
            throw new InvalidOperationException();

        if (!message.Title.Contains("ORDER"))
            throw new FormatException();
        
        _repository.Add(message);
        
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