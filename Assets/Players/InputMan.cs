using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class InputMan : MonoBehaviour
{
    private PlayerUI playerUI;
    private PlayerInput playerInput;
    private InputActions inputs;
    private Vector2 aimInputVector = new Vector2(0, 0);
    private float startingZ = 0;
    public Renderer mesh;
    Material materialInstance;
    [SerializeField] Vector2[] playerColors;
    [SerializeField] Material eyeMaterial;
    [SerializeField] Material[] eyeMaterialsList;
    [SerializeField] GameObject playerMesh;
    [SerializeField] GameObject[] hats;
    int currentColorIndex=0;

    [SerializeField] GameObject aimReticle;
    [SerializeField] Rigidbody aimHand;
    [SerializeField] Rigidbody otherHand;
    [SerializeField] Rigidbody head;
    [SerializeField] Rigidbody legR;
    
    [SerializeField] float aimForceMultiplier = 100.0f;
    private Rigidbody hips;
    private float aimReticleDepth = 10;
    private Vector3 aimVector;
    private Vector3 aimHandPos;

    [SerializeField] GameObject grappleProjectile;
    [SerializeField] float grappleProjectileForce = 700.0f;
    [SerializeField] float grapplingForce = 500.0f;
    private bool isHooked = false;

    [SerializeField] VisualEffect jetpackVfx;
    [SerializeField] VisualEffect hookShootVfx; 
    [SerializeField] Light jetPackLight;
    [SerializeField] float jetPackForce;
    [SerializeField] float jetPackTime;
    [SerializeField] float jetPackResetTime;
    [SerializeField] GameObject jetPackReadyEffect;
    [SerializeField] CameraScript cameraScript;
    bool jetPackReady = true;
    bool isJetPacking = false;
    bool isPunching = false;
    bool lastPunchDir = false;
    bool isDead = false;


   
    public bool isAutoStand = true;
    [SerializeField] float autoStandForce;

    //Punch
    [SerializeField] VisualEffect swordVFX;

    //Sounds

    [SerializeField] AudioSource playerSound1;
    [SerializeField] AudioClip[] SwordSwoshes;


    //Managers
    [SerializeField] GameManager gameManager;

    public void OnAimStick(InputAction.CallbackContext context)
    {
        aimInputVector = context.ReadValue<Vector2>();
    }

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        startingZ = transform.position.z;
        hips = GetComponent<Rigidbody>();
        cameraScript = GameObject.Find("GameManagerCamera").GetComponent<CameraScript>();
       // assignPlayerColor(3);
       // eyeMaterial = playerMesh.GetComponent<SkinnedMeshRenderer>().materials[1];
        //materialInstance = new Material(mesh.material);
        //mesh.material = materialInstance;
        //mesh.material.SetVector("_mainColorAdjust", new Vector2(0,0));
    }

    private void FixedUpdate()
    {
       
        Vector3 aimForce = new Vector3(-aimInputVector.x * aimForceMultiplier, aimInputVector.y * aimForceMultiplier, 0);
        // aimVector = aimHand.transform.TransformDirection(Vector3.up).normalized;
        //aimVector = new Vector3(aimVector.x, aimVector.y, 0);
        aimVector = new Vector3(-aimInputVector.x, aimInputVector.y, 0).normalized;
        aimHandPos = aimHand.transform.position;
        if (aimInputVector.magnitude > 0.1f)
        {
            aimHand.drag = 8.0f;
        }
        else
        {
            aimHand.drag = 1;
        }

        Vector3 aimPos = new Vector3(transform.position.x + aimVector.x * 3, transform.position.y + +aimVector.y * 3, aimReticleDepth);
        aimReticle.transform.position = aimPos;

        aimHand.AddForce(aimForce);
        if (isAutoStand)
        {
            hips.AddForce(Vector3.up * autoStandForce);
            head.AddForce(Vector3.up * (autoStandForce * 1.2f));
            return;
        }
        if (isHooked)
        {
            Vector3 grappleVect = grappleProjectile.transform.position - aimHand.position;
            float forcePercent = Mathf.InverseLerp(0, 10, grappleVect.magnitude);
            Vector3 force = grappleVect.normalized;
            force = force * forcePercent * grapplingForce;
            aimHand.AddForce(force * grappleProjectileForce);
        }
        if (isJetPacking)
        {
            aimHand.AddForce((aimHand.transform.up + (Vector3.up * 1/2)) * jetPackForce * 1);
           // aimHand.AddForce((aimHand.transform.forward + (Vector3.up * -1 / 2)) * jetPackForce * -1);
           // otherHand.AddForce((aimHand.transform.forward + (Vector3.up * -1 / 2)) * jetPackForce * -1);
            jetPackLight.intensity = Mathf.Sin(Time.deltaTime * 100);
           
        }
        float zForcePercent = Mathf.InverseLerp(startingZ, startingZ + 1, Mathf.Abs(transform.position.z));
        Vector3 zforce = new Vector3(0, 0, -1 * Mathf.Sign(transform.position.z) * zForcePercent * 100);
        hips.AddForce(zforce);
    }
    public void JetPack(InputAction.CallbackContext context)
    {
        if (!jetPackReady) { return; }
        if (!isJetPacking)
        {
            jetpackVfx.Play(); isJetPacking = true;
            jetPackLight.enabled = true;
            Invoke("JetPackOff", jetPackTime);
            jetPackReady = false;
            jetPackReadyEffect.SetActive(false);
        }
        
    }
    public void Grapple(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && !isAutoStand)
        {
            grappleProjectile.GetComponent<grapplingHook>().shootgrapple(aimHandPos, aimVector);
            hookShootVfx.Play();
        }
    }

    public void GrappleRelease(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Canceled)
        {
            grappleProjectile.GetComponent<grapplingHook>().disableGrapple();
        }
    }
    public void Punch(InputAction.CallbackContext context)
    {
        if (isPunching) { return; }
        isPunching = true;
        if (!lastPunchDir)
        {
           
            lastPunchDir = true;
            Vector3 punchDirection = Vector3.up;
            otherHand.AddForce(punchDirection.normalized * 5, ForceMode.Impulse);
        }
        else
        {
           
            lastPunchDir = false;
            Vector3 punchDirection =  Vector3.down;
            otherHand.AddForce(punchDirection.normalized * 5, ForceMode.Impulse);
        }

        Debug.Log("lastPunchdir = "+  lastPunchDir);
        
       
        swordVFX.Play();
        int randomSound = Random.Range(0, SwordSwoshes.Length-1);
        playerSound1.clip = SwordSwoshes[randomSound];
        playerSound1.Play();
        Invoke("StopPunch", 0.3f);
        Invoke("EndPunch", 0.1f);
        
    }
    private void StopPunch()
    {
        swordVFX.Stop();
    }

    private void EndPunch()
    {
        isPunching = false;
    }
    public void Next(InputAction.CallbackContext context)
    {
        if (cameraScript.playerSelect&& context.performed)
        {
             mesh.material.SetVector("_mainColorAdjust",playerColors[currentColorIndex]);
            Debug.Log("colorIndex" + currentColorIndex);
            currentColorIndex++;
            if(currentColorIndex >= playerColors.Length)
            {
                currentColorIndex = 0;
            }
            //materialInstance
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == grappleProjectile)
        {
            Unhooked();
        }
    }

    public void Hooked()
    {
        isHooked = true;
    }

    public void Unhooked()
    {
        isHooked = false;
    }

    private void JetPackOff()
    {
        isJetPacking = false;
        Invoke("JetPackOn",jetPackResetTime);
        jetpackVfx.Stop();
        jetPackLight.enabled = false;
        if (!isDead) { playerUI.PlayerBoostUnready(); ; }
    }
    private void JetPackOn()
    {
        jetPackReady = true;
        jetPackReadyEffect.SetActive(true);
        if (!isDead) { playerUI.PlayerBoostReady(); ; }
        
    }
    public void AutoStand(bool on)
    {
        isAutoStand = on;
    }

    public void StartButton(InputAction.CallbackContext context)
    {   if (context.performed && gameManager.gameOver || context.performed && gameManager.victory)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
        if (cameraScript.playerSelect && context.performed)
        {
            cameraScript.StopPlayerSelect();
        }
    }
    public void assignPlayerColor(int playerNr)
    {
        SkinnedMeshRenderer smr = playerMesh.GetComponent<SkinnedMeshRenderer>();

        // Get a copy of the materials array (creates instances if not already)
        Material[] mats = smr.materials;

        // Assign the new material to index 0
        mats[1] = eyeMaterialsList[playerNr];

        // Reassign the modified array back to the renderer
        smr.materials = mats;
        if(playerNr != 0)
        {
            hats[playerNr].gameObject.SetActive(true);
        }
    }
    public void AssignPlayerUI(PlayerUI playerUIToAssign)
    {
        
        playerUI = playerUIToAssign;
    }
    public void OnDeath()
    {
        playerUI.PlayerDeadIcon();
        isDead = true;
    }
}
