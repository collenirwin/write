/* global msgDeleteTag */
/* global msgPost */
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

    window.msgPost = new Msg();
    window.msgDeleteTag = new Msg();
    window.msgError = new Msg();

    // End Vars

    // Startup

    setTimeout(function() {
        $("#txtTitle").focus()
    }, 200); // Makes the fade in of the focus outline more noticeable

    window.msgDeleteTag.init("Remove all tags?",
        "Remove all the tags you've made for this post?",
        "<input type='button' class='msgButton ol' value='Remove All' onclick='window.removeAllTags();msgDeleteTag.close();' />" +
        "<input type='button' class='msgButton ol' value='Cancel' onclick='window.msgDeleteTag.close();' />"
        );
    
    window.msgPost.init("",
        "Are you sure you want to post this piece? Remember, anyone will be able to view it.",
        "<input type='button' class='msgButton ol' value='Post' onclick='window.post();' />" +
        "<input type='button' class='msgButton ol' value='Cancel' onclick='window.msgPost.close();' />"
        );
        
    window.msgError.init("Error",
        "",
        "<input type='button' class='msgButton ol' value='Okay' onclick='window.msgError.close();' />"
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
                        "<input type='button' id='b_" + tagID + "' class='tagX' value='x' onclick='window.removeTag(" + tagID + ")' />" +
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

    window.removeTag = function(id) {
        $("#t_" + id.toString()).remove(); // remove tag span
        tags.splice(id, 1); // remove tag from tag array

        if (tags.length === 0) // hide tag container if no tags
            $(tagCont).fadeOut("fast");
    }

    window.removeAllTags = function() {
        $("#tagError").fadeOut("fast");
        tags = [];
        $(tagCont).fadeOut("fast");
        $(tagDiv).html("");
    }
    
    function stringifyTags() {
        var str = "";
        for (var x = 0; x < tags.length; x++) {
            str += escape(
                (tags[x].length > 20) ? tags[x].substring(0, 20) : tags[x]
                ) + "|";
        }
        return str;
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
        window.msgPost.title = escape($("#txtTitle").val());
        window.msgPost.show();
    });
    
    window.post = function() {
        $.ajax({
			type: "POST",
            url: "../php/post.php",
            data: 
                "title=" + $("#txtTitle").val() + 
                "&body=" + $("#txtBody").val() + 
                "&edit=" + ($("#chkEdit").is(":checked")) ? "1" : "0" +
                "&tags=" + stringifyTags(),
            success: function(msg) {
                if ($.isNumeric(msg)) {
                    window.location.href = "../post/?post_id=" + msg.toString();
                } else {
                    window.msgError.body = escape(msg.toString());
                    window.msgError.show();
                }
            }, 
            error: function() {
                window.msgError.body = "Couldn't contact the server. Please try again later.";
                window.msgError.show();
            }
	    });
    }

    // End Post
});
