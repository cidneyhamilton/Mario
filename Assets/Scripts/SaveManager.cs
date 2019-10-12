using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{

	public int highScore;

	const string SAVE = "SAVE.dat";   

	private string SavePath {
		get {
			return Application.persistentDataPath + "/" + SAVE;
		}
	}
	public void SaveData() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(SavePath);

		// Create a container for the data
		GameData data = new GameData();
		data.highScore = highScore;

		// Serialize the data
		bf.Serialize(file, data);

		file.Close();
	}

	public void LoadData() {
		if (File.Exists(SavePath)) {
			BinaryFormatter bf = new BinaryFormatter();
			
			FileStream file = File.Open(SavePath, FileMode.Open);
			GameData data = (GameData) bf.Deserialize(file);
			file.Close();

			highScore = data.highScore;
		}
	}
}

[Serializable]
public class GameData {

	public int highScore;
}
