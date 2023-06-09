using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class stackOperations : MonoBehaviour
{

    public GameObject boxPrefab;
    public Vector3 shifts;
    public GameObject top;
    public GameObject topText;
    private int count = 0;
    [SerializeField] private TMP_InputField input;
    GameObject newBox;
    GameObject newTextObj;
    public GameObject textPrefab;
    public GameObject warning;


    public string text;
    private myStack stack = new myStack();


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

        warning.GetComponent<Text>().text = "";

        text = input.text;

        if (text == "")
        {
            warning.GetComponent<Text>().text = "You must enter a value first!";
        }
        else
        {
            newBox = Instantiate(boxPrefab, transform.position + shifts, Quaternion.identity);

            Color randomColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
            Renderer renderer = newBox.GetComponent<Renderer>();
            renderer.material.color = randomColor;

            newBox.GetComponentInChildren<Text>().text = text;
            topText.GetComponent<Text>().text = "Element " + text + " pushed successfully on the stack.";
            stack.push(newBox);
        }
    }

    public void removeBox()
    {
        warning.GetComponent<Text>().text = "";

        if (stack.isEmpty())
        {
            warning.GetComponent<Text>().text = "There are no elements to be popped!";
            topText.GetComponent<Text>().text = "";
            return;
        }
        else
        {
            GameObject topBox = stack.pop();

            top.GetComponent<Renderer>().material.color = topBox.GetComponent<Renderer>().material.color;

            top.GetComponentInChildren<Text>().text = topBox.GetComponentInChildren<Text>().text;

            topText.GetComponent<Text>().text = "The popped element is: " + topBox.GetComponentInChildren<Text>().text;

            Destroy(topBox);
        }

    }





    public void peekk()
    {
        warning.GetComponent<Text>().text = "";
        count++;
        if (stack.isEmpty())
        {
            warning.GetComponent<Text>().text = "There are no elements in the stack!";
            topText.GetComponent<Text>().text = "";
        }
        else
        {

            top.GetComponent<Renderer>().material.color = stack.peek().GetComponent<Renderer>().material.color;
            top.GetComponentInChildren<Text>().text = stack.peek().GetComponentInChildren<Text>().text;

            topText.GetComponent<Text>().text = "The top element is: " + stack.peek().GetComponentInChildren<Text>().text;
        }
    }



}

public class myStack
{
    private GameObject[] array = new GameObject[100];
    private int size = 0;

    public void push(GameObject num)
    {
        if (size == array.Length)
        {
            GameObject[] temp = new GameObject[array.Length * 2];
            System.Array.Copy(array, temp, size);
            array = temp;
        }

        array[size++] = num;
    }

    public GameObject pop()
    {
        if (size == 0)
        {
            return null;
        }

        return array[--size];
    }

    public GameObject peek()
    {
        if (size != 0)
        {
            return array[size - 1];
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