using DG.Tweening;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    float colorChangeDuration = 0.45f;
    void Start()
    {
        DOTween.Init();
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
                gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            
            else if (other.gameObject.GetComponent<RedPlayer>())
            {
                RedColorChange();
                gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            
            else if (other.gameObject.GetComponent<GreenPlayer>())
            {
                GreenColorChange();
                gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            
            else if (other.gameObject.GetComponent<YellowPlayer>())
            {
                YellowColorChange();
                gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
