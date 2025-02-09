using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    bool hasPackage = false;
    [SerializeField] float destroyTime = 1f;

    SpriteRenderer spriteRenderer;
    Driver driver;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   
        driver = GetComponent<Driver>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch! It's so painful!");
        driver.moveSpeed = driver.slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("You got the Package!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyTime);
        }

        if(other.tag == "Customer")
        {
            if(hasPackage)
            {
                Debug.Log("You delivered the package!");
                hasPackage = false;
                spriteRenderer.color = noPackageColor;
            }
            else
            {
                Debug.Log("You don't have a package to deliver!");
            }
        }

        if(other.tag == "booster")
        {
            Debug.Log("You got a boost!");
            driver.moveSpeed = driver.boostSpeed;
        }
    }

}
