using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionGroup : MonoBehaviour
{
    public Button uiButton;
    public Image paddleReference;
    public bool isColorPlayer = false;
    public void OnButtonClick()
    {
        paddleReference.color = uiButton.colors.normalColor;
 
        if (isColorPlayer)
        {
            SaveController.Instance.colorPlayer = paddleReference.color;
        }
        else
        {
            SaveController.Instance.colorEnemy = paddleReference.color;
        }
    }

}
