using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private float Minspeed = 12;  
    private float Maxspeed = 16;
    private float Maxtorque = 10;
    private float Xrange = 4;
    private float Yspanpos = -2;
    private GameManager gameManager;
    public int PointValue;
    public ParticleSystem explotionparticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(),RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.IsGameActive)
        {
            Destroy(gameObject);
            Instantiate(explotionparticle, transform.position, explotionparticle.transform.rotation);
            gameManager.UpdateScore(PointValue);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
         {

         gameManager.Gameover();

         }
        
    }
    Vector3 RandomForce()
    {
        return  Vector3.up *Random.Range(Minspeed, Maxspeed);
    }

    float RandomTorque()
    {
        return Random.Range(-Maxtorque, Maxtorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-Xrange, Xrange), Yspanpos);
    }
}
