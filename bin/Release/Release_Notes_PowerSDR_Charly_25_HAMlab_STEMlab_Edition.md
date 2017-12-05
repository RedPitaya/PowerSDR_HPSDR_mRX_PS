## Release notes of PowerSDR Charly 25 / HAMlab / STEMlab Edition:


#### commit 7989e517ffbff2ea6b1afb1cd64f52096c38d264
Date:   Thu Jul 20 16:34:10 2017 +0200

- Commit of the new master build for customer release with the new HAMlab 160-6.
    

#### commit 32b1f34e202a1cf9f887a5cfe9a6e96c772831ae
Date:   Tue Jul 11 01:54:44 2017 +0200

- Implemented improvements in the TX Frequency Sweep Test functionality.


#### commit 038b076a04e329e6be8031eba301e9c0de328c38
Date:   Mon Jul 10 02:21:42 2017 +0200

- Added SWR measuring routine and SWR view to the C25 TX Frequency Sweep Test.
- Added frequency border checks to the C25 TX Frequency Sweep Test.
    

#### commit 80bf55e6fb15a7de6d0a0093199b42e2f1c79644
Date:   Fri Jul 7 02:17:58 2017 +0200

- Improved the PowerSDR software update functionality.


#### commit 1405c725238410b816b37a9d52ac331c6c8dc9e5
Date:   Fri Jul 7 00:05:50 2017 +0200

- Merged in the features of TAPR/OpenHPSDR-PowerSDR version 3.4.2 manually.
    

#### commit 72538247258f6719a3317497819f72fef8796144
Date:   Sat Jul 1 15:33:33 2017 +0200

- Extended the remote start/stop routines and the version detection routine for the SDR applications on the Red Pitaya devices. They can now handle: sdr_transceiver_hpsdr, hamlab_sdr_transceiver_hpsdr and stemlab_sdr_transceiver_hpsdr.
- Improved the VFO A frequency up/down by tune step routines to differentiate Behringer MIDI controllers from all others.
 

#### commit f609fba0daecbdc9ebbc9e1ec6ace267fbf4c4f8
Date:   Fri Jun 30 03:59:58 2017 +0200

- Added new functionality "TX Frequency Sweep Test" at the "C25 Tests" setup page.


#### commit c3794bc7418ff61cd1d3f8cf60626b3eee6c253f
Date:   Thu Jun 29 17:01:45 2017 +0200

- Added functionality to the MIDI interface: Move VFO A Up/Down by Tune Step via buttons.


#### commit c05c91b23f22abb59f3648d5a8c9540badc2bed8
Date:   Mon Jun 26 01:46:06 2017 +0200

- Added support for the Red Pitaya SDR app version detection by PowerSDR.   


#### commit b7956861a147864744654e7547b2aad389eea11a
Date:   Sun Jun 25 00:37:57 2017 +0200

- Upgraded the Charly 25 / HAMlab / STEMlab remote start up functionality to work with the new SDR app: "stemlab_sdr_transceiver_hpsdr".
- Added a functionality which does a ping before trying to connect to the Red Pitaya device which should be started up remotely.


#### commit 1bd85ad94a4f8b07e985eada4122a591ecfdb5fc
Date:   Sat Jun 24 02:15:40 2017 +0200

- Added PowerSDR software update functionality via the Red Pitaya download server.
- Added support for the forward- and backward-power and swr sensing head.
   

#### commit 5a08e677d9fe5fe9e8ecce5d5d5ee91bc7840a80
Date:   Fri Jun 16 01:43:35 2017 +0200
   
- Implemented a control mechanism to enable or disable the Antenna 1/2 button on the console (Charly 25LC board doesn't have a second antenna port).   


#### commit 621c2f360c09da683d1b873a079aade0858eee0f
Date:   Thu Jun 15 03:30:30 2017 +0200

- Added support for Charly 25, HAMlab and STEMlab hardware detection.


#### commit c18de29fa2550522cb2f09b56063aac551acb58b
Date:   Tue Jun 6 02:43:46 2017 +0200

- Merged in the features from OpenHPSDR-PowerSDR version 3.4.1.
    

#### commit c482f6651615fb4a02fcee5d21aaecac0537f509
Date:   Wed May 24 01:39:20 2017 +0200

- Changed the path variable for the settings from FlexRadio Systems to Red Pitaya to avoid incompatibility with parallel installations.


#### commit d7055b92b9cdb7f0da0bdfb94362b325c02c23da
Date:   Sun May 21 18:23:34 2017 +0200

- Merged in the features of OpenHPSDR-PowerSDR version 3.3.17.


#### commit 4ac12e29dcc63c978b96eaee029bc501f997151d
Date:   Thu May 18 01:53:36 2017 +0200

- Merged in the features of OpenHPSDR-PowerSDR version 3.3.15.


#### commit aa9c444a7092a81d6d6cdadea04b8b509e30aaff
Date:   Thu Apr 27 02:40:35 2017 +0200

- Changed the behaviour of the setup wizard when model Charly 25 or HAMlab / STEMlab is selected to skip the HPSDR and ANAN device specific hardware settings.


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
