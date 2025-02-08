using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Circle: Hey! You hit me!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Martinee blue");   
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("Good bye");    
    }
}
