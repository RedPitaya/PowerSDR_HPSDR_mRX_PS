/*  Midi2Cat

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

Modifications to support the Behringer CMD PL-1 controller
by Chris Codella, W2PA, Feb 2017.  Indicated by //-W2PA comment lines.

*/

//
// Charly 25, HAMlab and STEMlab SDR Modifications Copyright (C) 2016 - 2019 Markus Grundner / DG8MG
//

using System;
using System.Threading;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using Midi2Cat.IO;
using Midi2Cat.Data;
using System.Reflection;

namespace Midi2Cat
{
    public class MidiMessageManager
    {
        public string DbFile { get; set; }

        Midi2CatDatabase DB = null;
        object midi_handler_lock = new object();
        Dictionary<int, ControllerBinding> bindings = new Dictionary<int, ControllerBinding>();
        //PowerSDR.DJConsole djConsole;
        Object midi2CatCommands;

        public MidiMessageManager(Object Midi2CatCommands, string DbFile)
        {
            this.midi2CatCommands = Midi2CatCommands;
            this.DbFile = DbFile;
        }

        public void Open() 
        {
            if (bindings.Count > 0)
            {
                Close();
            }

            MidiDevices devices = new MidiDevices();
            DB = new Midi2CatDatabase(DbFile);
            int Idx=0;
            foreach (string inDevice in devices.InDevices)
            {
                // see if we can find settings for this device
                List<ControllerMapping> mappings = DB.GetMappings(inDevice, MappingFilter.Active); 
                if (mappings.Count > 0)
                {
                    InitDevice(inDevice, mappings, Idx);
                }
                Idx++;
            }
        }

        public void Close()
        {
            foreach( var binding in bindings.Values)
            {
                // DG8MG
                // Extension for Charly 25 frontpanel hardware
                if (binding.DeviceName == "Arduino Micro")
                {
                    DB.SaveChanges(binding.DeviceName);
                }
                // DG8MG

                binding.Device.CloseMidiIn();
                binding.Device.CloseMidiOut();
            }
            bindings.Clear();
        }

        public MidiDevice PL1Device()
        {
            if (bindings.Count == 0) return null;
            int index = 0;

            foreach (var binding in bindings.Values)
            {
                if (binding.DeviceName == "CMD PL-1") index = binding.DeviceIndex;
                break;
            }

            MidiDevice device = bindings[index].Device;
            return device;
        }

        public int PL1Index() //-W2PA Used to get the index of the PL-1.  Assumes only one is connected.
        {
            if (bindings.Count == 0) return -1;
            int index = -1;

            foreach (var binding in bindings.Values)
            {
                if (binding.DeviceName == "CMD PL-1")
                {
                    index = binding.DeviceIndex;
                    break;
                }
            }
            return index;
        }

        public void SendUpdateToMidi(CatCmd cmd, double pct)  //-W2PA Send Pl-1 knob or slider LED update message (CMD Micro doesn't have such LEDs)
        {
            int index = PL1Index(); 
            if (index < 0) return;  // no Behringer PL-1 is connected so no need to do anything

            ControllerMapping mapping;
            mapping = DB.GetReverseMapping(bindings[index].DeviceName, cmd);

            MidiDevice device = bindings[index].Device;

            if (mapping != null)
            {
                int ctlID = mapping.MidiControlId;
                int n = Convert.ToInt32(16.0 * pct);
                if (ctlID == 73) device.SetPL1KnobLight(n, 10); // If it's actually the slider, its LEDs need ctlID=10
                else device.SetPL1KnobLight(n, ctlID);  // All other Pl-1 knobs
            }

            return;
        }

        // DG8MG
        // Extension for Charly 25 frontpanel hardware
        // Used to get the index of Charly 25 frontpanel
        public int C25FrontpanelIndex()
        {
            if (bindings.Count == 0) return -1;
            int index = -1;

            foreach (var binding in bindings.Values)
            {
                if (binding.DeviceName == "Arduino Micro")
                {
                    index = binding.DeviceIndex;
                    break;
                }
            }
            return index;
        }

