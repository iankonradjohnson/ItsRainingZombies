using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ZombieController : MonoBehaviour
{
    public GameObject character;
    Animator zombieAnimator;
    public float minDistance;
    public float chaseSpeed = 4;
    public GameObject bulletPrefab;
    public UnityEngine.UI.Text score;
    public UnityEngine.UI.Text health;
    private int ScoreInt;

    // Start is called before the first frame update
    void Start()
    {
        zombieAnimator = gameObject.GetComponent<Animator>();
    }


    void OnCollisionEnter(Collision collisionObj)
    {
        // if bullet hits a zombie, kill it and increment score
        if (collisionObj.gameObject.tag == "Bullet")
        {
            // increment score
            ScoreInt = System.Int32.Parse(score.text) + 1;
            score.text = ScoreInt.ToString();


            zombieAnimator.SetTrigger("deathTrigger");
            transform.LookAt(character.transform);
            Destroy(collisionObj.gameObject);
        }
    }



    void Update()
    {
        // get distance of zombie
        float distance = Vector3.Distance(gameObject.transform.position, character.transform.position);

        // if current animation is zombie death, wait a second then destroy object
        if (zombieAnimator.GetCurrentAnimatorStateInfo(0).IsName("Zombie Death") && zombieAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Destroy(this.gameObject);
        }

        // if current animation is zombie death, corrent orientation and do nothing
        if (zombieAnimator.GetCurrentAnimatorStateInfo(0).IsName("Zombie Death"))
        {
            transform.LookAt(character.transform);
            return;
        }

        // if animation is zombie attack and within attack range, stop movement
        if (zombieAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Zombie Attack" && distance < minDistance)
        {
            transform.LookAt(character.transform);

            if (!(System.Int32.Parse(health.text) <= 0))
            {
                health.text = (System.Int32.Parse(health.text) - 3).ToString();
            }

            return;
        }

        // if distance is within range in general, attack
        if (distance < minDistance)
        {
            zombieAnimator.SetTrigger("attackTrigger");
            zombieAnimator.ResetTrigger("runTrigger");
            transform.LookAt(character.transform);
            return;
        }
        // else keep running toward camera
        else
        {
            zombieAnimator.SetTrigger("runTrigger");
            zombieAnimator.ResetTrigger("attackTrigger");

            transform.LookAt(character.transform);
            transform.Translate(chaseSpeed * Vector3.forward * Time.deltaTime);
        }
    }
}
