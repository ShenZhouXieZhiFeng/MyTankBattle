using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TankBattle
{
    public class CustomizeState : MenuStateBase
    {
        #region member
        [Header("功能按钮")]
        [SerializeField]
        private Button cancelButton, acceptButton, createButton;

        #endregion

        #region unity
        private void Start()
        {
            cancelButton.onClick.AddListener(doBtnCancel);
            acceptButton.onClick.AddListener(doBtnAccept);
            createButton.onClick.AddListener(doBtnCreate);
        }

        #endregion

        #region btn action
        void doBtnCancel()
        {
            m_manager.SwitchState(typeof(MainPanelState));
        }

        void doBtnAccept()
        {

        }

        void doBtnCreate()
        {

        }

        #endregion

        #region override
        public override void EnterPanel()
        {
            base.EnterPanel();
        }

        public override void UpdatePanel()
        {
            base.UpdatePanel();
        }

        public override void ExitPanel(MenuPanelType _newStateType)
        {
            base.ExitPanel(_newStateType);
        }
        #endregion

    }
}
