@echo off
REM Create PLTone skin graphics from existing files
cls
set BASEDIR=%APPDATA%\FlexRadio Systems\PowerSDR\Skins

:DEFAULT
echo.
echo Default
cd %BASEDIR%\Default\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:BEPPE
echo.
echo Beppe
cd %BASEDIR%\Beppe\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:IK3VIG_black
echo.
echo IK3VIG Black
cd %BASEDIR%\IK3VIG Black\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:IK3VIG_blue
echo.
echo IK3VIG Blue
cd %BASEDIR%\IK3VIG Blue\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:IK3VIG_blue2
echo.
echo IK3VIG Blue2
cd %BASEDIR%\IK3VIG Blue2\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:IK3VIG_bobcat
echo.
echo IK3VIG BobCAT
cd %BASEDIR%\IK3VIG BobCAT\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:IK3VIG_cyan
echo.
echo IK3VIG Cyan
cd %BASEDIR%\IK3VIG cyan\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:IK3VIG_lcd
echo.
echo IK3VIG LCD
cd %BASEDIR%\IK3VIG LCD\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:IK3VIG_metal1
echo.
echo IK3VIG Metal1
cd %BASEDIR%\IK3VIG metal1\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:IK3VIG_metal2
echo.
echo IK3VIG Metal2
cd %BASEDIR%\IK3VIG metal2\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:IK3VIG_military
echo.
echo IK3VIG Military
cd %BASEDIR%\IK3VIG Military\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:IK3VIG_silverBlack
echo.
echo IK3VIG Silver-Black
cd %BASEDIR%\IK3VIG Silver-Black\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:IK3VIG_silverGlass
echo.
echo Silver-Glass
cd %BASEDIR%\IK3VIG Silver-Glass\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:IK3VIG_silverGreen
echo.
echo Silver-Green
cd %BASEDIR%\IK3VIG Silver-Green\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:IK3VIG_graphiteGreen
echo.
echo Graphite-Green
cd %BASEDIR%\IK3VIG Graphite-Green\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:W5WC_2D_Gray
echo.
echo W5WC_2D_Gray
cd %BASEDIR%\W5WC 2D Gray\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:OpenHPSDR-Gray
echo.
echo OpenHPSDR-Gray
cd %BASEDIR%\OpenHPSDR-Gray\Console
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%
echo Completed

:DEFAULT 2011
cd %BASEDIR%\Default 2011\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%

:DEFAULT 2012
cd %BASEDIR%\Default 2012\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%

:IK3VIG 2012 - 1
cd %BASEDIR%\IK3VIG 2012 - 1\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%

:IK3VIG 2012 - 2
cd %BASEDIR%\IK3VIG 2012 - 2\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%

:IK3VIG 2012 - 3
cd %BASEDIR%\IK3VIG 2012 - 3\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%

:IK3VIG 2012 - 4
cd %BASEDIR%\IK3VIG 2012 - 4\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%

:WB6RQN 2D 2012
cd %BASEDIR%\WB6RQN 2D 2012\Console
copy /Y chkNR-0.png chkPLTone-0.png
copy /Y chkNR-1.png chkPLTone-1.png
copy /Y chkNR-0.png chkMicMute-0.png
copy /Y chkNR-1.png chkMicMute-1.png
copy /Y chkNR-0.png chkShowTXFilter-0.png
copy /Y chkNR-1.png chkShowTXFilter-1.png
copy /Y panelModeSpecificPhone.png panelModeSpecificFM.png
copy /Y ptbMic-back.png ptbFMMic-back.png
copy /Y ptbMic-head.png ptbFMMic-head.png
copy /Y chkVFOSync-0.png radFMDeviation2kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation2kHz-1.png
copy /Y chkVFOSync-0.png radFMDeviation5kHz-0.png
copy /Y chkVFOSync-1.png radFMDeviation5kHz-1.png
copy /Y chkVFOSync-0.png chkFMCTCSS-0.png
copy /Y chkVFOSync-1.png chkFMCTCSS-1.png
copy /Y chkNB-0.png chkFMVAC-0.png
copy /Y chkNB-0.png chkFMTXSimplex-0.png
copy /Y chkNB-0.png chkFMTXLow-0.png
copy /Y chkNB-0.png chkFMTXHigh-0.png
copy /Y chkNB-0.png chkFMTXRev-0.png
copy /Y chkNB-0.png btnFMMemoryUp-0.png
copy /Y chkNB-0.png btnFMMemoryDown-0.png
copy /Y chkNB-0.png btnFMMemory-0.png
copy /Y chkNB-1.png chkFMVAC-1.png
copy /Y chkNB-1.png chkFMTXSimplex-1.png
copy /Y chkNB-1.png chkFMTXLow-1.png
copy /Y chkNB-1.png chkFMTXHigh-1.png
copy /Y chkNB-1.png chkFMTXRev-1.png
copy /Y chkNB-1.png btnFMMemoryUp-1.png
copy /Y chkNB-1.png btnFMMemoryDown-1.png
copy /Y chkNB-1.png btnFMMemory-1.png
copy /Y ptbAF-back.png ptbRX1AF-back.png
copy /Y ptbAF-head.png ptbRX1AF-head.png
copy /Y ptbAF-back.png ptbRX2AF-back.png
copy /Y ptbAF-head.png ptbRX2AF-head.png
copy /Y chkNB-0.png chkVAC1-0.png
copy /Y chkNB-1.png chkVAC1-1.png
copy /Y chkNB-0.png chkVAC2-0.png
copy /Y chkNB-1.png chkVAC2-1.png
copy /Y ptbCWSpeed-back.png ptbCWAPFBandwidth-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFBandwidth-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFFreq-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFFreq-head.png
copy /Y ptbCWSpeed-back.png ptbCWAPFGain-back.png
copy /Y ptbCWSpeed-head.png ptbCWAPFGain-head.png
copy /Y chkRIT-0.png chkCWAPFEnabled-0.png
copy /Y chkRIT-1.png chkCWAPFEnabled-1.png
cd %BASEDIR%

echo Completed
:EXIT