        public bool C25SendUpdateToMidi(CatCmd cmd, int state)
		{
            int index = -1;
            List<ControllerMapping> mappings = null;

            // Get the MIDI controller index of the Charly 25 frontpanel
            index = C25FrontpanelIndex();

            // If no Charly 25 frontpanel is present, tell the caller that no frontpanel is connected
            if (index < 0) return false;

            MidiDevice device = bindings[index].Device;

            // Get all button mappings of the Charly 25 frontpanel
            mappings = DB.C25FrontpanelGetButtonMappings();

            // If no mappings are given, return and tell the caller that a frontpanel is connected
            if (mappings != null)
            {
                int midiCtlID = -1;

                // There's a CAT command given which must be updated, so find the related button
                foreach(ControllerMapping mapping in mappings)
                {
                    if (mapping.CatCmd.CatCommandId.ToString() == cmd.ToString())
                    {
                        midiCtlID = mapping.MidiControlId;
                        break;
                    }
                }

                // If a mapped button was found continue
                if (midiCtlID != -1)
                {
                    try
                    {
                        // Check if the button is located on the virtual second level of the frontpanel
                        if (midiCtlID > 15)
                        {
                            ControllerMapping first_level_mapping = DB.GetMapping(device.GetDeviceName(), midiCtlID - 16);
                            ControllerMapping second_level_mapping = DB.GetMapping(device.GetDeviceName(), midiCtlID);

                            // Check if the LED must be switched off
                            if (state == 0)
                            {
                                // Save the state of the virtual button on the second level
                                second_level_mapping.MidiOutCmdSetValue = "BS00";
                                DB.UpdateOrAdd(device.GetDeviceName(), second_level_mapping);
                                
                                // Check if there is a CAT command mapped on the virtual first level of this button and the LED on the first level is switched on
                                if (first_level_mapping != null && first_level_mapping.MidiOutCmdSetValue == "BS01")
                                {
                                    // Redefine the state for the LED's on the button
                                    state = 1;
                                }
                            }
                            // LED of the virtual second level must be switched on
                            else
                            {
                                // Redefine the state for the LED's on the button
                                state = 2;

                                // Save the state of the virtual button on the second level
                                second_level_mapping.MidiOutCmdSetValue = "BS02";
                                DB.UpdateOrAdd(device.GetDeviceName(), second_level_mapping);
                            }

                            midiCtlID -= 16;
                        }
                        // Button is located on the virtual first level of the frontpanel
                        else
                        {
                            ControllerMapping first_level_mapping = DB.GetMapping(device.GetDeviceName(), midiCtlID);
                            ControllerMapping second_level_mapping = DB.GetMapping(device.GetDeviceName(), midiCtlID + 16);

                            // Check if the LED must be switched off
                            if (state == 0)
                            {
                                // Save the state of the virtual button on the first level
                                first_level_mapping.MidiOutCmdSetValue = "BS00";
                                DB.UpdateOrAdd(device.GetDeviceName(), first_level_mapping);
                                
                                // Check if there is a CAT command mapped on the virtual second level of this button and the LED on the second level is switched on
                                if (second_level_mapping != null && second_level_mapping.MidiOutCmdSetValue == "BS02")
                                {
                                    // Redefine the state for the LED's on the button
                                    state = 2;
                                }
                            }
                            // LED of the virtual first level must be switched on
                            else
                            {
                                // Save the state of the virtual button on the first level
                                first_level_mapping.MidiOutCmdSetValue = "BS01";
                                DB.UpdateOrAdd(device.GetDeviceName(), first_level_mapping);
                            }
                        }

                        // Update the LEDs of the related button to the new state
                        device.C25FrontpanelUpdateButtonLED(state, midiCtlID);
                        System.Console.WriteLine("C25SendUpdateToMidi was called by CAT command: {0} to set new state: {1} on midiCtlID: {2}", cmd, state, midiCtlID);
                    }
                    catch
                    {
                    }
                }
            }
            return true;
        }

