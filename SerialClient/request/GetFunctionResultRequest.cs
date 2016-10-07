using System;

namespace SerialClient
{
    public class GetFunctionResultRequest : SerialMessage
    {
        public GetFunctionResultRequest(float x, float y) : base(SerialProtocol.CmdCode.GetResultRequest)
        {
            var serializedX = BitConverter.GetBytes(x);
            var serializedY = BitConverter.GetBytes(y);
            var data = new byte[serializedX.Length + serializedY.Length];

            System.Buffer.BlockCopy(serializedX, 0, data, 0, serializedX.Length);
            System.Buffer.BlockCopy(serializedY, 0, data, serializedX.Length, serializedY.Length);

            _data = data;
            SetLength(data.Length);
        }

        protected internal GetFunctionResultRequest(SerialMessage obj) : base(obj.GetCode(), obj.GetData())
        {
            
        }

        public static GetFunctionResultRequest Convert(SerialMessage msg)
        {
            return new GetFunctionResultRequest(msg);
        }
    }
}
