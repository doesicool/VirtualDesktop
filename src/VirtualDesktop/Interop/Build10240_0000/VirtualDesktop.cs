using System;
using System.Collections.Generic;
using System.Linq;
using WindowsDesktop.Interop.Proxy;

namespace WindowsDesktop.Interop.Build10240;

internal class VirtualDesktop : ComWrapperBase<IVirtualDesktop>, IVirtualDesktop
{
    private Guid? _id;

    public VirtualDesktop(ComInterfaceAssembly assembly, object comObject)
        : base(assembly, comObject)
    {
    }

    public bool IsViewVisible(IntPtr hWnd)
        => this.InvokeMethod<bool>(Args(hWnd));

    public Guid GetID()
        => this._id ?? (Guid)(this._id = this.InvokeMethod<Guid>());

    public string GetName()
    {
        string regKeyName = $@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VirtualDesktops\Desktops\{{{this.GetID()}}}";
        string? desktopName = (string?)Microsoft.Win32.Registry.GetValue(regKeyName, "Name", null);
        return desktopName ?? $"Desktop {WindowsDesktop.VirtualDesktop.GetIndexFromId(this.GetID()) + 1}";
    }

    public string GetWallpaperPath()
        => "";
}
