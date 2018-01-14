using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle
{
    public class Log
    {
        public static bool EnableLog = true;

        public static void ShowLog(object _msg)
        {
            Debug.Log(_msg);
        }
    }
}