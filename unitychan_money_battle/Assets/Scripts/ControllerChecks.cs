﻿namespace UnityStandardAssets.Characters.ThirdPerson
{
    using System.Collections.Generic;
    using InControl;
    using UnityStandardAssets.Cameras;
    using UnityEngine;


    // This example roughly illustrates the proper way to add multiple players from existing
    // devices. Notice how InputManager.Devices is not used and no index into it is taken.
    // Rather a device references are stored in each player and we use InputManager.OnDeviceDetached
    // to know when one is detached.
    //
    // InputManager.Devices should be considered a pool from which devices may be chosen,
    // not a player list. It could contain non-responsive or unsupported controllers, or there could
    // be more connected controllers than your game supports, so that isn't a good strategy.
    //
    // To detect a joining player, we just check the current active device (which is the last
    // device to provide input) for a relevant button press, check that it isn't already assigned
    // to a player, and then create a new player with it.
    //
    // NOTE: Due to how Unity handles joysticks, disconnecting a single device will currently cause
    // all devices to detach, and the remaining ones to reattach. There is no reliable workaround
    // for this issue. As a result, a disconnecting controller essentially resets this example.
    // In a more real world scenario, we might keep the players around and throw up some UI to let
    // users activate controllers and pick their players again before resuming.
    //
    // This example could easily be extended to use bindings. The process would be very similar,
    // just creating a new instance of your action set subclass per player and assigning the
    // device to its Device property.
    //
    public class ControllerChecks : MonoBehaviour
    {
        public GameObject playerPrefab;
        AbstractTargetFollower followCamera;

        const int maxPlayers = 2;

        List<Vector3> playerPositions = new List<Vector3>() {
            new Vector3(0,0.15f,0),
            new Vector3(3,0.15f,0)
        };

        Vector3 playerrot = new Vector3(0, 180, 0);

        [HideInInspector]public List<ThirdPersonUserControl> players = new List<ThirdPersonUserControl>(maxPlayers);



        void Start()
        {
            InputManager.OnDeviceDetached += OnDeviceDetached;
        }


        void Update()
        {
            var inputDevice = InputManager.ActiveDevice;

            if (JoinButtonWasPressedOnDevice(inputDevice))
            {
                if (ThereIsNoPlayerUsingDevice(inputDevice))
                {
                    CreatePlayer(inputDevice);
                }
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                KeybordCreatePlayer();
            }
        }


        bool JoinButtonWasPressedOnDevice(InputDevice inputDevice)
        {
            return inputDevice.Action1.WasPressed || inputDevice.Action2.WasPressed || inputDevice.Action3.WasPressed || inputDevice.Action4.WasPressed;
        }


        ThirdPersonUserControl FindPlayerUsingDevice(InputDevice inputDevice)
        {
            var playerCount = players.Count;
            for (var i = 0; i < playerCount; i++)
            {
                var player = players[i];
                if (player.Device == inputDevice)
                {
                    return player;
                }
            }

            return null;
        }


        bool ThereIsNoPlayerUsingDevice(InputDevice inputDevice)
        {
            return FindPlayerUsingDevice(inputDevice) == null;
        }


        void OnDeviceDetached(InputDevice inputDevice)
        {
            var player = FindPlayerUsingDevice(inputDevice);
            if (player != null)
            {
                RemovePlayer(player);
            }
        }


        ThirdPersonUserControl CreatePlayer(InputDevice inputDevice)
        {
            if (players.Count < maxPlayers)
            {
                // Pop a position off the list. We'll add it back if the player is removed.
                var playerPosition = playerPositions[0];
                playerPositions.RemoveAt(0);

                var gameObject = (GameObject)Instantiate(playerPrefab, playerPosition, Quaternion.identity);
                gameObject.name = "UnityChanPlayer" + players.Count;
                //followCamera.targetObjname = GameObject.Find(gameObject.name);
                var player = gameObject.GetComponent<ThirdPersonUserControl>();
                player.Device = inputDevice;
                players.Add(player);

                return player;
            }

            return null;
        }
        ThirdPersonUserControl KeybordCreatePlayer()
        {
            if(players.Count < maxPlayers)
            {
                var playerPosition = playerPositions[0];
                playerPositions.RemoveAt(0);

                var gameObject = (GameObject)Instantiate(playerPrefab, playerPosition, Quaternion.identity);
                gameObject.name = "UnityChanPlayer" + players.Count;
                var player = gameObject.GetComponent<ThirdPersonUserControl>();
                players.Add(player);

                return player;
            }
            return null;
        }

        void RemovePlayer(ThirdPersonUserControl player)
        {
            playerPositions.Insert(0, player.transform.position);
            players.Remove(player);
            player.Device = null;
            Destroy(player.gameObject);
        }
        void OnGUI()
        {
            const float h = 22.0f;
            var y = 10.0f;
            if (players.Count < maxPlayers)
            {
                GUI.Label(new Rect(10, y, 300, y + h), "プレイヤー数が足りません！: " + players.Count + "/" + maxPlayers);
            }
            else
            {
                GUI.Label(new Rect(10, y, 300, y + h), "オッケー！: " + players.Count + "/" + maxPlayers);
                y += h;
                GUI.Label(new Rect(10, y, 300, y + h), "'Gキー' 又は 'Startボタン' を押して対戦開始！");
                y += h;
            }
            y += h;

            
        }
    }
}