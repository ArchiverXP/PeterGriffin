using BepInEx;
using PeterGriffin.NightUtils;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using HarmonyLib;
using PeterGriffin.Peters;

namespace PeterGriffin
{
    [BepInPlugin("com.archiverxp.peter", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {

        public Sprite spite;
        public Sprite chris;
        public Texture2D wario;
        public Texture2D hario;
        private SpriteRenderer Spherebob;
        public GameObject peter;
        public GameObject ammo;
        public GameObject gaymeObject;
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {"com.archiverxp.peter"} is loaded!");
            SceneManager.LoadScene("BusStation");
        }

        void MrKrabs()
        {
            if (Global.loadingLevel == false)
            {
                var lois = new LoisGriffin();
                lois.OnEnable();
            }
            else
            {
                var lois = new LoisGriffin();
                lois.OnDestroy();
            }
        }
        void Squidward()
        {

        }
        void Update()
        {
            MrKrabs(); //ATTACK
        }
    }
}
