using System;
using UnityEngine;


namespace Static
{
    public enum StrPrefs
    {
        server_ip,
        nickname,
        session_name,
        message,
        session_info
    }


    public enum IntPrefs
    {
        sender,
        session_id,
        chat_buffer_updates
    }
    
    public static class PlayerPrefsWrapper
    {
        public static event EventHandler<(StrPrefs, string)> StringPrefsChanged;
        
        public static event EventHandler<(IntPrefs, int)> IntPrefsChanged;

        public static string Get(StrPrefs stringType)
        {
            return PlayerPrefs.GetString(stringType.ToString());
        }
        
        public static int Get(IntPrefs intType)
        {
            return PlayerPrefs.GetInt(intType.ToString());
        }
        
        public static void Set(StrPrefs stringType, string data)
        {
            PlayerPrefs.SetString(stringType.ToString(), data);
            StringPrefsChanged?.Invoke(null, (stringType, data));
        }
        
        public static void Set(IntPrefs intType, int data)
        {
            PlayerPrefs.SetInt(intType.ToString(), data);
            IntPrefsChanged?.Invoke(null, (intType, data));
        }

        public static string Take(StrPrefs stringType)
        {
            string data = Get(stringType);
            Set(stringType, "");
            return data;
        }
        
        public static int Take(IntPrefs intType)
        {
            int data = Get(intType);
            Set(intType, 0);
            return data;
            
        }
    }
}