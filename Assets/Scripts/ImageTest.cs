using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTest : MonoBehaviour {
/*
     // The output of the image
     public Image img;
  
     // The source image
     public string url = "https://secure.meetupstatic.com/photos/member/7/3/e/7/thumb_275789671.jpeg";
  
     IEnumerator Start() {
         WWW www = new WWW(url);
         yield return www;
         img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
     }
*/
    public string url = "https://secure.meetupstatic.com/photos/member/1/f/8/0/highres_273668064.jpeg";

    IEnumerator Start()
    {
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        using (WWW www = new WWW(url))
        {
            yield return www;
            www.LoadImageIntoTexture(tex);
            GetComponent<Renderer>().material.mainTexture = tex;
        }
    }
}
