// write.js
// author: Collen Irwin
// requires: jQuery, utils.js
// desc: contains functions needed specifically by the write page

$(document).ready(function() {

    // Vars

    var tags = [],
        tagCont = $("#tagsContainer"),
        tagDiv  = $("#tags"),
        tagText = $("#txtTag");

    // End Vars

    // Startup

    setTimeout(function() {
        $("#txtTitle").focus()
    }, 200); // Makes the fade in of the focus outline more noticeable
    
    // End Startup

    // Tagging

    function createTag(tag) {
        if ($(tagCont).is(":hidden"))
            $(tagCont).show(250); // Show the tag container if it's currently hidden

        // Trim whitespace, replace bad chars, underscoreize spaces
        tag = spaceReplace(escape($.trim(tag)));

        if (tag.length > 2) { // must be atleast 2 characters long
            if (tags.indexOf(tag) === -1) { // tag hasn't been used yet on this post
                tags.push(tag);
                var tagID = (tags.length - 1).toString();
                $(tagDiv).append(
                    "<span id='t_" + tagID + "' class='tag'>" +
                    tag +
                    "<input type='button' id='b_" + tagID + "' class='tagX' value='x' onclick='removeTag(" + tagID + ")' />" +
                    "</span>");
                $(tagText).val("");
            } else {
                // Error message here
            }
        } else {
            // Error message here
        }

        
    }

    removeTag = function(id) {
        $("#t_" + id.toString()).remove(); // remove tag span
        tags.splice(id, 1); // remove tag from tag array

        if (tags.length === 0)
            $(tagCont).hide();
    }

    $(tagText).on("keypress", function(e) {
        if (e.which == 13)
            createTag($(tagText).val());
    });

    $("#btnTag").on("click touchend", function() {
        createTag($(tagText).val());
    });

    // End Tagging
});