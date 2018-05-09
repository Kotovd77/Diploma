using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {

	public Button menuButton, startButton, pauseButton, resetButton;
	public Toggle toggleForLinearStand, toggleForNonLinearStand;
	public GameObject panel,startButtonObject, pauseButtonObject, resetButtonObject;
	// Use this for initialization


	public void onMenuButtonClick(){
		if (panel.activeSelf) {
			panel.SetActive (false);
			startButtonObject.SetActive (false);
			pauseButtonObject.SetActive (false);
			resetButtonObject.SetActive (false);
		} else {
			panel.SetActive (true);
			startButtonObject.SetActive (true);
			pauseButtonObject.SetActive (true);
			resetButtonObject.SetActive (true);
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

