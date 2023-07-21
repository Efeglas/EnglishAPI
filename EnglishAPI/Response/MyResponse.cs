namespace EnglishAPI.Response
{
    public class MyResponse
    {
        public List<string> Message { get; set; }
        public object[] Data { get; set; }
        public MyResponse(bool error, List<string> message, object[] data)
        {
            Message = message;
            Data = data;
        }

        public MyResponse(List<string> message)
        {
            Data = new object[0];
            Message = message;
        }

        public MyResponse(string message)
        {
            Data = new object[0];
            List<string> messages = new List<string>();
            messages.Add(message);
            Message = messages;
        }
    }
}
