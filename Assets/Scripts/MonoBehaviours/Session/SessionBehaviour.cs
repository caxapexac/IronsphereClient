using System.Collections.Generic;
using CaxapCommon.Enums;
using CaxapCommon.Wrappers;
using JsonSchemas;
using JsonSchemas.Generators;
using Singletons;
using UnityEngine;


namespace MonoBehaviours.Session
{
    public class SessionBehaviour : MonoBehaviour
    {
        private static SessionBehaviour _instance;

        private string _sessionName;
        private States _state;
        private List<int> _playersUid;

        private void Awake()
        {
            _instance = this;
            _sessionName = null;
            _state = States.choosing;
            _playersUid = null;
        }
        
        private void Start()
        {
            God.NetworkManager.Send(new in_session_info());
        }

        private void Update()
        {
            
        }
        
        private void OnDestroy()
        {
            _instance = null;
        }

        public static void SetPlayers(List<int> players_uid)
        {
            if (!_instance) return;
            _instance._playersUid = players_uid;
        }

        public static abstract_generator GetGenerator()
        {
            if (!_instance) return null;
            abstract_generator generator;
            
            // TODO
            int seed = PlayerPrefsWrapper.Get(IntPrefs.setup_seed);
            List<int> players_uid = _instance._playersUid;
            int tilemap_scale_x = PlayerPrefsWrapper.Get(IntPrefs.setup_tilemap_scale_x);
            int tilemap_scale_y = PlayerPrefsWrapper.Get(IntPrefs.setup_tilemap_scale_y);
            generator = new simple(seed, players_uid, tilemap_scale_x, tilemap_scale_y);
            // TODO

            return generator;
        }
    }
}