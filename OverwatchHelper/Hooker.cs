﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices;

namespace OverwatchHelper
{
    //this class hooks inputs and forwards data to other classes
    class Hooker
    {

        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        public Keys aimKey;
        public Capturer capturer;

        public Hooker(Capturer capturer, Keys aimKey)
        {
            this.capturer = capturer;
            this.aimKey = aimKey;
        }

        public bool running = false;

        private bool isKeyDown(Keys key)
        {
            return Convert.ToInt32(GetAsyncKeyState(key)) == -32767;
        }

        public int delay = 15;
        public void run()
        {
            running = true;
            while (running)
            {

                capturer.enabled = isKeyDown(aimKey);

                System.Threading.Thread.Sleep(delay);
            }
        }
    }
}