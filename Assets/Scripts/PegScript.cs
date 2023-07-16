using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegScript : MonoBehaviour
{
    bool isOn = true;
    [SerializeField] Color hitColor;
    [SerializeField] Sprite hitSprite;
    void Hit()
    {
        isOn = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = hitSprite;
        gameObject.GetComponent<SpriteRenderer>().color = hitColor;
    }

    bool GetIsOn()
    {
        return isOn;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            Hit();
        }
    }
}
