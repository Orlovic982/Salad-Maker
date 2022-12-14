using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScipt : MonoBehaviour
{
    GameObject apple;
    int numberOfElemntsApple;
    int currenetSliceApple = 0;
    GameObject banana;
    int numberOfElemntsBanana;
    int currenetSliceGreen = 0;

    [SerializeField] GameObject sliceBananaButton;

    [SerializeField] GameObject sliceAppleButton;

    // Start is called before the first frame update
    void Start()
    {


        apple = transform.GetChild(0).gameObject;
        banana = transform.GetChild(1).gameObject;
        numberOfElemntsApple = apple.transform.childCount;
        Debug.Log("Child Count Apple: " + apple.transform.childCount);
        numberOfElemntsBanana = banana.transform.childCount;
        Debug.Log("Child Count Banana: " + banana.transform.childCount);
        SetAppleUi();
    }

    // Update is called once per frame
    void Update()
    {


    }



    public void SetBananaUI()
    {
        Debug.Log("Set green UI");
        SetApppleInivisible();
        SetBananaSliceButton();
        for (int i = 0; i < numberOfElemntsBanana; i++)
        {

            banana.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = true;

        }
    }

    private void SetApppleInivisible()
    {
        for (int i = 0; i <  numberOfElemntsApple; i++)
        {
            if (apple.transform.GetChild(i).gameObject.GetComponent<Rigidbody>().isKinematic == false)
            {
                apple.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                apple.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    public void SetAppleUi()
    {

        SetBananaInvisible();
        SetAppleSliceButton();
    
        for (int i = 0; i < numberOfElemntsApple; i++)
        {
            Debug.Log("Check red element: " + i);

            apple.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = true;

        }

    }

    private void SetBananaInvisible()
    {
        for (int i = 0; i < numberOfElemntsBanana; i++)
        {

            if (banana.transform.GetChild(i).gameObject.GetComponent<Rigidbody>().isKinematic == false)
            {
                banana.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                banana.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    public void CutBanana()
    {
        if (currenetSliceGreen < numberOfElemntsBanana)
        {
            banana.transform.GetChild(currenetSliceGreen).gameObject.GetComponent<Rigidbody>().isKinematic = false;
            banana.transform.GetChild(currenetSliceGreen).gameObject.GetComponent<MeshCollider>().enabled=true;
            banana.transform.GetChild(currenetSliceGreen).gameObject.GetComponent<MeshCollider>().convex = true;
            currenetSliceGreen++;
            Debug.Log("Current slice green:" + currenetSliceGreen);
        }

        NextLevel();

    }


    public void CutApple()
    {

        Debug.Log("cutApple:"+ "slicenum:"+ currenetSliceApple);

        if (currenetSliceApple < numberOfElemntsApple)
        {
            Debug.Log("cutApple slice number"+ currenetSliceApple) ;
            apple.transform.GetChild(currenetSliceApple).gameObject.GetComponent<Rigidbody>().isKinematic = false;
            apple.transform.GetChild(currenetSliceApple).gameObject.GetComponent<MeshCollider>().enabled=true;
            apple.transform.GetChild(currenetSliceApple).gameObject.GetComponent<MeshCollider>().convex = true;
            currenetSliceApple++;
            Debug.Log("Current slice Red:" + currenetSliceApple);
        }

    }


    public void SetAppleSliceButton()
    {
        sliceBananaButton.SetActive(false);
        sliceAppleButton.SetActive(true);
    }

    public void SetBananaSliceButton()
    {
        sliceBananaButton.SetActive(true);
        sliceAppleButton.SetActive(false);
    }


    private void NextLevel()
    {
        if(currenetSliceApple==numberOfElemntsApple&& currenetSliceGreen == numberOfElemntsBanana)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
