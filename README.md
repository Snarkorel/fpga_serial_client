# fpga_serial_client
for labs

Serial protocol:

<Header byte (0xAB)> <Length byte (whole packet len)> <Command code byte> <Data bytes (if present)> ... <Footer byte (0xEF)>