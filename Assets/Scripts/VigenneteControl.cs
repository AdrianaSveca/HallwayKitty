
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class VigenneteControl : MonoBehaviour
{
    public CatMovement catMovement;
    public Volume globalVolume;
    private Vignette vignette;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globalVolume.profile.TryGet(out vignette);
        //get the vignette component from the global volume, used to control the intensity of the vignette effect
        
    }

    // Update is called once per frame
    void Update()
    {
        if (catMovement.currentPointIndex == 5)
        {
            //get vigenette component and set its intensity to 0.5, 
            // creating a vignette effect when the player reaches the cat
            vignette.color.value= Color.red;
            vignette.intensity.value = 0.1f;
            

        }
        else if (catMovement.currentPointIndex == 6)
        {
            //get vigenette component and set its intensity to 1.5, 
            // removing the vignette effect when the player reaches the cat
            vignette.color.value= Color.red;
            vignette.intensity.value = 0.3f;
            
        }
        else if (catMovement.currentPointIndex == 7)
        {
            //get vigenette component and set its intensity to 0.5, 
            // creating a vignette effect when the player reaches the cat
            vignette.color.value= Color.red;
            vignette.intensity.value = 0.7f;
            
        }
        
    }
}
