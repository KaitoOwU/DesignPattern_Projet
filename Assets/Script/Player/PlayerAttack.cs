using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Vector3? GetTargetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return null;
    }
}
