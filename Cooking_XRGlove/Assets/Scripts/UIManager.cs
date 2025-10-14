using UnityEngine;
using System.Collections.Generic;
public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [System.Serializable]
    public class PanelEntry
    {
        public string panelName;
        public GameObject panelObject;
        public bool isExclusivePanel = true;
    }

    public PanelEntry[] panalEntries;
    private Dictionary<string, PanelEntry> panels = new Dictionary<string, PanelEntry>();

    private void Awake()
    {
        foreach (var entry in panalEntries)
        {
            panels.Add(entry.panelName, entry);
        }
    }

    public void OpenPanel(string panelName)
    {
        // 1. Check if the panel exists
        if (!panels.ContainsKey(panelName))
        {
            Debug.LogWarning($"UIManager: Panel named '{panelName}' not found!");
            return;
        }

        // Get the full entry for the target panel
        PanelEntry targetEntry = panels[panelName];

        // 2. Decide whether to close all active panels
        if (targetEntry.isExclusivePanel)
        {
            // The new panel is exclusive, so close all other panels first.
            CloseAllPanelsExcept(targetEntry.panelObject);
        }

        // 3. Open the target panel
        // We use the entry's GameObject to set it active.
        targetEntry.panelObject.SetActive(true);
    }

    // Helper function to close all panels except one (if specified).
    private void CloseAllPanelsExcept(GameObject exceptionPanel = null)
    {
        foreach (var entry in panels.Values)
        {
            // Close the panel if it's not the one we want to keep open.
            if (entry.panelObject != exceptionPanel)
            {
                entry.panelObject.SetActive(false);
            }
        }
    }
}
