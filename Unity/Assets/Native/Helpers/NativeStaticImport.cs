using System.Runtime.InteropServices;
using UnityEngine;

// Использование библиотеки статически (в билде)
public class NativeStaticImport : MonoBehaviour
{
    [DllImport ("LogicDll")]
    public static extern float Sin(float a, float b);
    
    
    void Start()
    {
        Debug.Log("Mingw" + Sin(10, 2));
    }

    void Update()
    {
        
    }
}
