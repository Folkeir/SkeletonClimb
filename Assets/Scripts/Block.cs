using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Block : MonoBehaviour
{
    [SerializeField] Mesh[] blocks;
    [SerializeField] BlockAddition[] BlockAdditions;
    MeshFilter _meshFilter;
    [SerializeField] GameObject[] particles;
    [SerializeField] int particleAmount;
    [SerializeField] VisualEffect breakEffect;
    [SerializeField] int health = 6;
    [SerializeField] GameObject shatteredObject;
    [SerializeField] float shatteredObjectForce = 100;
    [SerializeField] bool hasDamagedMesh =true;
     bool randomizeBlock =false;
    
    [SerializeField] bool explodeable = false;
    [SerializeField] float explodeForceRadius = 2;
    [SerializeField] float explosionForce = 100;
    [SerializeField] bool explodeOnCollision = false;
    [SerializeField] VisualEffect explosion;
    [SerializeField] GameObject damageDecal;
    [SerializeField] bool randomizeMesh = false;
    void Start()
    {

        _meshFilter = GetComponent<MeshFilter>();
        if (randomizeBlock)
        {
            int randomIndex = Random.Range(0, blocks.Length);
            _meshFilter.mesh = blocks[randomIndex];
        }


    }

    public void Break()
    {
        if (damageDecal != null) { damageDecal.SetActive(false); }
       
        if (BlockAdditions != null)
        {
            foreach (BlockAddition blockAddition in BlockAdditions)
            {
                if (blockAddition != null)
                {
                    blockAddition.DropAdditions();
                }
                
            }

        }
        
       
        foreach (Transform child in transform)
        {
            // Check if the child GameObject has the desired tag
            if (child.CompareTag("Hook"))
            {
                // Do something with the GameObject that has the tag
                Debug.Log("Found tag " + "Hook" + " in child: " + child.name);
                child.GetComponent<Rigidbody>().useGravity = true;
            }
        }
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        shatteredObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(false);
        for(int i = 0; i < shatteredObject.transform.childCount-1; i++)
        {
            shatteredObject.transform.GetChild(i).GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * shatteredObjectForce);
        }
        if (explodeable)
        {
            explosion.Play();
            Collider[] colliders = Physics.OverlapSphere(transform.position, explodeForceRadius);

            foreach(Collider collider in colliders)
            {
                if (collider.gameObject.GetComponent<Block>() != null)
                {
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                    collider.gameObject.GetComponent<Block>().TakeDamage();
                }
                if(collider.gameObject.tag == "Dynamic" || collider.gameObject.tag == "Player")
                {
                    if(collider.gameObject.GetComponent<Rigidbody>() != null)
                    {
                        collider.gameObject.GetComponent<Rigidbody>().AddForce((collider.transform.position - transform.position).normalized * explosionForce, ForceMode.Impulse);
                    }
                   
                }
            }
        }
            
        
        Invoke("DestroyThis", 2);
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }
    public void TakeDamage()
    {
       
        health--;
        

        breakEffect.Play();
      //  Debug.Log("TakeDAmage, Current hP: " + health);
        if (health == 2 && hasDamagedMesh)
        {

           // _meshFilter.mesh.Clear();
           // transform.GetChild(0).gameObject.SetActive(true);
           damageDecal.SetActive(true);

        }
        if (health <= 0)
        {
            Break();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && explodeOnCollision)
        {
            Break();
        }
    }
}
