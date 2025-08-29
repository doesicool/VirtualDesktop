using System;
using System.Runtime.InteropServices;

namespace WindowsDesktop.Interop.Build10240
{
    [ComImport]
    [Guid("00000000-0000-0000-0000-000000000000") /* replace at runtime */]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IVirtualDesktopManagerInternal2
    {
        void SetName(IVirtualDesktop desktop, HString name);
    }
}
