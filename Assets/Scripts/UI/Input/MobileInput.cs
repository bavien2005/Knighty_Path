using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static float horizontal = 0;
    public static bool jump = false;

    public void MoveLeft() => horizontal = -1;
    public void MoveRight() => horizontal = 1;
    public void StopMove() => horizontal = 0;
    public void Jump() => jump = true;

    public void MoveUp() => jump = false;
}
