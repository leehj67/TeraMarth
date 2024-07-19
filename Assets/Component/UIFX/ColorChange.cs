using UnityEngine;

public class ColorChange : MonoBehaviour
{
    // ������ ������ 3D ��ü�� Renderer�� ������ ����
    public Renderer targetRenderer;

    // ������ ������ ����
    public Color newColor = Color.red;

    private Color oldColor;

    // ��ư�� Ŭ���� �� ȣ��� �޼���
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