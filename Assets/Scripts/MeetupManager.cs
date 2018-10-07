using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BestHTTP;
using LitJson;
using System;
using m = Model;

public class MeetupManager : MonoBehaviour {

	public Text memberInfo;
	public Text memberBio;
	public GameObject layout;
	public Texture2D blackTexture;
	List<m.Member> memberList;

	float lat = 0f;
    float lon = 0f;	
	// Use this for initialization
	void Start () {
		IEnumerator coroutine = GetLocation();
        StartCoroutine(coroutine);
		this.GetGroups();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator GetLocation() {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser) {
			Debug.Log("!Input.location.isEnabledByUser");
            yield break;
		}

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)  {
			Debug.Log("Wait until service initializes...");
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1) {
            Debug.Log("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed) {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else {
            // Access granted and location value could be retrieved
            Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
			this.lat = Input.location.lastData.latitude;
			this.lon = Input.location.lastData.longitude;
			// this.GetGroups();
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();		
	}

	public void GetGroups() {
		// this.lat = 50.0595f; // TODO get it from GPS
    	// this.lon = 14.3255f;
		if (this.lat == 0f) this.lat = 39.5516f;
		if (this.lon == 0f) this.lon = 2.6202f;
		string url = 	Constants.MEETUP_HOST + 
						Constants.METHOD_GROUPS + 
                		"?photo-host=public&page=20&sign=true" +
                		"&key=" + Constants.API_KEY +
                		"&lat=" + this.lat + 
                		"&lon=" + this.lon;
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
		string memberBio = "";
		// Debug.Log(response.DataAsText);
		List<m.Member> memberResponse = JsonMapper.ToObject<List<m.Member>>(response.DataAsText);
		this.memberList = memberResponse;
		foreach(m.Member member in memberResponse) {
			// Debug.Log(member.name);
			memberInfo = member.name + ", " + member.city;
			memberBio = member.bio;
			if (member.photo != null) {
				// Debug.Log(member.photo.highres_link);
				// Debug.Log(member.photo.thumb_link);
				photoUrl = member.photo.highres_link;
			}
		}
		this.memberInfo.text = memberInfo;
		this.memberBio.text = memberBio;
		Debug.Log("this.LoadImage(photoUrl): " + photoUrl);
		IEnumerator coroutine = LoadImage(photoUrl);
        StartCoroutine(coroutine);
	}

    public IEnumerator LoadImage(string url) {
        Debug.Log("LoadImage");
		this.layout.GetComponent<Renderer>().material.mainTexture = this.blackTexture;
        Texture2D tex;		
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
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
			string memberBio = member.bio;
			this.memberInfo.text = memberInfo;
			this.memberBio.text = memberBio;
			string photoUrl = member.photo.highres_link != null ? member.photo.highres_link : member.photo.photo_link;
			IEnumerator coroutine = LoadImage(photoUrl);
			StartCoroutine(coroutine);
		} else {
			this.GetRandomMember();
		}
	}	
}
