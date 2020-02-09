// В случае релиза
// открыть крышку,
// потянуть рычаг,
// нажать кнопку,
// убрать это говно
#define NATIVE_RUNTIME
//^^^

using System;
using System.IO;
using UnityEngine;
using Debug = UnityEngine.Debug;


namespace ScriptsNative
{
    // One script instance must exist on the scene!
    public class NativeFunctions : MonoBehaviour
    {
        private const string LibName = "LogicDll";

#if NATIVE_RUNTIME //NativeRuntimeLoader
        private static IntPtr _libraryPtr;


        private delegate Game InitDelegate(InputEventList events);


        private delegate int LoopDelegate(Game game, InputEventList events);


        private delegate int KillDelegate(Game game, InputEventList events);


        public static Game Init(InputEventList events)
        {
            return NativeRuntimeLoader.Invoke<Game, InitDelegate>(_libraryPtr, events);
        }

        public static int Loop(Game game, InputEventList events)
        {
            return NativeRuntimeLoader.Invoke<int, LoopDelegate>(_libraryPtr, game, events);
        }

        public static int Kill(Game game, InputEventList events)
        {
            return NativeRuntimeLoader.Invoke<int, KillDelegate>(_libraryPtr, game, events);
        }

        // On enter play mode
        private void Awake()
        {
            if (_libraryPtr != IntPtr.Zero) return;
            string path = Path.Combine(Application.dataPath, LibName);
            _libraryPtr = NativeRuntimeLoader.LoadLibrary(path);
            if (_libraryPtr != IntPtr.Zero) Debug.Log("Native library loaded");
            else Debug.LogError("Failed to load native library");
        }

        // On exit play mode
        private void OnApplicationQuit()
        {
            if (_libraryPtr == IntPtr.Zero) return;
            if (NativeRuntimeLoader.FreeLibrary(_libraryPtr)) Debug.Log("Native library successfully unloaded.");
            else Debug.Log("Native library could not be unloaded.");
        }

#else // DllImport
        [DllImport (LibName)]
        public static extern Game Init(InputEventList events);
        
        [DllImport (LibName)]
        public static extern int Loop(Game game, InputEventList events);
        
        [DllImport (LibName)]
        public static extern int Kill(Game game, InputEventList events);

#endif
    }
}