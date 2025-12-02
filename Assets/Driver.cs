using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField]float steerSpeed = 180f;
    [SerializeField]float moveSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        float steer = 0f;
        float move = 0f;

        if(Keyboard.current.wKey.isPressed)
        {
            move = 1f;
            Debug.Log("W key is pressed");
        }

        else if(Keyboard.current.sKey.isPressed)
        {
            move = -1f;
            Debug.Log("S key is pressed");
        }
        if (Keyboard.current.aKey.isPressed)

        {
            steer = 1f;
            Debug.Log("A key is pressed");
        }
        
        else if(Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
            Debug.Log("D key is pressed");
        }
        
        float moveamount = move * moveSpeed * Time.deltaTime;
        float steeramount = steer * steerSpeed * Time.deltaTime;

        transform.Translate(0,moveamount,0);
        transform.Rotate(0, 0, steeramount);
        //transform.Translate(0, 0, 1);
    }
}
