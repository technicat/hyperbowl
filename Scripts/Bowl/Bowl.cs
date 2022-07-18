using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour {

public Transform ball;

public AudioClip cheer;
public AudioClip boo;
public AudioClip OK;

public Light flarelight;

private int turn;
private int frame;

private Object[] skies;
private Object[] flares;

private AudioSource audio;

private Ball ballscript;

static bool showflare = true;

void Awake() {
	ballscript = ball.GetComponent<Ball>();
	audio = GetComponent<AudioSource>();
	skies = Resources.LoadAll("Skybox",typeof(Material));
	flares = Resources.LoadAll("Flare",typeof(Flare));
	RandomSky();
}

void RandomSky() {
	if (skies != null) {
		var sky = skies[Random.Range(0,skies.Length-1)];
		RenderSettings.skybox = (Material)sky;
	}
	if (flares != null) {
		var flare = flares[Random.Range(0,flares.Length-1)];
		flarelight.flare = (Flare)flare;
	}
}


void Start() {
	NewGame();
}

void NewGame() {
	frame = 0;
	turn = 0;
}

void Update() {
	// ball 1
	if (turn == 0) {
		if (PinsDown() == 10) {
			Strike();
		} else {
			if (ballscript.IsSunk()) {
				if (PinsDown() == 0) {
					Gutter0();
				} else {
					NotSoBad0();
				}
			}		
		}
	} else {
		// ball 2
		if (PinsDown() == 10) {
			Spare();
		} else {
			if (ballscript.IsSunk()) {
				if (PinsDown() == 0) {
					Gutter1();
				} else {
					NotSoBad1();
				}
			}		
		}
	}
}

int PinsDown() {
	return Rack.knockedOver;
}

void Spare() {
	BroadcastMessage("Score","Spare!");
	audio.clip=cheer;
	audio.Play();
	Fugu.GameCenter.Achievement("com.technicat.fugubowl.spare",100);
	Turn0();
}

void Strike() {
	BroadcastMessage("Score","Strike!");
	audio.clip=cheer;
	audio.Play();
	Fugu.GameCenter.Achievement("com.technicat.fugubowl.strike",100);
	Turn0();
}

void ResetBall() {
	ballscript.ResetPosition();
}

void ResetEverything() {
	RandomSky();
	BroadcastMessage("ResetPosition");
}	

void Turn0() {
	ResetEverything();
	turn = 0;
	frame++;
	// need to check for end of game, i.e. frame 10
}

void Turn1() {
	ResetBall();
	turn = 1;
}

void NotSoBad0() {
	NotSoBadMessage();
	Turn1();
}

void NotSoBad1() {
	NotSoBadMessage();
	Turn0();
}

void NotSoBadMessage() {
	BroadcastMessage("Score",""+PinsDown()+" pins!");
	audio.clip=OK;
	audio.Play();
}

void Gutter0() {
	Gutter();
	Turn1();
}

void Gutter1() {
	Gutter();
	Turn0();
}

void Gutter() {
	BroadcastMessage("Score","Gutter!");
	audio.clip=boo;
	audio.Play();
}

}