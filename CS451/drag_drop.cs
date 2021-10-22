using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_drop : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    private bool isClone = false;
    private float rotateAngle=0;
    public GameObject Object; 
    GameObject objectClone;
    private int overlap=0;

    private int rotateDirection=0;
    void Update(){

        if(isBeingHeld == true){

            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            if(!isClone){
                objectClone.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
            }

        }

        if(Input.GetKeyDown("a"))
        {
          rotateDirection=1;
        }
        if(Input.GetKeyUp("a"))
        {
          rotateDirection=0;
        }
        if(Input.GetKeyUp("d"))
        {
          rotateDirection=0;
        }
        if(Input.GetKeyDown("d"))
        {
            rotateDirection=-1;
        }

        if(rotateDirection==1)
        {
            rotateAngle += 25* Time.deltaTime;
            objectClone.gameObject.transform.rotation = Quaternion.Euler( new Vector3(0,0,rotateAngle));
        }
        else if(rotateDirection==-1)
        {
            rotateAngle -= 25* Time.deltaTime;
            objectClone.gameObject.transform.rotation = Quaternion.Euler( new Vector3(0,0,rotateAngle));
        }


        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.name.Contains("Clone"))
        // {
        //     Debug.Log("1");
        //     overlap++;
        //     Debug.Log("Value of overlap");
        //     Debug.Log(overlap);
        // }  
        // Debug.Log("2");

        overlap++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // if (collision.gameObject.name.Contains("Clone"))
        // {
        //     Debug.Log("3");
        //     overlap--;
        //     Debug.Log("Value of overlap");
        //     Debug.Log(overlap);
        // }
        overlap--;
        // Debug.Log("4");
            
    }

    private void OnMouseDown(){

        if(Input.GetMouseButtonDown(0)){
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            if(!isClone){
                objectClone = Instantiate(Object, new Vector2(startPosX,startPosY), transform.rotation) as GameObject;
                objectClone.GetComponent<drag_drop>().isClone = true;
            }
            
            isBeingHeld = true;
        }

    }

    private void OnMouseUp(){
        isBeingHeld = false;
        rotateDirection=0;
        Debug.Log(overlap);

        if (!isClone && objectClone.GetComponent<drag_drop>().overlap > 0)
                Destroy(objectClone);

        // Destroy(Squareclone);
        // if(overlap>0)
        // {
        //     Destroy(Squareclone);
        // }
        
    }

    // private bool HasOverlap()
    // {
    //     if (overlap > 0)
    //         return true;
        
    //     return false;
    // }

}
