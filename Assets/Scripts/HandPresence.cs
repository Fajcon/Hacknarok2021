using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    private InputDevice targetDevice;
    private InputDevice secondHand;
    public XRNode inputSource;
    
    public GameObject handModelPrefab;
    public GameObject menuPrefab;
    public GameObject productPrefab;
    public bool showMenu = true;
    public bool menuOn;
    public List<string> products;
        
    private Animator handAnimator;
    private GameObject spawnedHandModel;
    private GameObject spawnedMenuModel;
    static private int activeProduct = 0;

    private int slower = 10;
    private int iterator = 0;

    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        if (devices.Count > 0)
        { 
            targetDevice = devices[0];
        }
        spawnedHandModel = Instantiate(handModelPrefab, transform);
        handAnimator = spawnedHandModel.GetComponent<Animator>();

        if (showMenu)
        {
            spawnedMenuModel = Instantiate(menuPrefab, transform);
        }
    }

    void ShowMenu() //TODO napraw to gówno
    {
        spawnedMenuModel.SetActive(true);
        for (int i = 0; i < 7; i++)
        {
            GameObject go = spawnedMenuModel.transform.Find("Product" + i).gameObject;
            TextMeshPro textMesh = go.GetComponent<TextMeshPro>();
            if (i < products.Count)
            {
                textMesh.SetText(products[i]);
                if (i == activeProduct)
                {
                    textMesh.color = Color.cyan;
                }
                else
                {
                    textMesh.color = Color.black;
                }
            }
            else
            {
                textMesh.SetText("");
            }
        }
    }

    void CloseMenu()
    {
        spawnedMenuModel.SetActive(false);
    }

    void Updatehandanimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }

        if (showMenu)
        {
            iterator++;
            if (secondHand.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 axisValue) && (iterator % slower) == 0)
            {
                if (axisValue.y <= -0.5)
                {
                    activeProduct += 1;
                    activeProduct = activeProduct >= 7 ? 0 : activeProduct;
                }
                else if(axisValue.y >= 0.5)
                {
                    activeProduct -= 1;
                    activeProduct = activeProduct < 0 ? 7 : activeProduct;
                }
            }
            
            if (secondHand.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue) &&
                secondaryButtonValue)
            {
                flag = true;

            }

            if (flag && secondHand.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValuex) &&
                !secondaryButtonValuex)
            {
                flag = false;
                Debug.Log(activeProduct);
                products.RemoveAt(activeProduct);
            }
        }

        if (showMenu)
        {
            if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttonValue) && buttonValue)
            {
                menuOn = true;
                ShowMenu();
            }
            else
            {
                menuOn = false;
                CloseMenu();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        secondHand = InputDevices.GetDeviceAtXRNode(inputSource);
        spawnedHandModel.SetActive(true);
        Updatehandanimation();
    }
}
