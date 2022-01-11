using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomEnd : MonoBehaviour
{

    private Vector3 endPos;
    public float speed;
    public GameObject myCamra;
    bool move;
    bool used;

    public GameObject nextSpawnPoint;
    public GameObject preRoom;
    public GameObject nextDoor;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            myCamra.transform.position = Vector3.Lerp(myCamra.transform.position, endPos, speed * Time.deltaTime);
            if(myCamra.transform.position == endPos)
            {
                move = false;
            }
        }
    }

    public void setPosition()
    {
        endPos = new Vector3(myCamra.transform.position.x + 42.7f, myCamra.transform.position.y, myCamra.transform.position.z);
        move = true;
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(used == false)
            {
                setPosition();
                used = true;
                Destroy(preRoom);
                nextDoor.GetComponent<doorScript>().isWorking = true;
                nextSpawnPoint.GetComponent<spawnRandom>().spawn();
            }

        }

    }
}
