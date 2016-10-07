using System;
using System.Windows.Forms;

namespace SerialClient
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Test();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void Test()
        {
            //Get Result
            
            var test = new GetFunctionResultRequest(0.15F, 12.0F);
            var serializedTest = test.Serialize();
            var deserializedTest = GetFunctionResultRequest.Convert(SerialMessage.Deserialize(serializedTest));

            var testBytes = new byte[] { 0xAB, 0x08, 0x03, 0x4F, 0x00, 0x00, 0x00, 0xEF };
            var deserializedFloat = ResultResponse.Convert(SerialMessage.Deserialize(testBytes));
            var testFloat = deserializedFloat.GetResult();

            //Init

            var test1 = new InitRequest();
            serializedTest = test1.Serialize();
            var deserializedTest1 = InitRequest.Convert(SerialMessage.Deserialize(serializedTest));

            testBytes = new byte[] {0xAB, 0x04, 0x04, 0xEF};
            var deserialized1 = InitResponse.Convert(SerialMessage.Deserialize(testBytes));
            var testCode = deserialized1.GetCode();
            if (!deserialized1.IsOk())
                throw new Exception("Test failed!");

            //DeInit

            var test2 = new DeInitRequest();
            serializedTest = test2.Serialize();
            var deserializedTest2 = DeInitRequest.Convert(SerialMessage.Deserialize(serializedTest));

            testBytes = new byte[] { 0xAB, 0x04, 0x05, 0xEF };
            var deserialized2 = DeInitResponse.Convert(SerialMessage.Deserialize(testBytes));
            testCode = deserialized2.GetCode();
            if (!deserialized2.IsOk())
                throw new Exception("Test failed!");
        }
    }
}
