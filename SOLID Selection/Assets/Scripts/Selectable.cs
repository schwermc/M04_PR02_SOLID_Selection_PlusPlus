using TMPro;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lookPercentageLabel;
    [HideInInspector] public float lookPrecentage;

    public void Update()
    {
        lookPercentageLabel.text = lookPrecentage.ToString("F3");
        lookPercentageLabel.transform.LookAt(Camera.main.transform.position);
        lookPercentageLabel.transform.Rotate(0, 180, 0);
    }
}
