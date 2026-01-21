using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MapDrag : MonoBehaviour
{

    [Header("DRAG CAMERA")]
    [SerializeField] private float dragSpeed = 1f;
    [SerializeField] private Vector2 minLimit;
    [SerializeField] private Vector2 maxLimit;

    private Vector3 lastMousePos;
    private bool isDragging;

    [Header("ScrollWheel")]
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float minZoom = 3f;
    [SerializeField] private float maxZoom = 10f;


    private Camera cam;


    private void Awake()
    {
        cam = GetComponent<Camera>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 delta = Input.mousePosition - lastMousePos;
            Vector3 move = new Vector3(-delta.x, -delta.y, 0) * dragSpeed * Time.deltaTime;

            transform.Translate(move);

            lastMousePos = Input.mousePosition;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scroll) > 0.01f)
        {
            cam.orthographicSize -= scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(
                cam.orthographicSize,
                minZoom,
                maxZoom
            );
        }
    }
 
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minLimit.x, maxLimit.x);
        pos.y = Mathf.Clamp(pos.y, minLimit.y, maxLimit.y);
        transform.position = pos;
    }
}
