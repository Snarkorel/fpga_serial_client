struct serial_message {
	uint8_t header;
	uint8_t length;
	uint8_t cmd;
	uint8_t *data;
	uint8_t footer;
} SerialMessage;