using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    // For object
    private RectTransform _rectTransform;
    private Canvas _canvas; // Looking for parent canvas
    
    // Stores mouse pointer position
    private Vector2 _originalLocalPointerPosition;
    
    // Store original card location and scale
    private Vector3 _originalPanelLocalPosition;
    private Vector3 _originalScale;
    
    // TO DO: Convert to enums for better readability
    private enum CardState
    {
        Idle,
        Hover,
        Drag,
        Play
    }

    private CardState _currentState = CardState.Idle;
    
    private Quaternion _originalRotation;
    private Vector3 _originalPosition;

    [SerializeField] private float selectScale = 1.1f;
    [SerializeField] private Vector2 cardPlay;
    [SerializeField] private Vector3 playPosition;
    [SerializeField] private GameObject glowEffect;
    [SerializeField] private GameObject playArrow; // Enables dynamic arrow where we want to play our card
    // TO DO: Add a serialized field of a float that will hold a time that it takes for the card to reach its target

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _originalScale = _rectTransform.localScale;
        _originalPosition = _rectTransform.localPosition;
        _originalRotation = _rectTransform.localRotation;
    }

    private void Update()
    {
        switch (_currentState)
        {
            case CardState.Hover:
                HandleHoverState();
                break;
            case CardState.Drag:
                HandleDragState();
                if (!Input.GetMouseButton(0)) // Check if mouse button is released
                {
                    ReturnToIdleState();
                }
                break;
            case CardState.Play:
                HandlePlayState();
                if (!Input.GetMouseButton(0)) // Check if mouse button is released
                {
                    ReturnToIdleState();
                }
                break;
            case CardState.Idle:
            default:
                break;
        }
    }

    private void ReturnToIdleState()
    {
        _currentState = CardState.Idle;
        _rectTransform.localScale = _originalScale;       // Reset Scale
        _rectTransform.localRotation = _originalRotation; // Reset Rotation
        _rectTransform.localPosition = _originalPosition; // Reset Position
        glowEffect.SetActive(false);                      // Disable Glow Effect
        playArrow.SetActive(false);                       // Disable playArrow
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_currentState != CardState.Idle) return;
        _originalPosition = _rectTransform.localPosition;
        _originalRotation = _rectTransform.localRotation;
        _originalScale = _rectTransform.localScale;
            
        _currentState = CardState.Hover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_currentState != CardState.Hover) return;
        ReturnToIdleState();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_currentState != CardState.Hover) return;
        _currentState = CardState.Drag; // Drag State
        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvas.GetComponent<RectTransform>(), // Gets position of mouse on screen
            eventData.position,              // Current mouse position in screen coordinates
            eventData.pressEventCamera,                // The camera that registered the click
            out _originalLocalPointerPosition);        // Stores the calculated mouse position relative to the canvas
        
        // Stores the position where the click happened
        _originalPanelLocalPosition = _rectTransform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_currentState != CardState.Drag) return;
        
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.GetComponent<RectTransform>(),
                eventData.position,
                eventData.pressEventCamera,
                out var localPointerPosition)) return;
        
        // Ensures the card follows the mouse and not just the mouse movement
        localPointerPosition /= _canvas.scaleFactor;
        
        Vector3 offsetToOriginal =  localPointerPosition - _originalLocalPointerPosition;
        _rectTransform.localPosition = _originalPanelLocalPosition + offsetToOriginal;

        // TO DO: Use lerp to make smoother
        // Vector3.Lerp();

        if (!(_rectTransform.localPosition.y > cardPlay.y)) return;
        
        _currentState = CardState.Play;
        playArrow.SetActive(true);
        _rectTransform.localPosition = playPosition;
    }

    private void HandleHoverState()
    {
        glowEffect.SetActive(true);
        _rectTransform.localScale = _originalScale * selectScale;
    }

    private void HandleDragState()
    {
        // Set the card's rotation to zero
        _rectTransform.localRotation = Quaternion.identity;
    }

    private void HandlePlayState()
    {
        _rectTransform.localPosition = playPosition;
        _rectTransform.localRotation = Quaternion.identity;

        if (!(Input.mousePosition.y < cardPlay.y)) return;
        
        _currentState = CardState.Drag;
        playArrow.SetActive(false);
    }
}
