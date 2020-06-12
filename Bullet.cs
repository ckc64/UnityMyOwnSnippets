
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Vector3 shootDir;

   public void Setup()
    {
       
        Destroy(gameObject, 3f);
    }


    private void OnCollisionEnter2D(Collision2D collidedObject)
    {
       
        Debug.Log(collidedObject.collider.name);
        Destroy(gameObject);
    }
    private void Update()
    {
        //float moveSpeed = 100f;
        //transform.position += shootDir * moveSpeed * Time.deltaTime;
        Setup();
    }

    private float ConvertVectorFloatToAngle(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(n < 0)
        {
            n += 360;
        }

        return n;
    }
}
