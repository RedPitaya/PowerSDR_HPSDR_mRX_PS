﻿/*  Midi2Cat

Description: A subsystem that facilitates mapping Windows MIDI devices to CAT commands.
 
Copyright (C) 2016 Andrew Mansfield, M0YGG

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

The author can be reached by email at:  midi2cat@cametrix.com

Modifications to support the Behringer Midi controllers
by Chris Codella, W2PA, April 2017.  Indicated by //-W2PA comment lines.

*/

//
// Charly 25, HAMlab and STEMlab SDR Modifications Copyright (C) 2016 - 2018 Markus Grundner / DG8MG
//

using Midi2Cat;
using Midi2Cat.Data; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Midi2Cat.IO; //-W2PA Necessary for changes to support Behringer PL-1 (and others)

namespace PowerSDR
{
    public class Midi2CatCommands
    {
        private CATParser parser;
        private CATCommands commands;
        private MidiMessageManager midiManager = null; 


        public Midi2CatCommands(Console c)
        {
            midiManager = new MidiMessageManager(this, c.AppDataPath + "midi2cat.xml");
            parser = new CATParser(c);
            commands = new CATCommands(c, parser);
            OpenMidi2Cat();
        }


        #region Midi2Cat

        public void OpenMidi2Cat()
        {
            midiManager.Open();
        }

        public void CloseMidi2Cat()
        {
            midiManager.Close();
        }

        public string Midi2CatDbFile
        {
            get
            {
                if (midiManager != null)
                    return midiManager.DbFile;
                return null;
            }
        }

        #endregion

        #region Console2Midi

        public void SendUpdateToMidi(CatCmd cmd, double pct)  //-W2PA* Use the MidiMessageManager to send an update to the proper device/control LEDs
        {
            midiManager.SendUpdateToMidi(cmd, pct);
            return;
        }

        // DG8MG
        // Extension for Charly 25 frontpanel hardware
        // Use the MidiMessageManager to send an update to the LEDs on the Charly 25 frontpanel
        public bool Charly25SendUpdateToMidi(CatCmd cmd, int state)
        {
            return midiManager.Charly25SendUpdateToMidi(cmd, state);
        }

        // Get all information about the mapped knobs and buttons on the Charly 25 frontpanel
        public List<ControllerMapping> Charly25GetFrontpanelMappings()
        {
            return midiManager.Charly25GetFrontpanelMappings();
        }
        // DG8MG
        #endregion

        #region Execute Command

        //-W2PA Added device parameter to all commands to support return messages to devices with LEDs such as the Behringers

