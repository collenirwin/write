// utils.js
// author: Collen Irwin
// requires: jQuery
// desc: utility functions used throughout the site

$(document).ready(function() {

    // Vars

    var escapeList = [
        ["<", "&lt;"],
        [">", "&gt;"],
        ["/", "&#47;"],
        ['"', "&quot;"],
        ["'", "&#39;"],
        [" ", "&nbsp;"]
    ];

    // End Vars

    // show outline
    $(".ol").focus(function() {
        $(this).css("outline-color", "#43CD80"); // Sea Green 3
    });

    // hide outline
    $(".ol").on("blur", function() {
        $(this).css("outline-color", "transparent");
    });

    // returns the passed string with all questionable characters properly escaped for html
    escape = function(str) {
        for (var x = 0; x < 6; x++)
            str = str.split(escapeList[x][0]).join(escapeList[x][1]);

        return str;
    }

    // returns the passed string with all spaces replaced with underscores
    spaceReplace = function(str) {
        str = str.split("&nbsp;").join("_")
            .split(" ").join("_");

        return str;
    }
});