namespace SerialClient
{
    public class InitRequest : SerialMessage
    {
        public InitRequest() : base(SerialProtocol.CmdCode.InitRequest)
        {

        }

        protected internal InitRequest(SerialMessage obj) : base(obj.GetCode(), obj.GetData())
        {

        }

        public static InitRequest Convert(SerialMessage msg)
        {
            return new InitRequest(msg);
        }
    }
}
