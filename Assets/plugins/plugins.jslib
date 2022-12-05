var plugin = {
    OpenNewTab : function(url)
    {
        url = Pointer_stringify(url);
        window.open(url,'_blank');
    },
    OpenNewLink : function(url)
    {
        url = Pointer_stringify(url);
        window.open(url,'_self');
    },
    OpenLinkWithToken : function(url)
    {
        url = Pointer_stringify(url);
        window.open(url,'_self');
    },
    BrowserGetLinkHREF : function()
	{
		var search = window.location.href;
		var searchLen = lengthBytesUTF8(search) + 1;
		var buffer = _malloc(searchLen);
		stringToUTF8(search, buffer, searchLen);
		return  buffer;
	},
};
mergeInto(LibraryManager.library, plugin);