using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KSP;
using Toolbar;
using UnityEngine;

namespace BOSS3
{
    [KSPAddon(KSPAddon.Startup.MainMenu, false)]
    public class BOSS3 : MonoBehaviourExtended
    {
        MainWindow Main;
        public IButton toolbarButton;
        public Boolean showFullUI = true;

        internal override void Awake()
        {
            Main = gameObject.AddComponent<MainWindow>();
        }

        internal override void OnGUIOnceOnly()
        {
            initToolbar();

        }

        private void initToolbar()
        {
            toolbarButton = ToolbarManager.Instance.add("BOSS", "toolbarButton");
            toolbarButton.TexturePath = showFullUI ? "BOSS/bon" : "BOSS/boff";
            toolbarButton.ToolTip = "Toggle Bolt-On Screenshot System";
            toolbarButton.OnClick += e =>
            {
                if (showFullUI)
                {
                    Main.Visible = false;
                }
                else if (!showFullUI)
                {
                    Main.Visible = true;
                }
                toolbarButton.TexturePath = showFullUI ? "BOSS/bon" : "BOSS/boff";
            };
        }
    }

    internal class MainWindow : MonoBehaviourWindow
    {
        internal override void Awake()
        {
            Visible = true;
            WindowCaption = "B.O.S.S Control";
            WindowRect = new Rect(0, 0, 300, 400);
            TooltipsEnabled = false;
            
            otherwindows = new List<OtherWindows>();
            OtherWindows winTemp = gameObject.AddComponent<OtherWindows>();
            otherwindows.Add(winTemp);
        }

        internal override void OnGUIOnceOnly()
        {
          
        }

        
        private List<OtherWindows> otherwindows;

        internal override void DrawWindow(int id)
        {
            GUILayout.Space(20);
            if (GUILayout.Button("Open New Window"))
            {
               
            }
            if (GUILayout.Button("Destroy a Window"))
            {
                if (otherwindows.Count > 0)
                {
                    otherwindows[0].Visible = false;
                    otherwindows[0] = null;
                    otherwindows.RemoveAt(0);
                }
            }
        }

     

    }

    internal class OtherWindows : MonoBehaviourWindow
    {
        internal override void Awake()
        {
            WindowCaption = "Burst Fire";
            Visible = false;
            WindowRect = new Rect(UnityEngine.Random.Range(100, 800), UnityEngine.Random.Range(100, 800), 300, 300);
            ClampToScreen = true;
            DragEnabled = true;
            TooltipsEnabled = true;
        }

      
        Boolean togglevalue = false;
        internal override void DrawWindow(int id)
        {
            GUILayout.Button("This is a button");
            togglevalue = GUILayout.Toggle(togglevalue, "This is a Toggle");
            GUILayout.Button("Unity button", SkinsLibrary.DefUnitySkin.button);
            GUILayout.Label("DragEnabled:" + DragEnabled.ToString());

        }
    }


}
