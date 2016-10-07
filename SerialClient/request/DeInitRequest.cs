namespace SerialClient
{
    public class DeInitRequest : SerialMessage
    {
        public DeInitRequest() : base(SerialProtocol.CmdCode.DeInitRequest)
        {

        }

        protected internal DeInitRequest(SerialMessage obj) : base(obj.GetCode(), obj.GetData())
        {

        }

        public static DeInitRequest Convert(SerialMessage msg)
        {
            return new DeInitRequest(msg);
        }
    }
}
