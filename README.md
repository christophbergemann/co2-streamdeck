# CO2 sensor plugin for Elgato Stream Deck

## Overview

This tool can be used to display CO2 and temperature readings from a specific [low cost CO2 sensor][Co2 sensor] on the [Elgato Stream Deck][Stream Deck].

## Usage

On start, the button of this plugin will be plain green. 
On button press, it will connect to the sensor and display CO2 and temperature data.

## Installation

If you have the .NET SDK installed, just execute

```PowerShell
dotnet build
```

This should install it in your Stream Deck console.

## TODO

The action currently does not stop reading if it becomes hidden. 
This whole lifecycle management should be done better. 

## References
This is based on the [StreamDeckToolkit][Dotnet Template] .NET template for creating Stream Deck plugins.


<!-- References -->
[Stream Deck]: https://www.elgato.com/en/gaming/stream-deck "Elgato's Stream Deck landing page for the hardware, software, and SDK"
[Dotnet Template]: https://github.com/FritzAndFriends/StreamDeckToolkit
[Co2 sensor]: https://www.amazon.de/dp/B00TH3OW4Q