using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace SevenDwarfs.SaveData
{
    /// <summary>
    /// �Z�[�u�f�[�^�̕ۑ��ƌĂяo���@�\
    /// �Z�[�u�@�\�Ƃ��Ďg�p���镔���̓Q�[�����Ŏ���
    /// �\������x��AES�Í���
    /// </summary>
    public class SaveDataManager
    {
        /// <summary>
        /// �Z�[�u����
        /// �Z�[�u�f�[�^�N���X��json�ɂ��ĕۑ�����
        /// </summary>
        /// <param name="obj"></param>
        public void Save<T>(object obj)
        {
            var json = JsonUtility.ToJson(obj);
            var encrypted = Encrypt(json);

            var savePath = CreateSavePath(typeof(T));
            File.WriteAllBytes(savePath, encrypted);
        }

        /// <summary>
        /// ���[�h����
        /// �ۑ�����Ă���json����Z�[�u�f�[�^�N���X������ĕԂ�
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public T Load<T>()
        {
            var savePath = CreateSavePath(typeof(T));
            var encrypted = File.ReadAllBytes(savePath);
            var json = Decrypt(encrypted);

            return JsonUtility.FromJson<T>(json);
        }

        /// <summary>
        /// �Í���
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        private byte[] Encrypt(string plainText)
        {
            byte[] encrypted;

            using (AesManaged aes = CreateAesManaged())
            {
                var encryptor = aes.CreateEncryptor();

                using MemoryStream memoryStream = new();
                using CryptoStream cryptoStream = new(memoryStream, encryptor, CryptoStreamMode.Write);
                using (StreamWriter writer = new(cryptoStream))
                {
                    writer.Write(plainText);
                }
                encrypted = memoryStream.ToArray();
            }

            return encrypted;
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="encrypted"></param>
        /// <returns></returns>
        private string Decrypt(byte[] encrypted)
        {
            string plainText;

            using (AesManaged aes = CreateAesManaged())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor();

                // Create the streams used for decryption.
                using MemoryStream memoryStream = new(encrypted);
                using CryptoStream cryptoStream = new(memoryStream, decryptor, CryptoStreamMode.Read);
                using StreamReader reader = new(cryptoStream);
                plainText = reader.ReadToEnd();
            }

            return plainText;
        }

        /// <summary>
        /// AesManaged�̐ݒ�
        /// </summary>
        /// <returns></returns>
        private AesManaged CreateAesManaged()
        {
            const string AesKey = "sevendwarfs12345";
            const string AesIv = "sevendwarfs44444";

            AesManaged aes = new();

            aes.KeySize = 128;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(AesKey);
            aes.IV = Encoding.UTF8.GetBytes(AesIv);

            return aes;
        }

        /// <summary>
        /// �Z�[�u�f�[�^�̃p�X���쐬
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string CreateSavePath(Type type)
        {
            var typeName = type.Name;
            var encriptedTypeName = Encrypt(typeName);

            // �Z�[�u�f�[�^���͌^�����n�b�V�����������̂��������Ĕ��f����
            SHA256CryptoServiceProvider cryptoProvider = new();
            var hashBytes = cryptoProvider.ComputeHash(encriptedTypeName);
            StringBuilder hashName = new();
            foreach (byte hashByte in hashBytes)
            {
                hashName.Append(hashByte.ToString("x2"));
            }

            string saveDataPath = Application.persistentDataPath + "/.sav_" + hashName;
            return saveDataPath;
        }
    }
}
