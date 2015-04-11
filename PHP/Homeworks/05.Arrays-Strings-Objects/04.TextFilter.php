<?php
$input = 'It is not Linux, it is GNU/Linux. Linux is merely the kernel, while GNU adds the functionality. Therefore we owe it to them by calling the OS GNU/Linux!
Sincerely, a Windows client';
$banlist = ['Linux', 'Windows'];
$replaceList = ['*****', '******'];
echo str_replace($banlist, $replaceList, $input);