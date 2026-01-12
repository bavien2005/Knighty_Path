using UnityEngine;


public class CursorManager : MonoBehaviour
{
    public Texture2D handCursor;
    public Vector2 hotSpot = Vector2.zero;

    public static CursorManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetHandCursor()
    {
        Cursor.SetCursor(handCursor, hotSpot, CursorMode.Auto);
    }

    public void ResetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}

