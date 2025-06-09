using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    [SerializeField] private float constScale;
    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        //3D Sprite test용
        var distance = Vector3.Distance(this.transform.position, target.transform.position);
        this.transform.localScale = Vector3.one * (distance * constScale);

        this.transform.forward = target.transform.forward;
    }
}
