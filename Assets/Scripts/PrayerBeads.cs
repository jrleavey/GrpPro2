using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayerBeads : MonoBehaviour
{
    public GameObject Player;
    public GameObject pickupParticle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.GetComponent<PlayerController>().AddPrayerBead();
            Instantiate(pickupParticle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}