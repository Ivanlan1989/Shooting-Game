using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;

namespace Tests
{
    public class MainMenu
    {
        // A Test behaves as an ordinary method
        //[Test]
        //public void MainMenuSimplePasses()
        //{
        //    // Use the Assert class to test conditions
        //    //Assert.AreEqual(true, false);
        //    //Assert.AreEqual(sceneIndex, expectedSceneIndex);
        //    //PlayGame(null, true, true
        //    //QuitGame();
        //}

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        //[UnityTest]
        //public IEnumerator MainMenuWithEnumeratorPasses()
        //{
        //    // Use the Assert class to test conditions.
        //    // Use yield to skip a frame.
        //    //Test vaiables
        //    string scenePath = null;
        //    bool isSceneActive = true;
        //    bool isSceneLoaded = true;
        //    //Excpected variables
        //    string expectedScenePath = "Assets/Scenes.SampleScene.unity";
        //    bool expectedIsSceneActive = false;
        //    bool expectedIsSceneLoaded = false;
        //    //Assert tests
        //    yield return null;
        //    Assert.AreEqual(expectedScenePath, scenePath);
        //    yield return null;
        //    Assert.AreEqual(expectedIsSceneActive, isSceneActive);
        //    yield return null;
        //    Assert.AreEqual(expectedIsSceneLoaded, isSceneLoaded);
        //}

        //[Test]
        //public void PlayGame()
        //{
        //    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1
        //    //PlayeGameScenePathTest(scenePath);
        //    //PlayeGameSceneActiveTest(isSceneActive);
        //    //PlayeGameSceneLoadedTest(isSceneLoaded);
        //    //Assert.Throws<ArgumentException>(() => EditorSceneManager.OpenScene("Assets/Scenes.SampleScene.unity"));
        //}

        [Test]
        public void PlayeGameScenePathTest()
        {
            string scenePath = null;
            string expectedScenePath = "Assets/Scenes.SampleScene.unity";
            Assert.AreEqual(expectedScenePath, scenePath);
            //Assert.Throws<ArgumentException>(() => EditorSceneManager.OpenScene(scenePath));
        }

        [Test]
        public void PlayeGameSceneActiveTest()
        {
            bool isSceneActive = true;
            bool expectedIsSceneActive = false;
            Assert.AreEqual(expectedIsSceneActive, isSceneActive);
        }
        [Test]
        public void PlayeGameSceneLoadedTest()
        {
            bool isSceneLoaded = true;
            bool expectedIsSceneLoaded = false;
            Assert.AreEqual(expectedIsSceneLoaded, isSceneLoaded);
        }

        //[Test]
        //public void QuitGame()
        //{
        //    Debug.Log("Game has now quit.");
        //    Application.Quit();
        //    Assert.Throws<ArgumentException>(() => EditorSceneManager.OpenScene("Assets/Scenes.SampleScene.unity"));
        //}
    }
}
