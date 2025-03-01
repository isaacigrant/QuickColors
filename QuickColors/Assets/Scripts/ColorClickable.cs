using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorClickable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Color myColor;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(myColor.ToString());
        CheckIfChosenColor();
    }

    public void SetMyColor(Color color)
    {
        myColor = color;
        gameObject.GetComponent<Image>().color = color;
    }

    private void CheckIfChosenColor()
    {
        if (myColor.Equals(GameManager.instance.chosenColor))
        {
            GameManager.instance.RemoveColorFromList(myColor);
            GameManager.instance.GenerateNewChosenColor();
            Debug.Log("My Color is the same as Chosen Color");
            Destroy(gameObject);
            return;
        }

        Debug.Log("My Color is different then Chosen Color");
        SFXManager.instance.PlayWrongBuzz();
    }
}
