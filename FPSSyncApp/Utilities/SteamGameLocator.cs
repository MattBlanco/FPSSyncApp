using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.IO;

namespace FPSSyncApp.Utilities
{
    /// <summary>
    ///  Used to find folder for specified game
    /// </summary>
    public class SteamGameLocator
    {
        private static string GetSteamFolder()
        {
            RegistryKey steamKey = Registry.LocalMachine.OpenSubKey("Software\\Valve\\Steam") ?? Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Valve\\Steam");
            return steamKey.GetValue("InstallPath").ToString();
        }

        private static List<string> GetLibraryFolders()
        {
            List<string> library = new List<string>();

            string steamFolder = GetSteamFolder();
            library.Add(steamFolder);

            string configFile = steamFolder + "\\config\\config.vdf";

            Regex regex = new Regex("BaseInstallFolder[^\"]*\"\\s*\"([^\"]*)\"");
            using (StreamReader reader = new StreamReader(configFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        library.Add(Regex.Unescape(match.Groups[1].Value));
                    }
                }
            }

            return library;
        }

        public static string gameFolder(string gameName)
        {
            var appFolders = GetLibraryFolders().Select(x => x + "\\SteamApps\\common");
            foreach (var folder in appFolders)
            {
                try
                {
                    var matches = Directory.GetDirectories(folder,  gameName);
                    if (matches.Length >= 1)
                    {
                        return matches[0];
                    }
                }
                catch (DirectoryNotFoundException)
                {
                    //continue;
                }
            }
            return null;
        }

        public static string valvegameFolder(string gameName)
        {
            var appFolders = GetLibraryFolders().Select(x => x + "\\SteamApps\\common");
            foreach (var folder in appFolders)
            {
                try
                {
                    var matches = Directory.GetDirectories(folder, gameName);
                    if (matches.Length >= 1)
                    {
                        return matches[0];
                    }
                }
                catch (DirectoryNotFoundException)
                {
                    //continue;
                }
            }
            return null;
        }
    }
}
