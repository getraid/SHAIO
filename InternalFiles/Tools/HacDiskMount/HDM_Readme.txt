HacDiskMount 1.0.4-4 (10.06.2018)

Allows to open Switch eMMC RawNand dumps (and physical devices) and lets you perform operations on the individual partitions within, 
such as dump/restore from file, or mount them as a drive letter in Windows (with transparent crypto performed provided you have your BIS keys).

The program must be run as administrator in order to Install/Uninstall the mounting point virtual disk driver and to open non-removable physical disk devices
(which shouldn't be needed, as all card readers/mass storage gadgets appear as removable disks), however after that all other operations can be done without admin rights.

The "Passthrough zeroes" option is experimental, and will make the dumps/files read from the mounted disk more compressible (as unallocated sectors will become zeroes),
however as some files are sparse (such as savedata partition images), their hashes will differ depending on if this option is turned on/off (but it shouldn't matter).

For updates check https://switchtools.sshnuke.net