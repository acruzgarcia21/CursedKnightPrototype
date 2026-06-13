using UnityEngine;

public class PositionObject : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject objectToPosition;
    public int widthDivider = 2;
    public int heightDivider = 2;
    public float widthMultiplier = 1f;
    public float heightMultiplier = 1f;

    public bool updatePosition = false;

    private void Start()
    {
        if(mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        SetObjectPosition();
    }

    private void Update()
    {
        if (updatePosition)
        {
            SetObjectPosition();
        }
    }

    private void SetObjectPosition()
    {
        if(mainCamera != null && objectToPosition != null && widthDivider != 0 && heightDivider != 0)
        {
            var height = 2f * mainCamera.orthographicSize;
            var width = height * mainCamera.aspect;

            // Calculate segment size
            var segmentWidth = width / widthDivider;
            var segmentHeight = height / heightDivider;

            // Calculate new position based on segments
            var newX = (segmentWidth * (widthMultiplier - 0.5f)) - (width / 2);
            var newY = (segmentHeight * (heightMultiplier - 0.5f)) - (height / 2);

            objectToPosition.transform.position = new Vector3(newX, newY, objectToPosition.transform.position.z);
        }
    }
}