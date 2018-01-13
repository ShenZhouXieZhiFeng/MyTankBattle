using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle
{
    public class ReferenceManager : Singleton<ReferenceManager>
    {
        [Header("TankPreview")]
        public Camera PreviewCamera;
        public TankPreview TankPreview;

    }
}
