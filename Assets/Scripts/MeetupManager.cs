using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP;
using LitJson;
using System;
using m = Model;

public class MeetupManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetGroups();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetGroups() {
		float lat = 41.9097f; // TODO get it from GPS
    	float lon = 12.2558f;
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
		Debug.Log(response.DataAsText);
		List<m.Group> groupResponse = JsonMapper.ToObject<List<m.Group>>(response.DataAsText);
		foreach(m.Group group in groupResponse) {
			Debug.Log(group.urlname);
		}
		this.GetMembers(groupResponse[0].urlname);
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
		Debug.Log(response.DataAsText);
		List<m.Member> memberResponse = JsonMapper.ToObject<List<m.Member>>(response.DataAsText);
		foreach(m.Member member in memberResponse) {
			// Debug.Log(member.name);
			if (member.photo != null) {
				Debug.Log(member.photo.highres_link);
				Debug.Log(member.photo.thumb_link);
			}
		}		
	}
}
