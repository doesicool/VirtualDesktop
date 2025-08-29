﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WindowsDesktop.Interop.Proxy;

namespace WindowsDesktop.Interop.Build10240;

internal class VirtualDesktopManagerInternal2 : ComWrapperBase<IVirtualDesktopManagerInternal2>, IVirtualDesktopManagerInternal2
{
    private readonly ComWrapperFactory _factory;

    public VirtualDesktopManagerInternal2(ComInterfaceAssembly assembly, ComWrapperFactory factory)
        : base(assembly, CLSID.VirtualDesktopManagerInternal2)
    {
        this._factory = factory;
    }

    public void SetName(IVirtualDesktop desktop, string name)
        => this.InvokeMethod(Args(((VirtualDesktop)desktop).ComObject, new HString(name)));

    private VirtualDesktop InvokeMethodAndWrap(object?[]? parameters = null, [CallerMemberName] string methodName = "")
        => new(this.ComInterfaceAssembly, this.InvokeMethod<object>(parameters, methodName) ?? throw new Exception("Failed to get IVirtualDesktop instance."));
}
