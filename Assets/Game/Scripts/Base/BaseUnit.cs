using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUnit : MonoBehaviour
{
    #region SetFromInspect
    [Header("MaxSpeed")]
    [SerializeField]
    protected float MaxSpeed = 20f;
    [Header("MinSpeed")]
    [SerializeField]
    protected float MinSpeed = 5f;
    #endregion

    #region Members
    private int energy = 100;
    /// <summary>
    /// 能量
    /// </summary>
    public int Energy
    {
        get { return energy; }
        protected set { energy = value; }
    }

    private int damage = 0;
    /// <summary>
    /// 破损程度,0-100
    /// </summary>
    public int Damage
    {
        get { return damage; }
        protected set
        {
            damage = value;
            //计算破损级别
            DamagedType temp = DamagedType.ZeroGrade;
            if (damage == 0)
            {
                temp = DamagedType.ZeroGrade;
            }
            else if (damage > 0 && damage <= 40)
            {
                temp = DamagedType.OneGrade;
            }
            else if (damage > 40 && damage <= 80)
            {
                temp = DamagedType.TwoGrade;
            }
            else if (damage > 80 && damage < 100)
            {
                temp = DamagedType.ThreeGrade;
            }
            else if (damage == 100)
            {
                temp = DamagedType.DiedGrade;
            }
            //计算当前最大速度
            curMaxSpeed = Mathf.Lerp(MaxSpeed, MinSpeed, (int)temp / 4);
            damagedLevel = temp;
        }
    }

    private DamagedType damagedLevel = DamagedType.ZeroGrade;
    /// <summary>
    /// 破损级别，根据破损程度自动维护
    /// </summary>
    public DamagedType DamagedLevel
    {
        get { return damagedLevel; }
    }

    private float curMaxSpeed;
    /// <summary>
    /// 当前最大速度，根据破损级别自动调整
    /// </summary>
    public float CurMaxSpeed
    {
        get { return curMaxSpeed; }
    }

    [SerializeField]
    private Vector3 currentMove;
    /// <summary>
    /// 当前移动速度，包含横向和纵向
    /// </summary>
    public Vector3 CurrentMove
    {
        get { return currentMove; }
        protected set { currentMove = value; }
    }

    [SerializeField]
    private Vector3 currentAcceleratedMove;
    /// <summary>
    /// 当前加速度，横纵向
    /// </summary>
    public Vector3 CurrentAcceleratedMove
    {
        get { return currentAcceleratedMove; }
        protected set { currentAcceleratedMove = value; }
    }

    private float mass = 5;
    /// <summary>
    /// 质量
    /// </summary>
    public float Mass
    {
        get { return mass; }
        protected set { mass = value; }
    }

    #endregion
}
