/*using System;
using System.Net.Http;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using TMPro;
using Proyecto26;

public class BackendII : MonoBehaviour
{
    public static BackendII Instance { get; private set; }
    public string auth;
    public string baseUrl;
    public string IGT_name;
    public static string IGT_id = "BDT";

    public string game_id;
    public string username;

    public string bearer;

    public int tokenAmount = 0;
    public TMP_Text authText;
    public TMP_Text amountText;
    public float originalFontSize = 0;
    // public TMP_Text tokentext;
    public HttpClient client = new HttpClient();
    public string deeplinkURL;
    public TMP_Text dbText;

    public int newAmount = 0;

    User user = new User();


    private void Awake()
    {
        string bearerInput = "xar-K1yKcEICAWuh10ZylQOs-bearer-3AQ3fOPMueqBlJS7f7UH-admin-P1ESJbighL6htWzLvPwX";
        PlayerPrefs.SetString("bearer", bearerInput);
        bearer = PlayerPrefs.GetString("bearer");
        amountText.text = "" + PlayerPrefs.GetInt("score");
        CallAuth();
        Refresh();

        if (Instance == null)
        {
            Instance = this;
            Application.deepLinkActivated += onDeepLinkActivated;
            if (!string.IsNullOrEmpty(Application.absoluteURL))
            {
                // Cold start and Application.absoluteURL not null so process Deep Link.
                onDeepLinkActivated(Application.absoluteURL);
            }
            // Initialize DeepLink Manager global variable.
            else deeplinkURL = "[none]";
        }
        else
        {
            Destroy(gameObject);
        }


    }

    public void Start()
    {

        //Global.backend = this;
        DontDestroyOnLoad(this.gameObject);
        client = new HttpClient();
        // originalFontSize = tokentext.fontSize;
        Debug.Log("baseurl: " + baseUrl);
        Debug.Log("bearer: " + bearer);
        Debug.Log("user: " + auth);
        CallAuth();
    }
    public class ForceAcceptAll : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }

    private void CallAuth()
    {
#if UNITY_WEBGL
        GetAuthFromWebGL();
#endif

#if UNITY_EDITOR
        StartCoroutine(GetUser(() =>
        {
            GetDBToken();
        }));
#endif
    }

    public void Refresh()
    {
        name = PlayerPrefs.GetString("username");
        RestClient.Get<User>("https://fir-claim-default-rtdb.asia-southeast1.firebasedatabase.app/" + name + ".json").Then(response =>
        {
            user = response;
            dbText.text = "" + user.score;
            
        });
    }

    public static int score()
    {
        int sc = PlayerPrefs.GetInt("score");
        return sc;
    }

    public void GetAuthFromWebGL()
    {
        int pm = Application.absoluteURL.IndexOf("?");
        if (pm != -1)
        {
            auth = Application.absoluteURL.Split("?"[0])[1].Split("=")[1];
            Debug.Log("new user: " + auth);
            PlayerPrefs.SetString("Auth", auth);
        }
    }

    public void PostToDatabase()
    {
        User user = new User();
        name = PlayerPrefs.GetString("username");
        RestClient.Put("https://fir-claim-default-rtdb.asia-southeast1.firebasedatabase.app/" + name + ".json", user);
    }

    public void GetFromDatabase()
    {
        name = PlayerPrefs.GetString("username");
        RestClient.Get<User>("https://fir-claim-default-rtdb.asia-southeast1.firebasedatabase.app/" + name + ".json").Then(response =>
        {
            user = response;
            dbText.text = "" + user.score;
        });
    }

    public static int claimAmount()
    {
        int token = PlayerPrefs.GetInt("claim");
        return token;
    }

    public void ClaimFromDB()
    {
        name = PlayerPrefs.GetString("username");
        RestClient.Get<User>("https://fir-claim-default-rtdb.asia-southeast1.firebasedatabase.app/" + name + ".json").Then(response =>
        {
            user = response;
            PlayerPrefs.SetInt("claim", user.score);
        });

        int token = claimAmount();
        int prevAmount = PlayerPrefs.GetInt("score");

        newAmount = token + prevAmount;
        PlayerPrefs.SetInt("claim", newAmount);
        PostToDatabase();
    }

  *//*  public void GetTotalClaimDatabase()
    {
        name = PlayerPrefs.GetString("username");
        RestClient.Get<User>("https://fir-claim-default-rtdb.asia-southeast1.firebasedatabase.app/" + name + ".json").Then(response =>
        {
            user = response;
            claimText.text = "" + user.claim;
        });
    }
*//*


    public void GetDBToken()
    {

    }


    public IEnumerator GetUser(Action callback)
    {
        var cert = new ForceAcceptAll();
        // Call asynchronous network methods in a try/catch block to handle exceptions.
        UnityWebRequest request = UnityWebRequest.Get($"{baseUrl}/api/v1/users/{auth}");
        request.SetRequestHeader("Authorization", "Bearer " + bearer);
        request.certificateHandler = cert;

        // Send
        cert?.Dispose();

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error :(");
            // onErrorCallback(request.result);
            authText.text = "login error";
            Debug.LogError(request.error, this);
        }
        else
        {
            var jsonData = JSON.Parse(request.downloadHandler.text);
            this.username = jsonData["username"];
            authText.text = username;
            PlayerPrefs.SetString("username", username);
            Debug.Log("User retrieved.");
            callback.Invoke();
        }
    }

    public static string nama()
    {
        string uname = PlayerPrefs.GetString("username");
        return uname;
    }

    public void VoidClaimIGT()
    {
        ClaimFromDB();
        string auth = PlayerPrefs.GetString("auth");

        int amount = PlayerPrefs.GetInt("score");
        string token_id = PlayerPrefs.GetString("IGT ID");

        Debug.Log("Clicked claim button");
        StartCoroutine(ClaimIGT());
        int IGT_value = amount * 0;
        PlayerPrefs.SetInt("score", IGT_value);
        Debug.Log("Bearer: " + bearer);
        dbText.SetText(IGT_value.ToString());
    }




    public IEnumerator ClaimIGT()
    {
        //bearer = PlayerPrefs.GetString("Bearer");
        //Get from firestore
        var amount = PlayerPrefs.GetInt("score");
        var id_igt = PlayerPrefs.GetString("IGT ID");
        var cert = new ForceAcceptAll();

        //var amount = PlayerPrefs.GetInt("IGT");
        Debug.Log("Claiming Token " + id_igt);

        UnityWebRequest request = new UnityWebRequest($"{baseUrl}/api/v1/transactions/distribute?TokenId={id_igt}&Amount={amount}&Auth={auth}", "POST");
        request.SetRequestHeader("Authorization", "Bearer " + bearer);

        request.certificateHandler = cert;

        // Send
        cert?.Dispose();

        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error :(");
            // onErrorCallback(request.result);
            Debug.LogError(request.error, this);
        }
        else
        {
            int value = amount * 0;
            PlayerPrefs.SetInt("score", value);
            GetDBToken();
            Debug.Log("Claimed Token. Please check Xarcade.");

        }
    }

   

    public void ResetValue(int IGT_value, int LET_value, int NFT_value)
    {
        IGT_value = 0; LET_value = 0; NFT_value = 0;
        dbText.SetText(IGT_value.ToString());
    }



    public IEnumerator Login(string email, string password)
    {
        var cert = new ForceAcceptAll();
        //bearer = PlayerPrefs.GetString("Bearer");
        Debug.Log("login lmao ");
        string url = "https://xarcade-api.proximaxtest.com";
        string body = "{ \"username\":\"" + username + "\", \"password\":\"" + password + "\"}";

        using (UnityWebRequest request = UnityWebRequest.Put(url + "/users/login", body))
        {
            request.SetRequestHeader("Content-Type", "application/json");

            request.certificateHandler = cert;

            // Send
            cert?.Dispose();

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error :(");
                Debug.LogError(request.error, this);
            }
            else
            {
                Debug.Log("login Success!");

            }
        }
    }

    public void OpenLogin()
    {
        //bearer = PlayerPrefs.GetString("Bearer");
        //Application.OpenURL("https://games.xarcade.app/android-auth/A0195B44F0947BC7/tt:%2F%2Fauth");
        Application.OpenURL("https://xarcade-gamer.proximaxtest.com/android-auth/");
    }

    private void onDeepLinkActivated(string url)
    {
        //bearer = PlayerPrefs.GetString("Bearer");
        // Update DeepLink Manager global variable, so URL can be accessed from anywhere.
        deeplinkURL = url;
        // Decode the URL to determine action. 
        // In this example, the app expects a link formatted like this:
        // unitydl://mylink?scene1
        this.auth = url.Split("?"[0])[1].Split("=")[1];
        authText.text = this.auth;
        StartCoroutine(GetUser(() =>
        {
            GetDBToken();
        }));

        Debug.Log("Opened from deeplink!");
    }

}
*/