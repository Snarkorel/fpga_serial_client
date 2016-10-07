namespace SerialClient
{
    public class InitResponse : SerialMessage
    {
        public const int Size = SerialMessage.BaseLength;

        protected InitResponse() { }

        protected internal InitResponse(SerialMessage obj) : base(obj.GetCode(), obj.GetData()) { }

        public static InitResponse Convert(SerialMessage msg)
        {
            return new InitResponse(msg);
        }

        public bool IsOk()
        {
            return _code == SerialProtocol.CmdCode.InitResponse;
        }
    }
}
