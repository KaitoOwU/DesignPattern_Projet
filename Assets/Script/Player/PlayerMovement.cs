using UnityEngine;

public class PlayerMovement : EntityMovement
{
    
    public void MoveToMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _agent.SetDestination(hit.point);
        }
    }
    
}
