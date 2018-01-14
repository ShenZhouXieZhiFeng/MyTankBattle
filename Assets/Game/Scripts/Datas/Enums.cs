namespace TankBattle {

    /// <summary>
    /// 自转方向
    /// </summary>
    public enum RotationDirection
    {
        Left,
        Right
    }

    /// <summary>
    /// 破损级别
    /// </summary>
    public enum DamagedType
    {
        ZeroGrade = 0,  //0
        OneGrade = 1,  //0-40
        TwoGrade = 2,  //40-80
        ThreeGrade = 3,  //80-100
        DiedGrade = 4   //100
    }

    /// <summary>
    /// Menu界面ui面板弹出类型
    /// </summary>
    public enum MenuPanelType
    {
        Cover,//覆盖所有
        Window//窗口模式
    }

}
