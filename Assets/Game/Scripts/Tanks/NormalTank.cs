using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle
{
    public class NormalTank : BaseUnit
    {

        [Header("用户控制")]
        public bool PlayerCc = false;

        void Start()
        {

        }

        void Update()
        {
            if (PlayerCc)
            {
                float vel = Input.GetAxis("Vertical");
                float rota = Input.GetAxis("Horizontal");
                UpdateUnit(vel, rota);
            }
        }
    }
}
