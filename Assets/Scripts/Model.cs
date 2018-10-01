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
}
