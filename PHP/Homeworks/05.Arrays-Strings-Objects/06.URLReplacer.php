<?php
$input = '<p>Come and visit <a href="http://softuni.bg">the Software University</a> to master the art of programming. You can always check our <a href="www.softuni.bg/forum">forum</a> if you have any questions.</p>';
//Replace;
//$data = ['/<a href="/' => '[URL=', '/">/' => ']', '/<\/a>/' => '[/URL]'];
//foreach ($data as $pattern => $replace) {
//   $input = preg_replace($pattern, $replace, $input);
//}
//echo htmlentities($input);
//Regex;
$pattern = '/(?:<a.+?href=")(.+?)(?:">)(.+?)(?:<\/a>)/';
$result = ['[URL=', ']', '[/URL]'];
$input = preg_replace_callback($pattern, function ($match) {
    return '[URL=' . $match[1] . ']' . $match[2] . '[/URL]';
}, $input);
echo htmlentities($input);