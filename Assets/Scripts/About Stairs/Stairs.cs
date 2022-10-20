using UnityEngine;

public class Stairs : MonoBehaviour
{
    void BlueColorChange()
    {
        gameObject.transform.GetComponent<Renderer>().material.color = new Color(0, 0, 255);
    }
    
    void RedColorChange()
    {
        gameObject.transform.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
    }
    
    void GreenColorChange()
    {
        gameObject.transform.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
    }
    
    void YellowColorChange()
    {
        gameObject.transform.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
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
