using UnityEngine;

public class Coin : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerStats>() == null) { return; }

        collision.gameObject.GetComponent<PlayerStats>().CollectCoin();
        Destroy(this.gameObject);
    }
}