        public CmdState MultiRxOnOff(int msg, MidiDevice device)
        {
            parser.nSet = 1;
            parser.nGet = 0;

            if (msg == 127)
            {
                int MultiRxState = Convert.ToInt16(commands.ZZMU(""));

                if (MultiRxState == 0)
                {
                    commands.ZZMU("1");
                    return CmdState.On;
                }

                if (MultiRxState == 1)
                {
                    commands.ZZMU("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }


        public void Rx1ModeNext(int msg, MidiDevice device)
        {
            parser.nSet = 2;
            parser.nGet = 0;
            int SelectedMode = Convert.ToInt16(commands.ZZMD(""));

            if ((SelectedMode < 11) && (msg == 127))
            {
                commands.ZZMD((SelectedMode + 1).ToString("00"));
            }
        }


        public void Rx1ModePrev(int msg, MidiDevice device)
        {
            parser.nSet = 2;
            parser.nGet = 0;
            int SelectedMode = Convert.ToInt16(commands.ZZMD(""));

            if ((SelectedMode > 0) && (msg == 127))
            {
                commands.ZZMD((SelectedMode - 1).ToString("00"));
            }
        }

        public void Rx1FilterWider(int msg, MidiDevice device)
        {
            parser.nSet = 2;
            parser.nGet = 0;
            int SelectedFilter = Convert.ToInt16(commands.ZZFI(""));

            if ((SelectedFilter > 0) && (msg == 127))
            {
                commands.ZZFI((SelectedFilter - 1).ToString("00"));
            }
        }


        public void Rx1FilterNarrower(int msg, MidiDevice device)
        {
            parser.nSet = 2;
            parser.nGet = 0;
            int SelectedFilter = Convert.ToInt16(commands.ZZFI(""));

            if ((SelectedFilter < 14) && (msg == 127))
            {
                commands.ZZFI((SelectedFilter + 1).ToString("00"));
            }
        }


        public void VfoAtoB(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                //parser.nSet = 11;
                //parser.nGet = 0;

                //string FreqA = commands.ZZFA("");
                //commands.ZZFB(FreqA);

                //-W2PA This makes the function match its equivalent console function (e.g. mode gets copied)
                Console.getConsole().CATVFOAtoB();
            }
        }


        public void VfoBtoA(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                //parser.nSet = 11;
                //parser.nGet = 0;

                //string FreqB = commands.ZZFB("");
                //commands.ZZFA(FreqB);

                //-W2PA This makes the function match its equivalent console function (e.g. mode gets copied)
                Console.getConsole().CATVFOBtoA();
            }
        }

        public void VfoSwap(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                //parser.nSet = 11;
                //parser.nGet = 0;

                //string FreqB = commands.ZZFB("");
                //string FreqA = commands.ZZFA("");
                //commands.ZZFA(FreqB);
                //commands.ZZFB(FreqA);

                //-W2PA This makes the function match its equivalent console function (e.g. mode gets copied)
                Console.getConsole().CATVFOABSwap();
            }
        }

        public void XIT(int msg, MidiDevice device)
        {
            parser.nSet = 5;
            parser.nGet = 0;

            if ((msg < 64) & (msg >= 0))
            {
                int XITValue = (-1280 + (msg * 20));
                commands.ZZXF(XITValue.ToString("0000"));
            }
            if ((msg >= 64) & (msg <= 127))
            {
                int XITValue = ((msg - 64) * 20);
                commands.ZZXF("+" + XITValue.ToString("0000"));
            }
            return;
        }


        public void RIT(int msg, MidiDevice device)
        {
            parser.nSet = 5;
            parser.nGet = 0;

            if ((msg < 64) & (msg >= 0))
            {
                int RITValue = (-1280 + (msg * 20));
                commands.ZZRF(RITValue.ToString("0000"));
            }
            if ((msg >= 64) & (msg <= 127))
            {
                int RITValue = ((msg - 64) * 20);
                commands.ZZRF("+" + RITValue.ToString("0000"));
            }
            return;
        }

        bool IsBehringerCMD(MidiDevice device)
        {
            string deviceName = device.GetDeviceName();
            if (deviceName.Contains("CMD")) return true;
            else return false;
        }

        public void RIT_inc(int msg, MidiDevice device)
        {
            parser.nSet = 2;
            parser.nGet = 0;

            string deviceName = device.GetDeviceName();
            if (IsBehringerCMD(device))  //-W2PA special handling for Behringer wheel style knobs
            {
                if (msg == 127 || msg <= 1) //-W2PA for Behringer PL-1 type knob/wheel push button, to zero the setting
                {
                    commands.ZZRC();
                }
                else if (msg < 64) //-W2PA for Behringer PL-1 knob/wheel
                {
                    commands.ZZRD("");
                }
                else if (msg > 64)  //-W2PA for Behringer PL-1 knob/wheel
                {
                    commands.ZZRU("");
                }
            }
            else  //-W2PA Original code in Midi2Cat
            {
                if (msg == 127)
                {
                    commands.ZZRD("");
                }

                if (msg == 1)
                {
                    commands.ZZRU("");
                }
            }

        }

        public void XIT_inc(int msg, MidiDevice device)  //-W2PA Rewritten to use a mini-wheel like the ones on the Behringer PL-1
                                                         //-W2PA XIT_inc is different from RIT_inc because the CAT commands are different in CATCommands.cs
        {
            parser.nSet = 5;
            parser.nGet = 0;
            parser.nAns = 5;
            long freq = Convert.ToInt32(commands.ZZXF(""));
            int mode = Convert.ToInt16(commands.ZZMD(""));

            string deviceName = device.GetDeviceName();
            if (IsBehringerCMD(device))  //-W2PA special handling for Behringer wheel style knobs
            {
                if ((msg == 127 || msg <= 1))  //-W2PA for Behringer PL-1 type knob/wheel push button, to zero the setting
                {
                    commands.ZZXC();
                    return;
                }

                if ((msg < 64) && (freq > -99995))
                {
                    freq = freq - 10;  //-W2PA Changed to operate in all modes.
                    if (freq < 0) commands.ZZXF(freq.ToString("D4"));
                    if (freq >= 0) commands.ZZXF("+" + freq.ToString("D4"));
                }

                if ((msg > 64) && (freq < 99995))
                {
                    freq = freq + 10;  //-W2PA Changed to operate in all modes.
                    if (freq < 0) commands.ZZXF(freq.ToString("D4"));
                    if (freq >= 0) commands.ZZXF("+" + freq.ToString("D4"));
                }
            }
            else  //-W2PA Original code in Midi2Cat 
            {
                if ((msg == 127) && (freq > -99995))
                {
                    //if ((mode == 0) || (mode == 1)) freq = freq - 10;
                    //if ((mode == 3) || (mode == 4)) freq = freq - 10;
                    freq = freq - 10;
                    if (freq < 0) commands.ZZXF(freq.ToString("D4"));
                    if (freq >= 0) commands.ZZXF("+" + freq.ToString("D4"));
                }

                if ((msg == 1) && (freq < 99995))
                {
                    //if ((mode == 0) || (mode == 1)) freq = freq + 10;
                    //if ((mode == 3) || (mode == 4)) freq = freq + 10;
                    freq = freq + 10;
                    if (freq < 0) commands.ZZXF(freq.ToString("D4"));
                    if (freq >= 0) commands.ZZXF("+" + freq.ToString("D4"));
                }
            }

        }

        public void RIT_clear(int msg, MidiDevice device)
        {
            parser.nSet = 0;
            parser.nGet = 0;

            if (msg == 127)
            {
                commands.ZZRC();
            }
        }

        public void XIT_clear(int msg, MidiDevice device)
        {
            parser.nSet = 0;
            parser.nGet = 0;

            if (msg == 127)
            {
                commands.ZZXC();
            }
        }

        public void TuningStepUp(int msg, MidiDevice device)
        {
            parser.nSet = 2;
            parser.nGet = 0;

            if ((Convert.ToInt16(commands.ZZAC("")) < 22) && (msg == 127))
            {
                commands.ZZSU();
            }
        }

        public void TuningStepDown(int msg, MidiDevice device)
        {
            parser.nSet = 2;
            parser.nGet = 0;

            if ((Convert.ToInt16(commands.ZZAC("")) > 0) && (msg == 127))
            {
                commands.ZZSD();
            }
        }

        //    case 50: // Volume DeckA - Volume

        public void VolumeVfoA(int msg, MidiDevice device)
        {
            parser.nSet = 3;
            parser.nGet = 0;

            try
            {
                double vol = msg * 0.787;
                commands.ZZLA(vol.ToString("000"));
                return;
            }
            catch
            {
                return;
            }
        }

        //-W2PA Incremental volume control for Behringer PL-1 or similar knobs as wheels. Also added an item for Wheel in CatCmdDb.cs
        public void VolumeVfoA_inc(int msg, MidiDevice device)
        {
            parser.nSet = 3;
            parser.nGet = 0;

            try
            {
                string curVol = commands.ZZLA("");
                int cV = Int32.Parse(curVol);
                if (msg != 127 && msg != 0)  //-W2PA Ignore knob click presses
                {
                    cV += msg - 64;
                    commands.ZZLA(cV.ToString("000")); //-W2PA This seems to slide both the RX0 (A) and left slider at bottom
                }
                return;
            }
            catch
            {
                return;
            }
        }

        //    case 51: // Volume DeckB - Volume

        public void VolumeVfoB(int msg, MidiDevice device)
        {

            parser.nSet = 3;
            parser.nGet = 0;

            try
            {
                double vol = msg * 0.787;
                commands.ZZLC(vol.ToString("000"));
                return;
            }
            catch
            {
                return;
            }

        }

        //-W2PA Incremental volume control for Behringer PL-1 or similar knobs as wheels. Also added an item for Wheel in CatCmdDb.cs
        public void VolumeVfoB_inc(int msg, MidiDevice device)
        {

            parser.nSet = 3;
            parser.nGet = 0;

            try
            {
                string curVol = commands.ZZLE("");
                int cV = Int32.Parse(curVol);
                if (msg != 127 && msg != 0)  //-W2PA Ignore knob click presses
                {
                    cV += msg - 64;
                    commands.ZZLE(cV.ToString("000")); //-W2PA RX1 (B) 
                }
                return;
            }
            catch
            {
                return;
            }

        }

        public void RX2Volume(int msg, MidiDevice device)
        {
            parser.nSet = 3;
            parser.nGet = 0;

            try
            {
                double RX2vol = msg * 0.787;
                commands.ZZLE(RX2vol.ToString("000"));
                return;
            }
            catch
            {
                return;
            }
        }

        public void RX2Pan(int msg, MidiDevice device)
        {
            parser.nSet = 3;
            parser.nGet = 0;

            try
            {
                double RX2vol = msg * 0.787;
                commands.ZZLF(RX2vol.ToString("000"));
                return;
            }
            catch
            {
                return;
            }
        }

        //    case 52: // Pitch DeckA - FilterBandwidth
        public void FilterBandwidth(int msg, MidiDevice device)
        {
            parser.nSet = 5;
            parser.nGet = 0;
            int FilterBW = Convert.ToInt16(commands.ZZIS(""));

            if (msg == 1)
            {
                FilterBW = FilterBW + 50;
                commands.ZZIS(FilterBW.ToString("00000"));
                return;
            }

            if (msg == 127)
            {
                FilterBW = FilterBW - 50;
                commands.ZZIS(FilterBW.ToString("00000"));
                return;
            }
        }

        public void FilterShift(int msg, MidiDevice device)
        {
            int ShiftValue = (int)(((msg / 1.27) - 50) * 20);
            parser.nSet = 5;
            parser.nGet = 0;
            if (ShiftValue < 0)
            {
                commands.ZZIT(ShiftValue.ToString("0000"));
            }
            if (ShiftValue >= 0)
            {
                commands.ZZIT("+" + ShiftValue.ToString("0000"));
            }
            return;
        }



        //    case 49: //Crossfader

        public void RatioMainSubRx(int msg, MidiDevice device)
        {
            parser.nSet = 3;
            parser.nGet = 0;

            try
            {
                double mix = msg * 0.787;
                commands.ZZLB(mix.ToString("000"));
                commands.ZZLD((100 - mix).ToString("000"));
                return;
            }
            catch
            {
                return;
            }

        }


        public CmdState AutoNotchOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int AutoNotchState = Convert.ToInt16(commands.ZZNT(""));

                if (AutoNotchState == 0)
                {
                    commands.ZZNT("1");
                    return CmdState.On;
                }
                if (AutoNotchState == 1)
                {
                    commands.ZZNT("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }


        public CmdState Rx1NoiseBlanker1OnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int Rx1NB1State = Convert.ToInt16(commands.ZZNA(""));

                if (Rx1NB1State == 0)
                {
                    commands.ZZNA("1");
                    return CmdState.On;
                }
                if (Rx1NB1State == 1)
                {
                    commands.ZZNA("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }



        public CmdState Rx2NoiseBlanker1OnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int Rx2NB1State = Convert.ToInt16(commands.ZZNC(""));

                    if (Rx2NB1State == 0)
                    {
                        commands.ZZNC("1");
                        return CmdState.On;
                    }
                    if (Rx2NB1State == 1)
                    {
                        commands.ZZNC("0");
                        return CmdState.Off;
                    }
                }
                catch
                {
                    return CmdState.NoChange;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState Rx1Noiseblanker2OnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int Rx1NB2State = Convert.ToInt16(commands.ZZNB(""));

                    if (Rx1NB2State == 0)
                    {
                        commands.ZZNB("1");
                        return CmdState.On;
                    }
                    if (Rx1NB2State == 1)
                    {
                        commands.ZZNB("0");
                        return CmdState.Off;
                    }
                }
                catch
                {
                    return CmdState.NoChange;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState Rx2Noiseblanker2OnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int Rx2NB2State = Convert.ToInt16(commands.ZZND(""));

                    if (Rx2NB2State == 0)
                    {
                        commands.ZZND("1");
                        return CmdState.On;
                    }
                    if (Rx2NB2State == 1)
                    {
                        commands.ZZND("0");
                        return CmdState.Off;
                    }
                }
                catch
                {
                    return CmdState.NoChange;
                }
            }
            return CmdState.NoChange;

        }

        public CmdState LockVFOOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int VfoLockState = Convert.ToInt16(commands.ZZVL(""));

                if (VfoLockState == 0)
                {
                    commands.ZZVL("1");
                    return CmdState.On;
                }
                if (VfoLockState == 1)
                {
                    commands.ZZVL("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState LockVFOAOnOff(int msg, MidiDevice device) 
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int VfoLockState = Convert.ToInt16(commands.ZZUX(""));

                if (VfoLockState == 0)
                {
                    commands.ZZUX("1");
                    return CmdState.On;
                }
                if (VfoLockState == 1)
                {
                    commands.ZZUX("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState LockVFOBOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int VfoLockState = Convert.ToInt16(commands.ZZUY(""));

                if (VfoLockState == 0)
                {
                    commands.ZZUY("1");
                    return CmdState.On;
                }
                if (VfoLockState == 1)
                {
                    commands.ZZUY("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState RitOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int RitState = Convert.ToInt16(commands.ZZRT(""));

                if (RitState == 0)
                {
                    commands.ZZRT("1");
                    return CmdState.On;
                }
                if (RitState == 1)
                {
                    commands.ZZRT("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState XitOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int XitState = Convert.ToInt16(commands.ZZXS(""));

                if (XitState == 0)
                {
                    commands.ZZXS("1");
                    return CmdState.On;
                }
                if (XitState == 1)
                {
                    commands.ZZXS("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public void SetAFGain(int msg, MidiDevice device)
        {
            int AFGain = (int)(msg / 1.27);
            parser.nSet = 3;
            commands.ZZAG(AFGain.ToString("000"));
            return;
        }

        //public void ChangeFreqVfoA(int msg, MidiDevice device)
        //{
        //    if (msg == 127)
        //    {
        //        commands.ZZSA();
        //    }
        //    if (msg == 1)
        //    {
        //        commands.ZZSB();
        //    }
        //}

        public int StringToFreq(string s)
        {
            int d = 0;
            int t = Convert.ToInt16(s);
            switch (t)
            {
                case 0:
                    d = 0000001;
                    break;
                case 1:
                    d = 000010;
                    break;
                case 2:
                    d = 000025;
                    break;
                case 3:
                    d = 000050;
                    break;
                case 4:
                    d = 000100;
                    break;
                case 5:
                    d = 000250;
                    break;
                case 6:
                    d = 000500;
                    break;
                case 7:
                    d = 001000;
                    break;
                case 8:
                    d = 002500;
                    break;
                case 9:
                    d = 005000;
                    break;
                case 10:
                    d = 006250;
                    break;
                case 11:
                    d = 009000;
                    break;
                case 12:
                    d = 010000;
                    break;
                case 13:
                    d = 012500;
                    break;
                case 14:
                    d = 015000;
                    break;
                case 15:
                    d = 020000;
                    break;
                case 16:
                    d = 025000;
                    break;
                case 17:
                    d = 030000;
                    break;
                case 18:
                    d = 050000;
                    break;
                case 19:
                    d = 100000;
                    break;
                case 20:
                    d = 250000;
                    break;
                case 21:
                    d = 500000;
                    break;
                case 22:
                    d = 1000000;
                    break;
                case 23:
                    d = 10000000;
                    break;
            }
            return (d);
        }


        //-W2PA This increments or decrements the number of MIDI messages that cause a single tune step increment
        // It is useful when using coarse increments, such as 100kHz, and wanting more wheel rotation for each one
        // so that tuning isn't so critical.
        public void MidiMessagesPerTuneStepUp(int msg, MidiDevice device)
        {
            if (msg >= 126) Console.getConsole().CATMidiMessagesPerTuneStepUp();
        }
        public void MidiMessagesPerTuneStepDown(int msg, MidiDevice device) 
        {
            if (msg >= 126) Console.getConsole().CATMidiMessagesPerTuneStepDown();
        }
        public CmdState MidiMessagesPerTuneStepToggle(int msg, MidiDevice device) 
        {
            if (msg >= 126)
            {
                CmdState retState = CmdState.Off;
                int mpts = Console.getConsole().MidiMessagesPerTuneStep;

                if (mpts == Console.getConsole().MinMIDIMessagesPerTuneStep) retState = CmdState.On;  // switching to max
                else if (mpts == Console.getConsole().MaxMIDIMessagesPerTuneStep) retState = CmdState.Off; // switching to min
                else
                {   // on the off chance the user has set the value to some intermediate value, force reset to min
                    Console.getConsole().MidiMessagesPerTuneStep = Console.getConsole().MinMIDIMessagesPerTuneStep;
                    return CmdState.Off;
                }
                // Do the toggle
                Console.getConsole().CATMidiMessagesPerTuneStepToggle();
                return retState;
            }
            else
            {
                return CmdState.NoChange;
            }   
        }

        private int msgs_since_reversal = 0;  //-W2PA Used to keep track of rotation and apply MidiMessagesPerTuneStep from console
        private int current_tuning_direction = 0;  // -1 = CCW, 1 = CW -- 0 is uninitialized value

        //-W2PA  Routine to implement MIDI wheel VFO tuning using the original code from Midi2Cat
        private void ProcessStdMIDIWheelAsVFO(int direction, int step, bool RoundToStepSize, long freq, int mode, string vfo)
        {
            int ico;
            if (vfo == "a") ico = Convert.ToInt16(commands.ZZRA("")); else ico = Convert.ToInt16(commands.ZZRB(""));

            //-W2PA Check granularity of MIDI messages - i.e. rotation amount - to cause an increment
            // For testing:
            // Console.getConsole().MidiMessagesPerTuneStep = 16;

            if (current_tuning_direction == 0) // First time tuning
            {
                msgs_since_reversal = 0;
                if (direction > 125) current_tuning_direction = 1;
                else current_tuning_direction = -1;
            }

            if ((direction > 125 && current_tuning_direction == 1) ||
                (direction < 3 && current_tuning_direction == -1))
            {  // continuing in same direction
                msgs_since_reversal++;
                int mpts = Console.getConsole().MidiMessagesPerTuneStep;
                if (msgs_since_reversal < mpts)
                    return; // Not enough rotation to act
                else
                {   // ok to tune, reset the counter then go tune
                    msgs_since_reversal = 0;
                }
            }
            else // direction has reversed 
            {
                msgs_since_reversal = 1;
                current_tuning_direction = -current_tuning_direction;
                int mpts = Console.getConsole().MidiMessagesPerTuneStep;
                if (msgs_since_reversal < mpts)  // i.e. if msgs/step isn't 1                
                    return;
            }


            switch (mode)
            {
                case 7: //DIGU
                    {
                        if (ico == 1) //elminate CAT Offset for DIGU in case selected
                        {
                            int offsetDIGU = Convert.ToInt16(commands.ZZRH(""));

                            if (direction == 127 || direction == 126)
                            {
                                freq -= offsetDIGU;
                                long x = SnapTune(freq, step, -1, RoundToStepSize) + offsetDIGU;
                                if (vfo == "a") commands.ZZFA(x.ToString("D11")); else commands.ZZFB(x.ToString("D11"));
                            }
                            if (direction == 1 || direction == 2)
                            {
                                freq -= offsetDIGU;
                                long x = SnapTune(freq, step, 1, RoundToStepSize) + offsetDIGU;
                                if (vfo == "a") commands.ZZFA(x.ToString("D11")); else commands.ZZFB(x.ToString("D11"));
                            }

                        }
                        else
                        {
                            if (direction == 127 || direction == 126)
                            {
                                if (vfo == "a") commands.ZZFA((SnapTune(freq, step, -1, RoundToStepSize).ToString("D11")));
                                else commands.ZZFB((SnapTune(freq, step, -1, RoundToStepSize).ToString("D11")));
                            }
                            if (direction == 1 || direction == 2)
                            {
                                if (vfo == "a") commands.ZZFA((SnapTune(freq, step, 1, RoundToStepSize).ToString("D11")));
                                else commands.ZZFB((SnapTune(freq, step, 1, RoundToStepSize).ToString("D11")));
                            }
                        }
                        break;
                    }
                case 9: //DIGL
                    {
                        if (ico == 1) //elminate CAT Offset for DIGL in case selected
                        {
                            int offsetDIGL = Convert.ToInt16(commands.ZZRL(""));

                            if (direction == 127 || direction == 126)
                            {
                                freq += offsetDIGL;
                                long x = SnapTune(freq, step, -1, RoundToStepSize) - offsetDIGL;
                                if (vfo == "a") commands.ZZFA(x.ToString("D11")); else commands.ZZFB(x.ToString("D11"));
                            }
                            if (direction == 1 || direction == 2)
                            {
                                freq += offsetDIGL;
                                long x = SnapTune(freq, step, 1, RoundToStepSize) - offsetDIGL;
                                if (vfo == "a") commands.ZZFA(x.ToString("D11")); else commands.ZZFB(x.ToString("D11"));
                            }

                        }
                        else
                        {
                            if (direction == 127 || direction == 126)
                            {
                                if (vfo == "a") commands.ZZFA((SnapTune(freq, step, -1, RoundToStepSize).ToString("D11")));
                                else commands.ZZFB((SnapTune(freq, step, -1, RoundToStepSize).ToString("D11")));
                            }
                            if (direction == 1 || direction == 2)
                            {
                                if (vfo == "a") commands.ZZFA((SnapTune(freq, step, 1, RoundToStepSize).ToString("D11")));
                                else commands.ZZFB((SnapTune(freq, step, 1, RoundToStepSize).ToString("D11")));
                            }
                        }
                        break;
                    }
                default: //for all other modes
                    {

                        if (direction == 127 || direction == 126)
                        {
                            if (vfo == "a") commands.ZZFA((SnapTune(freq, step, -1, RoundToStepSize).ToString("D11")));
                            else commands.ZZFB((SnapTune(freq, step, -1, RoundToStepSize).ToString("D11")));
                        }
                        if (direction == 1 || direction == 2)
                        {
                            if (vfo == "a") commands.ZZFA((SnapTune(freq, step, 1, RoundToStepSize).ToString("D11")));
                            else commands.ZZFB((SnapTune(freq, step, 1, RoundToStepSize).ToString("D11")));
                        }
                        break;
                    }
            }

        }

        //-W2PA  Routine to implement variable speed tuning using the Behringer CMD PL-1 (and others) MIDI controller main wheel
        private void ProcessBehringerMainWheelAsVFO(int direction, int step, bool RoundToStepSize, long freq, int mode, string vfo, string deviceName)
        {
            int stepMult = 1;

            //-W2PA Check granularity of MIDI messages - i.e. rotation amount - to cause an increment
            // For testing:
            // Console.getConsole().MidiMessagesPerTuneStep = 16;

            if (current_tuning_direction == 0) // First time tuning
            {
                msgs_since_reversal = 0;
                if (direction > 64) current_tuning_direction = 1;
                else current_tuning_direction = -1;
            }
            
            if ((direction > 64 && current_tuning_direction == 1) ||
                (direction < 64 && current_tuning_direction == -1)) 
            {  // continuing in same direction
                msgs_since_reversal++;
                int mpts = Console.getConsole().MidiMessagesPerTuneStep;
                if (msgs_since_reversal < mpts)
                    return; // Not enough rotation to act
                else
                {   // ok to tune, reset the counter then go tune
                    msgs_since_reversal = 0;
                }
            }
            else // direction has reversed 
            {
                msgs_since_reversal = 1;
                current_tuning_direction = -current_tuning_direction;
                int mpts = Console.getConsole().MidiMessagesPerTuneStep;
                if (msgs_since_reversal < mpts)  // i.e. if msgs/step isn't 1                
                    return;                    
            }


                // Handle the PL-1 and Micro slightly different due to the different behavior of their large wheels
                if (deviceName == "CMD PL-1")
            {
                if ((direction <= 58 && direction >= 10) || (direction >= 70 && direction <= 117)) //-W2PA Fast spin of Behringer wheel, multiply steps
                {
                    stepMult = 3;
                }
                if ((direction <= 57 && direction >= 10) || (direction >= 71 && direction <= 117)) //-W2PA Faster spin of Behringer wheel, multiply steps
                {
                    stepMult = 7;
                }
                if ((direction <= 56 && direction >= 10) || (direction >= 72 && direction <= 117)) //-W2PA Faster spin of Behringer wheel, multiply steps
                {
                    stepMult = 11;
                }
                if ((direction <= 52 && direction >= 10) || (direction >= 76 && direction <= 117)) //-W2PA Fastest spin of Behringer wheel, multiply steps more
                {
                    stepMult = 200;
                }
            }
            else if (deviceName == "CMD Micro")  // These wheels need more spinning to get to higher numbers than the PL-1, so start increasing earlier.
            {
                if ((direction <= 62 && direction >= 10) || (direction >= 66 && direction <= 117)) //-W2PA Fast spin of Behringer wheel, multiply steps
                {
                    stepMult = 3;
                }
                if ((direction <= 61 && direction >= 10) || (direction >= 67 && direction <= 117)) //-W2PA Faster spin of Behringer wheel, multiply steps
                {
                    stepMult = 7;
                }
                if ((direction <= 60 && direction >= 10) || (direction >= 68 && direction <= 117)) //-W2PA Faster spin of Behringer wheel, multiply steps
                {
                    stepMult = 11;
                }
                if ((direction <= 58 && direction >= 10) || (direction >= 70 && direction <= 117)) //-W2PA Fastest spin of Behringer PL-1 wheel, multiply steps more
                {
                    stepMult = 200;
                }
            }
            else if (deviceName.Contains("CMD"))  // Try handling all other Behringer controllers
            {
                if ((direction <= 62 && direction >= 10) || (direction >= 66 && direction <= 117)) //-W2PA Fast spin of Behringer wheel, multiply steps
                {
                    stepMult = 3;
                }
                if ((direction <= 61 && direction >= 10) || (direction >= 67 && direction <= 117)) //-W2PA Faster spin of Behringer wheel, multiply steps
                {
                    stepMult = 7;
                }
                if ((direction <= 60 && direction >= 10) || (direction >= 68 && direction <= 117)) //-W2PA Faster spin of Behringer wheel, multiply steps
                {
                    stepMult = 11;
                }
                if ((direction <= 58 && direction >= 10) || (direction >= 70 && direction <= 117)) //-W2PA Fastest spin of Behringer PL-1 wheel, multiply steps more
                {
                    stepMult = 200;
                }
            }
            else return;         

            int ico;
            if (vfo == "a") ico = Convert.ToInt16(commands.ZZRA("")); else ico = Convert.ToInt16(commands.ZZRB(""));
            switch (mode)
            {
                case 7: //DIGU
                    {
                        if (ico == 1) //elminate CAT Offset for DIGU in case selected
                        {
                            int offsetDIGU = Convert.ToInt16(commands.ZZRH(""));

                            //if (direction == 127)
                            if (direction < 64 && direction >= 25) //-W2PA Make Behringer wheel work for tuning
                            {
                                freq -= offsetDIGU;
                                long x = SnapTune(freq, step, -1 * stepMult, RoundToStepSize) + offsetDIGU;
                                if (vfo == "a") commands.ZZFA(x.ToString("D11")); else commands.ZZFB(x.ToString("D11"));
                            }
                            //if (direction == 1)
                            if (direction > 64 && direction <= 105) //-W2PA Make Behringer wheel work for tuning
                            {
                                freq -= offsetDIGU;
                                long x = SnapTune(freq, step, 1 * stepMult, RoundToStepSize) + offsetDIGU;
                                if (vfo == "a") commands.ZZFA(x.ToString("D11")); else commands.ZZFB(x.ToString("D11"));
                            }


                        }
                        else
                        {
                            //if (direction == 127)
                            if (direction < 64 && direction >= 25) //-W2PA Make Behringer wheel work for tuning
                            {
                                if (vfo == "a") commands.ZZFA((SnapTune(freq, step, -1 * stepMult, RoundToStepSize).ToString("D11")));
                                else commands.ZZFB((SnapTune(freq, step, -1 * stepMult, RoundToStepSize).ToString("D11")));
                            }
                            //if (direction == 1)
                            if (direction > 64 && direction <= 105) //-W2PA Make Behringer wheel work for tuning
                            {
                                if (vfo == "a") commands.ZZFA((SnapTune(freq, step, 1 * stepMult, RoundToStepSize).ToString("D11")));
                                else commands.ZZFB((SnapTune(freq, step, 1 * stepMult, RoundToStepSize).ToString("D11")));
                            }
                        }
                        break;
                    }
                case 9: //DIGL
                    {
                        if (ico == 1) //elminate CAT Offset for DIGL in case selected
                        {
                            int offsetDIGL = Convert.ToInt16(commands.ZZRL(""));

                            //if (direction == 127)
                            if (direction < 64 && direction >= 25) //-W2PA Make Behringer wheel work for tuning
                            {
                                freq += offsetDIGL;
                                long x = SnapTune(freq, step, -1 * stepMult, RoundToStepSize) - offsetDIGL;
                                if (vfo == "a") commands.ZZFA(x.ToString("D11")); else commands.ZZFB(x.ToString("D11"));
                            }
                            //if (direction == 1)
                            if (direction > 64 && direction <= 105) //-W2PA Make Behringer wheel work for tuning
                            {
                                freq += offsetDIGL;
                                long x = SnapTune(freq, step, 1 * stepMult, RoundToStepSize) - offsetDIGL;
                                if (vfo == "a") commands.ZZFA(x.ToString("D11")); else commands.ZZFB(x.ToString("D11"));
                            }

                        }
                        else
                        {
                            //if (direction == 127)
                            if (direction < 64 && direction >= 25) //-W2PA Make Behringer wheel work for tuning
                            {
                                if (vfo == "a") commands.ZZFA((SnapTune(freq, step, -1 * stepMult, RoundToStepSize).ToString("D11")));
                                else commands.ZZFB((SnapTune(freq, step, -1 * stepMult, RoundToStepSize).ToString("D11")));
                            }
                            //if (direction == 1)
                            if (direction > 64 && direction <= 105) //-W2PA Make Behringer wheel work for tuning
                            {
                                if (vfo == "a") commands.ZZFA((SnapTune(freq, step, 1 * stepMult, RoundToStepSize).ToString("D11")));
                                else commands.ZZFB((SnapTune(freq, step, 1 * stepMult, RoundToStepSize).ToString("D11")));
                            }
                        }
                        break;
                    }
                default: //for all other modes
                    {

                        //if (direction == 127)
                        if (direction < 64 && direction >= 25) //-W2PA Make Behringer wheel work for tuning
                        {
                            if (vfo == "a") commands.ZZFA((SnapTune(freq, step, -1 * stepMult, RoundToStepSize).ToString("D11")));
                            else commands.ZZFB((SnapTune(freq, step, -1 * stepMult, RoundToStepSize).ToString("D11")));
                        }
                        //if (direction == 1)
                        if (direction > 64 && direction <= 105) //-W2PA Make Behringer wheel work for tuning
                        {
                            if (vfo == "a") commands.ZZFA((SnapTune(freq, step, 1 * stepMult, RoundToStepSize).ToString("D11")));
                            else commands.ZZFB((SnapTune(freq, step, 1 * stepMult, RoundToStepSize).ToString("D11")));
                        }
                        break;
                    }
            }

        }

        public void ChangeFreqVfoA(int msg, MidiDevice device)
        {
            parser.nSet = 2;
            parser.nGet = 0;
            int step = StringToFreq(commands.ZZAC(""));
            ChangeFreqVfoA(msg, step, true, device);
        }

        //private void ChangeFreqVfoA(int direction, int step, bool RoundToStepSize)
        //{
        //    parser.nGet = 0;
        //    parser.nSet = 11;
        //    long freq = Convert.ToInt64(commands.ZZFA(""));
        //    parser.nAns = 11;
        //    int mode = Convert.ToInt16(commands.ZZMD(""));
        //    commands.isMidi = true;
        //    //System.Diagnostics.Debug.WriteLine("Msg=" + msg);
        //    switch (mode)
        //    {
        //        case 7: //DIGU
        //            {
        //                if (Convert.ToInt16(commands.ZZRA("")) == 1) //elminate CAT Offset for DIGU in case selected
        //                {
        //                    int offsetDIGU = Convert.ToInt16(commands.ZZRH(""));

        //                    if (direction == 127)
        //                    {
        //                        freq -= offsetDIGU;
        //                        long x = SnapTune(freq, step, -1, RoundToStepSize) + offsetDIGU;
        //                        commands.ZZFA(x.ToString("D11"));
        //                    }
        //                    if (direction == 1)
        //                    {
        //                        freq -= offsetDIGU;
        //                        long x = SnapTune(freq, step, 1, RoundToStepSize) + offsetDIGU;
        //                        commands.ZZFA(x.ToString("D11"));
        //                    }

        //                }
        //                else
        //                {
        //                    if (direction == 127)
        //                    {
        //                        commands.ZZFA((SnapTune(freq, step, -1, RoundToStepSize).ToString("D11")));
        //                    }
        //                    if (direction == 1)
        //                    {
        //                        commands.ZZFA((SnapTune(freq, step, 1, RoundToStepSize).ToString("D11")));
        //                    }
        //                }
        //                break;
        //            }
        //        case 9: //DIGL
        //            {
        //                if (Convert.ToInt16(commands.ZZRA("")) == 1) //elminate CAT Offset for DIGL in case selected
        //                {
        //                    int offsetDIGL = Convert.ToInt16(commands.ZZRL(""));

        //                    if (direction == 127)
        //                    {
        //                        freq += offsetDIGL;
        //                        long x = SnapTune(freq, step, -1, RoundToStepSize) - offsetDIGL;
        //                        commands.ZZFA(x.ToString("D11"));
        //                    }
        //                    if (direction == 1)
        //                    {
        //                        freq += offsetDIGL;
        //                        long x = SnapTune(freq, step, 1, RoundToStepSize) - offsetDIGL;
        //                        commands.ZZFA(x.ToString("D11"));
        //                    }

        //                }
        //                else
        //                {
        //                    if (direction == 127)
        //                    {
        //                        commands.ZZFA((SnapTune(freq, step, -1, RoundToStepSize).ToString("D11")));
        //                    }
        //                    if (direction == 1)
        //                    {
        //                        commands.ZZFA((SnapTune(freq, step, 1, RoundToStepSize).ToString("D11")));
        //                    }
        //                }
        //                break;
        //            }
        //        default: //for all other modes
        //            {

        //                if (direction == 127)
        //                {
        //                    commands.ZZFA((SnapTune(freq, step, -1, RoundToStepSize).ToString("D11")));
        //                }
        //                if (direction == 1)
        //                {
        //                    commands.ZZFA((SnapTune(freq, step, 1, RoundToStepSize).ToString("D11")));
        //                }
        //                break;
        //            }
        //    }
        //    commands.isMidi = false;
        //}


        //-W2PA Modified to select Behringer PL-1, Micro, or original code
        private void ChangeFreqVfoA(int direction, int step, bool RoundToStepSize, MidiDevice device)  
        {

            parser.nGet = 0;
            parser.nSet = 11;
            long freq = Convert.ToInt64(commands.ZZFA(""));
            parser.nAns = 11;
            int mode = Convert.ToInt16(commands.ZZMD(""));
            commands.isMidi = true;
            //System.Diagnostics.Debug.WriteLine("Msg=" + msg);

            string devName = device.GetDeviceName();
            if (devName == "CMD PL-1")  
            {
                ProcessBehringerMainWheelAsVFO(direction, step, RoundToStepSize, freq, mode, "a", "CMD PL-1");
            }
            else if (devName == "CMD Micro")
            {
                ProcessBehringerMainWheelAsVFO(direction, step, RoundToStepSize, freq, mode, "a", "CMD Micro");
            }
            else if (devName.Contains("CMD"))
            {
                ProcessBehringerMainWheelAsVFO(direction, step, RoundToStepSize, freq, mode, "a", "CMD");
            }
            else
            {
                ProcessStdMIDIWheelAsVFO(direction, step, RoundToStepSize, freq, mode, "a");  // Original handler
            }

            commands.isMidi = false;
        }


        public long SnapTune(long freq, int step, int num_steps, bool RoundToStepSize)
        {
            long temp;

            if (step == 0) //catch to avoid division by zero
            {
                return freq;
            }

            if (RoundToStepSize)
            {
                try
                {
                    temp = freq / step; // do integer division to end up on a step size boundary
                }
                catch
                {
                    return freq;
                }

                // handle when starting frequency was already on a step size boundary and tuning down
                if (num_steps < 0 && freq % step != 0)
                    num_steps++; // off boundary -- add one as the divide takes care of one step

                temp += num_steps; // increment by the number of steps (positive or negative)

                freq = temp * step; // multiply back up to get hz
                return freq; // return freq in MHz
            }
            else
            {
                if (num_steps > 0)
                    return freq + step;
                else
                    return freq - step;
            }
        }

        //public void ChangeFreqVfoB(int msg, MidiDevice device)
        //{
        //    bool RoundToStepSize = true;
        //    parser.nSet = 2;
        //    parser.nGet = 0;
        //    int mode;
        //    if (int.TryParse(commands.ZZMD(""), out mode) == false)
        //        return;
        //    int step = StringToFreq(commands.ZZAC(""));
        //    parser.nSet = 11;
        //    long freq = Convert.ToInt64(commands.ZZFB(""));
        //    parser.nAns = 11;

        //    commands.isMidi2 = true;

        //    switch (mode)
        //    {
        //        case 7: //DIGU
        //            {
        //                if (Convert.ToInt16(commands.ZZRB("")) == 1) //elminate CAT Offset for DIGU in case selected
        //                {
        //                    int offsetDIGU = Convert.ToInt16(commands.ZZRH(""));

        //                    if (msg == 127)
        //                    {
        //                        freq -= offsetDIGU;
        //                        long x = SnapTune(freq, step, -1, RoundToStepSize) + offsetDIGU;
        //                        commands.ZZFB(x.ToString("D11"));
        //                    }
        //                    if (msg == 1)
        //                    {
        //                        freq -= offsetDIGU;
        //                        long x = SnapTune(freq, step, 1, RoundToStepSize) + offsetDIGU;
        //                        commands.ZZFB(x.ToString("D11"));
        //                    }

        //                }
        //                else
        //                {
        //                    if (msg == 127)
        //                    {
        //                        commands.ZZFB((SnapTune(freq, step, -1, RoundToStepSize).ToString("D11")));
        //                    }
        //                    if (msg == 1)
        //                    {
        //                        commands.ZZFB((SnapTune(freq, step, 1, RoundToStepSize).ToString("D11")));
        //                    }
        //                }
        //                break;
        //            }
        //        case 9: //DIGL
        //            {
        //                if (Convert.ToInt16(commands.ZZRB("")) == 1) //elminate CAT Offset for DIGL in case selected
        //                {
        //                    int offsetDIGL = Convert.ToInt16(commands.ZZRL(""));

        //                    if (msg == 127)
        //                    {
        //                        freq += offsetDIGL;
        //                        long x = SnapTune(freq, step, -1, RoundToStepSize) - offsetDIGL;
        //                        commands.ZZFB(x.ToString("D11"));
        //                    }
        //                    if (msg == 1)
        //                    {
        //                        freq += offsetDIGL;
        //                        long x = SnapTune(freq, step, 1, RoundToStepSize) - offsetDIGL;
        //                        commands.ZZFB(x.ToString("D11"));
        //                    }

        //                }
        //                else
        //                {
        //                    if (msg == 127)
        //                    {
        //                        commands.ZZFB((SnapTune(freq, step, -1, RoundToStepSize).ToString("D11")));
        //                    }
        //                    if (msg == 1)
        //                    {
        //                        commands.ZZFB((SnapTune(freq, step, 1, RoundToStepSize).ToString("D11")));
        //                    }
        //                }
        //                break;
        //            }
        //        default:
        //            {

        //                if (msg == 127)
        //                {
        //                    commands.ZZFB((SnapTune(freq, step, -1, RoundToStepSize).ToString("D11")));
        //                }
        //                if (msg == 1)
        //                {
        //                    commands.ZZFB((SnapTune(freq, step, 1, RoundToStepSize).ToString("D11")));
        //                }
        //                break;
        //            }
        //    }
        //    commands.isMidi2 = false;
        //}

        //-W2PA Modified to select Behringer PL-1, Micro, or original code
        public void ChangeFreqVfoB(int msg, MidiDevice device)
        {
            bool RoundToStepSize = true;
            parser.nSet = 2;
            parser.nGet = 0;
            int mode;
            int direction = msg;
            if (int.TryParse(commands.ZZMD(""), out mode) == false)
                return;
            int step = StringToFreq(commands.ZZAC(""));
            parser.nSet = 11;
            long freq = Convert.ToInt64(commands.ZZFB(""));
            parser.nAns = 11;

            commands.isMidi2 = true;

            string devName = device.GetDeviceName();
            if (devName == "CMD PL-1")  //W2PA- Special handling for Behringer 
            {
                ProcessBehringerMainWheelAsVFO(direction, step, RoundToStepSize, freq, mode, "b", "CMD PL-1");
            }
            else if (devName == "CMD Micro")
            {
                ProcessBehringerMainWheelAsVFO(direction, step, RoundToStepSize, freq, mode, "b", "CMD Micro");
            }
            else if (devName.Contains("CMD"))
            {
                ProcessBehringerMainWheelAsVFO(direction, step, RoundToStepSize, freq, mode, "b", "CMD");
            }
            else
            {
                ProcessStdMIDIWheelAsVFO(direction, step, RoundToStepSize, freq, mode, "b");
            }

            commands.isMidi2 = false;
        }


        public CmdState BinauralOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int BINState = Convert.ToInt16(commands.ZZBI(""));

                if (BINState == 0)
                {
                    commands.ZZBI("1");
                    return CmdState.On;
                }
                if (BINState == 1)
                {
                    commands.ZZBI("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState MuteOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int MuteState = Convert.ToInt16(commands.ZZMA(""));

                if (MuteState == 0)
                {
                    commands.ZZMA("1");
                    return CmdState.On;
                }
                if (MuteState == 1)
                {
                    commands.ZZMA("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState SpurReductionOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int SRState = Convert.ToInt16(commands.ZZSR(""));

                if (SRState == 0)
                {
                    commands.ZZSR("1");
                    return CmdState.On;
                }
                if (SRState == 1)
                {
                    commands.ZZSR("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }


        public CmdState NoiseReductionOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int NRState = Convert.ToInt16(commands.ZZNR(""));

                if (NRState == 0)
                {
                    commands.ZZNR("1");
                    return CmdState.On;
                }
                if (NRState == 1)
                {
                    commands.ZZNR("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState NoiseReduction2OnOff(int msg, MidiDevice device)  //-W2PA Corrected name to appropriate one for ZZNS
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int NRState = Convert.ToInt16(commands.ZZNS(""));

                if (NRState == 0)
                {
                    commands.ZZNS("1");
                    return CmdState.On;
                }
                if (NRState == 1)
                {
                    commands.ZZNS("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState Rx2NoiseReductionOnOff(int msg, MidiDevice device)  //-W2PA Corrected to calling ZZNV instead of ZZNS as above
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                // DG8MG: Correction of the NRState query, replaced ZZNS by ZZNV. Old incorrect version below.
                int NRState = Convert.ToInt16(commands.ZZNV(""));
                // int NRState = Convert.ToInt16(commands.ZZNS(""));
                // DG8MG

                if (NRState == 0)
                {
                    commands.ZZNV("1");
                    return CmdState.On;
                }
                if (NRState == 1)
                {
                    commands.ZZNV("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState Rx2NoiseReduction2OnOff(int msg, MidiDevice device)  //-W2PA Added function to call ZZNW
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                // DG8MG: Correction of the NRState query, replaced ZZNS by ZZNW. Old incorrect version below.
                int NRState = Convert.ToInt16(commands.ZZNW(""));
                // int NRState = Convert.ToInt16(commands.ZZNS(""));
                // DG8MG

                if (NRState == 0)
                {
                    commands.ZZNW("1");
                    return CmdState.On;
                }
                if (NRState == 1)
                {
                    commands.ZZNW("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState Rx2PreAmpOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int PreAmpState = Convert.ToInt16(commands.ZZPB(""));

                    if (PreAmpState == 0)
                    {
                        commands.ZZPB("1");
                        return CmdState.On;
                    }
                    if (PreAmpState == 1)
                    {
                        commands.ZZPB("0");
                        return CmdState.Off;
                    }
                }
                catch
                {
                    return CmdState.NoChange;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState VfoSyncOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int SyncState = Convert.ToInt16(commands.ZZSY(""));

                if (SyncState == 0)
                {
                    commands.ZZSY("1");
                    return CmdState.On;
                }
                if (SyncState == 1)
                {
                    commands.ZZSY("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState SplitOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int SplitState = Convert.ToInt16(commands.ZZSP(""));

                if (SplitState == 0)
                {
                    commands.ZZSP("1");
                    return CmdState.On;
                }
                if (SplitState == 1)
                {
                    commands.ZZSP("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState MOXOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int MOXState = Convert.ToInt16(commands.ZZTX(""));

                if (MOXState == 0)
                {
                    commands.ZZTX("1");
                    return CmdState.On;
                }
                if (MOXState == 1)
                {
                    commands.ZZTX("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState VOXOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int VOXState = Convert.ToInt16(commands.ZZVE(""));

                if (VOXState == 0)
                {
                    commands.ZZVE("1");
                    return CmdState.On;
                }
                if (VOXState == 1)
                {
                    commands.ZZVE("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState CompanderOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int CMPRState = Convert.ToInt16(commands.ZZCP(""));

                if (CMPRState == 0)
                {
                    commands.ZZCP("1");
                    return CmdState.On;
                }
                if (CMPRState == 1)
                {
                    commands.ZZCP("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState StereoDiversityOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int DXState = Convert.ToInt16(commands.ZZDX(""));

                if (DXState == 0)
                {
                    commands.ZZDX("1");
                    return CmdState.On;
                }
                if (DXState == 1)
                {
                    commands.ZZDX("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState DEXPOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int DEXPState = Convert.ToInt16(commands.ZZGE(""));

                if (DEXPState == 0)
                {
                    commands.ZZGE("1");
                    return CmdState.On;
                }
                if (DEXPState == 1)
                {
                    commands.ZZGE("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState RX2OnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int RX2State = Convert.ToInt16(commands.ZZRS(""));
                    if (RX2State == 0)
                    {
                        commands.ZZRS("1");
                        return CmdState.On;
                    }
                    if (RX2State == 1)
                    {
                        commands.ZZRS("0");
                        return CmdState.Off;
                    }
                }
                catch
                {
                    return CmdState.NoChange;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState StartOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;
                try
                {
                    int StartState = Convert.ToInt16(commands.ZZPS(""));

                    parser.nSet = 1;

                    if (StartState == 0)
                    {
                        commands.ZZPS("1");
                        return CmdState.On;
                    }
                    if (StartState == 1)
                    {
                        commands.ZZPS("0");
                        return CmdState.Off;
                    }
                }
                catch
                {
                    return CmdState.NoChange;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState TunerOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int TunerState = Convert.ToInt16(commands.ZZOV(""));

                    if (TunerState == 0)
                    {
                        commands.ZZOV("1");
                        return CmdState.On;
                    }
                    if (TunerState == 1)
                    {
                        commands.ZZOV("0");
                        return CmdState.Off;
                    }
                }
                catch
                {
                    return CmdState.NoChange;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState TunOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int TunerState = Convert.ToInt16(commands.ZZTU(""));

                    if (TunerState == 0)
                    {
                        commands.ZZTU("1");
                        return CmdState.On;
                    }
                    if (TunerState == 1)
                    {
                        commands.ZZTU("0");
                        return CmdState.Off;
                    }
                }
                catch
                {
                    return CmdState.NoChange;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState TunerBypassOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int TunerState = Convert.ToInt16(commands.ZZOW(""));

                    if (TunerState == 0)
                    {
                        commands.ZZOW("1");
                        return CmdState.On;
                    }
                    if (TunerState == 1)
                    {
                        commands.ZZOW("0");
                        return CmdState.Off;
                    }
                }
                catch
                {
                    return CmdState.NoChange;
                }
            }
            return CmdState.NoChange;
        }


        public void ZeroBeatPress(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                commands.ZZZB();
            }
        }

        public void BandUp(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 0;

                try
                {
                    commands.ZZBU();
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void BandDown(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 0;

                try
                {
                    commands.ZZBD();
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Rx2BandUp(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 0;

                try
                {
                    commands.ZZBA();
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Rx2BandDown(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 0;

                try
                {
                    commands.ZZBB();
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void PreAmpSettingsKnob(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 1;

            try
            {
                switch (Convert.ToInt16(commands.ZZFM()))
                {
                    case 0: // HPSDR HERMES ANAN10
                        {
                            if ((msg >= 0) && (msg < 64))
                            {
                                commands.ZZPA("1");
                                return;
                            }
                            if ((msg >= 64) && (msg < 128))
                            {
                                commands.ZZPA("0");
                                return;
                            }
                            break;
                        }
                    case 1: // w/ALEX ANAN100/D
                        {
                            if ((msg >= 0) && (msg < 16))
                            {
                                commands.ZZPA("1");
                                return;
                            }
                            if ((msg >= 16) && (msg < 32))
                            {
                                commands.ZZPA("0");
                                return;
                            }
                            if ((msg >= 32) && (msg < 48))
                            {
                                commands.ZZPA("2");
                                return;
                            }
                            if ((msg >= 48) && (msg < 64))
                            {
                                commands.ZZPA("3");
                                return;
                            }
                            if ((msg >= 64) && (msg < 80))
                            {
                                commands.ZZPA("4");
                                return;
                            }
                            if ((msg >= 80) && (msg < 96))
                            {
                                commands.ZZPA("5");
                                return;
                            }
                            if ((msg >= 112) && (msg < 128))
                            {
                                commands.ZZPA("6");
                                return;
                            }
                            break;
                        }
                    case 2: //ANAN10
                        {
                            if ((msg >= 0) && (msg < 32))
                            {
                                commands.ZZPA("0");
                                return;
                            }
                            if ((msg >= 32) && (msg < 64))
                            {
                                commands.ZZPA("1");
                                return;
                            }
                            if ((msg >= 64) && (msg < 96))
                            {
                                commands.ZZPA("2");
                                return;
                            }
                            if ((msg >= 96) && (msg < 128))
                            {
                                commands.ZZPA("3");
                                return;
                            }

                            break;
                        }
                    case 3: //ANAN100/D
                        {
                            if ((msg >= 0) && (msg < 25))
                            {
                                commands.ZZPA("0");
                                return;
                            }
                            if ((msg >= 25) && (msg < 51))
                            {
                                commands.ZZPA("1");
                                return;
                            }
                            if ((msg >= 51) && (msg < 77))
                            {
                                commands.ZZPA("2");
                                return;
                            }
                            if ((msg >= 77) && (msg < 102))
                            {
                                commands.ZZPA("3");
                                return;
                            }
                            if ((msg >= 102) && (msg < 128))
                            {
                                commands.ZZPA("4");
                                return;
                            }
                            break;
                        }
                }
            }
            catch
            {
                return;
            }
        }

        public void CWSpeed(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 2;

            try
            {
                if (msg != 0)
                {
                    double cwspeed = msg / 2.1333 + 1;
                    string a = cwspeed.ToString("00");
                    commands.ZZCS(cwspeed.ToString("00"));

                }
                return;
            }
            catch
            {
                return;
            }
        }

        public void CWSpeed_inc(int msg, MidiDevice device) //-W2PA Added a CW speed increment for Behringer mini-wheel knobs
        {
            parser.nGet = 0;
            parser.nSet = 2;

            try
            {
                if (msg == 63 || msg == 65 )
                {
                    Int32 cwspeed = Convert.ToInt32(commands.ZZCS(""));
                    if (msg == 65 && cwspeed < 60) cwspeed++;
                    if (msg == 63 && cwspeed > 1 ) cwspeed--;
                    commands.ZZCS(cwspeed.ToString("00"));
                    return;
                }
                return;
            }
            catch
            {
                return;
            }
        }

        //-W2PA Added knob/slider control of APF Tune
        public void APFFreq(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 1;

            try
            {
                double apffreq = ((msg * 3.937) - 250);

                if (apffreq >= 0)
                {
                    commands.ZZAT(apffreq.ToString("000"));
                }
                if (apffreq < 0)
                {
                    commands.ZZAT(apffreq.ToString("000"));
                }
                return;
            }
            catch
            {
                return;
            }
        }

        //-W2PA Added knob/slider control of APF Bandwidth
        public void APFBandwidth(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 3;

            try
            {
                double apfbw = ((msg * 1.1023) + 10);
                commands.ZZAB(apfbw.ToString("000"));                
                return;
            }
            catch
            {
                return;
            }
        }

        //-W2PA Added knob/slider control of APF Gain
        public void APFGain(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 4;

            try
            {
                double apfgain = ((msg * 0.7874) + 0);
                commands.ZZAA("+" + apfgain.ToString("000"));                
                return;
            }
            catch
            {
                return;
            }
        }

        public void AGCLevel(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 4;

            try
            {
                double agclevel;
                string devName = device.GetDeviceName();
                if (IsBehringerCMD(device))  //W2PA- Special handling for Behringer sliders
                {
                    agclevel = (( (127 - msg) * 1.099) - 20);
                }
                else agclevel = ((msg * 1.099) - 20);

                if (agclevel >= 0)
                {
                    commands.ZZAR("+" + agclevel.ToString("000"));
                }
                if (agclevel < 0)
                {
                    commands.ZZAR(agclevel.ToString("000"));
                }
                return;
            }
            catch
            {
                return;
            }
        }

        public void AGCLevel_inc(int msg, MidiDevice device)  //-W2PA Support for Behringer CMD PL-1 style wheel/knobs
        {
            parser.nGet = 0;
            parser.nSet = 4; 
            parser.nAns = 4;

            try
            {
                double agcMax = 120;
                double agcMin = -20;
                int currAGC = Convert.ToInt32(commands.ZZAR(""));

                if (msg == 127 || msg == 0) return; //-W2PA Ignore knob click presses

                if (msg < 64)
                {
                    if (currAGC > agcMin) currAGC--;
                }
                else if (msg > 64)
                {
                    if (currAGC < agcMax) currAGC++;
                }
                commands.ZZAR("+" + currAGC.ToString("000"));

                double setAGC = Convert.ToDouble(currAGC);

                int nLED = Convert.ToInt32(15.0 * (setAGC - agcMin) / (agcMax - agcMin));
                if (nLED < 1) nLED = 1;  //-W2PA Keep the last LED from going out.
                if (nLED > 15) nLED = 15;

            }
            catch
            {
                return;
            }
        }

        public void RX2AGCLevel(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 4;

            try
            {
                double agclevel;
                string devName = device.GetDeviceName();
                if (IsBehringerCMD(device))  //W2PA- Special handling for Behringer sliders
                {
                    agclevel = (( (127 - msg) * 1.099) - 20);
                }
                else agclevel = ((msg * 1.099) - 20);

                if (agclevel >= 0)
                {
                    commands.ZZAS("+" + agclevel.ToString("000"));
                }
                if (agclevel < 0)
                {
                    commands.ZZAS(agclevel.ToString("000"));
                }
                return;
            }
            catch
            {
                return;
            }
        }

        public void RX2AGCLevel_inc(int msg, MidiDevice device)  //-W2PA Support for Behringer CMD PL-1 wheel/knobs
        {
            parser.nGet = 0;
            parser.nSet = 4;  
            parser.nAns = 4;

            try
            {
                double agcMax = 120;
                double agcMin = -20;
                int currAGC = Convert.ToInt32(commands.ZZAS(""));

                if (msg == 127 || msg == 0) return; //-W2PA Ignore knob click presses

                if (msg < 64)
                {
                    if (currAGC > agcMin) currAGC--;
                }
                else if (msg > 64)
                {
                    if (currAGC < agcMax) currAGC++;
                }
                commands.ZZAS("+" + currAGC.ToString("000"));

                double setAGC = Convert.ToDouble(currAGC);

                int nLED = Convert.ToInt32(15.0 * (setAGC - agcMin) / (agcMax - agcMin));
                if (nLED < 1) nLED = 1;  //-W2PA Keep the last LED from going out.
                if (nLED > 15) nLED = 15;

            }
            catch
            {
                return;
            }
        }

        public void MicGain(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 3;
            parser.nAns = 3;

            try
            {
                double micgain = (msg / 1.82);
                string a = micgain.ToString("000");
                commands.ZZMG(micgain.ToString("000"));

            }
            catch
            {
                return;
            }
        }

        public void SquelchControl(int msg, MidiDevice device)
        {
            parser.nSet = 0;
            parser.nSet = 3;

            try
            {
                double sqlctrl = 160 - (msg * 1.26);
                commands.ZZSQ(sqlctrl.ToString("000"));
                return;
            }
            catch
            {
                return;
            }
        }

        public void CPDRLevel(int msg, MidiDevice device)
        {
            parser.nSet = 0;
            parser.nSet = 2;

            try
            {
                double cpdr = msg * 0.078;
                commands.ZZCT(cpdr.ToString("00"));
                return;
            }
            catch
            {
                return;
            }
        }

        public void DXLevel(int msg, MidiDevice device)
        {
            parser.nSet = 0;
            parser.nSet = 2;

            try
            {
                double dx = msg * 0.078;
                commands.ZZDY(dx.ToString("00"));
                return;
            }
            catch
            {
                return;
            }
        }

        public void VOXGain(int msg, MidiDevice device)
        {
            parser.nSet = 0;
            parser.nSet = 4;

            try
            {
                double vox = msg * 7.89;
                commands.ZZVG(vox.ToString("0000"));
                return;
            }
            catch
            {
                return;
            }
        }

        public void DEXPThreshold(int msg, MidiDevice device)
        {
            parser.nSet = 0;
            parser.nSet = 4;

            try
            {
                double dexp = -160 + (msg * 1.26);
                if (dexp < 0)
                {
                    commands.ZZGL(dexp.ToString("000"));
                    return;
                }
                else
                {
                    commands.ZZGL(dexp.ToString("0000"));
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        public void TXAFMonitor(int msg, MidiDevice device)
        {
            parser.nSet = 3;
            parser.nGet = 0;

            try
            {
                double txaf = msg * 0.787;
                commands.ZZTM(txaf.ToString("000"));
                return;
            }
            catch
            {
                return;
            }
        }

        public void DriveLevel(int msg, MidiDevice device)
        {
            parser.nSet = 3;
            parser.nGet = 0;

            try
            {
                double drive = msg * 0.787;
                commands.ZZPC(drive.ToString("000"));
                return;
            }
            catch
            {
                return;
            }
        }

        public void DriveLevel_inc(int msg, MidiDevice device)  //-W2PA Support for Behringer CMD PL-1 style wheel/knobs
        {
            parser.nGet = 0;
            parser.nSet = 3; 
            parser.nAns = 4;

            try
            {
                double drvMax = 100;
                double drvMin = 0;
                int currDrive = Convert.ToInt32(commands.ZZPC(""));

                if (msg == 127 || msg == 0) return; //-W2PA Ignore knob click presses

                if (msg < 64)
                {
                    if (currDrive > drvMin) currDrive--;
                }
                else if (msg > 64)
                {
                    if (currDrive < drvMax) currDrive++;
                }
                commands.ZZPC(currDrive.ToString("000"));

                double setDrive = Convert.ToDouble(currDrive);

                int nLED = Convert.ToInt32(15.0 * (setDrive - drvMin) / (drvMax - drvMin));
                if (nLED < 1) nLED = 1;  //-W2PA Keep the last LED from going out.
                if (nLED > 15) nLED = 15;

            }
            catch
            {
                return;
            }
        }


        //public void DriveLevel_incr(int msg, MidiDevice device)
        //{
        //    parser.nSet = 3;
        //    parser.nGet = 0;
        //    parser.nAns = 4;

        //    try
        //    {
        //        double drive = msg * 0.787;
        //        commands.ZZPC(drive.ToString("000"));
        //        return;
        //    }
        //    catch
        //    {
        //        return;
        //    }
        //}

        public CmdState RXEQOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int RXEQState = Convert.ToInt16(commands.ZZER(""));

                if (RXEQState == 0)
                {
                    commands.ZZER("1");
                    return CmdState.On;
                }
                if (RXEQState == 1)
                {
                    commands.ZZER("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState TXEQOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int TXEQState = Convert.ToInt16(commands.ZZET(""));

                if (TXEQState == 0)
                {
                    commands.ZZET("1");
                    return CmdState.On;
                }
                if (TXEQState == 1)
                {
                    commands.ZZET("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState SquelchOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int sql = Convert.ToInt16(commands.ZZSO(""));

                    if (sql == 0)
                    {
                        commands.ZZSO("1");
                        return CmdState.On;
                    }
                    if (sql == 1)
                    {
                        commands.ZZSO("0");
                        return CmdState.Off;
                    }
                }
                catch
                {
                    return CmdState.NoChange; ;
                }
            }
            return CmdState.NoChange;
        }

        public void AGCModeKnob(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 1;

            if ((msg >= 0) && (msg < 22))
            {
                commands.ZZGT("0");
                return;
            }
            if ((msg >= 22) && (msg < 43))
            {
                commands.ZZGT("1");
                return;
            }
            if ((msg >= 43) && (msg < 64))
            {
                commands.ZZGT("2");
                return;
            }
            if ((msg >= 64) && (msg < 85))
            {
                commands.ZZGT("3");
                return;
            }

            if ((msg >= 85) && (msg < 106))
            {
                commands.ZZGT("4");
                return;
            }

            if ((msg >= 106) && (msg < 128))
            {
                commands.ZZGT("5");
                return;
            }

        }

        public void AGCModeUp(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 1;

            if (msg == 127)
            {
                try
                {
                    int agcstate = Convert.ToInt16(commands.ZZGT(""));

                    if ((agcstate > 0) && (agcstate <= 5))
                    {
                        agcstate = agcstate - 1;
                        commands.ZZGT(agcstate.ToString("0"));
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        public void AGCModeDown(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 1;

            if (msg == 127)
            {
                try
                {
                    int agcstate = Convert.ToInt16(commands.ZZGT(""));

                    if ((agcstate >= 0) && (agcstate < 5))
                    {
                        agcstate = agcstate + 1;
                        commands.ZZGT(agcstate.ToString("0"));
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        public void PreampFlex5000(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 1;

            if (msg == 127)
            {
                try
                {
                    if (commands.ZZFM() == "1") //check if TRX = Flex5000
                    {
                        if (commands.ZZPA("") == "0")
                        {
                            commands.ZZPA("1");
                            return;
                        }

                        if (commands.ZZPA("") == "1")
                        {
                            commands.ZZPA("0");
                            return;
                        }
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        public void DisplayAverage(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int avg = Convert.ToInt16(commands.ZZDA(""));

                    if (avg == 0)
                    {
                        commands.ZZDA("1");
                        return;
                    }
                    if (avg == 1)
                    {
                        commands.ZZDA("0");
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        public void DisplayPeak(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int avg = Convert.ToInt16(commands.ZZPO(""));

                    if (avg == 0)
                    {
                        commands.ZZPO("1");
                        return;
                    }
                    if (avg == 1)
                    {
                        commands.ZZPO("0");
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        public void DisplayTxFilter(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int txf = Convert.ToInt16(commands.ZZTF(""));

                    if (txf == 0)
                    {
                        commands.ZZTF("1");
                        return;
                    }
                    if (txf == 1)
                    {
                        commands.ZZTF("0");
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        public CmdState VACOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int vac = Convert.ToInt16(commands.ZZVA(""));

                    if (vac == 0)
                    {
                        commands.ZZVA("1");
                        return CmdState.On;
                    }
                    if (vac == 1)
                    {
                        commands.ZZVA("0");
                        return CmdState.Off;
                    }
                }
                catch
                {
                    return CmdState.NoChange;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState VAC2OnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int vac2 = Convert.ToInt16(commands.ZZVK(""));

                    if (vac2 == 0)
                    {
                        commands.ZZVK("1");
                        return CmdState.On;
                    }
                    if (vac2 == 1)
                    {
                        commands.ZZVK("0");
                        return CmdState.Off;
                    }
                }
                catch
                {
                    return CmdState.NoChange;
                }
            }
            return CmdState.NoChange;
        }

        public void IQtoVAC(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int iq = Convert.ToInt16(commands.ZZVH(""));

                    if (iq == 0)
                    {
                        commands.ZZVH("1");
                        return;
                    }
                    if (iq == 1)
                    {
                        commands.ZZVH("0");
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        public void IQtoVACRX2(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int iq = Convert.ToInt16(commands.ZZVJ(""));
                    int vac2 = Convert.ToInt16(commands.ZZVH(""));

                    if (iq == 0)
                    {
                        commands.ZZVH("1");
                        commands.ZZVJ("1");
                        return;
                    }
                    if (iq == 1)
                    {
                        commands.ZZVJ("0");
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }
        }


        public void DisplayModePrev(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int dpm = Convert.ToInt16(commands.ZZDM(""));

                    if ((dpm > 0) && (dpm <= 7))
                    {
                        dpm = dpm - 1;
                        commands.ZZDM(dpm.ToString("0"));
                        return;
                    }

                    if ((dpm == 9)) //workaround Bug #3661
                    {
                        dpm = 6;
                        commands.ZZDM(dpm.ToString("0"));
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        public void DisplayModeNext(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int dpm = Convert.ToInt16(commands.ZZDM(""));

                    if ((dpm >= 0) && (dpm < 7))
                    {
                        dpm = dpm + 1;
                        commands.ZZDM(dpm.ToString("0"));
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        public void ZoomDec(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int zoom = Convert.ToInt16(commands.ZZPZ(""));
                    int zoomf = Convert.ToInt16(commands.ZZPY(""));
                    //if ((zoomf >= 10) && (zoomf <= 49))
                    //{
                    //    commands.ZZPZ("0");
                    //    return;
                    //}
                    if ((zoomf >= 51) && (zoomf <= 150))
                    {
                        commands.ZZPZ("0");
                        return;
                    }
                    if ((zoomf >= 151) && (zoomf <= 200))
                    {
                        commands.ZZPZ("1");
                        return;
                    }
                    if ((zoomf >= 201) && (zoomf <= 225))
                    {
                        commands.ZZPZ("2");
                        return;
                    }
                    if ((zoomf >= 226) && (zoomf <= 240))
                    {
                        commands.ZZPZ("3");
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        public void ZoomInc(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    int zoom = Convert.ToInt16(commands.ZZPZ(""));
                    int zoomf = Convert.ToInt16(commands.ZZPY("")); //check slider position and select closest step

                    if ((zoomf >= 10) && (zoomf <= 49))
                    {
                        commands.ZZPZ("0"); //050
                        return;
                    }
                    if ((zoomf >= 50) && (zoomf <= 149))
                    {
                        commands.ZZPZ("1"); //150
                        return;
                    }
                    if ((zoomf >= 150) && (zoomf <= 199))
                    {
                        commands.ZZPZ("2"); //200
                        return;
                    }
                    if ((zoomf >= 200) && (zoomf <= 225))
                    {
                        commands.ZZPZ("3"); //225
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        //public void ZoomSliderFix(int msg, MidiDevice device)
        //{
        //    parser.nGet = 0;
        //    parser.nSet = 3;

        //    double zoom = (msg * 1.797) + 10;
        //    commands.ZZPY(zoom.ToString("000"));
        //    return;
        //}

        public void ZoomSliderInc(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 3;

            try
            {
                int zoom = Convert.ToInt16(commands.ZZPY(""));
                if ((msg == 127) && (zoom >= 15))
                {
                    zoom = zoom - 5;
                    commands.ZZPY(zoom.ToString("000"));
                    return;
                }
                if ((msg == 1) && (zoom <= 235))
                {
                    zoom = zoom + 5;
                    commands.ZZPY(zoom.ToString("000"));
                    return;
                }
            }
            catch
            {
                return;
            }
        }


        public void PanSliderInc(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 4;

            try
            {
                int pan = Convert.ToInt16(commands.ZZPE(""));
                if ((msg == 127) && (pan >= 50))
                {
                    pan = pan - 25;
                    commands.ZZPE(pan.ToString("0000"));
                    return;
                }
                if ((msg == 1) && (pan <= 235))
                {
                    pan = pan + 25;
                    commands.ZZPE(pan.ToString("0000"));
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        public void PanSlider(int msg, MidiDevice device)
        {
            try
            {
                parser.nSet = 4;
                parser.nGet = 0;

                double PanValue = msg * 7.87;
                commands.ZZPE(PanValue.ToString("0000"));
                return;
            }
            catch
            {
                return;
            }
        }


        public CmdState SpectralNoiseBlankerOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int Rx1SNBState = Convert.ToInt16(commands.ZZNN(""));

                if (Rx1SNBState == 0)
                {
                    commands.ZZNN("1");
                    return CmdState.On;
                }
                if (Rx1SNBState == 1)
                {
                    commands.ZZNN("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState SpectralNoiseBlankerRx2OnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int Rx2SNBState = Convert.ToInt16(commands.ZZNO(""));

                if (Rx2SNBState == 0)
                {
                    commands.ZZNO("1");
                    return CmdState.On;
                }
                if (Rx2SNBState == 1)
                {
                    commands.ZZNO("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public void QuickModeSave(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    commands.ZZQS();
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void CWXMacro1(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    commands.ZZKM("1");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void CWXMacro2(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    commands.ZZKM("2");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void CWXMacro3(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    commands.ZZKM("3");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void CWXMacro4(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    commands.ZZKM("4");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void CWXMacro5(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    commands.ZZKM("5");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void CWXMacro6(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    commands.ZZKM("6");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void CWXMacro7(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    commands.ZZKM("7");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void CWXMacro8(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    commands.ZZKM("8");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void CWXMacro9(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    commands.ZZKM("9");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void CWXStop(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    commands.ZZSS();
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public CmdState MONOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int MONState = Convert.ToInt16(commands.ZZMO(""));

                if (MONState == 0)
                {
                    commands.ZZMO("1");
                    return CmdState.On;
                }
                if (MONState == 1)
                {
                    commands.ZZMO("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public void PanCenter(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    commands.ZZPD();
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void QuickModeRestore(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                try
                {
                    commands.ZZQR();
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void ZoomSliderFix(int msg, MidiDevice device)
        {
            try
            {
                parser.nSet = 3;
                parser.nGet = 0;

                double ZoomValue = msg * 1.88;
                commands.ZZPY(ZoomValue.ToString("000"));
                return;
            }
            catch
            {
                return;
            }
        }

        public void FilterHigh(int msg, MidiDevice device)
        {
            int tuningstep = 20;

            string devName = device.GetDeviceName();
            if (IsBehringerCMD(device)) //W2PA- Special handling for Behringer
            {
                //-W2PA Map to what it expects for the Hercules, as originally written
                if (msg == 63) msg = 127;
                if (msg == 65) msg = 1;
            }

                try
            {
                parser.nGet = 0;
                parser.nSet = 2;

                string s = commands.ZZMD("");
                int mode = Convert.ToInt32(s);

                if ((mode == 3) || (mode == 4) || (mode == 7) || (mode == 8) || (mode == 9))
                {
                    tuningstep = 20;
                }
                else
                {
                    tuningstep = 50;
                }
            }
            catch
            {
                return;
            }

            try
            {

                parser.nSet = 5;
                parser.nGet = 0;
                parser.nAns = 5;

                string s = commands.ZZFH("");

                int UpperEdge = Convert.ToInt32(s);


                if ((msg == 1) && (UpperEdge >= 0))
                {
                    UpperEdge = UpperEdge + tuningstep;
                    commands.ZZFH(UpperEdge.ToString("00000"));
                    return;
                }

                if ((msg == 1) && (UpperEdge < 0))
                {
                    if (UpperEdge > (-tuningstep - 1))
                    {
                        UpperEdge = UpperEdge + tuningstep;
                        commands.ZZFH(UpperEdge.ToString("00000"));
                        return;
                    }
                    else
                    {
                        UpperEdge = UpperEdge + tuningstep;
                        commands.ZZFH(UpperEdge.ToString("0000"));
                        return;
                    }
                }

                if ((msg == 127) && (UpperEdge >= 0))
                {
                    if (UpperEdge < tuningstep)
                    {
                        UpperEdge = UpperEdge - tuningstep;
                        commands.ZZFH(UpperEdge.ToString("0000"));
                        return;
                    }
                    else
                    {
                        UpperEdge = UpperEdge - tuningstep;
                        commands.ZZFH(UpperEdge.ToString("00000"));
                        return;
                    }
                }

                if ((msg == 127) && (UpperEdge < 0))
                {
                    UpperEdge = UpperEdge - tuningstep;
                    commands.ZZFH(UpperEdge.ToString("0000"));
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        public void FilterLow(int msg, MidiDevice device)
        {
            int tuningstep = 20;

            string deviceName = device.GetDeviceName();
            if (IsBehringerCMD(device))  //-W2PA special handling for Behringer wheel style knobs
            {
                //-W2PA Map to what it expects for the Hercules, as originally written
                if (msg == 63) msg = 127;
                if (msg == 65) msg = 1;
            }

            try
            {
                parser.nGet = 0;
                parser.nSet = 2;

                string s = commands.ZZMD("");
                int mode = Convert.ToInt32(s);

                if ((mode == 3) || (mode == 4) || (mode == 7) || (mode == 8) || (mode == 9))
                {
                    ; // tuningstep = tuningstep;
                }
                else
                {
                    tuningstep = 50;
                }
            }
            catch
            {
                return;
            }

            try
            {

                parser.nSet = 5;
                parser.nGet = 0;
                parser.nAns = 5;

                string s = commands.ZZFL("");

                int LowerEdge = Convert.ToInt32(s);


                if ((msg == 1) && (LowerEdge >= 0))
                {
                    LowerEdge = LowerEdge + tuningstep;
                    commands.ZZFL(LowerEdge.ToString("00000"));
                    return;
                }

                if ((msg == 1) && (LowerEdge < 0))
                {
                    if (LowerEdge > (-tuningstep - 1))
                    {
                        LowerEdge = LowerEdge + tuningstep;
                        commands.ZZFL(LowerEdge.ToString("00000"));
                        return;
                    }
                    else
                    {
                        LowerEdge = LowerEdge + tuningstep;
                        commands.ZZFL(LowerEdge.ToString("0000"));
                        return;
                    }
                }

                if ((msg == 127) && (LowerEdge >= 0))
                {
                    if (LowerEdge < tuningstep)
                    {
                        LowerEdge = LowerEdge - tuningstep;
                        commands.ZZFL(LowerEdge.ToString("0000"));
                        return;
                    }
                    else
                    {
                        LowerEdge = LowerEdge - tuningstep;
                        commands.ZZFL(LowerEdge.ToString("00000"));
                        return;
                    }
                }

                if ((msg == 127) && (LowerEdge < 0))
                {
                    LowerEdge = LowerEdge - tuningstep;
                    commands.ZZFL(LowerEdge.ToString("0000"));
                    return;
                }
            }
            catch
            {
                return;
            }

        }

        public void VACGainRX(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 3;

            try
            {
                int vac = (int)((msg - 63) * 0.64);
                commands.ZZVB(vac.ToString("000;-00;000"));
                return;

            }
            catch
            {
                return;
            }
        }

        public void VACGainTX(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 3;

            try
            {
                int vac = (int)((msg - 63) * 0.64);
                commands.ZZVC(vac.ToString("000;-00;000"));
                return;

            }
            catch
            {
                return;
            }
        }


        public void VAC2GainRX(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 3;

            try
            {
                int vac = (int)((msg - 63) * 0.64);
                commands.ZZVW(vac.ToString("000;-00;000"));
                return;

            }
            catch
            {
                return;
            }
        }

        public void VAC2GainTX(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 3;

            try
            {
                int vac = (int)((msg - 63) * 0.64);
                commands.ZZVX(vac.ToString("000;-00;000"));
                return;

            }
            catch
            {
                return;
            }
        }



        //public void ESCOnOff(int msg, MidiDevice device)
        //{
        //    if (msg == 127)
        //    {
        //        parser.nGet = 0;
        //        parser.nSet = 1;

        //        int ESC = Convert.ToInt16(commands.ZZDE(""));

        //        if (ESC == 0)
        //        {
        //            commands.ZZDE("1");
        //            return;
        //        }
        //        if (ESC == 1)
        //        {
        //            commands.ZZDE("0");
        //            return;
        //        }
        //    }
        //}

        public CmdState CTunOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int ESC = Convert.ToInt16(commands.ZZCN(""));

                if (ESC == 0)
                {
                    commands.ZZCN("1");
                    return CmdState.On;
                }
                if (ESC == 1)
                {
                    commands.ZZCN("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public CmdState ESCFormOnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int ESC = Convert.ToInt16(commands.ZZDF(""));

                if (ESC == 0)
                {
                    commands.ZZDF("1");
                    return CmdState.On;
                }
                if (ESC == 1)
                {
                    commands.ZZDF("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public void WaterfallLowLimit(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 4;

            try
            {
                int wf = (int)((msg - 63) * 3.125);
                commands.ZZDN(wf.ToString("0000;-000;0000"));
                commands.ZZDQ(wf.ToString("0000;-000;0000"));
                return;

            }
            catch
            {
                return;
            }
        }

        public void WaterfallHighLimit(int msg, MidiDevice device)
        {
            parser.nGet = 0;
            parser.nSet = 4;

            try
            {
                int wf = (int)((msg - 63) * 3.125);
                commands.ZZDO(wf.ToString("0000;-000;0000"));
                commands.ZZDP(wf.ToString("0000;-000;0000"));
                return;

            }
            catch
            {
                return;
            }
        }

        public CmdState MuteRX2OnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int MuteState = Convert.ToInt16(commands.ZZMB(""));

                if (MuteState == 0)
                {
                    commands.ZZMB("1");
                    return CmdState.On;
                }
                if (MuteState == 1)
                {
                    commands.ZZMB("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public void Band160m(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBS("160");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band80m(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBS("080");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band60m(int msg, MidiDevice device) //not yet implemented PSDR 2.4.4
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBS("060");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band40m(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBS("040");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band30m(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBS("030");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band20m(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBS("020");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }


        public void Band17m(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBS("017");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band15m(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBS("015");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band12m(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBS("012");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band10m(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBS("010");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band6m(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBS("006");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band2m(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBS("002");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band160mRX2(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBT("160");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band80mRX2(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBT("080");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band60mRX2(int msg, MidiDevice device) //not yet implemented PSDR 2.4.4
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBT("060");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }


        public void Band40mRX2(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBT("040");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band30mRX2(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBT("030");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band20mRX2(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBT("020");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }


        public void Band17mRX2(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBT("017");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band15mRX2(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBT("015");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band12mRX2(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBT("012");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band10mRX2(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBT("010");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band6mRX2(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBT("006");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void Band2mRX2(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 3;

                try
                {
                    commands.ZZBT("002");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void ModeSSB(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;
                parser.nAns = 3;

                int band = 0;

                try
                {
                    band = Convert.ToInt16(commands.ZZBS(""));
                }
                catch
                {
                    band = 0;
                }

                parser.nGet = 0;
                parser.nSet = 2;
                parser.nAns = 2;

                try
                {
                    if (band >= 40) commands.ZZMD("00");
                    if (band < 40) commands.ZZMD("01");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void ModeLSB(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;

                try
                {
                    commands.ZZMD("00");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }
        public void ModeUSB(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;

                try
                {
                    commands.ZZMD("01");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void ModeDSB(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;

                try
                {
                    commands.ZZMD("02");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void ModeCW(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;

                try
                {
                    commands.ZZMD("01");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void ModeCWL(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;

                try
                {
                    commands.ZZMD("03");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void ModeCWU(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;

                try
                {
                    commands.ZZMD("04");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void ModeFM(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;

                try
                {
                    commands.ZZMD("05");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void ModeAM(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;

                try
                {
                    commands.ZZMD("06");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void ModeDIGU(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;

                try
                {
                    commands.ZZMD("07");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }


        public void ModeSPEC(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;

                try
                {
                    commands.ZZMD("08");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void ModeDIGL(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;

                try
                {
                    commands.ZZMD("09");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void ModeSAM(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;

                try
                {
                    commands.ZZMD("10");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }


        public void ModeDRM(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;

                try
                {
                    commands.ZZMD("11");
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void MoveVFOADown100Khz(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;

                try
                {
                    commands.ZZAD("11");  //-W2PA 11 indicates 100kHz, 10 indicates 10kHz (as originally coded)
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        public void MoveVFOAUp100Khz(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 2;

                try
                {
                    commands.ZZAU("11");  //-W2PA 11 indicates 100kHz, 10 indicates 10kHz (as originally coded)
                    return;
                }
                catch
                {
                    return;
                }
            }
        }

        // DG8MG
        // Extension for Charly 25 and HAMlab hardware
        public void MoveCurrentVFODownByTuneStep(int msg, MidiDevice device)
        {
            parser.nSet = 2;
            parser.nGet = 0;
            int step = StringToFreq(commands.ZZAC(""));

            if (msg == 127)
            {
                if (IsBehringerCMD(device))
                {
                    ChangeFreqVfoA(63, step, true, device);
                }
                else
                {
                    ChangeFreqVfoA(127, step, true, device);
                }
            }
            else
            {
                long freq = 0;
                
                msg = msg * msg;
                commands.isMidi = true;
                parser.nSet = 11;

                if (MidiDevice.VFOSelect == 0)
                {
                    freq = Convert.ToInt64(commands.ZZFA(""));
                    commands.ZZFA((freq - msg * step).ToString("D11"));
                }
                else
                {
                    freq = Convert.ToInt64(commands.ZZFB(""));
                    commands.ZZFB((freq - msg * step).ToString("D11"));
                }

                commands.isMidi = false;
            }
        }

        public void MoveCurrentVFOUpByTuneStep(int msg, MidiDevice device)
        {
            parser.nSet = 2;
            parser.nGet = 0;
            int step = StringToFreq(commands.ZZAC(""));

            if (msg == 127)
            {
                if (IsBehringerCMD(device))
                {
                    ChangeFreqVfoA(65, step, true, device);
                }
                else
                {
                    ChangeFreqVfoA(1, step, true, device);
                }
            }
            else
            {
                long freq = 0;

                msg = msg * msg;
                commands.isMidi = true;
                parser.nSet = 11;

                if (MidiDevice.VFOSelect == 0)
                {
                    freq = Convert.ToInt64(commands.ZZFA(""));
                    commands.ZZFA((freq + msg * step).ToString("D11"));
                }
                else
                {
                    freq = Convert.ToInt64(commands.ZZFB(""));
                    commands.ZZFB((freq + msg * step).ToString("D11"));
                }

                commands.isMidi = false;
            }
        }

        public CmdState C25FrontpanelMenu_OnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int MenuState = Convert.ToInt16(commands.ZZFP(""));

                if (MenuState == 0)
                {
                    Charly25SendUpdateToMidi(CatCmd.C25FrontpanelMenu_OnOff, 1);
                    commands.ZZFP("1");
                    return CmdState.On;
                }
                if (MenuState == 1)
                {
                    Charly25SendUpdateToMidi(CatCmd.C25FrontpanelMenu_OnOff, 0);
                    commands.ZZFP("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }
        // DG8MG

        public CmdState APF_OnOff(int msg, MidiDevice device)
        {
            if (msg == 127)
            {
                parser.nGet = 0;
                parser.nSet = 1;

                int APFState = Convert.ToInt16(commands.ZZAP(""));

                if (APFState == 0)
                {
                    commands.ZZAP("1");
                    return CmdState.On;
                }
                if (APFState == 1)
                {
                    commands.ZZAP("0");
                    return CmdState.Off;
                }
            }
            return CmdState.NoChange;
        }

        public void ToggleVFOWheel(int msg, MidiDevice device)  //-W2PA Switch main PL-1 wheel function from VFO A to B
        {
            if (MidiDevice.VFOSelect == 0)
            {
                MidiDevice.VFOSelect = 1;
                return;
            }
            else if (MidiDevice.VFOSelect == 1)
            {
                MidiDevice.VFOSelect = 2;
                device.SetPL1ButtonLight(0);

                // DG8MG
                // Extension for Charly 25 frontpanel hardware
                Charly25SendUpdateToMidi(CatCmd.ToggleVFOWheel, 1);
                // DG8MG

                return;
            }
            else if (MidiDevice.VFOSelect == 2)
            {
                MidiDevice.VFOSelect = 3;
                return;
            }
            else
            {
                MidiDevice.VFOSelect = 0;
                device.SetPL1ButtonLight(1);

                // DG8MG
                // Extension for Charly 25 frontpanel hardware
                Charly25SendUpdateToMidi(CatCmd.ToggleVFOWheel, 0);
                // DG8MG
            }
            return;
        }

        #endregion

    }
}
