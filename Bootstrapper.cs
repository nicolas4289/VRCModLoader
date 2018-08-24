﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace VRCModLoader
{
    class Bootstrapper : MonoBehaviour
    {
        private bool loadmods = true;

        public event Action Destroyed = delegate {};
        
        void Awake()
        {
            if (Environment.CommandLine.Contains("--verbose") && !Screen.fullScreen)
            {
                Windows.GuiConsole.CreateConsole();
            }
            if (Environment.CommandLine.Contains("--nomodloader"))
            {
                loadmods = false;
            }
        }

        void Start()
        {
            Destroy(gameObject);
        }
        void OnDestroy()
        {
            if(loadmods) Destroyed();
        }
    }
}