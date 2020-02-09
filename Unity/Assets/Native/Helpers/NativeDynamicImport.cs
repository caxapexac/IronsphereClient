using System;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;


// Использование библиотеки динамически (на время тестирования)
public class NativeDynamicImport : MonoBehaviour
{
    #region API

    public delegate int MultiplyFloat(float number, float multiplyBy);
    
    public delegate float Sin(float words);

    #endregion

    
    private static IntPtr _nativeLibraryPtr;
    
    private void Awake()
    {
        if (_nativeLibraryPtr != IntPtr.Zero) return;
        string path = Path.Combine(Application.dataPath, "LogicDll.dll");
        _nativeLibraryPtr = Native.LoadLibrary(path);
        if (_nativeLibraryPtr == IntPtr.Zero) Debug.LogError("Failed to load native library");
    }

    private void Start()
    {
        float a = Native.Invoke<float, Sin>(_nativeLibraryPtr, Time.time);
        Debug.Log(a);
    }

    private void Update()
    {
        float a = Native.Invoke<float, Sin>(_nativeLibraryPtr, Time.time);
        transform.position = Vector3.up * a;
    }

    private void OnApplicationQuit()
    {
        if (_nativeLibraryPtr == IntPtr.Zero) return;
        Debug.Log(Native.FreeLibrary(_nativeLibraryPtr) ? "Native library successfully unloaded." : "Native library could not be unloaded.");
    }

    [MenuItem("Native/Rebuild shortcut %&g", false, 100)]
    public static void Build()
    {
        Debug.Log("Building");
        string path = Path.GetFullPath(Path.Combine(Application.dataPath, "compile.bat"));
        Process.Start(path);
    }
}