using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityPanelController : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] int _abilityIndex;
    [SerializeField] Player player;
    [SerializeField] Color color;
    Image image;
    int time = 3;
    private void Start()
    {
        image = GetComponent<Image>();
        image.color = color;    
    }
   

    public void OnPointerDown(PointerEventData eventData)
    {
        player.currentAbbilityIndex = _abilityIndex;
       StartCoroutine(SmoothColorTransition(false, color));
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(SmoothColorTransition(true, color));
    }

    IEnumerator SmoothColorTransition(bool transitionAway, Color c)
    {
        if(c== Color.red)
        {
            if (transitionAway)
            {

                for (float i = 1; i >= 0; i -= Time.deltaTime * time)
                {

                    image.color = new Color(1, i, i, 1);
                    yield return null;
                }
            }

            else
            {

                for (float i = 0; i <= 1; i += Time.deltaTime * time)
                {

                    image.color = new Color(1, i, i, 1);
                    yield return null;
                }
            }
        }
        else if(Color.green == c)
        {
            if (transitionAway)
            {
               
                for (float i = 1; i >= 0; i -= Time.deltaTime* time)
                {
                    
                    image.color = new Color(i, 1, i, 1);
                    yield return null;
                }
            }
            
            else
            {
               
                for (float i = 0; i <= 1; i += Time.deltaTime* time)
                {
                   
                    image.color = new Color(i, 1, i, 1);
                    yield return null;
                }
            }
        }
        else if(Color.cyan == c)
        {
            if (transitionAway)
            {

                for (float i = 1; i >= 0; i -= Time.deltaTime * time)
                {

                    image.color = new Color(i, 1, 1, 1);
                    yield return null;
                }
            }

            else
            {

                for (float i = 0; i <= 1; i += Time.deltaTime * time)
                {

                    image.color = new Color(i, 1, 1, 1);
                    yield return null;
                }
            }
        }
        else if(Color.black == c)
        {
            if (transitionAway)
            {

                for (float i = 1; i >= 0; i -= Time.deltaTime * time)
                {

                    image.color = new Color(i, i, i, 1);
                    yield return null;
                }
            }

            else
            {

                for (float i = 0; i <= 1; i += Time.deltaTime * time)
                {

                    image.color = new Color(i, i, i, 1);
                    yield return null;
                }
            }
        }
    }

}
