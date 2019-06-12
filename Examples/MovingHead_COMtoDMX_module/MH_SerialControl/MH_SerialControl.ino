// Visual Micro is in vMicro>General>Tutorial Mode
// 
/*
    Name:       MH_SerialControl.ino
    Created:	16-2-2019 02:10:43
    Author:     HPZB-RV\ryanv
*/

String inputString = "";         // a String to hold incoming data
bool stringComplete = false;  // whether the string is complete

// The setup() function runs once each time the micro-controller starts
#include <DmxMaster.h>
void setup()
{
	DmxMaster.usePin(3);
	DmxMaster.maxChannel(11);
	delay(5);
	Serial.begin(9600);
	inputString.reserve(20);

}

// Add the main program code into the continuous loop() function
void loop()
{
	if (stringComplete)
	{
		String SChannel = inputString.substring(0, inputString.indexOf(' '));
		String SData = inputString.substring(inputString.indexOf(' ')+1, inputString.end());

		int Channel = SChannel.toInt();
		int Data = SData.toInt();

		DmxMaster.write(Channel, Data);
		inputString = "";
		stringComplete = false;
	}



}

void serialEvent() {
	while (Serial.available()) {
		// get the new byte:
		char inChar = (char)Serial.read();
		// add it to the inputString:
		inputString += inChar;
		// if the incoming character is a newline, set a flag so the main loop can
		// do something about it:
		if (inChar == '\n') {
			stringComplete = true;
		}
	}
}