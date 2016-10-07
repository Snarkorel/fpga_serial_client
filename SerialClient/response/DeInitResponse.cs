namespace SerialClient
{
    public class DeInitResponse : SerialMessage
    {
        public const int Size = SerialMessage.BaseLength;

        protected DeInitResponse() { }

        protected internal DeInitResponse(SerialMessage obj) : base(obj.GetCode(), obj.GetData()) { }

        public static DeInitResponse Convert(SerialMessage msg)
        {
            return new DeInitResponse(msg);
        }

        public bool IsOk()
        {
            return _code == SerialProtocol.CmdCode.DeInitResponse;
        }
    }
}
