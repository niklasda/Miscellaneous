using System;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace DiaryMaster 
{
	/// <summary>
	/// Summary description for MRUMenuItem.
	/// </summary>
	[Serializable] public class MruMenuItem : MenuItem, ISerializable
	{
		private string[] mru;
		private int m_count;

		/// <summary>
		/// Create a new MRU MenuItem with specified name
		/// </summary>
		/// <param name="sMenuItemName">Name of MenuItem</param>
		public MruMenuItem(string sMenuItemName) : base(sMenuItemName)
		{
		}

		/// <summary>
		/// Create a new MRU MenuItem.
		/// Also use by menu merge
		/// </summary>
		public MruMenuItem() : base()
		{	
		}

		/// <summary>
		/// Return the MRU list
		/// </summary>
		public string[] MRUFiles 
		{
			get { return mru; }
		}

		/// <summary>
		/// Initialize the MRU submenu with the specified filenames
		/// </summary>
		/// <param name="files">Files to add to list</param>
		public void Initialize(string[] files) 
		{
			mru = files;
			m_count = mru.Length;
			
			for(int i=0; i<m_count; i++) 
			{
				if(mru[i].Trim().Length>0) 
				{
					MenuItem mmru = new MenuItem(mru[i], new EventHandler(OnMruClick));
					this.MenuItems.Add(mmru);
				}
			}
		}

		/// <summary>
		/// Adds a file to the MRU list.
		/// Replace the first one if list is full
		/// </summary>
		/// <param name="file">file to add to list</param>
		public void FileOpened(string file) 
		{
			int found = m_count-1;
			for(int j=0;j<m_count;j++) 
			{
				if(file==mru[j]) 
				{
					found=j;
					break;
				}
			}

			while(found>0)
			{
				mru[found] = mru[--found];
			}
		
			mru[0] = file;
			this.MenuItems.Clear();
			
			for(int i=0; i<m_count; i++) 
			{
				if(mru[i].Trim().Length>0) 
				{
					MenuItem mmru = new MenuItem(mru[i], new EventHandler(OnMruClick));
					this.MenuItems.Add(mmru);
				}
			}
			
		}

		/// <summary>
		/// Fired when a mru menuitem is clicked
		/// </summary>
		public event EventHandler MruClicked; 
		private void OnMruClick(object o, EventArgs e) 
		{
			if(MruClicked != null) 
			{
				MruClicked(o, e); 
			}
		}

		private MruMenuItem(SerializationInfo info, StreamingContext context )
		{
			if(info.MemberCount>1)
			{
				Text = info.GetString("mruname");
				int iCount = info.GetInt32("mrucount");
				if(info.MemberCount>(iCount+1))
				{
					string[] arMru = new string[iCount];
					for(int i=0; i<iCount; i++) 
					{
						arMru[i] = info.GetString("mru"+i);
					}

					Initialize(arMru);
				}
			}
		}

		// A method called when serializing
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) 
		{
			int iCount = mru.Length;
			info.AddValue("mruname", base.Text);
			info.AddValue("mrucount", iCount);

			for(int i=0; i<iCount; i++) 
			{
				info.AddValue("mru"+i, mru[i]);
			}
		}
	}
}