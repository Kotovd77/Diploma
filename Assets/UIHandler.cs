using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {

	public Button menuButton, startButton, pauseButton, resetButton;
	public Toggle toggleForLinearStand, toggleForNonLinearStand;
	public GameObject menuPanel;
	// Use this for initialization


	public void onMenuButtonClick(){
		if (menuPanel.activeSelf) {
			menuPanel.SetActive (false);
		} else {
			menuPanel.SetActive (true);
		}
	}

	public void onLinearToggleCheck(){
		if (toggleForLinearStand.isOn)
			toggleForNonLinearStand.interactable = false;
		
		else
			toggleForNonLinearStand.interactable = true;
	}

	public void onNonLinearToggleCheck(){
		if (toggleForNonLinearStand.isOn)
			toggleForLinearStand.interactable = false;
		else
			toggleForLinearStand.interactable = true;
	}
		
}

