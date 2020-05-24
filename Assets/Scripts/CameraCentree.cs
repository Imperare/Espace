using UnityEngine;

public class CameraCentree : MonoBehaviour
{
    public GameObject fusee;
    public float timeOffset;
    public Vector3 posOffset;
    public Vector3 velocite;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, fusee.transform.position + posOffset, ref velocite, timeOffset);
    }
}
 