using UnityEngine;
using System.Collections;
public class Arrow : MonoBehaviour
{
    public float lifetime;
    public float damage;


    public void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            //hurt the player
        }
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(lifetime);
        Die();
    }
    private void Die()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
