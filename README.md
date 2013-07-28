Introduction
============

This was an application written as part of an interview. The problem presented on the day was to create an application that would read from BBC Radio feeds (such as http://www.bbc.co.uk/radio2/programmes/schedules) and extract information about the currently broadcasting show, with the hypothetical usage that this information would then be presented on the screen of a DAB radio, for example. The test was timeboxed to three hours, and I have left the state as it was at the end of that time. I upload it here to give an example of my coding style.


Detail
======

There is a console app that takes two parameters: first is the HTML URL of the feed (e.g. http://www.bbc.co.uk/radio2/programmes/schedules), second is the location of the file to output to
It will populate a StationSchedule class using the feed, and then use BroadcastWatcher to monitor the current broadcast and output information when that changes
Please start by looking at Program.cs to get an idea of how the program builds up its information and then spins up BroadcastWatcher, which just loops every <timeout> seconds to check the current broadcast.

At time of finishing, I was looking at adding more tests around BroadcastWatcher to verify functionality. 
The program will output current broadcast information to the console and to a file (via different listeners), but this obviously needs more unit testing around those listeners and the BroadcastWatcher.

C# classes that equate to the JSON objects from the BBC feed were generated using http://json2csharp.com/ - I didn't spend much time tidying them so those are not representative of the naming conventions I would traditionally use.