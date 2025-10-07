using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {
    [System.Serializable]
    public class PanalEntry {
        public string panalName;
        public GameObject panalObject;
    }

    public PanalEntry[] panalEntries;
    private Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();

    private void Awake() {
        foreach (var entry in panalEntries) {
            panels.Add(entry.panalName, entry.panalObject);
        }
    }

    public void OpenPanel(string panalName) {
        foreach (var panel in panels.Values) {
            panel.SetActive(false);
        }

        if (panels.ContainsKey(panalName)) {
            panels[panalName].SetActive(true);
        }
    }
}
