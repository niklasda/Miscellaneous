<%@ Language=VBScript %>
<html>
<head>
	<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    <title>En Mutafon</title>
    <link rel="StyleSheet" href="/css/stil.css" type="text/css" title="styles">

    <script>
        (function(i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r;
            i[r] = i[r] || function() {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date();
            a = s.createElement(o),
                m = s.getElementsByTagName(o)[0];
            a.async = 1;
            a.src = g;
            m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-62799904-1', 'auto');
        ga('send', 'pageview');
    </script>
</head>

<body>

<ul>
<li><a class="link" href="http://dahlman.biz/index.html">dahlman.biz</a>

</ul>

<%
Response.Write "<span class=""info"">ServerName: " & Request.ServerVariables("SERVER_NAME") & "</span><br>"
Response.Write "<span class=""info"">InstanceID: " & Request.ServerVariables("INSTANCE_ID") & "</span><br>"
Response.Write "<span class=""info"">LocalAddr: " & Request.ServerVariables("LOCAL_ADDR") & "</span><br>"
Response.Write "<span class=""info"">RemoteAddr: " & Request.ServerVariables("REMOTE_ADDR") & "</span><br>"
Response.Write "<span class=""info"">URL: " & Request.ServerVariables("URL") & "</span><br>"
Response.Write "<span class=""info"">UserAgent: " & Request.ServerVariables("HTTP_USER-AGENT") & "</span><br>"
Response.Write "<span class=""info"">dbq: " & Server.MapPath("/dbq/") & "</span><br>"
%>


</body>
</html>
