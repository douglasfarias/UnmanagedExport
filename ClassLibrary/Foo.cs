using System.Runtime.InteropServices;

namespace ClassLibrary
{

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Foo
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 42)]
        public string Value;
    }
}
