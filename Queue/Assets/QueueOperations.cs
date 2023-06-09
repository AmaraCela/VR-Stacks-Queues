using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;

public class queueOperations : MonoBehaviour
{

    public GameObject boxPrefab;
    public Vector3 shifts;
    public GameObject first;
    
    [SerializeField] private TMP_InputField input;
    GameObject newBox;
    GameObject newTextObj;
    public GameObject textPrefab;
    public float forwardForce;
    public GameObject show;
    public string text;
    //private myStack stack = new myStack();
    private myQueue queue = new myQueue();
    public float lastForce;
    public GameObject war;
    private GameObject last;
    public GameObject firstCanva;


    // Update is called once per frame
    /*void Update()
    {
        if (newBox != null)
        {
            newTextObj.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(newBox.GetComponent<RectTransform>().position);
        }

    }*/


    public void createBox()
    {
        war.GetComponentInChildren<UnityEngine.UI.Text>().text = "";
        if(queue.getSize()==10)
        {
            war.GetComponentInChildren<UnityEngine.UI.Text>().text = "You have exceeded the size limit";
        }
        else { 
        text = input.text;
            if (text == "")
            {
                war.GetComponentInChildren<UnityEngine.UI.Text>().text = "Please enter an element";
            }
            else { 

        newBox = Instantiate(boxPrefab, transform.position + shifts, Quaternion.identity);

        Color randomColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        Renderer renderer = newBox.GetComponent<Renderer>();
        renderer.material.color = randomColor;
        queue.enqueue(newBox);
        newBox.GetComponentInChildren<UnityEngine.UI.Text>().text = text;
        show.GetComponent<UnityEngine.UI.Text>().text = "Element " + newBox.GetComponentInChildren<UnityEngine.UI.Text>().text +" enqueued successfully";
        //newBox.GetComponentInChildren<Text>().text = queue.getSize() + "";
        last = newBox;
        newBox.GetComponent<Rigidbody>().AddForce(-(forwardForce * Time.deltaTime),0,0);
       }
        }
    }

    public void removeBox()
    {
        war.GetComponentInChildren<UnityEngine.UI.Text>().text = "";

        if (queue.getSize()== 0)
        {

            war.GetComponentInChildren<UnityEngine.UI.Text>().text = "No elements to dequeue";
            show.GetComponent< UnityEngine.UI.Text> ().text = "";
        }
        else
        {
            GameObject topBox = queue.dequeue();
            firstCanva.GetComponentInChildren<UnityEngine.UI.Text>().text = topBox.GetComponentInChildren<UnityEngine.UI.Text>().text;
            first.GetComponent<Renderer>().material.color = topBox.GetComponent<Renderer>().material.color;
            show.GetComponent<UnityEngine.UI.Text>().text = "The element that was dequeued is: " + topBox.GetComponentInChildren<UnityEngine.UI.Text>().text;
            Destroy(topBox);
            last.GetComponent<Rigidbody>().AddForce(-(lastForce * Time.deltaTime), 0, 0);

        }
    }





    public void peekk()
    {
        war.GetComponentInChildren<UnityEngine.UI.Text>().text = "";
       
        if (queue.getSize()== 0)
        {
           
            war.GetComponentInChildren<UnityEngine.UI.Text>().text = "No elements to peek";
        }
        else
        {
            GameObject topBox = queue.peek();
            first.GetComponent<Renderer>().material.color = topBox.GetComponent<Renderer>().material.color;
            firstCanva.GetComponentInChildren<UnityEngine.UI.Text>().text = topBox.GetComponentInChildren<UnityEngine.UI.Text>().text;
            show.GetComponent<UnityEngine.UI.Text>().text = "The first element is: " + topBox.GetComponentInChildren<UnityEngine.UI.Text>().text;
        }
    }


}

public class myQueue
{
    private GameObject[] array = new GameObject[10];
    private int size = 0;

    public void enqueue(GameObject num)
    {
        if (size == array.Length)
        {
            /*GameObject[] temp = new GameObject[array.Length * 2];
            System.Array.Copy(array, temp, size);
            array = temp;*/
            return;
        }

        array[size++] = num;
    }

    public GameObject dequeue()
    {
        if (size == 0)
        {
            return null;
        }

        /*GameObject el = array[0];
        size = size - 1;
        for(int i = 0; i < size; i++)
        {
            array[i] = array[i + 1];
        }
        array[size] = null;*/
        GameObject el = array[0];
        size = size - 1;
        System.Array.Copy(array, 1, array, 0, size); // Shift the elements

        array[size] = null;
        return el;
    }

    public GameObject peek()
    {
        if (size != 0)
        {
            return array[0];
        }
        return null;
    }
    public int getSize()
    {
        return this.size;
    }

    public bool isEmpty()
    {
        return size == 0;
    }
}