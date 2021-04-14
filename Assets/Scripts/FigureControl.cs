using UnityEngine;

public class FigureControl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "TimeToDestroy")
        {
            Destroy(gameObject);
        }
    }
}
