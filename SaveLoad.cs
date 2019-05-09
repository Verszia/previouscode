using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    void Update() //update function
    {
        //temporary, for testing purposes
        if (Input.GetKeyDown("r")) //if r is pressed
        {
            NewGame(); //call new game function
        }
        if (Input.GetKeyDown("q")) //if q is pressed
        {
            SaveGame(); //call save function
        }
        if (Input.GetKeyDown("e")) //if e is pressed
        {
            LoadGame(); //call load function
        }
    }
    public void NewGame() //function to create new game
    {
        File.Delete(Application.persistentDataPath + "/game.save"); //deletes the save file for game
        File.Delete(Application.persistentDataPath + "/stats.save"); //deletes the save file for saves
        File.Delete(Application.persistentDataPath + "/ability.save"); //deletes the save file for abilites
        Debug.Log("Game Reset"); //displays "game reset" in debug.log when the function happens
    }
    public void SaveGame() //save game function
    {
        // 1
        Save save = CreateSaveGameObject();

        // 2
        BinaryFormatter bf = new BinaryFormatter(); //converts to binary
        FileStream file = File.Create(Application.persistentDataPath + "/game.save"); //opens file
        bf.Serialize(file, save); //serializes
        file.Close(); //closes file
        Debug.Log("Game Saved"); //shows "Game Saved" in debug log
    }

    public void LoadGame() //allows for the game to load
    {
        // 1
        if (File.Exists(Application.persistentDataPath + "/game.save")) //checks to see if game save exists
        {
            // 2
            BinaryFormatter bf = new BinaryFormatter(); //converts from binary to c#
            FileStream file = File.Open(Application.persistentDataPath + "/game.save", FileMode.Open); //opens file
            Save save = (Save)bf.Deserialize(file); //deserializes it
            file.Close(); //closes file

            Debug.Log("Game Loaded"); //shows "Game Loaded" in debug log
        }
        else
        {
            Debug.Log("No game saved!"); //shows "No game saved!" in debug log
        }
    }

    private Save CreateSaveGameObject() //creates class
    {
        Save save = new Save(); //creates save

        //put save.variablename to functions here

        return save; //returns the save value
    }
}

//filename.variablename format
