using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            transform.position = new Vector3(_target.transform.position.x, transform.position.y, -10);
        }
    }
}
