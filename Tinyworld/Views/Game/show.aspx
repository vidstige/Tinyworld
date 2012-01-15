<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Tinyworld.GameModel>" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<script type="text/javascript" src="/Scripts/mapper.js"></script>
</head>
<body>
	<div>		
		<img src="/Content/board.jpeg" class="mapper" width="1099" height="608" usemap="#regionsmap" alt="jj"/>
	</div>
	<map name="regionsmap">
	<% foreach (PolygonRegion region in ViewData.Model.MapRegions)
       { %>
			<area shape="polygon" coords="<%= region.HtmlCoordinates() %>" href="#" alt="Sun" />
    <% } %>
	</map>
		
	<div>
		<p>Available Races</p>
			<% foreach (Smallworld.Tribe tribe in ViewData.Model.AvailableTribes)
	      	{ %>
				<p><a href="/Game/select?race=<%= tribe.ToString() %>"><%= tribe.ToString() %></a></p>
			<% } %>
	</div>
		
</body>
</html>