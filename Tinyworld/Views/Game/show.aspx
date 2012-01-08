<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Tinyworld.Board>" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<img src="/Content/board.jpeg" width="1099" height="608" usemap="regionsmap" />
	<map name="regionsmap">
	<% foreach (PolygonRegion region in ViewData.Model.Regions)
       { %>
			<area shape="rect" coords="0,0,82,126" href="sun.htm" alt="Sun" />
    <% } %>
	</map>
</body>
