using UnityEngine;
using System.Collections;


public class SpeedEffect : MonoBehaviour {

    public ParticleSystem starParticles;

    ParticleSystemRenderer psr;
    private PlayerController pc;
    private float minSpeed;
    private float maxSpeed;

    void Start()
    {
        psr = starParticles.GetComponent<ParticleSystemRenderer>();
    }
    
    public void SetMinMaxSpeed(float minSpeed, float maxSpeed)
    {
        this.minSpeed = minSpeed;
        this.maxSpeed = maxSpeed;
    }

	public void ChangeSpeed(float speed)
    {
        
            float velocityScale = (speed > minSpeed) ? (speed - minSpeed) / (maxSpeed - minSpeed) : 0;
            psr.velocityScale = velocityScale / 2 ;
       
            float lengthScale = (speed < minSpeed) ? speed / 20 : 1;
            psr.lengthScale = 20 * lengthScale;
    }
}
