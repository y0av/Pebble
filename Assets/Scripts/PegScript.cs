using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegScript : MonoBehaviour
{
    bool isOn = true;
    [SerializeField] Color hitColor;
    [SerializeField] Sprite hitSprite;
    [SerializeField] float maxPlayerContactSeconds = 2;
    public ParticleSystem explosionParticles;

    // amount of time the player is incontact with this peg.
    float playerContactTime = 0;

    void Hit()
    {
        isOn = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = hitSprite;
        gameObject.GetComponent<SpriteRenderer>().color = hitColor;
        GetComponent<PeglAudioManager>().Hit(++LevelManager.Instance.currentPlayPegHit);
        GetComponentInChildren<TextPop>().TriggerPop(19);
        explosionParticles.Play();
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("stay: " + playerContactTime);
            playerContactTime += Time.deltaTime;
            if (playerContactTime > maxPlayerContactSeconds)
            {
                LevelManager.Instance.KillPeg(gameObject);
            }
        }
    }
}
