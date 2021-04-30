using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.TestTools;

namespace Tests
{
    public class videoPlayer
    {
        private GameObject testPlayer;
        private Player vid;

        [SetUp]
        public void SetUp()
        {
            testPlayer = GameObject.Instantiate(new GameObject());
            vid = new Player();
        }
        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator videoPlayerHasComponent()
        {
            yield return new WaitForSeconds(0.1f);

            //Assert.NotNull(vid.GetComponent<VideoPlayer>(), "Vid has correct components.");
            Assert.False(vid.getPlaying(), "Playing is false");
            // Use the Assert class to test conditions
        }

        [UnityTest]
        public IEnumerator videoStart()
        {
            yield return new WaitForSeconds(0.1f);


            Assert.Null(vid.getMovie(), "Movie name not here");
        }

        [TearDown]
        public void TearDown()
        {
            GameObject.Destroy(testPlayer);
        }
    }
}
