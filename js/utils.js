// utils.js
// author: Collen Irwin
// requires: jQuery
// desc: utility functions used throughout the site

// Vars

var MSG_LST = {
    tagTooShort: "Tags must be at least one character long",
    tagExists: "You've already entered that tag",
    tagLimitExceeded: "You've exceeded the maximum number of tags"
};

var escapeList = [
    ["<", "&lt;"  ],
    [">", "&gt;"  ],
    ["/", "&#47;" ],
    ['"', "&quot;"],
    ["'", "&#39;" ],
    [" ", "&nbsp;"],
    [";", "&semi;"],
    ["|", "&#124;"],
    ["*", "&ast;" ]
];

// End Vars

// show outline
$("body").on("focus", ".ol", function() {
    $(this).css("outline-color", "#43CD80"); // Sea Green 3
});

// hide outline
$("body").on("blur", ".ol", function() {
    $(this).css("outline-color", "transparent");
});

// returns the passed string with all questionable characters properly escaped for html
var escape = function(str) {
    for (var x = 0; x < 6; x++)
        str = str.split(escapeList[x][0]).join(escapeList[x][1]);

    return str;
}

// returns the passed string with all spaces replaced with underscores
var spaceReplace = function(str) {
    str = str.split("&nbsp;").join("_")
        .split(" ").join("_");

    return str;
}
