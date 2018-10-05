﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BestHTTP;
using LitJson;
using System;
using m = Model;

public class MeetupManager : MonoBehaviour {

public Text memberInfo;
	public GameObject layout;
	List<m.Member> memberList;
	// Use this for initialization
	void Start () {
		this.GetGroups();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetGroups() {
		float lat = 48.1356f; // TODO get it from GPS
    	float lon = 16.9758f;
		string url = 	Constants.MEETUP_HOST + 
						Constants.METHOD_GROUPS + 
                		"?photo-host=public&page=20&sign=true" +
                		"&key=" + Constants.API_KEY +
                		"&lat=" + lat + 
                		"&lon=" + lon;
		HTTPRequest request = new HTTPRequest (new Uri (url), OnRequestGroupsFinished);
		request.Send ();		
	}

	void OnRequestGroupsFinished(HTTPRequest request, HTTPResponse response)
	{
		// Debug.Log(response.DataAsText);
		List<m.Group> groupResponse = JsonMapper.ToObject<List<m.Group>>(response.DataAsText);
		foreach(m.Group group in groupResponse) {
			// Debug.Log(group.urlname);
		}
		int rnd = UnityEngine.Random.Range(0, groupResponse.Count);
		this.GetMembers(groupResponse[rnd].urlname);
	}

	public void GetMembers(string urlname) {
		string url = 	Constants.MEETUP_HOST + '/' + 
						urlname +
						"/members?&photo-host=public&page=20" +
						"sign=true" +
						"&key=" + Constants.API_KEY;
		HTTPRequest request = new HTTPRequest (new Uri (url), OnRequestMembersFinished);
		request.Send ();
	}

	void OnRequestMembersFinished(HTTPRequest request, HTTPResponse response) {
		string photoUrl = "";
		string memberInfo = "";
		// Debug.Log(response.DataAsText);
		List<m.Member> memberResponse = JsonMapper.ToObject<List<m.Member>>(response.DataAsText);
		this.memberList = memberResponse;
		foreach(m.Member member in memberResponse) {
			// Debug.Log(member.name);
			memberInfo = member.name + ", " + member.city;
			if (member.photo != null) {
				// Debug.Log(member.photo.highres_link);
				// Debug.Log(member.photo.thumb_link);
				photoUrl = member.photo.highres_link;
			}
		}
		this.memberInfo.text = memberInfo;
		Debug.Log("this.LoadImage(photoUrl): " + photoUrl);
		IEnumerator coroutine = LoadImage(photoUrl);
        StartCoroutine(coroutine);
	}

    public IEnumerator LoadImage(string url) {
        Debug.Log("LoadImage");
        Texture2D tex;		
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
		// this.layout.GetComponent<Renderer>().material.mainTexture = tex;
        using (WWW www = new WWW(url))
        {
            yield return www;
            www.LoadImageIntoTexture(tex);
            this.layout.GetComponent<Renderer>().material.mainTexture = tex;
        }        
    }

	public void GetRandomMember(){
		int rnd = UnityEngine.Random.Range(0, this.memberList.Count);
		m.Member member =  this.memberList[rnd];
		if (member.photo != null) {
			string memberInfo = member.name + ", " + member.city;
			this.memberInfo.text = memberInfo;
			string photoUrl = member.photo.highres_link != null ? member.photo.highres_link : member.photo.photo_link;
			IEnumerator coroutine = LoadImage(photoUrl);
			StartCoroutine(coroutine);
		} else {
			this.GetRandomMember();
		}
	}	
}
