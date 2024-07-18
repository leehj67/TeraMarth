using UnityEngine;

public class ColorChange : MonoBehaviour
{
    // 색상을 변경할 3D 객체의 Renderer를 참조할 변수
    public Renderer targetRenderer;

    // 색상을 변경할 변수
    public Color newColor = Color.red;

    private Color oldColor;

    // 버튼이 클릭될 때 호출될 메서드
    public void ChangeColor()
    {
        if (targetRenderer != null)
        {
            oldColor = targetRenderer.material.color;
            targetRenderer.material.color = newColor;
            newColor = oldColor;
        }
        else
        {
            Debug.LogError("Target Renderer is not assigned!");
        }
    }
}