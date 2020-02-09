using System.Runtime.InteropServices;
using System.Security;
using UnityEngine;


namespace ScriptsNative
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InputEventList
    {
        public int Count;
        private unsafe InputEvent* InputEvents;
    }
}
