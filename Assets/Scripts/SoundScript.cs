using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public CatMovement catMovement;
    public AudioSource staticSound;
    public AudioSource breathingSound;
    public AudioSource heartBeatSound;
    
    public AudioSource flickerSound; 
    public AudioSource doorSound;
    private bool doorSoundPlayed = false;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(catMovement.currentPointIndex)
        {
            case 0:
                
                break;
            case 1:
                break;
            case 2:
            if (flickerSound.isPlaying == false)
            {
                flickerSound.volume = 0.1f;
                flickerSound.Play();
            }
            if (breathingSound.isPlaying == false)
            {
                breathingSound.volume = 0.1f;
                breathingSound.Play();
            }
                break;
            case 3:
            if(breathingSound.isPlaying == false)
                {
                    breathingSound.volume = 0.2f;
                    breathingSound.Play();
                }
                if (heartBeatSound.isPlaying == false)
                {
                    heartBeatSound.volume = 0.2f;
                    heartBeatSound.Play();
                }
                if (!doorSoundPlayed)
                {
                    doorSound.volume = 0.05f;
                    doorSound.Play();
                    doorSoundPlayed = true;
                }
            
                break;
                case 4:
                if (breathingSound.isPlaying == false)                {
                    breathingSound.volume = 0.3f;
                    breathingSound.Play();
                }
                if(staticSound.isPlaying == true)
                {
                    staticSound.Stop();
                }
                if (staticSound.isPlaying == true)
                {
                    staticSound.volume = 0.0f;
                    staticSound.Play();
                }
                break;
                case 5:
                if (staticSound.isPlaying == false)
                {
                    staticSound.volume = 0.3f;
                    staticSound.Play();
                }
                if(heartBeatSound.isPlaying == false)
                {
                    heartBeatSound.volume = 0.3f;
                    heartBeatSound.Play();
                }
                break;
        }

    }
}