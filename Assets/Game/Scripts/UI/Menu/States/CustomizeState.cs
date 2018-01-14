using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle
{
    public class CustomizeState : MenuStateBase
    {
        public void DoBtnClose()
        {
            m_manager.SwitchState(typeof(MainPanelState));
        }

        public override void EnterPanel()
        {
            base.EnterPanel();
            gameObject.SetActive(true);
        }

        public override void UpdatePanel()
        {
            base.UpdatePanel();
        }

        public override void ExitPanel(MenuPanelType _newStateType)
        {
            base.ExitPanel(_newStateType);
        }

    }
}
