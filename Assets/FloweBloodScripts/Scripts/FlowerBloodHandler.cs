using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UIElements;

//this would be in some wepontype base class
public enum ImpactType
{
    BLUNT = 0,
    SHARP
}
public struct WeponData
{
    public float damadge;
    public ImpactType impactType;
    public float mass;
}
public class FlowerBloodHandler : MonoBehaviour
{
    [Tooltip("this is the partical system used when the object is hit")]
    [SerializeField] private ParticleSystem bloodSystem;
    private List<ParticleSystem> bloodParticles = new();

    List<Tuple<ParticleSystem, List<ParticleCollisionEvent>>> activeCollision = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CreateBloodAtLocation(Vector3 location, Collision2D col, WeponData data)
    {
        var hitLocation = location;
        var hitVel = col.rigidbody.linearVelocity;
        var hitNormal = col.contacts[0].normal;

        var system = Instantiate(bloodSystem, this.transform);
        system.transform.position = hitLocation;    

        //create the angle
        switch(data.impactType)
        {
            case ImpactType.SHARP:
                system.transform.rotation = Quaternion.LookRotation(hitVel);
                break;
            case ImpactType.BLUNT:
                //rotate to the impact normal
                system.transform.rotation = Quaternion.LookRotation(-hitNormal);
                break;
        }

        //change partical size based on force
      


    }
    private void OnParticleCollision(GameObject other)
    {
        activeCollision.Clear();
        //clean up the list before we look at it
        bloodParticles.RemoveAll(p => !p.IsAlive()); 

        //get all active blood systems and check if the collided with the thing
        foreach (var particle in bloodParticles) 
        {
            List<ParticleCollisionEvent> col = new List<ParticleCollisionEvent>();

            int numCol = particle.GetCollisionEvents(other, col);

            //if we have a collision add it to the active collisions
            if (numCol > 0) 
            {
                activeCollision.Add(new(particle, col));
            }
        }

    }
}
