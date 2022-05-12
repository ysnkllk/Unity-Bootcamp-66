using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : MonoBehaviour
{
    public static Scream instance;
    private Rigidbody2D rbHazel;
    

    public Transform firePoint;
    public Transform player;
    
    public GameObject screamPrefab;
    


    public float screamForce= 10f;
    public float y= 100f;
    public float x= 1f;

    private void Awake() => instance = this;

    void Start() 
    {
        firePoint=gameObject.transform;
     rbHazel = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Coroutine coroutine = StartCoroutine(instance.ScreamHazel(x, y, this.transform));
           
       }
    }


     void Shoot()
  {
    GameObject scream= Instantiate(screamPrefab, firePoint.position, firePoint.rotation);
    Rigidbody2D rbScream=scream.GetComponent<Rigidbody2D>();
    rbScream.AddForce(firePoint.right*screamForce,ForceMode2D.Impulse);
  }
  
 public IEnumerator ScreamHazel (float x, float y, Transform obj)
    {
        float timer = 0f;

        while(x > timer)
        {
            timer += Time.deltaTime;
            Vector2 dir = (obj.transform.position - this.transform.position).normalized;
            rbHazel.AddForce(-dir * y);
        }

        yield return 0;
    }


  
}
