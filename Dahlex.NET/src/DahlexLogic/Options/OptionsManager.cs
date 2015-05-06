using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dahlex.Settings
{
    public sealed class OptionsManager
    {
        public static Options GetOptions()
        {
            return new OptionsManager().LoadLocalOptions();
        }
        
        private Options LoadLocalOptions()
        {
            Options options;
            BinaryFormatter fmt = new BinaryFormatter();
            FileStream fs = null;

            try
            {
                FileInfo fi = new FileInfo("DahlexOptions.bin");
                if(fi.Exists)
                {
                    fs = fi.OpenRead();
                    options = (Options)fmt.Deserialize(fs);
                }
                else
                {
                    options = new Options();
                }
                return options;
            }
            catch
            {
                return new Options();
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        public void SaveLocalOptions(Options options)
        {
            BinaryFormatter fmt = new BinaryFormatter();
            FileStream fs = null;
            
            try
            {
                FileInfo fi = new FileInfo("DahlexOptions.bin");
                fs = fi.Create();
                fmt.Serialize(fs, options);
            }
            
            finally
            {
                if(fs!=null)
                {
                    fs.Close();
                }
            }
        }
    }
}
