/* 
 * Native dll invocation helper by Francis R. Griffiths-Keam
 * www.runningdimensions.com/blog
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;


namespace ScriptsNative
{
    public static class NativeRuntimeLoader
    {
        public static T Invoke<T, T2>(IntPtr library, params object[] pars)
        {
            IntPtr funcPtr = GetProcAddress(library, typeof(T2).Name);
            if (funcPtr == IntPtr.Zero)
            {
                Debug.LogWarning("Could not gain reference to method address.");
                return default(T);
            }

            var func = Marshal.GetDelegateForFunctionPointer(GetProcAddress(library, typeof(T2).Name), typeof(T2));
            return (T)func.DynamicInvoke(pars);
        }

        public static void Invoke<T>(IntPtr library, params object[] pars)
        {
            IntPtr funcPtr = GetProcAddress(library, typeof(T).Name);
            if (funcPtr == IntPtr.Zero)
            {
                Debug.LogWarning("Could not gain reference to method address.");
                return;
            }

            var func = Marshal.GetDelegateForFunctionPointer(funcPtr, typeof(T));
            func.DynamicInvoke(pars);
        }

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);
        
        
        [MenuItem("Native/Rebuild shortcut %&g", false, 100)]
        public static void Build()
        {
            Debug.Log("Building");
            string path = Path.GetFullPath(Path.Combine(Application.dataPath, "compile.bat"));
            Process.Start(path);
        }
    }
}