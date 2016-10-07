using System;

namespace SerialClient
{
    public class ResultResponse : SerialMessage
    {
        public const int Size = SerialMessage.BaseLength + sizeof(float);
        
        protected ResultResponse()
        {
        }

        protected internal ResultResponse(SerialMessage obj) : base(obj.GetCode(), obj.GetData())
        {

        }

        public static ResultResponse Convert(SerialMessage msg)
        {
            return new ResultResponse(msg);
        }

        public float GetResult()
        {
            return BitConverter.ToSingle(_data, 0);
        }
                
    }
}
