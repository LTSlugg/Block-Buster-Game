using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D _rgbd2;
    [SerializeField] int speed = 8;
    

    // Start is called before the first frame update
    void Start()
    {
       _rgbd2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputChecker();
    }

    private void InputChecker()
    {
        _rgbd2.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), 0);
    }
}
