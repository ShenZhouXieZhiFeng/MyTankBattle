using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace TankBattle
{
    [RequireComponent(typeof(RawImage))]
    public class RenderPreviewTank : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
    {
        RawImage m_image;
        RenderTexture m_texture;
        RectTransform m_rect;
        Camera m_camera;
        TankPreview m_tp;

        private Vector2 m_startingPosition;

        private void Start()
        {
            m_image = GetComponent<RawImage>();
            m_rect = GetComponent<RectTransform>();
            m_camera = ReferenceManager.GetInstance.PreviewCamera;
            m_tp = ReferenceManager.GetInstance.TankPreview;
            updateTexture();
        }

        void updateTexture()
        {
            if (!m_camera || !m_rect)
                return;
            Vector2 rectSize = m_rect.rect.size;
            m_texture = new RenderTexture((int)rectSize.x, (int)rectSize.y, 16, RenderTextureFormat.ARGB32);
            if (QualitySettings.antiAliasing > 0)
            {
                m_texture.antiAliasing = QualitySettings.antiAliasing;
            }
            m_camera.enabled = true;
            m_camera.targetTexture = m_texture;
            m_image.texture = m_texture;
        }

        //private void OnRectTransformDimensionsChange()
        //{
        //    if (enabled && gameObject.activeInHierarchy)
        //    {
        //        updateTexture();
        //    }
        //}

        private void OnEnable()
        {
            if (m_camera)
            {
                m_camera.enabled = true;
                updateTexture();
            }
        }

        private void OnDisable()
        {
            if (m_texture != null)
            {
                m_texture.Release();
                Destroy(m_texture);
                m_texture = null;
            }
            if (m_camera)
                m_camera.enabled = false;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            m_startingPosition = eventData.position;
            m_tp.BeginDrag();
        }

        public void OnDrag(PointerEventData eventData)
        {
            m_tp.AmongDrag(m_startingPosition.x, eventData.position.x);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            m_tp.EndDrag(m_startingPosition.x, eventData.position.x);
        }
    }
}
