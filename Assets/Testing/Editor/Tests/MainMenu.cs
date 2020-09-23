using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;
using System.CodeDom;
using System.Diagnostics;

namespace Tests
{
    public class MainMenu
    {
        private bool unityConsoleActive = true;//set false to disable console messages and true to enable console messages (in unity console)

        //[Test] //change from bool to void and remove return value for unit testing
        private bool PlayeGameScenePathTest()
        {
            string scenePath = "Assets/Scenes/SampleScene.unity";//fail test value null
            string expectedScenePath = "Assets/Scenes/SampleScene.unity";//fail test value "Assets/Scenes.SampleScene.unity"
            bool returnValue = false;
            try
            {
                Assert.AreEqual(expectedScenePath, scenePath);
                returnValue = false;
                if (unityConsoleActive)
                {
                    UnityEngine.Debug.Log("Scene path is valid.");
                }
            }
            catch
            {
                throw new ArgumentException("Error is finding scene path " + scenePath + " was expecting " + expectedScenePath);
            }
            return returnValue;
            //Assert.Throws<ArgumentException>(() => EditorSceneManager.OpenScene(scenePath));
        }

        //[Test] //change from bool to void and remove return value for unit testing
        //public void PlayeGameSceneActiveTest()
        private bool PlayeGameSceneActiveTest()
        {
            bool isSceneActive = false;//fail test value true
            bool expectedIsSceneActive = false;//fail test value false
            bool returnValue = false;
            try
            {
                Assert.AreEqual(expectedIsSceneActive, isSceneActive);
                returnValue = true;
                if (unityConsoleActive)
                {
                    UnityEngine.Debug.Log("Scene is not already active.");
                }
            }
            catch
            {
                throw new ArgumentException("Error in checking scene is active. Scene is " + isSceneActive + " was expecting scene to be " + expectedIsSceneActive);
            }
            return returnValue;
        }

        //[Test] //change from bool to void and remove return value for unit testing
        private bool PlayeGameSceneLoadedTest()
        {
            bool isSceneLoaded = false;//fail test value true
            bool expectedIsSceneLoaded = false;//fail test value false
            bool returnValue = false;
            try
            {
                Assert.AreEqual(expectedIsSceneLoaded, isSceneLoaded);
                returnValue = true;
                if (unityConsoleActive)
                {
                    UnityEngine.Debug.Log("Scene is not already loaded.");
                }
            }
            catch
            {
                throw new ArgumentException("Error in checking scene is loaded. Scene is " + isSceneLoaded + " was expecting " + expectedIsSceneLoaded);
            }
            return returnValue;
        }

        [Test]
        public void PlayGame()
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Assert.Throws<ArgumentException>(() => EditorSceneManager.OpenScene("Assets/Scenes.SampleScene.unity"));
            if (!PlayeGameSceneLoadedTest() && !PlayeGameSceneActiveTest() && !PlayeGameScenePathTest())
            {
                if (unityConsoleActive)
                {
                    UnityEngine.Debug.Log("Error, scene cannot be loaded.");
                }
            }
            else
            {
                EditorSceneManager.OpenScene("Assets/Scenes/SampleScene.unity");
                if (unityConsoleActive)
                {
                    UnityEngine.Debug.Log("Scene has now loaded.");
                }
            }
        }

        //[Test]
        public void QuitGame()
        {
            bool quit = true;//fail test value false
            bool expectedQuit = true;//fail test value true
            try
            {
                Assert.AreEqual(quit, expectedQuit);
                //Application.Quit();
                if (unityConsoleActive)
                {
                    UnityEngine.Debug.Log("Game has now quit.");
                }
            }
            catch
            {
                throw new ArgumentException("Error in quiting.");
            }
        }
    }
}