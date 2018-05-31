SwitchHacksAllInOne
![SHAIO Logo](https://image.flaticon.com/icons/svg/921/921691.svg?sanitize=true)
_Icon made by Freepik from www.flaticon.com_

![SHAIO MainMenu](https://i.imgur.com/KwouYJ1.png)
![SHAIO SDCardTool](https://i.imgur.com/kAhqy0E.png)
![SHAIO PayloadTool](https://i.imgur.com/CoMO5un.png)


#What is this
This is a tool to make switch hacking easier.
It not groundbreaking, but it certainly isn't bad. This windows applications allows you to easily extract premade packages for the microsd card, which goes into the switch.
Also this tool has TegraRcmSmash by @rajkosto and the drivers included which allow you to launch payloads from your windows machine. Hopefully you find this program useful.

#How to use
Go to http://git.getraid.com/SHAIO/

#Download
You can download either an installer (recommended) or a portable version(extract everything, else it won't work) [here](https://github.com/getraid/SHAIO/releases/latest)

<hr>
<small><center>this part is for people who want to improve the code:</center></small>

#How to Compile
Copy the contents of SHAIO/InternalFiles into SHAIO/SwitchHacksAllInOne/bin/debug and SHAIO/SwitchHacksAllInOne/bin/release folders and compile as usual via VisualStudio. All in written in C#.

#How to make my own version of this
Make sure to change the version and releases in SHAIO/docs/version.xml, as this is used by the updater.
If you want to change the folder structure: Every path is defined in PathSettings.cs

To make your own installer, download [InstallForge](https://installforge.net/download/) and open SHAIO/InstallForge PackageFile/Shaio.ifp. There you can adjust the settings you want and export as an installer. Make sure to set the proper version as well.

<hr>
#Credits

Special thanks to the people who made this possible:
------------------------------------------------------------
The Switchbrew-Team - http://switchbrew.org
Michael/SciresM - https://twitter.com/SciresM
naehrwert - https://twitter.com/naehrwert
fail0verflow - https://twitter.com/fail0verflow
DavidBuchanan314 - https://github.com/DavidBuchanan314
ktemkin - https://www.ktemkin.com/ 
hedgeberg - https://twitter.com/hedgeberg 
rajkosto - https://github.com/rajkosto
... and many more that I forgot to mention (I'm sorry!) ⊙﹏⊙
------------------------------------------------
Other Stuff used:
mahapps.metro MIT- https://mahapps.com/
Autoupdater.NET MIT- https://github.com/ravibpatel/AutoUpdater.NET
