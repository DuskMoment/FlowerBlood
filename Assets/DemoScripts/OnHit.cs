using UnityEngine;

public class OnHit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var contact = collision.contacts;

        Debug.Log("contact count");
        foreach (var c in contact) 
        {
            Debug.Log("CONTACTPOINT " + c.point);
        }
        WeponData data = new WeponData();
        data.impactType = ImpactType.BLUNT;
        data.mass = 10f;
        data.damadge = 1;

        GetComponent<FlowerBloodHandler>().CreateBloodAtLocation(contact[0].point, collision, data);
    }
    //keep track of acceleration because thjis is dumb unlike unreal >:(
}
