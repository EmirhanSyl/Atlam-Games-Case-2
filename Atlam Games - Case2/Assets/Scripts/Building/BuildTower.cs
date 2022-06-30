using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildTower : MonoBehaviour
{
    [SerializeField] private int requiredWoodAmountToBuild = 60;

    [SerializeField] private Image whellImage;
    [SerializeField] private Image whellImageBG;
    [SerializeField] private TMP_Text requirementText;

    [SerializeField] private GameObject archerTower;
    [SerializeField] private GameObject buildingCanvas;

    [SerializeField] private ParticleSystem buildParticles;

    private float progress;

    private bool playerOnTrigger;
    private bool buildingDone;
    

    void Update()
    {
        if (buildingDone) return;

        if (playerOnTrigger)
        {
            Building();
        }

        requirementText.text = requiredWoodAmountToBuild.ToString() + "/" + GameManager.instance.WoodCount();
        if (requiredWoodAmountToBuild < GameManager.instance.WoodCount())
        {
            requirementText.color = Color.green;
        }
        else
        {
            requirementText.color = Color.red;
        }
    }

    void Building()
    {
        if (GameManager.instance.WoodCount() < requiredWoodAmountToBuild)
        {
            return;
        }

        progress += Time.deltaTime;
        whellImage.fillAmount = progress / 2f;
        whellImageBG.fillAmount = progress / 2f;

        if (progress >= 2f)
        {
            GameManager.instance.DecreaseWood(requiredWoodAmountToBuild);
            BuildATower();
            
            progress = 0;
            whellImage.fillAmount = progress;
            whellImageBG.fillAmount = progress;
        }

    }

    void BuildATower()
    {
        archerTower.SetActive(true);
        buildingCanvas.SetActive(false);
        buildParticles.Play();
        buildingDone = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (buildingDone) return;
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (buildingDone) return;
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnTrigger = false;
            progress = 0;

            whellImage.fillAmount = progress;
            whellImageBG.fillAmount = progress;
        }
    }
}
