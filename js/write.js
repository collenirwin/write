// write.js
// author: Collen Irwin
// requires: jQuery, utils.js, msg.js
// desc: contains functions needed specifically by the write page

$(document).ready(function() {

    // Vars

    var tags = [],
        tagCont = $("#tagsContainer"),
        tagDiv  = $("#tags"),
        tagText = $("#txtTag");

    msgPost = new Msg();
    msgDeleteTag = new Msg();

    // End Vars

    // Startup

    setTimeout(function() {
        $("#txtTitle").focus()
    }, 200); // Makes the fade in of the focus outline more noticeable

    msgDeleteTag.init("Remove all tags?",
        "Remove all the tags you've made for this post?",
        "<input type='button' class='msgButton ol' value='Remove All' onclick='removeAllTags();msgDeleteTag.close();' />" +
        "<input type='button' class='msgButton ol' value='Cancel' onclick='msgDeleteTag.close();' />"
        );
    
    // End Startup

    // Tagging

    function createTag(tag) {
        if (tags.length < 30) { // 30 tag limit
            if (tag.length > 0) { // must be atleast 1 characters long

                if ($(tagCont).is(":hidden"))
                    $(tagCont).fadeIn("fast"); // Show the tag container if it's currently hidden

                // Trim whitespace, replace bad chars, underscoreize spaces
                tag = spaceReplace(escape($.trim(tag)));

                if (tags.indexOf(tag) === -1) { // tag hasn't been used yet on this post
                    $("#tagError").fadeOut("fast"); // Get rid of the error message

                    tags.push(tag); // Add tag to array
                    var tagID = (tags.length - 1).toString(); // ID for deletion

                    // Add tag html
                    $(tagDiv).append(
                        "<span id='t_" + tagID + "' class='tag'>" +
                        tag +
                        "<input type='button' id='b_" + tagID + "' class='tagX' value='x' onclick='removeTag(" + tagID + ")' />" +
                        "</span>");
                    $("#t_" + tagID).fadeIn("fast");
                    $(tagText).val(""); // Clear textbox
                } else {
                    showTagError(MSG_LST.tagExists);
                }
            } else {
                showTagError(MSG_LST.tagTooShort);
            }
        } else {
            showTagError(MSG_LST.tagLimitExceeded);
        }
        
    }

    function showTagError(msg) {
        $("#tagError").html(msg);
        $("#tagError").fadeIn("fast");
    }

    removeTag = function(id) {
        $("#t_" + id.toString()).remove(); // remove tag span
        tags.splice(id, 1); // remove tag from tag array

        if (tags.length === 0) // hide tag container if no tags
            $(tagCont).fadeOut("fast");
    }

    removeAllTags = function() {
        $("#tagError").fadeOut("fast");
        tags = [];
        $(tagCont).fadeOut("fast");
        $(tagDiv).html("");
    }

    $(tagText).on("keypress", function(e) {
        if (e.which == 13)
            createTag($(tagText).val());
    });

    $("#btnTag").on("click touchend", function() {
        createTag($(tagText).val());
    });

    // End Tagging

    // Post

    $("#btnPostWrite").on("click touchend", function() {
        msgPost.init("Post (title)?",
            "Are you sure you want to post this piece? Remember, anyone will be able to view it.",
            "<input type='button' class='msgButton ol' value='Post' />" +
            "<input type='button' class='msgButton ol' value='Cancel' onclick='msgPost.close();' />"
            );
        msgPost.show();
    });

    // End Post
});
