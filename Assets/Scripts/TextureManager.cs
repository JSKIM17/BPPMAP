using System;
using System.Collections;
using System.IO;
using UnityEngine;

public static class TextureManager
{
	public static string lastDate;
#if UNITY_EDITOR
	public static string DirectoryPath = Application.streamingAssetsPath;
#else
	public static string DirectoryPath = Application.persistentDataPath;
#endif

	public static string GetTimeText(DateTime time)
	{
		return time.ToString("yyMMdd");
	}
	public static string GetFormatFileName(string postNum)
	{
		return $"{postNum}_{DateTime.Now.ToString("yyMMdd")}";
	}

	public static string GetFormatFileName(string postNum, string timeText)
	{
		return $"{postNum}_{timeText}";
	}

	public static void SaveTextureAsJPG(Texture2D texture, string fileName)
	{
		byte[] bytes = texture.EncodeToJPG();
		string path = Path.Combine(DirectoryPath, fileName + ".jpg");
		File.WriteAllBytes(path, bytes);
		Debug.Log($"Texture saved to: {path}");
	}

	public static Texture2D LoadTextureFromFile(string fileName)
	{
		string path = Path.Combine(DirectoryPath, fileName + ".jpg");

		if (File.Exists(path)) {
			byte[] bytes = File.ReadAllBytes(path);
			Texture2D texture = new Texture2D(2, 2);
			texture.LoadImage(bytes);

			Debug.Log("Texture loaded from: " + path);
			return texture;
		}
		else {
			Debug.LogWarning("File not found: " + path);
			return null;
		}
	}

	// ������ �̹��� ������ �����ϴ� �Լ�
	public static void DeleteTextureFile(string fileName)
	{
		// ���� ��� ����
		string path = Path.Combine(DirectoryPath, fileName + ".jpg");

		// ������ �����ϴ��� Ȯ��
		if (File.Exists(path)) {
			// ���� ����
			File.Delete(path);
			Debug.Log("File deleted: " + path);
		}
		else {
			//Debug.LogWarning("File not found, cannot delete: " + path);
		}
	}
}
