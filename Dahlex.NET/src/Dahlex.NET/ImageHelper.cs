using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Forms;
using Dahlex.Settings;

namespace Dahlex
{
    public static class ImageHelper
    {
        
        internal static Image GetEmbeddedImage(string name)
        {
            Assembly a = Assembly.GetExecutingAssembly();

            string[] resNames = a.GetManifestResourceNames();
            foreach(string resName in resNames)
            {
                if (resName.ToLower().EndsWith(name.ToLower()))
                {            
                    Stream imgStream = a.GetManifestResourceStream(resName);
                    return Bitmap.FromStream(imgStream);
                }
            }
            throw new ApplicationException("Embedded image not found: "+ name);
          }


        private static void verifyCache(Options gameOptions)
        {
            if (professors == null)
            {
                SetupCache(gameOptions);
            }
        }
    
        internal static BoardImage getProfessorBitmap(Options gameOptions, int? previousIndex)
        {
            verifyCache(gameOptions);
            int target;
            int i = 0;
            
            if (previousIndex.HasValue)
            {
                target = previousIndex.Value;
            }
            else
            {
                target = rnd.Next(professors.Count);
            }
            
            foreach (KeyValuePair<int, Bitmap> pair in professors)
            {
                if (i++ == target)
                {
                    return new BoardImage(pair.Value, target, PieceType.Professor);
                }
            }
            return null;
        }

        internal static BoardImage getHeapBitmap(Options gameOptions, int? previousIndex)
        {
            verifyCache(gameOptions);
            int target;
            int i = 0;
            
            if(previousIndex.HasValue)
            {
                target = previousIndex.Value;
            }
            else
            {
                target = rnd.Next(heaps.Count);
            }
 
            foreach (KeyValuePair<int, Bitmap> pair in heaps)
            {
                if (i++ == target)
                {
                    return new BoardImage(pair.Value, target, PieceType.Heap);
                }
            }
            return null;
        }

        internal static BoardImage getRobotBitmap(Options gameOptions, int? previousIndex)
        {
            verifyCache(gameOptions);
            int target;
            int i = 0;
            
            if (previousIndex.HasValue)
            {
                target = previousIndex.Value;
            }
            else
            {
                target = rnd.Next(robots.Count);
            }
            
            foreach (KeyValuePair<int, Bitmap> pair in robots)
            {
                if (i++ == target)
                {
                    return new BoardImage(pair.Value, target, PieceType.Robot);
                }
            }
            return null;
        }

        private static Random rnd = new Random();
        
        private static Dictionary<string, Dictionary<PieceType, Dictionary<int, Bitmap>>> cache = new Dictionary<string,Dictionary<PieceType,Dictionary<int,Bitmap>>>();
        private static Dictionary<PieceType, Dictionary<int, Bitmap>> themeCache;
        private static Dictionary<int, Bitmap> professors;
        private static Dictionary<int, Bitmap> heaps;
        private static Dictionary<int, Bitmap> robots;

     //   internal static void EmptyCache(string themeName)
       // {
         //   cache[themeName] = null;
       // }
        internal static void SetupCache(Options gameOptions)
        {
            professors = new Dictionary<int, Bitmap>();
            heaps = new Dictionary<int, Bitmap>();
            robots = new Dictionary<int, Bitmap>();
            
            themeCache = new Dictionary<PieceType,Dictionary<int,Bitmap>>();

            themeCache.Add(PieceType.Professor, professors);
            themeCache.Add(PieceType.Heap, heaps);
            themeCache.Add(PieceType.Robot, robots);

            cache.Add(gameOptions.ThemeName, themeCache);

            cacheHeaps(gameOptions);
            cacheProfessors(gameOptions);
            cacheRobots(gameOptions);
            
        }
        private static void cacheProfessors(Options gameOptions)
        {
            FileInfo[] fis = GetFis(gameOptions);

            professors.Clear();
            if (fis.Length > 0)
            {
                foreach (FileInfo fi in fis)
                {
                    if (fi.Exists && fi.Name.ToLower().StartsWith("professor_"))
                    {
                        int num = GetNum(fi);
                        Image im = Image.FromStream(fi.OpenRead());
                        if(!professors.ContainsKey(num))
                        {
                            professors.Add(num, new Bitmap(im, gameOptions.PictureSize));
                        }
                    }
                }
            }
            else
            {
                Image im = GetEmbeddedImage("professor_01.png");
                professors.Add(1, new Bitmap(im, gameOptions.PictureSize));
            }
        }
        private static void cacheHeaps(Options gameOptions)
        {
            FileInfo[] fis = GetFis(gameOptions);

            heaps.Clear();
            if (fis.Length > 0)
            {
                foreach (FileInfo fi in fis)
                {
                    if (fi.Exists && fi.Name.ToLower().StartsWith("heap_"))
                    {
                        int num = GetNum(fi);
                        Image im = Image.FromStream(fi.OpenRead());
                        if(!heaps.ContainsKey(num))
                        {
                            heaps.Add(num, new Bitmap(im, gameOptions.PictureSize));
                        }
                    }
                }
            }
            else
            {
                Image im = GetEmbeddedImage("heap_01.png");
                heaps.Add(1, new Bitmap(im, gameOptions.PictureSize));
            }
        }
        
        private static void cacheRobots(Options gameOptions)
        {
            FileInfo[] fis = GetFis(gameOptions);

            robots.Clear();
            if (fis.Length > 0)
            {
                foreach (FileInfo fi in fis)
                {
                    if (fi.Exists && fi.Name.ToLower().StartsWith("robot_"))
                    {
                        int num = GetNum(fi);
                        Image im = Image.FromStream(fi.OpenRead());
                        if(!robots.ContainsKey(num))
                        {
                            robots.Add(num, new Bitmap(im, gameOptions.PictureSize));
                        }
                    }
                }
            }
            else
            {
                Image im = GetEmbeddedImage("robot_01.png");
                robots.Add(1, new Bitmap(im, gameOptions.PictureSize));
            }
        }

        private static int GetNum(FileInfo fi)
        {
            string fileNameEnd = fi.Name.ToLower().Replace("heap_", "");
            fileNameEnd = fileNameEnd.Replace("professor_", "");
            fileNameEnd = fileNameEnd.Replace("robot_", "");
            string number = fileNameEnd.Remove(fileNameEnd.IndexOf('.'));
            return int.Parse(number);
        }

        private static FileInfo[] GetFis(Options gameOptions)
        {
            FileInfo exefi = new FileInfo(Application.ExecutablePath);
            string root = exefi.DirectoryName;

            string app = root + @"\" + gameOptions.ThemesFolder + @"\" + gameOptions.ThemeName;
            DirectoryInfo di = new DirectoryInfo(app);
            return di.GetFiles();
        }
    }
}
