using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    private float _cameraSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            Vector3 desiredPos = _target.position + _offset;
            transform.position = Vector3.Lerp(transform.position, desiredPos, _cameraSpeed * Time.deltaTime);
        }
    }
}
