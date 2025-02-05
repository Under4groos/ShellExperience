﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellExperience.Helper.Enums
{
    public enum SHGFI_Flag : uint
    {
        SHGFI_ATTR_SPECIFIED = 0x000020000,
        SHGFI_OPENICON = 0x000000002,
        SHGFI_USEFILEATTRIBUTES = 0x000000010,
        SHGFI_ADDOVERLAYS = 0x000000020,
        SHGFI_DISPLAYNAME = 0x000000200,
        SHGFI_EXETYPE = 0x000002000,
        SHGFI_ICON = 0x000000100,
        SHGFI_ICONLOCATION = 0x000001000,
        SHGFI_LARGEICON = 0x000000000,
        SHGFI_SMALLICON = 0x000000001,
        SHGFI_SHELLICONSIZE = 0x000000004,
        SHGFI_LINKOVERLAY = 0x000008000,
        SHGFI_SYSICONINDEX = 0x000004000,
        SHGFI_TYPENAME = 0x000000400
    }
}
