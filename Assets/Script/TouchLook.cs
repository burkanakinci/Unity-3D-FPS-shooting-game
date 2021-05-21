using UnityEngine;
using UnityEngine.EventSystems;

public class TouchLook : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private float startPosX, startPosY;
    private float currentPosX, currentPosY;

    public float SlideHorizontal { get; private set; }
    public float SlideVertical { get; private set; }
    public void OnPointerDown(PointerEventData eventData)
    {
        startPosX = eventData.position.x;
        startPosY = eventData.position.y;
    }

    public void OnDrag(PointerEventData eventData)
    {
        currentPosX = eventData.position.x;
        currentPosY = eventData.position.y;


        if (startPosX - currentPosX <= -2)
        {
            SlideHorizontal = Mathf.Clamp(SlideHorizontal += 1f, min: -90f, max: 90f);
            startPosX = currentPosX;
        }
        else if (startPosX - currentPosX > 2)
        {
            SlideHorizontal = Mathf.Clamp(SlideHorizontal -= 1f, min: -90f, max: 90f);
            startPosX = currentPosX;
        }

        if (startPosY - currentPosY <= -2)
        {
            SlideVertical = Mathf.Clamp(SlideVertical += 1f, min: -90f, max: 90f);
            startPosY = currentPosY;
        }
        else if (startPosY - currentPosY >2)
        {
            SlideVertical = Mathf.Clamp(SlideVertical -= 1f, min: -90f, max: 90f);
            startPosY = currentPosY;
        }
    }

    // public void OnPointerUp(PointerEventData eventData){
    //     SlideHorizontal=currentPosX;
    //     SlideVertical=currentPosY;
    // }
}
