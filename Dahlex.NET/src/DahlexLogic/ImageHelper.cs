using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Dahlex.Settings;

namespace Dahlex
{
    public static class ImageHelper
    {

        public static Image GetEmbeddedImage(string name)
        {
            Assembly a = Assembly.GetExecutingAssembly();

            string[] resNames = a.GetManifestResourceNames();
            foreach (string resName in resNames)
            {
                if (resName.ToLower().EndsWith(name.ToLower()))
                {
                    Stream imgStream = a.GetManifestResourceStream(resName);
                    return Bitmap.FromStream(imgStream);
                }
            }
            throw new ApplicationException(string.Format("Embedded image not found: {0}", name));
        }
        
        private static void clearCache()
        {
            professors = null;
        }


        private static void verifyCache(Options gameOptions)
        {
            if (professors == null)
            {
                SetupCache(gameOptions);
            }
        }

        public static BoardImage GetProfessorBitmap(Options gameOptions, int? previousIndex)
        {
            verifyCache(gameOptions);
            int target;
            int i = 0;
            
            if (previousIndex.HasValue)
            {
                target = previousIndex.Value;
                return new BoardImage(professors[target], target, PieceType.Professor);
            }
            else
            {
                target = rnd.Next(professors.Count);
            }
            
            foreach (KeyValuePair<int, Bitmap> pair in professors)
            {
                if (i++ == target)
                {
                    return new BoardImage(pair.Value, pair.Key, PieceType.Professor);
                }
            }
            throw new ApplicationException(string.Format("No professor image ({0}) could be found for this theme ({1})", target, gameOptions.ThemeName));
        }

        public static BoardImage GetHeapBitmap(Options gameOptions, int? previousIndex)
        {
            verifyCache(gameOptions);
            int target;
            int i = 0;
            
            if(previousIndex.HasValue)
            {
                target = previousIndex.Value;
                return new BoardImage(heaps[target], target, PieceType.Heap);
            }
            else
            {
                target = rnd.Next(heaps.Count);
            }
 
            foreach (KeyValuePair<int, Bitmap> pair in heaps)
            {
                if (i++ == target)
                {
                    return new BoardImage(pair.Value, pair.Key, PieceType.Heap);
                }
            }
            throw new ApplicationException(string.Format("No heap image ({0}) could be found for this theme ({1})", target, gameOptions.ThemeName));
        }

        public static BoardImage GetRobotBitmap(Options gameOptions, int? previousIndex)
        {
            verifyCache(gameOptions);
            int target;
            int i = 0;
            
            if (previousIndex.HasValue)
            {
                target = previousIndex.Value;
                return new BoardImage(robots[target], target, PieceType.Robot);
            }
            else
            {
                target = rnd.Next(robots.Count);
            }
            
            foreach (KeyValuePair<int, Bitmap> pair in robots)
            {
                if (i++ == target)
                {
                    return new BoardImage(pair.Value, pair.Key, PieceType.Robot);
                }
            }
            throw new ApplicationException(string.Format("No robot image ({0}) could be found for this theme ({1})", target, gameOptions.ThemeName));
        }

        public static Dictionary<int, Bitmap> GetHeapBitmaps(Options gameOptions)
        {
            clearCache();
            verifyCache(gameOptions);
            int i = 0;
            Image[] images = new Image[heaps.Values.Count];
            foreach(Image o in heaps.Values)
            {
                images[i++] = o;
            }
            return heaps;
        }

        public static Dictionary<int,Bitmap> GetProfessorBitmaps(Options gameOptions)
        {
            clearCache();            
            verifyCache(gameOptions);
            int i = 0;
            Image[] images = new Image[professors.Values.Count];
            foreach (Image o in professors.Values)
            {
                images[i++] = o;
            }
            return professors;
        }

        public static Dictionary<int, Bitmap> GetRobotBitmaps(Options gameOptions)
        {
            clearCache();            
            verifyCache(gameOptions);
            int i = 0;
            Image[] images = new Image[robots.Values.Count];
            foreach (Image o in robots.Values)
            {
                images[i++] = o;
            }
            return robots;
        }

        private static Random rnd = new Random();
        
        private static Dictionary<string, Dictionary<PieceType, Dictionary<int, Bitmap>>> cache = new Dictionary<string,Dictionary<PieceType,Dictionary<int,Bitmap>>>();
        private static Dictionary<PieceType, Dictionary<int, Bitmap>> themeCache;
        private static Dictionary<int, Bitmap> professors;
        private static Dictionary<int, Bitmap> heaps;
        private static Dictionary<int, Bitmap> robots;

