using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TankBattle
{
    public class MenuStateManager : MonoBehaviour
    {
        [Header("状态列表")]
        [SerializeField]
        private MenuStateBase[] m_menuList;
        [Header("当前状态")]
        [SerializeField]
        private MenuStateBase m_currentState;
        [Header("是否刷新当前menu")]
        [SerializeField]
        private bool UpdateCurrentMenu = true;

        private void Awake()
        {
            foreach (MenuStateBase menu in m_menuList)
            {
                menu.InitState(this);
            }
            //将第一个状态设置成初始状态
            if (m_menuList.Length != 0)
            {
                m_currentState = m_menuList[0];
                m_currentState.EnterPanel();
            }
        }

        private void Update()
        {
            if (UpdateCurrentMenu && m_currentState != null)
            {
                m_currentState.UpdatePanel();
            }
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="_targetState"></param>
        public void SwitchState(Type _targetState)
        {
            MenuStateBase targetState = findState(_targetState);
            if (targetState == null)
            {
                Log.ShowLog("找不到对应的MENU状态：" + _targetState);
                return;
            }
            m_currentState.ExitPanel(targetState.MenuType);//退出状态
            m_currentState = targetState;//切换状态
            m_currentState.EnterPanel();//进入新状态
        }

        MenuStateBase findState(Type _targetState)
        {
            foreach (MenuStateBase menu in m_menuList)
            {
                if (menu.GetType() == _targetState)
                {
                    return menu;
                }
            }
            return null;
        }
    }
}
