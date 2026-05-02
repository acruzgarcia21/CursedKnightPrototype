using UnityEngine;
using UnityEngine.EventSystems; //This allows us to use Unity's event system to detect our mouse inputs
//These classes hold the methods required to handle UI interactions that we need
public class DragUIObject : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    private RectTransform _rectTransform;
    private Canvas _canvas;
    private Vector2 _originalLocalPointerPosition;
    private Vector3 _originalPanelLocalPosition;
    public float movementSensitivity = 1.0f; // Adjustable sensitivity if needed

    private void Awake()
    {
        //Get the RectTransform component of the attached GameObject
        _rectTransform = GetComponent<RectTransform>();
        //Get the Canvas component of the attached GameObject
        _canvas = GetComponentInParent<Canvas>();
    }

    //This is inherited from the IPointerDownHandler class referenced above
    public void OnPointerDown(PointerEventData eventData)
    {
        //Using the event system to detect what is clicked on
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.GetComponent<RectTransform>(),
            eventData.position,
            eventData.pressEventCamera,
            out _originalLocalPointerPosition);
        
        _originalPanelLocalPosition = _rectTransform.localPosition;
    }

    //This is inherited from the IDragHandler class referenced above
    public void OnDrag(PointerEventData eventData)
    {
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.GetComponent<RectTransform>(),
                eventData.position,
                eventData.pressEventCamera,
                out var localPointerPosition)) return;
        
        localPointerPosition /= _canvas.scaleFactor;

        // Adjusting the movement based on sensitivity
        Vector3 offsetToOriginal = (localPointerPosition - _originalLocalPointerPosition) * movementSensitivity;
        _rectTransform.localPosition = _originalPanelLocalPosition + offsetToOriginal;

        // Debug output
        //Comment out this line if not debugging an issue, otherwise it will flood the console unnecessarily
        Debug.Log($"Drag - LocalPointerPosition: {localPointerPosition}, Offset: {offsetToOriginal}," +
                  $" New Position: {_rectTransform.localPosition}"); 
    }
}
