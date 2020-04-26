using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private Animator playerAnimation;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtPartical;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public GameObject button;
    public float jumpForce=13 ;
    public float gravityModifier=2 ;
    public bool isOnground= true;
    public bool gameOver;
    private bool isAlive=true;

    //Counter
    public Text timerText;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody= GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnground && (isAlive ==true) )
        {
            playerRigidBody.AddForce(Vector3.up * jumpForce , ForceMode.Impulse );
            isOnground =false;
            playerAnimation.SetTrigger("Jump_trig");
            dirtPartical.Stop();
            playerAudio.PlayOneShot(jumpSound,1.0f);
        }

        UpdateTimerUI();


    }
    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnground=true;
            dirtPartical.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            explosionParticle.Play();
            dirtPartical.Stop();
            Debug.Log ("Game Over!");

            button.SetActive(true);
            gameOver=true;
            playerAnimation.SetBool("Death_b", true);
            playerAnimation.SetInteger("DeathType_int",1);
            isAlive=false;
            playerAudio.PlayOneShot(crashSound,1.0f);

        }
    }
    public void UpdateTimerUI()
    {
        if (isAlive)
        {

            //set timer UI
            secondsCount += Time.deltaTime;
            timerText.text = hourCount + "h:" + minuteCount + "m:" + (int)secondsCount + "s";
            if (secondsCount >= 60)
            {
                minuteCount++;
                secondsCount = 0;
            }
            else if (minuteCount >= 60)
            {
                hourCount++;
                minuteCount = 0;
            }
        }
        
    }

}
