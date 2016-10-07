using System;

namespace SerialClient
{
    public class SerialProtocol
    {
        public const byte Header = 0xAB;
        public const byte Footer = 0xEF;
        
        public enum CmdCode : byte
        {
            InitRequest = 0,
            DeInitRequest = 1,
            GetResultRequest = 2,
            ResultResponse = 3,
            InitResponse = 4,
            DeInitResponse = 5
        }
        
    }
}
