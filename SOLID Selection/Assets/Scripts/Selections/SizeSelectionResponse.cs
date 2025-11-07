using UnityEngine;

public class SizeSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] float scaler = .5f;
    private Vector3 rescale;
    private Vector3 orgianl;

    public void OnSelect(Transform selection)
    {
        var transform = selection.GetComponent<Transform>();
        SetScales(transform);
        if (transform != null)
            transform.localScale = rescale;
    }

    public void OnDeselect(Transform selection)
    {
        var transform = selection.GetComponent<Transform>();
        if (transform != null)
            transform.localScale = orgianl;
    }

    void SetScales(Transform selection)
    {
        orgianl = selection.localScale;
        rescale = selection.localScale * scaler;
    }
}
