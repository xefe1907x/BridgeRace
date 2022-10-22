using DG.Tweening;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip makeStairSound;
    
    float colorChangeDuration = 0.45f;
    void Start()
    {
        DOTween.Init();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void BuildStairsSoundActivator()
    {
        audioSource.PlayOneShot(makeStairSound);
    }

    void BlueColorChange()
    {
        gameObject.transform.GetComponent<Renderer>().material.DOColor(Color.blue, colorChangeDuration);
    }
    
    void RedColorChange()
    {
        gameObject.transform.GetComponent<Renderer>().material.DOColor(Color.red, colorChangeDuration);
    }
    
    void GreenColorChange()
    {
        gameObject.transform.GetComponent<Renderer>().material.DOColor(Color.green, colorChangeDuration);
    }
    
    void YellowColorChange()
    {
        gameObject.transform.GetComponent<Renderer>().material.DOColor(Color.yellow, colorChangeDuration);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            if (other.gameObject.GetComponent<BluePlayer>())
            {
                BlueColorChange();
                
                if (gameObject.GetComponent<MeshRenderer>().enabled == false)
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                    BuildStairsSoundActivator();
                }
            }
            
            else if (other.gameObject.GetComponent<RedPlayer>())
            {
                RedColorChange();
                
                if (gameObject.GetComponent<MeshRenderer>().enabled == false)
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                    BuildStairsSoundActivator();
                }
            }
            
            else if (other.gameObject.GetComponent<GreenPlayer>())
            {
                GreenColorChange();
                
                if (gameObject.GetComponent<MeshRenderer>().enabled == false)
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                    BuildStairsSoundActivator();
                }
            }
            
            else if (other.gameObject.GetComponent<YellowPlayer>())
            {
                YellowColorChange();
                
                if (gameObject.GetComponent<MeshRenderer>().enabled == false)
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                    BuildStairsSoundActivator();
                }
            }
        }
    }
}
