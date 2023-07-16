using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject ball;
    [SerializeField]
    CannonController cannonController;

    GameObject currentBall;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clocked");
        Instantiate(ball);
    }

    void OnMouseDown()
    {
        currentBall = Instantiate(ball,cannonController.muzzle.transform.position, Quaternion.identity);
        currentBall.GetComponent<Rigidbody2D>().AddForce(cannonController.getShootingVector());

    }
}