        private static void SetupCache(Options gameOptions)
        {
            professors = new Dictionary<int, Bitmap>();
            heaps = new Dictionary<int, Bitmap>();
            robots = new Dictionary<int, Bitmap>();

            themeCache = new Dictionary<PieceType, Dictionary<int, Bitmap>>();

            themeCache.Add(PieceType.Professor, professors);
            themeCache.Add(PieceType.Heap, heaps);
            themeCache.Add(PieceType.Robot, robots);

            if (cache.ContainsKey(gameOptions.ThemeName))
            {
                cache[gameOptions.ThemeName] = themeCache;
            }
            else
            {
                cache.Add(gameOptions.ThemeName, themeCache);
            }
            
            cacheHeaps(gameOptions);
            cacheProfessors(gameOptions);
            cacheRobots(gameOptions);
        }
        
        private static void cacheProfessors(Options gameOptions)
        {
            FileInfo[] fis = GetFilesInThemeFolder(gameOptions);

            professors.Clear();
            if (fis.Length > 0)
            {
                foreach (FileInfo fi in fis)
                {
                    if (fi.Exists && fi.Name.ToLower().StartsWith("professor_"))
                    {
                        int num = GetNumberFromImageName(fi);
                        Image im = Image.FromStream(fi.OpenRead());
                        if(!professors.ContainsKey(num))
                        {
                            professors.Add(num, new Bitmap(im, gameOptions.PictureSize));
                        }
                    }
                }
            }
            if(professors.Count==0)
            {
                Image im = GetEmbeddedImage("professor_01.png");
                professors.Add(1, new Bitmap(im, gameOptions.PictureSize));
            }
        }

        private static void cacheHeaps(Options gameOptions)
        {
            FileInfo[] fis = GetFilesInThemeFolder(gameOptions);

            heaps.Clear();
            if (fis.Length > 0)
            {
                foreach (FileInfo fi in fis)
                {
                    if (fi.Exists && fi.Name.ToLower().StartsWith("heap_"))
                    {
                        int num = GetNumberFromImageName(fi);
                        Image im = Image.FromStream(fi.OpenRead());
                        if(!heaps.ContainsKey(num))
                        {
                            heaps.Add(num, new Bitmap(im, gameOptions.PictureSize));
                        }
                    }
                }
            }
            if(heaps.Count==0)
            {
                Image im = GetEmbeddedImage("heap_01.png");
                heaps.Add(1, new Bitmap(im, gameOptions.PictureSize));
            }
        }
        
        private static void cacheRobots(Options gameOptions)
        {
            FileInfo[] fis = GetFilesInThemeFolder(gameOptions);

            robots.Clear();
            if (fis.Length > 0)
            {
                foreach (FileInfo fi in fis)
                {
                    if (fi.Exists && fi.Name.ToLower().StartsWith("robot_"))
                    {
                        int num = GetNumberFromImageName(fi);
                        Image im = Image.FromStream(fi.OpenRead());
                        if(!robots.ContainsKey(num))
                        {
                            robots.Add(num, new Bitmap(im, gameOptions.PictureSize));
                        }
                    }
                }
            }
            if(robots.Count==0)
            {
                Image im = GetEmbeddedImage("robot_01.png");
                robots.Add(1, new Bitmap(im, gameOptions.PictureSize));
            }
        }
                                                    
        private static int GetNumberFromImageName(FileInfo fi)
        {
            string fileNameEnd = fi.Name.ToLower().Replace("heap_", "");
            fileNameEnd = fileNameEnd.Replace("professor_", "");
            fileNameEnd = fileNameEnd.Replace("robot_", "");
            string number = fileNameEnd.Remove(fileNameEnd.IndexOf('.'));
            return int.Parse(number);
        }

        private static FileInfo[] GetFilesInThemeFolder(Options gameOptions)
        {
            string app = gameOptions.ThemesFolder + @"\" + gameOptions.ThemeName;
            DirectoryInfo di = new DirectoryInfo(app);
            return di.GetFiles();
        }

        public static int[] GetHeaps(Options gameOptions)
        {
            verifyCache(gameOptions);
            int[] keys = new int[heaps.Keys.Count];
            int i = 0;
            foreach(int k in heaps.Keys)
            {
                keys[i++] = k;
            }
            return keys;
        }

        public static int[] GetRobots(Options gameOptions)
        {
            verifyCache(gameOptions);
            int[] keys = new int[robots.Keys.Count];
            int i = 0;
            foreach (int k in robots.Keys)
                {
                keys[i++] = k;
            }
            return keys;
        }

        public static int[] GetProfessors(Options gameOptions)
        {
            verifyCache(gameOptions);
            int[] keys = new int[professors.Keys.Count];
            int i = 0;
            foreach (int k in professors.Keys)
            {
                keys[i++] = k;
            }
            return keys;
        }

    }
}
