using System;

namespace SerialClient
{
    public class SerialMessage
    {
        protected const int BaseLength = 4;

        private byte _header;
        protected byte _length;
        protected SerialClient.SerialProtocol.CmdCode _code;
        protected byte[] _data;
        private byte _footer;

        protected SerialMessage()
        {
        }

        public SerialMessage(SerialClient.SerialProtocol.CmdCode msgCode)
        {
            SetFrame();
            _code = msgCode;
            _length = BaseLength;
        }

        public SerialMessage(SerialClient.SerialProtocol.CmdCode msgCode, byte[] data)
        {
            SetFrame();
            _code = msgCode;
            SetLength(data.Length);
            _data = data;
        }

        protected void SetLength(int dataLength)
        {
            _length = (byte)(BaseLength + dataLength);
        }

        protected void SetFrame()
        {
            _header = SerialClient.SerialProtocol.Header;
            _footer = SerialClient.SerialProtocol.Footer;
        }

        public SerialClient.SerialProtocol.CmdCode GetCode()
        {
            return _code;
        }

        public byte GetLength()
        {
            return _length;
        }

        public byte[] GetData()
        {
            return _data;
        }

        public byte[] Serialize()
        {
            var dataArray = new byte[_length];
            dataArray[0] = _header;
            dataArray[1] = _length;
            dataArray[2] = (byte)_code;
            if (_data != null)
            {
                if (_data.Length != 0)
                {
                    System.Buffer.BlockCopy(_data, 0, dataArray, 3, _data.Length);
                }
            }
            dataArray[_length - 1] = _footer;

            return dataArray;
        }

        //public Type ToType()
        //{
        //    switch (_code)
        //    {
        //        //TODO: add all unimplemented types
        //        case SerialClient.SerialProtocol.CmdCode.Init:
        //            throw new NotImplementedException();
        //        case SerialClient.SerialProtocol.CmdCode.DeInit:
        //            throw new NotImplementedException();
        //        case SerialClient.SerialProtocol.CmdCode.GetResultRequest:
        //            return typeof(GetFunctionResultRequest);
        //        case SerialClient.SerialProtocol.CmdCode.ResultResponse:
        //            throw new NotImplementedException();
        //        default:
        //            return typeof(SerialMessage);
        //    }
        //}

        public static SerialMessage Deserialize(byte[] data)
        {
            if (data[0] != SerialClient.SerialProtocol.Header || data[data.Length - 1] != SerialClient.SerialProtocol.Footer)
                throw new Exception("Invalid packet boundaries!");
            if (data[1] != data.Length)
                throw new Exception("Invalid packet size!");

            var payloadSize = data.Length - BaseLength;
            var payload = new byte[payloadSize];
            System.Buffer.BlockCopy(data, 3, payload, 0, payloadSize);
            var obj = new SerialMessage((SerialClient.SerialProtocol.CmdCode)data[2], payload);

            return obj;
        }
    }
}
