<%@ LANGUAGE="VBSCRIPT" %>
<% Option Explicit 

'on error resume next


sub database_adddahlexhighscore(name, level, moves, score, scoredate)

	dim c_ConnectionString	
	c_ConnectionString = "DRIVER=MySQL;SERVER=localhost;DB=dahlmang_bookgame;UID=dahlmang_mysql;PWD=vermin8;"


	dim dbc
	set dbc = server.createobject("adodb.connection")
	dbc.open c_ConnectionString
	

	dim sql
    

    sql = "INSERT INTO dahlex_highscores (name, level, moves, score, scoredate) VALUES ( '"& name &"',"& level &","& moves &",'"& score &"','"& scoredate &"');"
    dbc.execute sql
    
	dbc.close
	set dbc = nothing

end sub


if request.form("name") <> "" then

	database_adddahlexhighscore  request.form("name"), request.form("level"), request.form("moves"), request.form("score"), request.form("scoredate") 

end if

%>


<body>
	

    <br>
    <form method="POST" action="dahlex_insert.asp" >
    <table border="1" cellspacing="0" cellpadding="2">
 
    <tr>
        <th colspan="2">Login</th>
    </tr>
    <tr>
    	<td align="right">Username:</td>
    	<td>
    		<input type="text" name="name" size="25" maxlength="50" value="">
    	</td>
    </tr>
    <tr>
        <td align="right">Password:</td>
        <td>
			<input type="text" name="level" size="25" maxlength="50" value="">
		</td>
    </tr>
    <tr>
      	<td colspan="2" align="center">
			<input type="submit" value="Login">
			<input type="reset" value="Clear">
			<input type="hidden" name="cmd" value="logmein">
		</td>
    </tr>
	</table>
	</form>
</body>
</html>