        public List<ControllerMapping> C25GetFrontpanelMappings()
        {
            int index = -1;
            List<ControllerMapping> mappings = null;

            // Get the MIDI controller index of the Charly 25 frontpanel
            index = C25FrontpanelIndex();

            // If no Charly 25 frontpanel is present, tell the caller that no frontpanel is connected
            if (index < 0) return null;

            MidiDevice device = bindings[index].Device;

            // Get all relevant mappings of the Charly 25 frontpanel
            mappings = DB.C25FrontpanelGetMappings();

            // If no mappings are given, return and tell the caller that a frontpanel is connected
            if (mappings != null)
            {
                return mappings;
            }
            else
            {
                return null;
            }
        }

        public void PL1InitialButtonLights(MidiDevice device)
        {

            //-W2PA Channel, Value, Status, ControlID, message bytes - but apparently it only pays attention to the string, others can all be zero
            device.SendMsg(0x01, 0x01, 0x90, 0x22, "902201");  //-W2PA CUE button
            device.SendMsg(0x01, 0x01, 0x90, 0x23, "902301");  //-W2PA play/pause button
            device.SendMsg(0x01, 0x01, 0x90, 0x26, "902601");  //-W2PA - button
            device.SendMsg(0x01, 0x01, 0x90, 0x27, "902701");  //-W2PA + button
            device.SendMsg(0x01, 0x00, 0x90, 0x24, "902400");  //-W2PA Rew button
            device.SendMsg(0x01, 0x00, 0x90, 0x25, "902500");  //-W2PA FF button
            device.SendMsg(0x01, 0x01, 0x90, 0x20, "902001");  //-W2PA SYNC button
            device.SendMsg(0x01, 0x01, 0x90, 0x21, "902101");  //-W2PA TAP button
            device.SendMsg(0x01, 0x01, 0x90, 0x1B, "901B01");  //-W2PA SCRATCH button
            device.SendMsg(0x01, 0x01, 0x90, 0x10, "901001");  //-W2PA 1 button
            device.SendMsg(0x01, 0x01, 0x90, 0x11, "901101");  //-W2PA 2 button
            device.SendMsg(0x01, 0x01, 0x90, 0x12, "901201");  //-W2PA 3 button
            device.SendMsg(0x01, 0x01, 0x90, 0x13, "901301");  //-W2PA 4 button
            device.SendMsg(0x01, 0x01, 0x90, 0x14, "901401");  //-W2PA 5 button
            device.SendMsg(0x01, 0x01, 0x90, 0x15, "901501");  //-W2PA 6 button
            device.SendMsg(0x01, 0x01, 0x90, 0x16, "901601");  //-W2PA 7 button
            device.SendMsg(0x01, 0x01, 0x90, 0x17, "901701");  //-W2PA 8 button
            device.SendMsg(0x01, 0x01, 0x90, 0x18, "901801");  //-W2PA LOAD button
            device.SendMsg(0x00, 0x00, 0x00, 0x00, "901900");  //-W2PA LOCK button
            //device.SendMsg(0x00, 0x00, 0x00, 0x00, "901A01");  //-W2PA DECK button - doesn't seem to work

            //-W2PA A silly but useful routine during startup to search for Behringer LED codes while in debug mode. Play with initial values and limits.
            //-W2PA Comment out the above set of light settings first.
            //int dev = 10;
            //int val = 0;
            //int stbyte = 176;
            //string dB;
            //string vB;
            //string stBs;
            //string m2s;
            //while (stbyte <= 0xFF)
            //{
            //    stBs = stbyte.ToString("X2");
            //    while (dev <= 0xFF)
            //    {
            //        dB = dev.ToString("X2");
            //        while (val <= 0x10)
            //        {
            //            vB = val.ToString("X2");
            //            m2s = stBs + dB + vB;
            //            device.SendMsg(0x01, 0x01, 0x90, dev, m2s);
            //            //Thread.Sleep(1);
            //            val++;
            //        }
            //        dev++;
            //        val = 0;
            //    }
            //    stbyte++;
            //    dev = 10;
            //}

            return;
        }

