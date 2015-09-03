The Privacy Patch
==========
The Privacy Patch was specifically to bypass the restriction that uk isp's put on websites. With V3, the system has changed completely. The original idea was to use a "plugin" system to patch each host, but due to a recent discovery (a developer on the team was using his code to mine user information), we have trashed that idea, and started fresh. There are no more plugins, every host is managed by a single web page, controlled by Elite.SO. The user only has to click a single button. No Plugins downloaded.

Features
==========
Hosts Patcher

Changelog
==========
V3.0.32 Alpha

Official "Usable" Alpha Release almost here!

Replaced code for splash screen. Code was removed when testing for runtime error caused by avast.

Added process checks to program start. If The Elite Patch is already running, and the user tries to run it again, it will close the old process and start a new one.

Fixed a bug where program would not close from memory.

Added Encryption Algorithm to hide password from human eyes

Added "isTEP" COM call for use with page redirection. If the browser doesnt return "isTEP" as a string, then it is assumed that the user is accessing via a web browser, and disables redirection (if enabled)

Removed COM calls for custom online url.

Removed Offline Mode COM calls and setting

Removed “Beta” com calls and setting

Removed “Product Key” setting and com calls

Removed misc unused com calls

Added “AutoLogin” com calls to program. If set, then The Privacy Patch will remember your username/password.

Added “setPass” routine to com calls

Added “autoLogin” routine to com calls

Updated “logout” routine to remove password as well as username

Updated session to contain program settings

Fixed typo on Login button (was "Login me in", now "Login")

Updated hosts list to only display hosts with "visible" set to 1

Edit Account is now 100% Functional

Program Preferences is now 100% Functional

Added redirect to javascript. JS calls for the COM string "isTEP". if it's returned and redirection is enabled, then it redirects. Otherwise, it is assumed that the user is on an unknown browser for recovery

Added "Autologin" field to database

Removed "Offline Mode" field from database

emoved "IsAlpha" field from database

Added "Visible" field to hosts table


V3.0.31 Alpha


Completed update checks (both server side and client side)

Update function 80% Complete (both server side and client side)

Server Scripts 90% Complete

Added Server Scripts to Source Control

V3.0.3 Alpha

Offline patching system completed.

Started work on online portion of patcher - Progress - 70% complete

V3.0.2 Alpha

Sucessfully ran and tested new system. Currently Patches "ThePirateBay" to a known tpb proxy. 

V3.0.1 Alpha

Moved from Proof of Concept Stage to Functioning.

Currently patches The Pirate bay to a fake IP Address. Still in testing and unusable.

V3.0 Alpha

Currently in Proof Of Concept Stage. Code not complete.


Requirements
==========
.Net Framework V4 Client Profile

(Source) Visual Studio 2010 (or Visual C# Express 2010)

(Source) Html/PHP Editor

(Source) HTTP Server

(Source) Database Server (Capable of handling PDO)

Issues
==========

Update system not fully functional

Some random memory leaks
