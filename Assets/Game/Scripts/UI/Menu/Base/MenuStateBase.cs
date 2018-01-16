using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle
{
    /// <summary>
    /// Menu面板状态基类
    /// </summary>
    public abstract class MenuStateBase : MonoBehaviour
    {
        [HideInInspector]
        public MenuPanelType MenuType = MenuPanelType.Cover;

        /// <summary>
        /// 状态控制实例
        /// </summary>
        protected MenuStateManager m_manager;

        public virtual void InitState(MenuStateManager _manager)
        {
            m_manager = _manager;
        }

        public virtual void EnterPanel()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// 面板的更新操作重写这个函数，不要重开一个update，便于统一管理
        /// </summary>
        public virtual void UpdatePanel()
        {

        }

        public virtual void ExitPanel(MenuPanelType _newStateType)
        {
            switch (_newStateType)
            {
                case MenuPanelType.Cover:
                    gameObject.SetActive(false);
                    break;
                case MenuPanelType.Window:
                    break;
            }
        }

    }
}
