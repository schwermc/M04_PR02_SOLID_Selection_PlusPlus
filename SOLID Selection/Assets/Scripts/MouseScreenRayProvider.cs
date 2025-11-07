using UnityEngine;

public class MouseScreenRayProvider : MonoBehaviour, IRayProvider
{
    public Ray CreateRay()
    {
        return Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        // return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}