        public void MicroInitialButtonLights(MidiDevice device)
        {
            //-W2PA Channel, Value, Status, ControlID, message bytes - but apparently it only pays attention to the string, others can all be zero
            device.SendMsg(0x00, 0x00, 0x00, 0x00, "901701");  //-W2PA L-Play/Pause button
            device.SendMsg(0x00, 0x00, 0x00, 0x00, "901801");  //-W2PA L-CUE button
            device.SendMsg(0x00, 0x00, 0x00, 0x00, "902701");  //-W2PA R-Play/Pause button
            device.SendMsg(0x00, 0x00, 0x00, 0x00, "902801");  //-W2PA R-CUE button
        }

        void InitDevice(string deviceName,List<ControllerMapping> mappings, int Idx)
        {
            MidiDevice device = new MidiDevice();
            device.OpenMidiIn(Idx, deviceName);

            Dictionary<int, MidMessageHandler> deviceBindings = BindMappingHandlers(mappings);
            ControllerBinding ctrlBinding= new ControllerBinding{ DeviceName=deviceName, DeviceIndex=Idx, Device=device, CmdBindings=deviceBindings};

            bindings.Add(Idx, ctrlBinding);


            device.onMidiDebugMessage += onMidiDebugMsg;
            device.onMidiInput += OnMidiInput;

            if (deviceName == "CMD PL-1") PL1InitialButtonLights(device);  //W2PA- Initialize the Behringer CMD PL-1 and Micro LED button lights
            if (deviceName == "CMD Micro") MicroInitialButtonLights(device);
        }

        Dictionary<int, MidMessageHandler> BindMappingHandlers(List<ControllerMapping> mappings)
        {
            Dictionary<int, MidMessageHandler> Bindings = new Dictionary<int, MidMessageHandler>();
            foreach (ControllerMapping mapping in mappings)
            {
                try
                {
                    string methodName = mapping.CatCmdId.ToString();
                    Type midi2CatCommandsType = midi2CatCommands.GetType();
                    MethodInfo methodInfo = midi2CatCommandsType.GetMethod(methodName);

                    if (mapping.CatCmd.IsToggled == false)
                    {
                        ProcessMidiMessageHandler binding = (ProcessMidiMessageHandler)Delegate.CreateDelegate(typeof(ProcessMidiMessageHandler), midi2CatCommands, methodInfo);
                        MidMessageHandler handler = new MidMessageHandler { CmdHandler = binding, MidiOutCmdDown = mapping.MidiOutCmdDown, MidiOutCmdUp = mapping.MidiOutCmdUp, MidiOutCmdSetValue = mapping.MidiOutCmdSetValue };
                        Bindings.Add(mapping.MidiControlId, handler);
                    }
                    else
                    {
                        ProcessMidiMessageToggleHandler binding = (ProcessMidiMessageToggleHandler)Delegate.CreateDelegate(typeof(ProcessMidiMessageToggleHandler), midi2CatCommands, methodInfo);
                        MidMessageHandler handler = new MidMessageHandler { ToggleCmdHandler = binding, MidiOutCmdDown = mapping.MidiOutCmdDown, MidiOutCmdUp = mapping.MidiOutCmdUp, MidiOutCmdSetValue = mapping.MidiOutCmdSetValue };
                        Bindings.Add(mapping.MidiControlId, handler);
                    }
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("!!!ERROR!!! MidiMessageManager:BindMappingHandlers: failed to bind mapping "+mapping.CatCmdId.ToString() );
                }
            }
            return Bindings;
        }

        void onMidiDebugMsg(int Device, Direction direction, Status status, string msg1, string msg2)
        {
            System.Diagnostics.Debug.WriteLine("Device:{0}, Direction:{1}, Status:{2}, msg1:{3}, msg2{4}", Device, direction, status, msg1, msg2);
        }

