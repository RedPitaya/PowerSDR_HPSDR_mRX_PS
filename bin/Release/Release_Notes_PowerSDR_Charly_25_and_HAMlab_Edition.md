## Release notes of PowerSDR Charly 25 / HAMlab Edition:

#### commit 1391b271bfeb09c699a0d44d6d7da7e1c62596af
Date:   Tue Apr 25 00:47:40 2017 +0200

- Added the following skins for the PowerSDR appearance: K2GX_Brushed_Black, K2GX_World_Time, Red Pitaya and changed the default skin to Red Pitaya.
- Added the allowed transmit frequencies of the 2200m, 630m and 60m band for the region setting Europe.
- Changed the minimum and maximum frequencies for the two tone test from +/- 20.000Hz to +/- 200.000Hz.


#### commit e61c05b78ff0571be0fb3c2d117a072c5160cef8
Date:   Thu Apr 20 03:13:05 2017 +0200

- Added test routines for the TX LPF and the RX attenuators and preamps of the Charly 25 and HAMlab hardware


#### commit 54476aebda13df2be7f86f7aa6f1ac2ac6374cbb
Date:   Fri Apr 7 03:14:38 2017 +0200

- Switching the antenna port turns off any transmit state now to avoid accidental transmitting.
- Avoided switching of Alex board signals when powering on if a Charly 25 or a HAMlab device is active.


#### commit 680c7e1dc66faa232ebb307ad4009e93dcac458c
Date:   Thu Apr 6 02:17:37 2017 +0200

- Added support for antenna 1 and 2 switching on the Charly 25AB board.
- Fixed bug to interrupt tune signal when tuning out of band.
- Corrected string output for current region on out of band error messages.
- Corrected band borders for 60 meter band of region Europe.


#### commit 5bbac841e2af9e46ae3c4f20b9778da2f903a5e0
Date:   Tue Mar 28 00:14:35 2017 +0200

- Corrected Center button functionality on Console which didn't work correctly for Charly 25 and HAMlab hardware.
- Corrected realtime signal strength display under RX2 Squelch button which wasn't working due to missing event call.
- Text on RX2 Squelch is now drawn in bold as on all other buttons.


#### commit 0ce68135df648101a7adb120114b67b61a2b453c
Date:   Mon Mar 27 22:42:05 2017 +0200

- Added functionality to store and recall the offset values of the RX level calibration for RX1 and RX2 band by band.


#### commit f8d58b57a2e379a2f63ba448e6332a308543ee7c
Date:   Mon Mar 20 00:02:55 2017 +0100

- Simplified the calibration routine for RX1 and RX2.


#### commit 32c0b40e2a83045e6c675a89295f845ca5b481dd
Date:   Sun Mar 19 17:04:03 2017 +0100

- Bug fixed: Calling the region update routine at this point is only allowed when the setup wizard ran before, otherwise the saved band and filter setting get lost!


#### commit f41119a8217446fdf27b51d953730a14473f89cd
Date:   Sun Mar 12 01:12:12 2017 +0100

- Corrected handling of the MOX button during CW keying.


#### commit 15680ad7fa52ec1c6fda83dc778291d8f634fb46
Date:   Sat Feb 18 18:54:34 2017 +0100

- Changed the behavior of the CW modes when tuning.
- Moving the power slider while tuning doesn't interrupt the output power any more.


#### commit 141daefe4584117e1abc9b0f9aa90335c7a26f8c
Date:   Thu Feb 9 01:45:40 2017 +0100

- Added a form to select the Charly 25 / HAMlab device which should be started up if more than one device is found on the network after Power ON was pressed.
- Added code to avoid error messages when the device selection is canceled.


#### commit 0d3eeaed21afee7f05b1aa9fbd034233dc1fb336
Date:   Wed Feb 1 02:11:30 2017 +0100

- Changed the search string for the MS Visual C++ Redistributable Package in the setup routine due to issues on Windows 64bit systems.


#### commit c2c7dc7ce79643129ade31a8c8e3895205b9022a
Date:   Wed Jan 25 02:16:24 2017 +0100

