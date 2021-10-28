using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Animator eyeBallAnimator;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
            eyeBallAnimator.SetFloat("distanceWithPlayer", distToPlayer);
    }
}
