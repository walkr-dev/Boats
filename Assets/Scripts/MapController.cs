using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MapController : MonoBehaviour
{
    public Canvas canvas;
    public RectTransform mapTransform;
    private Camera mapCamera;
    
    private bool isOpen;
    private Vector2 closedPos = new(25,25);
    private Vector2 openPos = Vector2.zero;

    private Vector3 openScale = new(3,3,3);

    private float closedFov;
    private float openFov = 140;

    private void Start() {
        mapCamera = GetComponent<Camera>();
        closedFov = mapCamera.fieldOfView;

        closedPos = new(-(canvas.pixelRect.size.x / 2.5f), -(canvas.pixelRect.size.y / 3));
        mapTransform.localPosition = closedPos;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.M)) { 
            OpenMap(); 
        }
    }

    private void OpenMap() {
        StopAllCoroutines();

        StartCoroutine(LerpPositions(isOpen ? closedPos : openPos, isOpen ? Vector3.one : openScale, isOpen ? closedFov : openFov, .2f));
        isOpen = !isOpen;
    }

    IEnumerator LerpPositions(Vector2 targetPosition, Vector3 targetSize, float targetFov, float duration)
    {        
        float time = 0;
        Vector2 startPosition = mapTransform.localPosition;
        Vector3 startSize = mapTransform.localScale;
        float startFov = mapCamera.fieldOfView;

        while (time < duration)
        {
            mapTransform.localPosition = Vector2.Lerp(startPosition, targetPosition, time / duration);
            mapTransform.localScale = Vector3.Lerp(startSize, targetSize, time / duration);
            mapCamera.fieldOfView = Mathf.Lerp(startFov, targetFov, time / duration);
            
            time += Time.deltaTime;
            yield return null;
        }

        mapTransform.localPosition = targetPosition;
        mapTransform.localScale = targetSize;
    }
}
