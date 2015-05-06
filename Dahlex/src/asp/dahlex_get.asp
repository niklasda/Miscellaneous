<%@ LANGUAGE="VBSCRIPT" %>
<% Option Explicit 

'on error resume next

function database_getdahlexhighscores(count)

	dim c_ConnectionString	
	c_ConnectionString = "DRIVER=MySQL;SERVER=localhost;DB=dahlmang_bookgame;UID=dahlmang_mysql;PWD=vermin8;"


	dim dbc
	set dbc = server.createobject("adodb.connection")
	dbc.open c_ConnectionString
	
    dim rs
	dim sql
	dim xmlscores

    sql = "SELECT id, name, level, moves, score, scoredate FROM dahlex_highscores ORDER BY level DESC, moves ASC LIMIT 0, "& count &";"
	
    Set rs = dbc.Execute(sql)

	xmlscores = "<?xml version=""1.0"" encoding=""iso-8859-1"" ?>"
	xmlscores = xmlscores & "<highscores>"
	do while not rs.eof

		xmlscores = xmlscores & "<highscore>"

		xmlscores = xmlscores & "<id>"
		xmlscores = xmlscores & rs.Fields("id")
		xmlscores = xmlscores & "</id>"
		
		xmlscores = xmlscores & "<name>"
		xmlscores = xmlscores & rs.Fields("name")
		xmlscores = xmlscores & "</name>"

		xmlscores = xmlscores & "<level>"
		xmlscores = xmlscores & rs.Fields("level")
		xmlscores = xmlscores & "</level>"

		xmlscores = xmlscores & "<moves>"
		xmlscores = xmlscores & rs.Fields("moves")
		xmlscores = xmlscores & "</moves>"

		xmlscores = xmlscores & "<score>"
		xmlscores = xmlscores & rs.Fields("score")
		xmlscores = xmlscores & "</score>"

		xmlscores = xmlscores & "<scoredate>"
		xmlscores = xmlscores & rs.Fields("scoredate")
		xmlscores = xmlscores & "</scoredate>"

		xmlscores = xmlscores & "</highscore>"

		rs.movenext
	loop
	xmlscores = xmlscores & "<highscores>"

	rs.Close
         
	dbc.close
	set dbc = nothing

	database_getdahlexhighscores = xmlscores
end function

response.write database_getdahlexhighscores(50)
%>
