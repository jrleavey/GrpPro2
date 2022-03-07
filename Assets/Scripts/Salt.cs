using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salt : MonoBehaviour
{
    public GameObject Player;
    public GameObject pickupParticle;
    private AudioSource AudioSource;
    public AudioClip pickup;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(pickup, transform.position);
            Player.GetComponent<PlayerController>().AddSaltCount();
            Instantiate(pickupParticle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}