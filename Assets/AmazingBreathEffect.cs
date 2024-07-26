using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmazingBreathEffect : MonoBehaviour
{
    public Transform targetTransform;
    public float minDuration = 1.0f; // 최소 애니메이션 시간
    public float maxDuration = 3.0f; // 최대 애니메이션 시간
    public float minSpeed = 0.5f; // 최소 속도
    public float maxSpeed = 2.0f; // 최대 속도
    public float delayBeforeBreathe = 2.0f; // 연기 효과 시작 전 대기 시간 (초)
    public float maxSize = 2.0f; // 최대 크기
    public float minSize = 0.1f; // 최소 크기

    private Vector3 initialScale;
    private float duration;
    private float speed;
    private float timer = 0.0f;
    private float delayTimer = 0.0f;
    private bool isTriggered = false;
    private Renderer objRenderer;

    void Start()
    {
        initialScale = targetTransform.localScale;
        SetRandomDurationAndSpeed();
        delayTimer = delayBeforeBreathe;

        objRenderer = targetTransform.GetComponent<Renderer>();
        if (objRenderer != null)
        {
            SetTransparency(0.8f); // 투명도 80%로 설정
        }
    }

    void Update()
    {
        if (delayTimer > 0)
        {
            delayTimer -= Time.deltaTime;
            if (delayTimer <= 0)
            {
                isTriggered = true;
                timer = 0.0f;
            }
        }

        if (isTriggered)
        {
            timer += Time.deltaTime * speed;
            float halfDuration = duration / 2.0f;

            float progress = timer / halfDuration;

            if (timer <= halfDuration)
            {
                targetTransform.localScale = Vector3.Lerp(initialScale * minSize, initialScale * maxSize, progress);
            }
            else if (timer <= duration)
            {
                targetTransform.localScale = Vector3.Lerp(initialScale * maxSize, initialScale * minSize, progress - 1);
            }
            else
            {
                timer = 0.0f;
                SetRandomDurationAndSpeed();
                SetRandomRotation();
                delayTimer = delayBeforeBreathe;
                isTriggered = false;
            }
        }
    }

    void SetRandomDurationAndSpeed()
    {
        duration = Random.Range(minDuration, maxDuration);
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void SetRandomRotation()
    {
        targetTransform.rotation = Random.rotation;
    }

    void SetTransparency(float alpha)
    {
        if (objRenderer != null)
        {
            foreach (Material mat in objRenderer.materials)
            {
                Color color = mat.color;
                color.a = alpha;
                mat.color = color;

                if (mat.HasProperty("_Color"))
                {
                    color = mat.GetColor("_Color");
                    color.a = alpha;
                    mat.SetColor("_Color", color);
                }

                if (mat.HasProperty("_BaseColor"))
                {
                    color = mat.GetColor("_BaseColor");
                    color.a = alpha;
                    mat.SetColor("_BaseColor", color);
                }

                mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                mat.SetInt("_ZWrite", 0);
                mat.DisableKeyword("_ALPHATEST_ON");
                mat.EnableKeyword("_ALPHABLEND_ON");
                mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                mat.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
            }
        }
    }
}