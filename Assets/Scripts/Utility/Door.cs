using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousSector;
    [SerializeField] private Transform nextSector;
    [SerializeField] private CameraController cam;


    private void Awake()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                cam.MovetoNewSector(nextSector);
                nextSector.GetComponent<Room>().ActivateRoom(true);
                previousSector.GetComponent<Room>().ActivateRoom(false);
            }
            else
            {
                cam.MovetoNewSector(previousSector);
                previousSector.GetComponent<Room>().ActivateRoom(true);
                nextSector.GetComponent<Room>().ActivateRoom(false);
            }
                
                
        }
    }
}
