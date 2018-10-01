using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Model : MonoBehaviour {

	public class Group {
		public Double score  { get; set; } //1,
		public int id  { get; set; } //,
		public string name  { get; set; } //"Singles Mallorca",
		public string status  { get; set; } //"active",
		public string link  { get; set; } //"https://www.meetup.com/es-ES/Singles-Mallorca/",
		public string urlname  { get; set; } //"Singles-Mallorca",
		public string description  { get; set; } //
		public Int64 created  { get; set; } //1502106459000,
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

	public class Member {
		public int id;// 14046916,
		public string name;//"Patrizia Di Gregorio",
		public string bio;//""I'm the founder of Expats Living in Rome. Since 2001,I've been involved with Expats living in all of Italy, organizing events and volunteering to help people. I'm Italo-American from upstate New York. If you have any questions contact me.",
		public string status;//""active",
		public Int64 joined;// 1297953305000,
		public string city;//""Albany",
		public string country;//""us",
		public string localized_country_name;//""EE. UU.",
		public string state;//""NY",
		public Double lat;// 42.65,
		public Double lon;// -73.75,
		public Photo photo;
		/*
		"group_profile": {
		"title": "Founder",
		"status": "active",
		"visited": 1530263891000,
		"created": 1299223483000,
		"updated": 1487069339000,
		"role": "organizer",
		"group": {
		"id": 1793166,
		"urlname": "Expats-living-in-Rome",
		"name": "Rome Expats & Diplomats Network in Rome",
		"status": "active",
		"who": "Rome Expat & Diplomats",
		"members": 1649,
		"join_mode": "open",
		"localized_location": "Roma, Italia",
		"group_photo": {
		"id": 458369499,
		"highres_link": "https://secure.meetupstatic.com/photos/event/7/3/3/b/highres_458369499.jpeg",
		"photo_link": "https://secure.meetupstatic.com/photos/event/7/3/3/b/600_458369499.jpeg",
		"thumb_link": "https://secure.meetupstatic.com/photos/event/7/3/3/b/thumb_458369499.jpeg",
		"type": "event",
		"base_url": "https://secure.meetupstatic.com"
		}
		},
		"answers": [
		{
		"question_id": 399509,
		"question": "How long have you lived in Rome?",
		"answer": "I have lived in Rome 11 years and have been involved in Expats living in Rome since 2001 "
		},
		{
		"question_id": 399507,
		"question": "Do you speak Italian?",
		"answer": "I do speak it but I prefer to speak English it's easier for me. I speak it better then writing it. "
		},
		{
		"question_id": 399597,
		"question": "Which languages do  you speak?",
		"answer": "I speak Italian & English"
		},
		{
		"question_id": 399508,
		"question": "What are you goals here in Rome?",
		"answer": "I'd like to improve my Italian cooking skills. Start my own business and do more international activities time permitting!"
		}
		],
		"intro": "I am the founder of Expats living in Rome. Since 2001 I  have been involved with Expats living in all of Italy organizing events, and meetups. I am  Italo-American from upstate New York and Bi-lingual. I love bring people together.",
		"link": "https://www.meetup.com/Expats-living-in-Rome/members/14046916/"
		}
		}
		*/
	}

	public class Photo {
		public int id;
		public string highres_link;
		public string photo_link;
		public string thumb_link;
		public string type;
		public string base_url;
	}	
}
