using System.Runtime.InteropServices;

namespace WindowsDesktop.Interop.Proxy;

[ComInterface]
public interface IVirtualDesktopManagerInternal2
{
    void SetName(IVirtualDesktop desktop, string name);
}
