using System.Runtime.InteropServices;


namespace ScriptsNative
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Game
    {
        public int a;
        public float b;
        public int[] c;
    }
}