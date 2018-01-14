using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle
{
    public class MainPanelState : MenuStateBase
    {
        public void DoBtnCustomize()
        {
            m_manager.SwitchState(typeof(CustomizeState));
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
