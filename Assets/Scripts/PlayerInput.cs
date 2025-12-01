using System.Drawing;
using Unity.Mathematics;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]private float _speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            print("Ik heb W ingedrukt.");
            Vector3 position = new Vector3(0, 0, 0);
            transform.position += (new Vector3(0, 1, 0) * Time.deltaTime * _speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            print("Ik heb A ingedrukt");
            Vector3 position = new Vector3(0, 0, 0);
            transform.position += (new Vector3(-1, 0, 0) * Time.deltaTime * _speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            print("Ik heb D ingedrukt.");
            Vector3 position = new Vector3(0, 0, 0);
            transform.position += (new Vector3(1, 0, 0) * Time.deltaTime * _speed);
        }
    }
}