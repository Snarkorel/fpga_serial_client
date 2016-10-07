using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace SerialClient
{
    public partial class Form1 : Form
    {
        private string[] _portnames;

        private SerialPort _port;

        private enum Direction
        {
            In = 0,
            Out = 1
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void UpdatePorts()
        {
            _portnames = SerialPort.GetPortNames();
            //TODO: thread-safe update
            portsBox.Items.Clear();
            portsBox.Items.AddRange(_portnames);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdatePorts();

        }

        private void PrintArray(Direction dir, byte[] array)
        {
            logTextBox.AppendText(dir.ToString() + ": ");
            foreach (var b in array)
            {
                logTextBox.AppendText(string.Format("{0:X2} ", b));
            }
            logTextBox.AppendText("\r\n");
        }

        private void CheckDataSent()
        {
            if (_port.BytesToWrite == 0)
            {
                logTextBox.AppendText("Successfuly sent!\r\n");
            }
            else
            {
                logTextBox.AppendText("Can't send some data!\r\n");
                //TODO
            }
        }

        private void openBox_CheckedChanged(object sender, EventArgs e)
        {
            if (baudRatesBox.Text == "" || portsBox.Text == "")
            {
                logTextBox.AppendText("Invalid Port name or baudrate parameter!\r\n");
                openBox.Checked = false;
                return;
            }

            if (openBox.Checked)
            {
                var baudrate = Convert.ToInt32(baudRatesBox.Text);
                _port = new SerialPort(portsBox.Text, baudrate);
                logTextBox.AppendText("Opening port " + portsBox.Text + " on speed " + baudrate + " baud/s...\r\n");
                if (_port.IsOpen)
                {
                    logTextBox.AppendText("Port already is open!\r\n");
                    return;
                }

                _port.ReadTimeout = 2000;
                _port.WriteTimeout = 2000;

                try
                {
                    _port.Open();
                }
                catch (Exception)
                {
                    logTextBox.AppendText("Error acquired while trying to open COM-port!\r\n");
                    return;
                }

                logTextBox.AppendText("Success!\r\n");
            }
            else
            {
                logTextBox.AppendText("Closing port " + _port.PortName + "...\r\n");
                if (!_port.IsOpen)
                {
                    logTextBox.AppendText("Port already is closed!\r\n");
                    return;
                }

                try
                {
                    _port.Close();
                }
                catch (Exception)
                {
                    logTextBox.AppendText("Error acquired while trying to open COM-port!\r\n");
                    return;
                }

                logTextBox.AppendText("Success!\r\n");
            }
        }

        private void initButton_Click(object sender, EventArgs e)
        {
            if (!CheckPort())
                return;
            
            logTextBox.AppendText("Sending Init message...\r\n");

            var responseBytes = new byte[InitResponse.Size];
            var init = new InitRequest().Serialize();
            _port.Write(init, 0, init.Length);

            PrintArray(Direction.Out, init);
            CheckDataSent();

            try
            {
                _port.Read(responseBytes, 0, InitResponse.Size);
            }
            catch (TimeoutException)
            {
                logTextBox.AppendText("FPGA doesn't respond!\r\n");
                return;
            }

            PrintArray(Direction.In, responseBytes);
            var response = InitResponse.Convert(SerialMessage.Deserialize(responseBytes));
            if (response.IsOk())
            {
                logTextBox.AppendText("FPGA Initialized!");
                MessageBox.Show("OK", "FPGA Initialization");
            }
        }

        private void deInitButton_Click(object sender, EventArgs e)
        {
            if (!CheckPort())
                return;
            
            logTextBox.AppendText("Sending DeInit message...\r\n");

            var responseBytes = new byte[DeInitResponse.Size];
            var deinit = new DeInitRequest().Serialize();
            _port.Write(deinit, 0, deinit.Length);

            PrintArray(Direction.Out, deinit);
            CheckDataSent();

            try
            {
                _port.Read(responseBytes, 0, DeInitResponse.Size);
            }
            catch (TimeoutException)
            {
                logTextBox.AppendText("FPGA doesn't respond!\r\n");
                return;
            }

            PrintArray(Direction.In, responseBytes);
            var response = DeInitResponse.Convert(SerialMessage.Deserialize(responseBytes));
            if (response.IsOk())
            {
                logTextBox.AppendText("FPGA Deinitialized!");
                MessageBox.Show("OK", "FPGA DeInitialization");
            }
                

        }

        private float CheckIsDouble(string str)
        {
            float result;
            try
            {
                result = (float)Convert.ToDouble(str);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Invalid value!", "X and Y arguments", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0F;
            }

            return result;
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (!CheckPort())
                return;
            
            var responseBytes = new byte[ResultResponse.Size];

            resultTextBox.Text = "";
            logTextBox.AppendText("Sending Calculate message...\r\n");

            float x = CheckIsDouble(xTextBox.Text);
            float y = CheckIsDouble(yTextBox.Text);
            var calculate = new GetFunctionResultRequest(x, y).Serialize();

            _port.Write(calculate, 0, calculate.Length);
            PrintArray(Direction.Out, calculate);
            CheckDataSent();

            try 
            {
                _port.Read(responseBytes, 0, ResultResponse.Size);
            }
            catch (TimeoutException)
            {
                logTextBox.AppendText("FPGA doesn't respond!\r\n");
                return;
            }
            
            PrintArray(Direction.In, responseBytes);
            var response = ResultResponse.Convert(SerialMessage.Deserialize(responseBytes));

            var result = response.GetResult();
            resultTextBox.Text = result.ToString();

            MessageBox.Show("Result: " + result.ToString(), "Computation result");
        }

        private bool IsPortReady()
        {
            if (_port == null)
                return false;

            if (!_port.IsOpen)
                return false;

            return true;
        }

        private bool CheckPort()
        {
            if (!IsPortReady())
            {
                logTextBox.AppendText("Port is closed or not configured!");
                MessageBox.Show("Port is closed or not configured!");
                return false;
            }
            return true;
        }
    }
}
