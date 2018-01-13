using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class BaseUnit : MonoBehaviour
{
    #region Fields
    [Header("能量")]
    [SerializeField]
    protected int energy = 100;
    [Header("当前速度")]
    [SerializeField]
    protected float curSpeed = 20f;
    [Header("当前旋转")]
    [SerializeField]
    protected float curRatate = 20f;
    [Header("质量")]
    [SerializeField]
    protected float mass = 5;

    private int damage = 0;
    private DamagedType damagedLevel = DamagedType.ZeroGrade;
    private Rigidbody m_rigidbody;
    #endregion

    #region Get A Set

    /// <summary>
    /// 能量
    /// </summary>
    public int Energy
    {
        get { return energy; }
        protected set { energy = value; }
    }

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
            damagedLevel = temp;
        }
    }

    /// <summary>
    /// 破损级别，根据破损程度自动维护
    /// </summary>
    public DamagedType DamagedLevel
    {
        get { return damagedLevel; }
    }

    /// <summary>
    /// 当前移动速度
    /// </summary>
    protected float CurMoveSpeed
    {
        get {
            return MRigidbody.velocity.magnitude;
        }
        set {
            MRigidbody.velocity = transform.forward * value * (curSpeed / Mass);
        }
    }

    /// <summary>
    /// 当前旋转
    /// </summary>
    protected float CurRotation
    {
        get
        {
            return MRigidbody.angularVelocity.magnitude;
        }
        set
        {
            MRigidbody.angularVelocity = transform.up * value * (curRatate / Mass);
        }
    }
    
    /// <summary>
    /// 质量
    /// </summary>
    public float Mass
    {
        get { return mass; }
        protected set { mass = value; }
    }

    /// <summary>
    /// 刚体
    /// </summary>
    protected Rigidbody MRigidbody
    {
        get {
            if (m_rigidbody == null)
                m_rigidbody = GetComponent<Rigidbody>();
            return m_rigidbody;
        }
    }

    #endregion

    #region Func

    /// <summary>
    /// 更新速度和旋转
    /// </summary>
    /// <param name="_vel"></param>
    /// <param name="_rota"></param>
    protected void UpdateUnit(float _vel,float _rota)
    {
        CurMoveSpeed = _vel;
        CurRotation = _rota;
    }

    #endregion
}
