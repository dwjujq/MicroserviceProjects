using Order.Common.Utility;

namespace JCZY.CAP.Message
{
    public class MessageData<T>
    {
        public string Id { get; set; }

        public T MessageBody { get; set; }

        public DateTime CreatedTime { get; set; }

        public MessageData(T messageBody)
        {
            MessageBody = messageBody;
            CreatedTime = DateTime.Now;
            Id = IdGeneratorUtility.NextId().ToString();
        }
    }
}
