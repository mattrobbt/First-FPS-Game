
using UnityEngine;
using UnityEngine.Networking;

public class playersetup : NetworkBehaviour
{
    [SerializeField] 
    Behaviour[] disableComponents;

    Camera overheadCamera;

    // Start is called before the first frame update
    void Start()
    {
        if(!isLocalPlayer){
            for(int x = 0; x < disableComponents.Length; x++){
                disableComponents[x].enabled = false;
            }
        }
        else{
            overheadCamera = Camera.main;
            if(overheadCamera != null){
                overheadCamera.gameObject.SetActive(false);
            }
            
        }
    }
    void OnDisable() {
        if(overheadCamera != null)
        {
            overheadCamera.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
