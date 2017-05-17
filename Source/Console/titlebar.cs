//=================================================================
// titlebar.cs
//=================================================================
// PowerSDR is a C# implementation of a Software Defined Radio.
// Copyright (C) 2004-2012  FlexRadio Systems 
// Copyright (C) 2010-2013  Doug Wigley
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
//
// You may contact us via email at: gpl@flexradio.com.
// Paper mail may be sent to: 
//    FlexRadio Systems
//    4616 W. Howard Lane  Suite 1-150
//    Austin, TX 78728
//    USA
//=================================================================

using System;
using System.Diagnostics;
using System.Reflection;

// DG8MG
using System.Windows.Forms;
// DG8MG

namespace PowerSDR
{
    class TitleBar
    {

        // DG8MG
        // Extension for Charly 25 and HAMlab hardware
#if DEBUG
        public const string BUILD = " - Debug Version: ";
#else
        public const string BUILD = " - Release Version: ";
#endif
        public const string BUILD_NAME = "mRX PS";
        public const string BUILD_EDITION = " - Charly 25 / HAMlab / STEMlab SDR Edition";

        public static string GetString()
        {
            string s = "PowerSDR™ OpenHPSDR";
            s += " " + BUILD_NAME;
            s += " " + BUILD_EDITION + BUILD;
            s += Application.ProductVersion.Substring(2, 10);
            s += " - Commit: " + Application.ProductVersion.Substring(Application.ProductVersion.LastIndexOf("_") + 1);

            return s;
        }
        // DG8MG

        // returns the PowerSDR version number in "a.b.c" format
        public static string GetVerNum()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion.Substring(0, fvi.FileVersion.LastIndexOf("."));
        }
    }
}