using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    [SerializeField]
    private Collider2D z_Collider;
    [SerializeField]
    private ContactFilter2D z_Filter;
    //only store one object, so first thing it collides with will be stored here
    private List<Collider2D> z_CollidedObjects = new List<Collider2D>(1);
    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //1st parameter is attribute who we ned to collide with, 2nd is the results
        z_Collider.OverlapCollider(z_Filter, z_CollidedObjects);

        //to check if we collided with anything go through the list
        foreach(var o in z_CollidedObjects)
        {
            OnCollided(o.gameObject);
        }
    }

    protected virtual void OnCollided(GameObject collidedObject)
    {
        Debug.Log("collided with " + collidedObject.name);
    }
}
