using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP;
using LitJson;
using System;

public class GroupsManager : MonoBehaviour {

public class Group {
    public Double score  { get; set; } //1,
    public int id  { get; set; } //,
    public string name  { get; set; } //"Singles Mallorca",
    public string status  { get; set; } //"active",
    public string link  { get; set; } //"https://www.meetup.com/es-ES/Singles-Mallorca/",
    public string urlname  { get; set; } //"Singles-Mallorca",
    public string description  { get; set; } //
    // public float created  { get; set; } //1502106459000,
    public string city  { get; set; } //"Palma",
    public string untranslated_city  { get; set; } //"Palma",
    public string country  { get; set; } //"ES",
    public string localized_country_name  { get; set; } //"España",
    public string localized_location  { get; set; } //"Palma, España",
    public string state  { get; set; } //"",
    public string join_mode  { get; set; } //"approval",
    public string visibility  { get; set; } //"public_limited",
    public Double lat  { get; set; } //39.57,
    public Double lon  { get; set; } //2.65,
    public int members  { get; set; } //1155,
    // TODO more fields to come...
}	

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
						this.METHOD_GROUPS + 
                		"?photo-host=public&page=20&sign=true" +
                		"&key=" + this.API_KEY +
                		"&lat=" + lat + 
                		"&lon=" + lon;
		HTTPRequest request = new HTTPRequest (new Uri (url), OnRequestFinished);
		request.Send ();		
	}

	void OnRequestFinished(HTTPRequest request, HTTPResponse response)
	{
		Debug.Log(response.DataAsText);
		List<Group> groupResponse = JsonMapper.ToObject<List<Group>>(response.DataAsText);
		foreach(Group group in groupResponse) {
			Debug.Log(group.urlname);
		}
	}
}
