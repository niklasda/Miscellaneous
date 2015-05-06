class Utils 
{
	static var gameName:String = "Dahlex v1.0 beta 2";

//	static function GetVersion():String 
	//{
		//return this.$version;
//	}
	
	 // not used yet. look in fla file
	 
	public function SaveHighscore(name:String, score:Number):Void
	{
		// if all the required fields have been filled in, create a LoadVars object instance and populate it.
		var send_lv:LoadVars = new LoadVars();
		send_lv.name = name;
		send_lv.email = "email_ti@text";
		send_lv.url = "";
		send_lv.comments = "comments_ta.text";
		send_lv.score = score;
	
	/*	send_lv.onLoad = function(success:Boolean) 
		{
			// if the comments were sent to the server and you received a response, clear the form fields and display an Alert message.
			if (success) 
			{
				Alert.show("Thank you for your comments.", "Success", Alert.OK);
			} 
			else 
			{
				// else you encountered an error while submitting to the server.
				Alert.show("Unable to process your comments at this time.", "Server Error", Alert.OK);
			}
		};*/
		// send the variables from Flash to the remote PHP template.
		send_lv.sendAndLoad("http://www.nida.se/dahlex/gb_insert.asp", send_lv, "POST");
	}

	
	public function LoadHighscores()
	{
		// create an XML object instance which is used to load comments from a remote server.
		var guestbook_xml:XML = new XML();
		guestbook_xml.ignoreWhite = true;
		guestbook_xml.onLoad = function(success:Boolean) 
		{
			if (success) 
			{
			//	infotext.text += guestbook_xml.toString();
				
				var numEntries = this.firstChild.childNodes.length;
				// loop through each of the entries from the XML packet...
				for (var i = 0; i<numEntries; i++) {
					// create a shortcut to the current child node
					var entry_xml:XMLNode = this.firstChild.childNodes[i].childNodes;
					
					/* set local variables for the name, email address, url, comments and timestamp. 
					Since you know the structure of the XML packet, you know the index of each of these child nodes. */
					var name_string:String = entry_xml[1].firstChild.nodeValue;
					var emailaddress_string:String = entry_xml[2].firstChild.nodeValue;
					var url_string:String = entry_xml[3].firstChild.nodeValue;
					var comments_string:String = entry_xml[4].firstChild.nodeValue;
					var datetime_string:String = entry_xml[6].firstChild.nodeValue;
					
					// the "entry_string" variable is used to hold the HTML formatted contents of the current guestbook entry
					var entry_string:String = "<p>";
					entry_string += "<span>"+name_string+"</span><br>";
					
					// if the email address isn't blank, append it to the current entry_string variable.
					if ((emailaddress_string != undefined) && (emailaddress_string.length>0)) {
						entry_string += "<a href=\"mailto:"+emailaddress_string+"\" target=\"_blank\">email</a><br>";
					}
					// if the url isn't blank, append it to the current entry_string variable.
					if ((url_string != undefined) && (url_string.length>0)) {
						// if the first five characters of the URL aren't "http:", set the prefix to "http://".
						var prefix_string:String = (url_string.substr(0, 5) != "http:") ? "http://" : "";
						entry_string += "<a href=\""+prefix_string+url_string+"\" target=\"_blank\">url</a><br>";
					}
					entry_string += comments_string+"<br>";
					entry_string += "<i>"+datetime_string+"</i><br>";
					entry_string += "</p>";
					// draw a horizontal line after each guestbook entry.
					entry_string += "<img src=\"line_gr\"><br>";
					// append each current entry to the current value of guestbook_ta
					//infotext.text += entry_string+"<br>";
				}
			} 
			else 
			{
				trace("error loading XML");
			}
		};
	
		// load the guestbook XML entries from the remote server.
		guestbook_xml.load("http://www.nida.se/dahlex/highscores.xml");
	}
}