- Added code to switch off the PureSignal autoattenuate functionality on Charly 25LC and HAMlab devices.
- Added Charly 25 and HAMlab specific RX2 level calibration routines.
- Added Charly 25 and HAMlab specific CW support.
- Added code to take over the currently selected IP address in the Setup menu even if the "Select IP" button was not pressed.


#### commit b3289b62ac2448e353916c97c18a7ec0cd94019d
Date:   Tue Jan 17 00:14:55 2017 +0100
 
- Changed default setting of the option "Allow PTT to override/bypass VAC for Phone" for VAC 1 to unchecked for Charly 25LC and HAMlab devices.
- Buffer Latency (ms) option: Added missing assignment when "Manual" is checked on all three Audio tabs.
- Always call the function DB.UpdateRegion(console.CurrentRegion) even during Console initialization to take over the chosen country from the setup wizard.
- The panel for the RX2 level calibration is now visible for Charly 25LC and HAMlab devices (preparation for the new RX2 level calibration function).
- Improved the handling of the RedPitaya SDR application remote stopping routine.


#### commit aa07167c3c5ca2c1ab43d95ea08b3d25c8c13463
Date:   Fri Jan 6 02:02:50 2017 +0100

- Changes for correct RX2 handling on Charly 25LC and HAMlab hardware


#### commit f977b4b26040bc230e603b0dde9cc96394d131e4
Date:   Mon Jan 2 02:22:02 2017 +0100
  
- Corrected band plan limits for Japan
- Changed handling of the 2200m and 630m band plans
- Added 2200m and 630m band plans of IARU Region 1
- Added debug output for band plan validation errors
- Added newer Microsoft Visual C++ 2015 Redistributable (x86) version: 14.0.24215


#### commit 630f46efc96fad5b44742ab6b89cb34c2bf18c8f
Date:   Mon Dec 26 21:37:31 2016 +0100

- Extended the application data path variable by " Charly25 HAMlab" to avoid incompatibility with other PowerSDR installations on the same computer.


#### commit 5aac8cb5b7cfde974f3f08b1b5b459e8b435aedf
Date:   Wed Dec 21 03:55:37 2016 +0100

- Changed the default gain values for the PA settings.


#### commit fd9db2de4e4eff809dc73a44b41b55ec3338584d
Date:   Wed Dec 21 01:35:55 2016 +0100

- Implemented MAC address scan for the automatically startup of the SDR application on the RedPitaya if "Reuse Last IP Address" and "Use Static IP Address" options are not set.
- Added exception handling for the network handling parts of the automatically startup routines.


#### commit c1d7f8feda171910e11cd39fdb55f61b187fbebd
Date:   Sat Dec 17 18:30:30 2016 +0100

- Implemented automatically startup of the SDR application on the RedPitaya if "Reuse Last IP Address" or "Use Static IP Address" option is set.
- Initial value for the power by band changed from 50 to the maximum of 100 to avoid confusion for the user.


#### commit 089ff951885f52ebd94fba6fab16b71fd8f6e744
Date:   Fri Dec 16 01:52:15 2016 +0100

- Added code to turn off the tune button when band or mode are changed.


#### commit 3ef8d63d708c0a6b059316d1f5662b4587e23645
Date:   Mon Nov 28 00:54:35 2016 +0100

- Modified the installer routine to work correctly on Windows 64bit systems.


#### commit 3f674f804b59a9a098d6c60862377ff30335c4a3
Date:   Tue Nov 15 00:26:18 2016 +0100

- Changed versions string in the title bar
- Attenuator / Preamp label is now lettered correctly


#### commit c374b50754eb1caa7a841b6f86326a2cbde81948
Date:   Sat Nov 12 13:27:47 2016 +0100

- Commit hash implemented for Git to show it in the title bar.


#### commit f4aad34271a8187a589a3b060b4b6fae451e4806
Date:   Wed Nov 2 22:19:20 2016 +0100

- Initial commit
