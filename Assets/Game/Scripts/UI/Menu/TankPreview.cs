using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TankBattle
{
    public class TankPreview : MonoBehaviour
    {
        [Header("SelfRotationSpeed")]
        [SerializeField]
        private float selfRotationSpeed = 0.6f;
        [Header("DragRotationScele")]
        [SerializeField]
        private float dragScele = 0.8f;
        [Header("SelfRotationDirection")]
        [SerializeField]
        private RotationDirection tankRotationDirection = RotationDirection.Right;

        public GameObject TankPrefab;

        Transform tank_rotation;
        bool isDrag = false;
        float startEnglY;

        void Start()
        {
            tank_rotation = transform.Find("TankRotation");
            loadTank(TankPrefab);
        }

        void Update()
        {
            if (isDrag)
                return;
            rotationSelf();
        }

        void rotationSelf()
        {
            if (tankRotationDirection == RotationDirection.Left)
                tank_rotation.Rotate(transform.up, selfRotationSpeed);
            else
                tank_rotation.Rotate(transform.up, -selfRotationSpeed);
        }

        void loadTank(GameObject _tankPrefab)
        {
            GameObject tank = Instantiate(_tankPrefab);
            tank.transform.parent = tank_rotation;
            tank.transform.position = Vector3.zero;
            tank.transform.rotation = Quaternion.Euler(Vector3.zero);
            tank.transform.localScale = Vector3.zero;
            tank.transform.DOScale(Vector3.one, 2);
        }

        public void BeginDrag()
        {
            isDrag = true;
            startEnglY = tank_rotation.rotation.eulerAngles.y;
        }

        public void AmongDrag(float _startPosX, float _curPosX)
        {
            float diff = startEnglY + dragScele * (_startPosX - _curPosX);
            setYRotation(diff);
        }
        void setYRotation(float _diff)
        {
            tank_rotation.rotation = Quaternion.Euler(new Vector3(tank_rotation.rotation.eulerAngles.x, _diff, tank_rotation.rotation.eulerAngles.z));
        }

        public void EndDrag(float _startPosX, float _curPosX)
        {
            if (_curPosX > _startPosX)
                tankRotationDirection = RotationDirection.Right;
            else if(_curPosX < _startPosX)
                tankRotationDirection = RotationDirection.Left;
            isDrag = false;
        }
        
    }
}
