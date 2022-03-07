using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayerBeads : MonoBehaviour
{
    public GameObject Player;
    public GameObject pickupParticle;
    private AudioSource audioSource;
    public AudioClip pickupkey;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(pickupkey, transform.position);
            Player.GetComponent<PlayerController>().AddPrayerBead();
            Instantiate(pickupParticle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}