# Movinghead Communication Module

```mermaid
graph LR
A[Computer] -- Serial --> B((COM module))
B -- DMX512 --> D[Movinghead]
```

This Module is for communication between Serial and DMX512. 
In the the project this is further used to communicate from a computer to an Movinghead. 

# Hardware 
Hardware used in this project:
* Arduino Uno (atmega 328p)
* [TinkerKit DMX Master Shield](https://nl.rs-online.com/web/p/processor-microcontroller-development-kits/7798870/) : (SN75176BD)

# Compiler:
*  [Arduino IDE](https://www.arduino.cc/) and
*  [Visual Studio ](https://visualstudio.microsoft.com/) with : [Visual micro extention](https://www.visualmicro.com/)


# How to Run / Compile:

1. Install compiler software here above. 
2. Add [DMX Library ](https://github.com/TinkerKit/DmxMaster)to arduino library folder.
 > [install location]Arduino\libraries
4. Open with visual studio or arduino IDE: compile + upload.


# How to use (Communication):

DMX has 2 variables to send: 
byte 

|                |ASCI                                   |
|----------------|---------------------------------------|
|protocol        | [BYTE channel] + " " + [BYTE value]   |
|EXAMPLE         | "12 255"                              |

the message will be closed with a new line char 