        void OnMidiInput(MidiDevice Device, int DeviceIdx, int ControlId, int Data, int Status, int Voice, int Channel)
        {
            Device.latestControlID = ControlId;  //-W2PA used when making PL-1 LEDs respond to control action 
            try
            {
                ControllerBinding ctrlBinding;
                if (bindings.TryGetValue(DeviceIdx, out ctrlBinding))
                {
                    MidMessageHandler handlers;
                    CmdState state=CmdState.NoChange;

                    if (ctrlBinding.CmdBindings.TryGetValue(ControlId, out handlers))
                    {
                        if (handlers != null)
                        {
                            lock (midi_handler_lock)
                            {
                                // DG8MG
                                // Extension for Charly 25 frontpanel hardware
                                string deviceName = "";

                                ControllerMapping c25FrontpanelMenuButtonMapping;
                                MidMessageHandler c25FrontpanelMenuHandler;

                                deviceName = Device.GetDeviceName();
                                c25FrontpanelMenuButtonMapping = DB.GetReverseMapping(deviceName, CatCmd.C25FrontpanelMenu_OnOff);
                                ctrlBinding.CmdBindings.TryGetValue(c25FrontpanelMenuButtonMapping.MidiControlId, out c25FrontpanelMenuHandler);

                                if (ControlId < 32 && Data != 0)
                                {
                                    int controlIdState = -1;
                                    int newControlId = -1;

                                    ControllerMapping mapping;

                                    // Check if a Charly 25 frontpanel is present and a menu button is present and the menu should be shown every time a frontpanel button is pressed
                                    if (deviceName == "Arduino Micro" && (c25FrontpanelMenuButtonMapping != null && c25FrontpanelMenuButtonMapping.MidiOutCmdDown != "") || ControlId == c25FrontpanelMenuButtonMapping.MidiControlId)
                                    {
                                        // Check if the menu is already visible
                                        if (c25FrontpanelMenuButtonMapping.MidiOutCmdSetValue == "BS01")
                                        {
                                            // Check if the menu should be hidden immediately
                                            if (ControlId == c25FrontpanelMenuButtonMapping.MidiControlId || c25FrontpanelMenuButtonMapping.MidiOutCmdDown == "" || c25FrontpanelMenuButtonMapping.MidiOutCmdDown == "BT00")
                                            {
                                                // Call the the Charly 25 frontpanel menu handler to hide the menu
                                                c25FrontpanelMenuHandler.ToggleCmdHandler(101, Device);

                                                // Update and save the state
                                                c25FrontpanelMenuButtonMapping.MidiOutCmdSetValue = "BS00";
                                                DB.UpdateOrAdd(deviceName, c25FrontpanelMenuButtonMapping);

                                                // Check if the pressed button was the Charly 25 frontpanel menu button
                                                if (ControlId == c25FrontpanelMenuButtonMapping.MidiControlId)
                                                {
                                                    // Return to avoid wrong menu handling
                                                    return;
                                                }
                                            }
                                        }
                                        // the menu isn't visible yet
                                        else
                                        {
                                            // Check if the menu button itself was pressed but no duration is defined
                                            if (ControlId == c25FrontpanelMenuButtonMapping.MidiControlId && (c25FrontpanelMenuButtonMapping.MidiOutCmdDown == "" || c25FrontpanelMenuButtonMapping.MidiOutCmdDown == "BT00"))
                                            {
                                                // Call the the Charly 25 frontpanel menu handler to show the menu infinitive
                                                c25FrontpanelMenuHandler.ToggleCmdHandler(100, Device);
                                            }
                                            else
                                            {
                                                int duration = 100;
                                                duration = int.Parse(c25FrontpanelMenuButtonMapping.MidiOutCmdDown.Remove(0, 2));

                                                // Check if the menu should be shown infinitive
                                                if (duration == 0)
                                                {
                                                    duration = 100;
                                                }

                                                // Call the the Charly 25 frontpanel menu handler to show the menu for the defined duration
                                                c25FrontpanelMenuHandler.ToggleCmdHandler(duration, Device);
                                            }

                                            // Update and save the state
                                            c25FrontpanelMenuButtonMapping.MidiOutCmdSetValue = "BS01";
                                            DB.UpdateOrAdd(deviceName, c25FrontpanelMenuButtonMapping);
                                            return;
                                        }
                                    }

                                    mapping = DB.GetMapping(deviceName, ControlId);

                                    // Check if there is an entry for another button to activate via tristate
                                    if (mapping.MidiOutCmdUp.Length == 4)
                                    {
                                        int.TryParse(mapping.MidiOutCmdUp.Substring(2), out newControlId);

                                        if (newControlId >= 0)
                                        {
                                            if (mapping.MidiOutCmdSetValue.Length == 4)
                                            {
                                                int.TryParse(mapping.MidiOutCmdSetValue.Substring(2), out controlIdState);
                                            }
                                            else
                                            {
                                                controlIdState = 0;
                                            }

                                            System.Diagnostics.Debug.WriteLine("Charly 25 frontpanel tristate button modified ControlId from: {0} ", ControlId);

                                            switch (controlIdState)
                                            {
                                                case 0:
                                                    mapping.MidiOutCmdSetValue = "BS01";
                                                    break;

                                                case 1:
                                                    mapping.MidiOutCmdSetValue = "BS02";
                                                    ControlId = newControlId;
                                                    break;

                                                case 2:
                                                    mapping.MidiOutCmdSetValue = "BS01";
                                                    break;
                                            }

                                            System.Diagnostics.Debug.WriteLine("to ControlId: {0} and new button state: {1} due to controlIdState: {2}.", ControlId, mapping.MidiOutCmdSetValue, controlIdState);

                                            DB.UpdateOrAdd(deviceName, mapping);
                                            ctrlBinding.CmdBindings.TryGetValue(ControlId, out handlers);
                                        }
                                    }
                                }
                                // DG8MG

                                if (handlers.CmdHandler != null)
                                {
                                    handlers.CmdHandler(Data, Device);
                                    if (Data <= 0)
                                        state = CmdState.Off;
                                    else
                                        state = CmdState.On;

                                    // DG8MG
                                    // Extension for Charly 25 frontpanel hardware
                                    System.Diagnostics.Debug.WriteLine("CAT command handler: {0}, with the parameters Data: {1} and Device: {2} was called.", handlers.CmdHandler.Method, Data, Device.GetDeviceName());
                                    // DG8MG
                                }
                                else if (handlers.ToggleCmdHandler != null)
                                {
                                    state = handlers.ToggleCmdHandler(Data, Device);
                                }

                                if (state == CmdState.On && handlers.MidiOutCmdDown != null)
                                {
                                    Device.SendMsg(Channel,0x7F, Status, ControlId,  handlers.MidiOutCmdDown);
                                }
                                if (state == CmdState.Off && handlers.MidiOutCmdUp != null)
                                {
                                    Device.SendMsg(Channel, 0x00, Status,ControlId, handlers.MidiOutCmdUp);
                                }
                                if (handlers.MidiOutCmdSetValue != null)
                                {
                                    Device.SendMsg(Channel, Data, Status, ControlId, handlers.MidiOutCmdSetValue);
                                }

                                // DG8MG
                                // Extension for Charly 25 frontpanel hardware
                                // Check if the frontpanel menu needs to be updated
                                if (ControlId < 32 && Data == 0 && ControlId != c25FrontpanelMenuButtonMapping.MidiControlId)
                                {
                                    // Update the frontpanel menu
                                    c25FrontpanelMenuHandler.ToggleCmdHandler(126, Device);
                                }
                                // DG8MG
                            }
                        }
                    }
                }
            }
            catch { }
        }

    }
}
